using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GestaoAlojamentosApp.App.Controllers;
using GestaoAlojamentosApp.App.ViewModels;
using GestaoAlojamentosApp.Domain.Enums;

namespace GestaoAlojamentosApp.App.Forms
{
    /// <summary>
    /// Formulário responsável pela gestão de alojamentos
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public partial class FormGestaoAlojamentos : Form
    {
        #region Atributos e Propriedades

        private readonly AlojamentoController _alojamentoController;
        private AlojamentoViewModel? _alojamentoSelecionado;
        private List<string> _imagens;
        private int _indiceImagemAtual;
        private BindingSource _alojamentosBindingSource = new BindingSource();

        #endregion

        #region Construtor

        public FormGestaoAlojamentos(AlojamentoController alojamentoController)
        {
            _alojamentoController = alojamentoController ?? throw new ArgumentNullException(nameof(alojamentoController));
            InitializeComponent();
            InicializarBindingSource();
            _imagens = new List<string>();
            _indiceImagemAtual = 0;
            PreencherComboBoxes();
            AtualizarDataGridView();
        }

        #endregion

        #region Inicialização da Interface

        private void InicializarBindingSource()
        {
            DataGridViewAlojamentos.DataSource = _alojamentosBindingSource;
        }

        private void PreencherComboBoxes()
        {
            ComboBoxStatus.DataSource = Enum.GetValues(typeof(StatusAlojamento)).Cast<StatusAlojamento>().ToList();
            ComboBoxTipo.DataSource = Enum.GetValues(typeof(TipoAlojamento)).Cast<TipoAlojamento>().ToList();
        }

        private void AtualizarDataGridView()
        {
            try
            {
                var alojamentos = _alojamentoController.ObterTodosAlojamentos();
                _alojamentosBindingSource.DataSource = alojamentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar alojamentos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos de Alojamento (Criação, Atualização, Remoção)

        private void AdicionarAlojamento()
        {
            if (CamposObrigatoriosInvalidos()) return;

            if (!ValidarEnumComboBox(ComboBoxStatus, out StatusAlojamento statusAlojamento)) return;
            if (!ValidarEnumComboBox(ComboBoxTipo, out TipoAlojamento tipoAlojamento)) return;

            try
            {
                var resultado = _alojamentoController.CriarAlojamento(
                    TextoNome.Text, TextoLocalizacao.Text,
                    decimal.Parse(TextoPreco.Text),
                    int.Parse(TextoCapacidade.Text),
                    int.Parse(TextoNumeroQuartos.Text),
                    statusAlojamento,
                    tipoAlojamento);

                if (resultado) AtualizarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar alojamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarAlojamento()
        {
            if (DataGridViewAlojamentos.SelectedRows.Count > 0)
            {
                var alojamentoSelecionado = DataGridViewAlojamentos.SelectedRows[0].DataBoundItem as AlojamentoViewModel;
                if (alojamentoSelecionado != null)
                {
                    try
                    {
                        if (!ValidarEnumComboBox(ComboBoxStatus, out StatusAlojamento statusAlojamento)) return;
                        if (!ValidarEnumComboBox(ComboBoxTipo, out TipoAlojamento tipoAlojamento)) return;

                        var resultado = _alojamentoController.AtualizarAlojamento(
                            alojamentoSelecionado.Id, TextoNome.Text,
                            TextoLocalizacao.Text, decimal.Parse(TextoPreco.Text),
                            int.Parse(TextoCapacidade.Text),
                            int.Parse(TextoNumeroQuartos.Text),
                            statusAlojamento,
                            tipoAlojamento);

                        if (resultado) AtualizarDataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao atualizar alojamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Erro: Alojamento selecionado é nulo.");
                }
            }
        }

        private void RemoverAlojamento()
        {
            if (DataGridViewAlojamentos.SelectedRows.Count > 0)
            {
                var alojamentoSelecionado = DataGridViewAlojamentos.SelectedRows[0].DataBoundItem as AlojamentoViewModel;
                if (alojamentoSelecionado != null)
                {
                    try
                    {
                        var resultado = _alojamentoController.RemoverAlojamento(alojamentoSelecionado.Id);
                        if (resultado) AtualizarDataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover alojamento: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Erro: Alojamento selecionado é nulo.");
                }
            }
        }

        private bool CamposObrigatoriosInvalidos()
        {
            if (string.IsNullOrWhiteSpace(TextoNome.Text) || string.IsNullOrWhiteSpace(TextoLocalizacao.Text))
            {
                MessageBox.Show("Nome e Localização do Alojamento são obrigatórios!");
                return true;
            }

            return false;
        }

        private bool ValidarEnumComboBox<T>(ComboBox comboBox, out T valor) where T : struct, Enum
        {
            if (!Enum.TryParse(comboBox.SelectedItem?.ToString(), out valor))
            {
                MessageBox.Show($"Selecione um valor valido para {typeof(T).Name}.");
                return false;
            }
            return true;
        }


        #endregion

        #region Métodos de Imagens (Adição, Remoção, Navegação)

        private void AdicionarImagem()
        {
            if (_alojamentoSelecionado == null || string.IsNullOrEmpty(TextoImagemPath.Text))
            {
                MessageBox.Show("Selecione um alojamento e forneça o caminho da imagem.");
                return;
            }

            var caminhoImagem = TextoImagemPath.Text;
            try
            {
                var resultado = _alojamentoController.AdicionarImagemAoAlojamento(_alojamentoSelecionado.Id, caminhoImagem);

                if (resultado)
                {
                    _imagens.Add(caminhoImagem);
                    AtualizarImagem();
                }
                else
                {
                    MessageBox.Show("Falha ao adicionar imagem.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoverImagem()
        {
            if (_alojamentoSelecionado == null || _imagens.Count == 0)
            {
                MessageBox.Show("Não há imagens para remover.");
                return;
            }

            var imagemRemovida = _imagens[_indiceImagemAtual];
            _imagens.RemoveAt(_indiceImagemAtual);

            try
            {
                if (_imagens.Count == 0)
                {
                    PictureBoxImagem.Image = null;
                    TextoImagemPath.Clear();
                }
                else
                {
                    if (_indiceImagemAtual >= _imagens.Count) _indiceImagemAtual = _imagens.Count - 1;
                    AtualizarImagem();
                }

                var resultado = _alojamentoController.RemoverImagemDoAlojamento(_alojamentoSelecionado.Id, imagemRemovida);
                if (resultado) MessageBox.Show("Imagem removida com sucesso.");
                else MessageBox.Show("Falha ao remover imagem.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarImagem()
        {
            if (_imagens.Count == 0)
            {
                PictureBoxImagem.Image = null;
                TextoImagemPath.Clear();
            }
            else
            {
                PictureBoxImagem.ImageLocation = _imagens[_indiceImagemAtual];
                TextoImagemPath.Text = _imagens[_indiceImagemAtual];
            }
        }

        private void NavegarImagens(int direcao)
        {
            if (_imagens.Count == 0) return;

            _indiceImagemAtual = (_indiceImagemAtual + direcao + _imagens.Count) % _imagens.Count;
            AtualizarImagem();
        }

        private void SelecionarImagem()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Ficheiros de Imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TextoImagemPath.Text = dialog.FileName;
            }
        }

        #endregion

        #region Eventos de Botões

        private void BotaoAdicionarAlojamento_Click(object sender, EventArgs e) => AdicionarAlojamento();
        private void BotaoAtualizarAlojamento_Click(object sender, EventArgs e) => AtualizarAlojamento();
        private void BotaoRemoverAlojamento_Click(object sender, EventArgs e) => RemoverAlojamento();
        private void BotaoAdicionarImagem_Click(object sender, EventArgs e) => AdicionarImagem();
        private void BotaoRemoverImagem_Click(object sender, EventArgs e) => RemoverImagem();
        private void BotaoProximaImagem_Click(object sender, EventArgs e) => NavegarImagens(1);
        private void BotaoImagemAnterior_Click(object sender, EventArgs e) => NavegarImagens(-1);
        private void BotaoSelecionarImagem_Click(object sender, EventArgs e) => SelecionarImagem();

        #endregion



        private void DataGridViewAlojamentos_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewAlojamentos.SelectedRows.Count > 0)
            {
                _alojamentoSelecionado = DataGridViewAlojamentos.SelectedRows[0].DataBoundItem as AlojamentoViewModel;
                if (_alojamentoSelecionado != null)
                {
                    PreencherCamposAlojamento();
                    _imagens = _alojamentoSelecionado.Imagens?.ToList() ?? new List<string>();
                    _indiceImagemAtual = 0;
                    AtualizarImagem();
                }
            }
        }

        private void PreencherCamposAlojamento()
        {
            TextoNome.Text = _alojamentoSelecionado?.Nome ?? string.Empty;
            TextoLocalizacao.Text = _alojamentoSelecionado?.Localizacao ?? string.Empty;
            TextoPreco.Text = _alojamentoSelecionado?.PrecoPorNoite.ToString() ?? string.Empty;
            TextoCapacidade.Text = _alojamentoSelecionado?.Capacidade.ToString() ?? string.Empty;
            TextoNumeroQuartos.Text = _alojamentoSelecionado?.NumeroDeQuartos.ToString() ?? string.Empty;
            ComboBoxStatus.SelectedItem = _alojamentoSelecionado?.Status;
            ComboBoxTipo.SelectedItem = _alojamentoSelecionado?.Tipo;
        }

    }
}
