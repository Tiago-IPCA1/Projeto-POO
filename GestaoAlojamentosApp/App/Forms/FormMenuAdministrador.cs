using System;
using System.Windows.Forms;
using GestaoAlojamentosApp.App.Controllers;

namespace GestaoAlojamentosApp.App.Forms
{
    public partial class FormMenuAdministrador : Form
    {
        private readonly AlojamentoController _alojamentoController;
        private readonly ClienteController _clienteController;
        private readonly ReservaController _reservaController;
        private readonly CheckInController _checkInController;
        private readonly PagamentoController _pagamentoController;

        // Injeção de dependências via construtor
        public FormMenuAdministrador(
            AlojamentoController alojamentoController,
            ClienteController clienteController,
            ReservaController reservaController,
            CheckInController checkInController,
            PagamentoController pagamentoController)
        {
            InitializeComponent();
            _alojamentoController = alojamentoController;
            _clienteController = clienteController;
            _reservaController = reservaController;
            _checkInController = checkInController;
            _pagamentoController = pagamentoController;

            InicializarForm();
        }

        private void InicializarForm()
        {
            this.WindowState = FormWindowState.Maximized;
            AbrirConteudoInicial("Bem-vindo ao Sistema!");
        }

        private void AbrirConteudoInicial(string mensagem)
        {
            pnlContent.Controls.Clear();
            Label labelContent = new Label
            {
                Text = mensagem,
                Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(10, 10)
            };

            pnlContent.Controls.Add(labelContent);
        }

        private void AbrirFormNoPainel(Form form)
        {
            pnlContent.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(form);
            form.Show();
        }

        // Clique em Gestão de Alojamentos
        private void GestaoAlojamentos_Click(object sender, EventArgs e)
        {
            AbrirConteudoInicial("Gestão de Alojamentos");
            FormGestaoAlojamentos formGestaoAlojamentos = new FormGestaoAlojamentos(_alojamentoController);
            AbrirFormNoPainel(formGestaoAlojamentos);
        }

        // Clique em Gestão de Clientes
        private void GestaoClientes_Click(object sender, EventArgs e)
        {
            AbrirConteudoInicial("Gestão de Clientes");
            FormGestaoClientes formGestaoClientes = new FormGestaoClientes(_clienteController);
            AbrirFormNoPainel(formGestaoClientes);
        }

        // Clique em Gestão de Reservas
        private void GestaoReservas_Click(object sender, EventArgs e)
        {
            AbrirConteudoInicial("Gestão de Reservas");
            FormGestaoReservas formGestaoReservas = new FormGestaoReservas(_reservaController, _clienteController, _alojamentoController);
            AbrirFormNoPainel(formGestaoReservas);
        }

        // Clique em Gestão de Check-ins
        private void GestaoCheckin_Click(object sender, EventArgs e)
        {
            AbrirConteudoInicial("Gestão de Check-ins");
            FormGestaoCheckIns formGestaoCheckIns = new FormGestaoCheckIns(_checkInController, _reservaController);
            AbrirFormNoPainel(formGestaoCheckIns);
        }

        // Clique em Gestão de Pagamentos
        private void GestaoPagamentos_Click(object sender, EventArgs e)
        {
            AbrirConteudoInicial("Gestão de Pagamentos");
            FormGestaoPagamentos formGestaoPagamentos = new FormGestaoPagamentos(_pagamentoController, _reservaController);
            AbrirFormNoPainel(formGestaoPagamentos);
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
