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
    /// Formulário responsável pela gestão de check-ins
    /// Autor: Tiago Vale
    /// Email: a27675@alunos.ipca.pt
    /// Instituto: IPCA
    /// </summary>
    public partial class FormGestaoCheckIns : Form
    {
        #region Atributos e Propriedades

        private readonly CheckInController _checkInController;
        private readonly ReservaController _reservaController;
        private BindingSource _checkInsBindingSource;
        private BindingSource _reservasBindingSource;

        #endregion

        #region Construtor

        public FormGestaoCheckIns(CheckInController checkInController, ReservaController reservaController)
        {
            _checkInController = checkInController ?? throw new ArgumentNullException(nameof(checkInController));
            _reservaController = reservaController ?? throw new ArgumentNullException(nameof(reservaController));

            InitializeComponent();

            _checkInsBindingSource = new BindingSource();
            _reservasBindingSource = new BindingSource();

            DataGridViewCheckIns.DataSource = _checkInsBindingSource;
            DataGridViewReservasConfirmadas.DataSource = _reservasBindingSource;

            PreencherComboBoxes();
            AtualizarReservasDataGridView();
            AtualizarCheckInsDataGridView();

            // Assinatura de eventos
            BotaoAdicionarCheckIn.Click += BotaoAdicionarCheckIn_Click;
            BotaoAtualizarStatusCheckIn.Click += BotaoAtualizarStatusCheckIn_Click;
            BotaoRemoverCheckIn.Click += BotaoRemoverCheckIn_Click;
        }

        #endregion

        #region Inicialização da Interface

        private void PreencherComboBoxes()
        {
            // Preenche o ComboBox de Status com os valores do Enum StatusCheckIn
            ComboBoxStatus.Items.AddRange(Enum.GetNames(typeof(StatusCheckIn)));
            ComboBoxStatus.SelectedIndex = 0;

            // Preenche o ComboBox de Reservas Confirmadas
            var reservasConfirmadas = _reservaController.ObterReservasPorStatus(StatusReserva.Confirmada);
            if (reservasConfirmadas == null || !reservasConfirmadas.Any())
            {
                MessageBox.Show("Nenhuma reserva confirmada encontrada.");
                return;
            }

            ComboBoxReservaId.DataSource = reservasConfirmadas.ToList();
            ComboBoxReservaId.DisplayMember = "Id";
            ComboBoxReservaId.ValueMember = "Id";
        }

        private void AtualizarReservasDataGridView()
        {
            // Atualiza a lista de reservas confirmadas
            var reservasConfirmadas = _reservaController.ObterReservasPorStatus(StatusReserva.Confirmada);
            _reservasBindingSource.DataSource = reservasConfirmadas;
        }

        private void AtualizarCheckInsDataGridView()
        {
            // Atualiza a lista de check-ins
            var checkIns = _checkInController.ObterTodosCheckIns();
            _checkInsBindingSource.DataSource = checkIns;
            DataGridViewCheckIns.ReadOnly = true;
        }

        #endregion

        #region Métodos de Check-In (Criação, Atualização, Remoção)

        private void AdicionarCheckIn()
        {
            try
            {
                // Valida se uma reserva foi selecionada
                if (ComboBoxReservaId.SelectedValue == null)
                {
                    MessageBox.Show("Selecione uma reserva.");
                    return;
                }

                var reservaId = (int)ComboBoxReservaId.SelectedValue;
                var dataHoraCheckIn = DateTimePickerDataHoraCheckIn.Value;
                var numeroDeClientes = (int)NumericUpDownNumeroClientes.Value;

                var resultado = _checkInController.CriarCheckIn(reservaId, dataHoraCheckIn, numeroDeClientes);

                if (resultado)
                {
                    MessageBox.Show("Check-in adicionado com sucesso!");
                    AtualizarCheckInsDataGridView();
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar check-in.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void AtualizarStatusCheckIn()
        {
            try
            {
                // Valida se um check-in foi selecionado e se o status foi selecionado corretamente
                if (DataGridViewCheckIns.SelectedRows.Count > 0)
                {
                    var checkInSelecionado = DataGridViewCheckIns.SelectedRows[0].DataBoundItem as CheckInViewModel;
                    if (checkInSelecionado != null && ComboBoxStatus.SelectedItem != null &&
                        Enum.TryParse(ComboBoxStatus.SelectedItem.ToString(), out StatusCheckIn novoStatus))
                    {
                        var resultado = _checkInController.AlterarStatusCheckIn(checkInSelecionado.Id, novoStatus);

                        if (resultado)
                        {
                            MessageBox.Show("Status do check-in atualizado com sucesso!");
                            AtualizarCheckInsDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao atualizar o status.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione um status válido.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um check-in para atualizar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void RemoverCheckIn()
        {
            try
            {
                // Valida se um check-in foi selecionado
                if (DataGridViewCheckIns.SelectedRows.Count > 0)
                {
                    var checkInSelecionado = DataGridViewCheckIns.SelectedRows[0].DataBoundItem as CheckInViewModel;
                    if (checkInSelecionado != null)
                    {
                        var resultado = _checkInController.RemoverCheckIn(checkInSelecionado.Id);

                        if (resultado)
                        {
                            MessageBox.Show("Check-in removido com sucesso!");
                            AtualizarCheckInsDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao remover check-in.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um check-in para remover.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        #endregion

        #region Eventos de Interface

        private void BotaoAdicionarCheckIn_Click(object? sender, EventArgs e)
        {
            if (sender is Button botao)
            {
                AdicionarCheckIn();
            }
        }

        private void BotaoAtualizarStatusCheckIn_Click(object? sender, EventArgs e)
        {
            if (sender is Button botao)
            {
                AtualizarStatusCheckIn();
            }
        }

        private void BotaoRemoverCheckIn_Click(object? sender, EventArgs e)
        {
            if (sender is Button botao)
            {
                RemoverCheckIn();
            }
        }

        private void DataGridViewReservasConfirmadas_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridViewReservasConfirmadas.SelectedRows.Count > 0)
            {
                var reservaSelecionada = DataGridViewReservasConfirmadas.SelectedRows[0].DataBoundItem as ReservaViewModel;
                if (reservaSelecionada != null)
                {
                    AtualizarCheckInsDataGridView();
                }
            }
        }

        #endregion
    }
}
