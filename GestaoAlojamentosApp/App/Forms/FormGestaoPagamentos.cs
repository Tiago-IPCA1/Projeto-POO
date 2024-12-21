using GestaoAlojamentosApp.App.Controllers;
using GestaoAlojamentosApp.App.ViewModels;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.App.Forms
{
    public partial class FormGestaoPagamentos : Form
    {
        #region Atributos e Propriedades

        private readonly PagamentoController _pagamentoController;
        private readonly ReservaController _reservaController;
        private BindingSource _pagamentosBindingSource = new BindingSource(); // BindingSource para pagamentos
        private BindingSource _reservasBindingSource = new BindingSource(); // BindingSource para reservas

        #endregion

        #region Construtor

        public FormGestaoPagamentos(PagamentoController pagamentoController, ReservaController reservaController)
        {
            InitializeComponent();
            _pagamentoController = pagamentoController ?? throw new ArgumentNullException(nameof(pagamentoController));
            _reservaController = reservaController ?? throw new ArgumentNullException(nameof(reservaController));
            InicializarBindingSource();
            PreencherComboBoxes();
            AtualizarDataGridViewReservasPendentes(); // Carregar as reservas pendentes
            AtualizarDataGridViewPagamentos(); // Carregar todos os pagamentos
        }

        #endregion

        #region Inicialização da Interface

        private void InicializarBindingSource()
        {
            // Inicializando o DataGridView para pagamentos e reservas
            DataGridViewPagamentos.DataSource = _pagamentosBindingSource;
            DataGridViewReservas.DataSource = _reservasBindingSource; // DataGridView para reservas pendentes
        }

        private void PreencherComboBoxes()
        {
            // Preenchendo os ComboBoxes com valores de Enum
            ComboBoxStatusPagamento.DataSource = Enum.GetValues(typeof(StatusPagamento)).Cast<StatusPagamento>().ToList();
            ComboBoxMetodoPagamento.DataSource = Enum.GetValues(typeof(MetodoPagamento)).Cast<MetodoPagamento>().ToList();
        }

        // Atualiza o DataGridView com todos os pagamentos
        private void AtualizarDataGridViewPagamentos()
        {
            try
            {
                // Obtém todos os pagamentos
                var todosPagamentos = _pagamentoController.ObterTodosPagamentos(); 
                _pagamentosBindingSource.DataSource = todosPagamentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar pagamentos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Atualiza o DataGridView com as reservas pendentes
        private void AtualizarDataGridViewReservasPendentes()
        {
            try
            {
                // Obtém reservas com status Pendente
                var reservasPendentes = _reservaController.ObterReservasPorStatus(StatusReserva.Pendente);
                _reservasBindingSource.DataSource = reservasPendentes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar reservas pendentes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos de Pagamento (Criação, Atualização, Remoção)

        private void AdicionarPagamento()
        {
            // Verifica se os campos obrigatorios estão preenchidos
            if (CamposObrigatoriosInvalidos()) return;

            // Valida os campos Enum de status e método de pagamento
            if (!ValidarEnumComboBox(ComboBoxStatusPagamento, out StatusPagamento statusPagamento)) return;
            if (!ValidarEnumComboBox(ComboBoxMetodoPagamento, out MetodoPagamento metodoPagamento)) return;

            try
            {
                var valor = decimal.Parse(TextBoxValorPagamento.Text);
                var reservaId = (int)NumericUpDownReservaId.Value;
                var dataPagamento = DateTimePickerDataPagamento.Value;

                // Verifica se a reserva está pendente
                var reserva = _reservaController.ObterReservaPorId(reservaId);
                if (reserva == null)
                {
                    MessageBox.Show("Reserva não encontrada.");
                    return;
                }

                // Verifica o status da reserva
                if (reserva.Status == StatusReserva.Cancelada)
                {
                    MessageBox.Show("Não é possível adicionar pagamento para uma reserva cancelada.");
                    return;
                }

                // Cria o pagamento
                var resultado = _pagamentoController.CriarPagamento(reservaId, valor, metodoPagamento, statusPagamento, dataPagamento);
                if (resultado)
                {
                    // Se o pagamento foi realizado, alteramos o status da reserva conforme o pagamento
                    if (statusPagamento == StatusPagamento.Confirmado)
                    {
                        // Alterar o status da reserva para "Confirmada"
                        _reservaController.AlterarStatusReserva(reservaId, StatusReserva.Confirmada);
                    }
                    else if (statusPagamento == StatusPagamento.Cancelado)
                    {
                        // Se o pagamento foi cancelado, a reserva também deve ser cancelada
                        _reservaController.AlterarStatusReserva(reservaId, StatusReserva.Cancelada);
                    }

                    MessageBox.Show("Pagamento adicionado com sucesso!");

                    // Atualiza a lista de pagamentos
                    AtualizarDataGridViewPagamentos();
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar pagamento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar pagamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlterarStatusPagamento()
        {
            try
            {
                // Verifica se há alguma linha selecionada
                if (DataGridViewPagamentos.SelectedRows.Count > 0)
                {
                    var pagamentoSelecionado = DataGridViewPagamentos.SelectedRows[0].DataBoundItem as PagamentoViewModel;
                    if (pagamentoSelecionado != null)
                    {
                        // Valida o campo Enum de status de pagamento
                        if (!ValidarEnumComboBox(ComboBoxStatusPagamento, out StatusPagamento statusPagamento)) return;

                        // Altera o status do pagamento
                        var resultado = _pagamentoController.AlterarStatusPagamento(pagamentoSelecionado.Id, statusPagamento);
                        if (resultado)
                        {
                            MessageBox.Show("Status do pagamento atualizado com sucesso!");
                            AtualizarDataGridViewPagamentos(); // Atualiza após alteração
                        }
                        else
                        {
                            MessageBox.Show("Erro ao alterar o status do pagamento.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar status: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoverPagamento()
        {
            try
            {
                // Verifica se há alguma linha selecionada
                if (DataGridViewPagamentos.SelectedRows.Count > 0)
                {
                    var pagamentoSelecionado = DataGridViewPagamentos.SelectedRows[0].DataBoundItem as PagamentoViewModel;
                    if (pagamentoSelecionado != null)
                    {
                        var resultado = _pagamentoController.RemoverPagamento(pagamentoSelecionado.Id);
                        if (resultado)
                        {
                            MessageBox.Show("Pagamento removido com sucesso!");
                            AtualizarDataGridViewPagamentos(); // Atualiza após remoção
                        }
                        else
                        {
                            MessageBox.Show("Erro ao remover pagamento.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover pagamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CamposObrigatoriosInvalidos()
        {
            if (string.IsNullOrWhiteSpace(TextBoxValorPagamento.Text) || ComboBoxStatusPagamento.SelectedItem == null || ComboBoxMetodoPagamento.SelectedItem == null)
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios!");
                return true;
            }

            return false;
        }

        private bool ValidarEnumComboBox<T>(ComboBox comboBox, out T valor) where T : struct, Enum
        {
            if (!Enum.TryParse(comboBox.SelectedItem?.ToString(), out valor))
            {
                MessageBox.Show($"Selecione um valor válido para {typeof(T).Name}.");
                return false;
            }
            return true;
        }

        #endregion

        #region Eventos de Interface

        // Botões de ações
        private void BotaoAdicionarPagamento_Click(object sender, EventArgs e) => AdicionarPagamento();
        private void BotaoAlterarStatusPagamento_Click(object sender, EventArgs e) => AlterarStatusPagamento();
        private void BotaoRemoverPagamento_Click(object sender, EventArgs e) => RemoverPagamento();

        #endregion

        #region Eventos de DataGridView

        // Quando a seleção no DataGridView muda
        private void DataGridViewPagamentos_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewPagamentos.SelectedRows.Count > 0)
            {
                var pagamentoSelecionado = DataGridViewPagamentos.SelectedRows[0].DataBoundItem as PagamentoViewModel;
                if (pagamentoSelecionado != null)
                {
                    PreencherCamposPagamento(pagamentoSelecionado);
                }
            }
        }

        // Preenche os campos de pagamento com as informações da reserva selecionada
        private void PreencherCamposPagamento(PagamentoViewModel pagamento)
        {
            NumericUpDownReservaId.Value = pagamento.ReservaId;
            TextBoxValorPagamento.Text = pagamento.Valor.ToString();
            ComboBoxMetodoPagamento.SelectedItem = pagamento.MetodoPagamento;
            ComboBoxStatusPagamento.SelectedItem = pagamento.StatusPagamento;
            DateTimePickerDataPagamento.Value = pagamento.DataPagamento;
        }

        #endregion

      
    }
}
