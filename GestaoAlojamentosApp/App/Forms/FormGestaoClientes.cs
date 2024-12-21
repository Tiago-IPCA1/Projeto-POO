using System;
using System.Linq;
using System.Windows.Forms;
using GestaoAlojamentosApp.App.Controllers;
using GestaoAlojamentosApp.App.ViewModels;

namespace GestaoAlojamentosApp.App.Forms
{
    /// <summary>
    /// Formulário responsável pela gestão de clientes
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public partial class FormGestaoClientes : Form
    {
        #region Atributos e Propriedades

        private readonly ClienteController _clienteController;
        private BindingSource _clientesBindingSource = new BindingSource(); 
        private ClienteViewModel _clienteVazio = new ClienteViewModel();  // Inicializa um cliente vazio para adição

        #endregion

        #region Construtor

        public FormGestaoClientes(ClienteController clienteController)
        {
            InitializeComponent();
            _clienteController = clienteController ?? throw new ArgumentNullException(nameof(clienteController));
            InicializarBindingSource();
            AtualizarClientesDataGridView();
        }

        #endregion

        #region Inicialização da Interface

        private void InicializarBindingSource()
        {
            // Inicializando o DataGridView com o BindingSource
            DataGridViewClientes.DataSource = _clientesBindingSource;
        }

        // Atualiza o DataGridView com todos os clientes e adiciona uma linha vazia para novos clientes
        private void AtualizarClientesDataGridView()
        {
            try
            {
                var clientes = _clienteController.ObterTodosClientes();
                var clientesList = clientes.ToList();

                // Adiciona a linha vazia apenas no momento de adição
                if (_clienteVazio != null)
                {
                    clientesList.Add(_clienteVazio);
                }

                _clientesBindingSource.DataSource = clientesList;

                DataGridViewClientes.ReadOnly = false; // Permitir edição dos campos
                DataGridViewClientes.AllowUserToAddRows = false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos de Criação, Atualização e Remoção de Clientes

        private void AdicionarCliente()
        {
            // Validação de campos
            if (CamposObrigatoriosInvalidos()) return;

            try
            {
                var nome = TextBoxNomeCliente.Text.Trim();
                var email = TextBoxEmailCliente.Text.Trim();
                var telefone = TextBoxTelefoneCliente.Text.Trim();
                var idade = int.Parse(TextBoxIdadeCliente.Text.Trim());

                // Adiciona o cliente
                var resultado = _clienteController.CriarCliente(nome, email, telefone, idade);
                if (resultado)
                {
                    MessageBox.Show("Cliente adicionado com sucesso!");
                    AtualizarClientesDataGridView();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarCliente()
        {
            try
            {
                if (DataGridViewClientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um cliente para atualizar.");
                    return;
                }

                var nome = TextBoxNomeCliente.Text.Trim();
                var email = TextBoxEmailCliente.Text.Trim();
                var telefone = TextBoxTelefoneCliente.Text.Trim();
                var idade = int.Parse(TextBoxIdadeCliente.Text.Trim());

                var clienteSelecionado = DataGridViewClientes.SelectedRows[0].DataBoundItem as ClienteViewModel;
                if (clienteSelecionado != null)
                {
                    var resultado = _clienteController.AtualizarCliente(clienteSelecionado.Id, nome, email, telefone, idade);
                    if (resultado)
                    {
                        MessageBox.Show("Cliente atualizado com sucesso!");
                        AtualizarClientesDataGridView();
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoverCliente()
        {
            try
            {
                if (DataGridViewClientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione um cliente para remover.");
                    return;
                }

                var clienteSelecionado = DataGridViewClientes.SelectedRows[0].DataBoundItem as ClienteViewModel;
                if (clienteSelecionado != null)
                {
                    var resultado = _clienteController.RemoverCliente(clienteSelecionado.Id);
                    if (resultado)
                    {
                        MessageBox.Show("Cliente removido com sucesso!");
                        AtualizarClientesDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao remover cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CamposObrigatoriosInvalidos()
        {
            if (string.IsNullOrWhiteSpace(TextBoxNomeCliente.Text) ||
                string.IsNullOrWhiteSpace(TextBoxEmailCliente.Text) ||
                string.IsNullOrWhiteSpace(TextBoxTelefoneCliente.Text) ||
                string.IsNullOrWhiteSpace(TextBoxIdadeCliente.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios!");
                return true;
            }

            if (!int.TryParse(TextBoxIdadeCliente.Text.Trim(), out _))
            {
                MessageBox.Show("Idade inválida.");
                return true;
            }

            return false;
        }

        #endregion

        #region Eventos de Interface

        private void BotaoAdicionarCliente_Click(object sender, EventArgs e) => AdicionarCliente();

        private void BotaoAtualizarCliente_Click(object sender, EventArgs e) => AtualizarCliente();

        private void BotaoRemoverCliente_Click(object sender, EventArgs e) => RemoverCliente();

        #endregion

        #region Eventos de DataGridView

        private void DataGridViewClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewClientes.SelectedRows.Count > 0)
            {
                var clienteSelecionado = DataGridViewClientes.SelectedRows[0].DataBoundItem as ClienteViewModel;

                if (clienteSelecionado != null && clienteSelecionado != _clienteVazio)
                {
                    TextBoxNomeCliente.Text = clienteSelecionado.Nome;
                    TextBoxEmailCliente.Text = clienteSelecionado.Email;
                    TextBoxTelefoneCliente.Text = clienteSelecionado.Telefone;
                    TextBoxIdadeCliente.Text = clienteSelecionado.Idade.ToString();
                    BotaoAdicionarCliente.Enabled = false;  // Desabilita o botão de adicionar
                }
                else
                {
                    LimparCampos(); // Limpa os campos se a linha vazia for selecionada
                    BotaoAdicionarCliente.Enabled = true;  // Habilita o botão de adicionar
                }
            }
        }

        #endregion

        #region Métodos Auxiliares

        private void LimparCampos()
        {
            TextBoxNomeCliente.Clear();
            TextBoxEmailCliente.Clear();
            TextBoxTelefoneCliente.Clear();
            TextBoxIdadeCliente.Clear();
        }

        #endregion
    }
}
