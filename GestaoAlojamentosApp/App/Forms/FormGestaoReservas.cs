using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GestaoAlojamentosApp.App.Controllers;
using GestaoAlojamentosApp.App.ViewModels;

namespace GestaoAlojamentosApp.App.Forms
{
    /// <summary>
    /// Formulário responsável pela gestão de reservas
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public partial class FormGestaoReservas : Form
    {
        #region Atributos e Propriedades

        private readonly ReservaController _reservaController;
        private readonly ClienteController _clienteController;
        private readonly AlojamentoController _alojamentoController;
        private ReservaViewModel? _reservaSelecionada;  // Permitindo que o campo seja nulo
        private BindingSource _reservasBindingSource = new BindingSource();  // Inicialização direta

        #endregion

        #region Construtor

        public FormGestaoReservas(ReservaController reservaController, ClienteController clienteController, AlojamentoController alojamentoController)
        {
            _reservaController = reservaController ?? throw new ArgumentNullException(nameof(reservaController));
            _clienteController = clienteController ?? throw new ArgumentNullException(nameof(clienteController));
            _alojamentoController = alojamentoController ?? throw new ArgumentNullException(nameof(alojamentoController));
            InitializeComponent();
            InicializarBindingSource();
            PreencherComboBoxes();
            AtualizarDataGridView();
        }

        #endregion

        #region Inicialização da Interface

        private void InicializarBindingSource()
        {
            DataGridViewReservas.DataSource = _reservasBindingSource;
        }

        private void PreencherComboBoxes()
        {
            var clientes = _clienteController.ObterTodosClientes();
            var alojamentos = _alojamentoController.ObterTodosAlojamentos();

            if (clientes != null && clientes.Count > 0)
            {
                ComboBoxClienteEmail.DataSource = clientes;
                ComboBoxClienteEmail.DisplayMember = "Email";
                ComboBoxClienteEmail.ValueMember = "Email";
            }

            if (alojamentos != null && alojamentos.Count > 0)
            {
                ComboBoxAlojamentoNome.DataSource = alojamentos;
                ComboBoxAlojamentoNome.DisplayMember = "Nome";
                ComboBoxAlojamentoNome.ValueMember = "Nome";
            }
        }

        private void AtualizarDataGridView()
        {
            var reservas = _reservaController.ObterTodasReservas();
            _reservasBindingSource.DataSource = reservas;
        }

        #endregion

        #region Métodos de Reserva (Criação, Atualização, Remoção)

        private void AdicionarReserva()
        {
            try
            {
                if (CamposObrigatoriosInvalidos()) return;

                var clienteEmail = ComboBoxClienteEmail.SelectedValue?.ToString() ?? string.Empty;
                var alojamentoNome = ComboBoxAlojamentoNome.SelectedValue?.ToString() ?? string.Empty;
                var dataInicio = DateTimePickerDataInicio.Value;
                var dataFim = DateTimePickerDataFim.Value;
                var numeroDePessoas = (int)NumericUpDownNumeroPessoas.Value;

                var resultado = _reservaController.CriarReserva(clienteEmail, alojamentoNome, dataInicio, dataFim, numeroDePessoas);
                if (resultado)
                {
                    AtualizarDataGridView();
                    MessageBox.Show("Reserva adicionada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar reserva.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void AtualizarReserva()
        {
            try
            {
                if (DataGridViewReservas.SelectedRows.Count > 0)
                {
                    var reservaSelecionada = DataGridViewReservas.SelectedRows[0].DataBoundItem as ReservaViewModel;
                    if (reservaSelecionada != null)
                    {
                        var clienteEmail = ComboBoxClienteEmail.SelectedValue?.ToString() ?? string.Empty;
                        var alojamentoNome = ComboBoxAlojamentoNome.SelectedValue?.ToString() ?? string.Empty;
                        var dataInicio = DateTimePickerDataInicio.Value;
                        var dataFim = DateTimePickerDataFim.Value;
                        var numeroDePessoas = (int)NumericUpDownNumeroPessoas.Value;

                        var resultado = _reservaController.AtualizarReserva(reservaSelecionada.Id, clienteEmail, alojamentoNome, dataInicio, dataFim, numeroDePessoas);
                        if (resultado)
                        {
                            AtualizarDataGridView();
                            MessageBox.Show("Reserva atualizada com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Erro ao atualizar reserva.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione uma reserva para atualizar.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void RemoverReserva()
        {
            try
            {
                if (DataGridViewReservas.SelectedRows.Count > 0)
                {
                    var reservaSelecionada = DataGridViewReservas.SelectedRows[0].DataBoundItem as ReservaViewModel;
                    if (reservaSelecionada != null)
                    {
                        var resultado = _reservaController.RemoverReserva(reservaSelecionada.Id);
                        if (resultado)
                        {
                            AtualizarDataGridView();
                            MessageBox.Show("Reserva removida com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Erro ao remover reserva.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private bool CamposObrigatoriosInvalidos()
        {
            if (ComboBoxClienteEmail.SelectedValue == null || ComboBoxAlojamentoNome.SelectedValue == null)
            {
                MessageBox.Show("Email do Cliente e Nome do Alojamento são obrigatórios!");
                return true;
            }
            return false;
        }

        #endregion

        #region Eventos de Botões

        private void AdicionarReserva_Click(object sender, EventArgs e) => AdicionarReserva();
        private void AtualizarReserva_Click(object sender, EventArgs e) => AtualizarReserva();
        private void RemoverReserva_Click(object sender, EventArgs e) => RemoverReserva();

        private void DataGridViewReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewReservas.SelectedRows.Count > 0)
            {
                _reservaSelecionada = DataGridViewReservas.SelectedRows[0].DataBoundItem as ReservaViewModel;
                if (_reservaSelecionada != null)
                {
                    PreencherCamposReserva();
                }
            }
        }

        private void PreencherCamposReserva()
        {
            ComboBoxClienteEmail.SelectedValue = _reservaSelecionada?.ClienteEmail ?? string.Empty;
            ComboBoxAlojamentoNome.SelectedValue = _reservaSelecionada?.AlojamentoNome ?? string.Empty;
            DateTimePickerDataInicio.Value = _reservaSelecionada?.DataInicio ?? DateTime.Now;
            DateTimePickerDataFim.Value = _reservaSelecionada?.DataFim ?? DateTime.Now;
            NumericUpDownNumeroPessoas.Value = _reservaSelecionada?.NumeroDePessoas ?? 1;
        }

        #endregion
    }
}
