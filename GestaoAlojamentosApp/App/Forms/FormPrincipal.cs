using System;
using System.Windows.Forms;
using GestaoAlojamentosApp.App.Controllers;

namespace GestaoAlojamentosApp.App.Forms
{
    public partial class FormPrincipal : Form
    {
        private readonly UtilizadorController _utilizadorController;
        private readonly FormMenuAdministrador _formMenuAdministrador;

        public FormPrincipal(UtilizadorController utilizadorController, FormMenuAdministrador formMenuAdministrador)
        {
            InitializeComponent();
            _utilizadorController = utilizadorController;
            _formMenuAdministrador = formMenuAdministrador;
            this.WindowState = FormWindowState.Maximized;
        }

        private void BotaoLogin_Click(object sender, EventArgs e)
        {
            string nomeDeUsuario = CaixaTextoNomeDeUsuario.Text;
            string senha = CaixaTextoSenha.Text;

            if (string.IsNullOrEmpty(nomeDeUsuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sucessoLogin = _utilizadorController.RealizarLogin(nomeDeUsuario, senha);

            if (sucessoLogin)
            {
                _formMenuAdministrador.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
