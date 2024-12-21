namespace GestaoAlojamentosApp.App.Forms
{
    partial class FormPrincipal
    {
        #region Código gerado pelo Designer

        private void InitializeComponent()
        {
            CaixaTextoNomeDeUsuario = new TextBox();
            CaixaTextoSenha = new TextBox();
            BotaoLogin = new Button();
            BotaoSair = new Button();
            lblUsername = new Label();
            lblPassword = new Label();
            lblWelcome = new Label();
            lblSubText = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // CaixaTextoNomeDeUsuario
            // 
            CaixaTextoNomeDeUsuario.Anchor = AnchorStyles.None;
            CaixaTextoNomeDeUsuario.BorderStyle = BorderStyle.FixedSingle;
            CaixaTextoNomeDeUsuario.Font = new Font("Arial", 12F);
            CaixaTextoNomeDeUsuario.Location = new Point(398, 290);
            CaixaTextoNomeDeUsuario.Name = "CaixaTextoNomeDeUsuario";
            CaixaTextoNomeDeUsuario.PlaceholderText = "Digite seu usuário";
            CaixaTextoNomeDeUsuario.Size = new Size(300, 30);
            CaixaTextoNomeDeUsuario.TabIndex = 2;
            CaixaTextoNomeDeUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // CaixaTextoSenha
            // 
            CaixaTextoSenha.Anchor = AnchorStyles.None;
            CaixaTextoSenha.BorderStyle = BorderStyle.FixedSingle;
            CaixaTextoSenha.Font = new Font("Arial", 12F);
            CaixaTextoSenha.Location = new Point(398, 360);
            CaixaTextoSenha.Name = "CaixaTextoSenha";
            CaixaTextoSenha.PasswordChar = '*';
            CaixaTextoSenha.PlaceholderText = "Digite sua senha";
            CaixaTextoSenha.Size = new Size(300, 30);
            CaixaTextoSenha.TabIndex = 3;
            CaixaTextoSenha.TextAlign = HorizontalAlignment.Center;
            // 
            // BotaoLogin
            // 
            BotaoLogin.Anchor = AnchorStyles.None;
            BotaoLogin.BackColor = Color.FromArgb(50, 150, 255);
            BotaoLogin.FlatAppearance.BorderSize = 0;
            BotaoLogin.FlatStyle = FlatStyle.Flat;
            BotaoLogin.Font = new Font("Arial", 12F, FontStyle.Bold);
            BotaoLogin.ForeColor = Color.White;
            BotaoLogin.Location = new Point(398, 430);
            BotaoLogin.Name = "BotaoLogin";
            BotaoLogin.Size = new Size(120, 45);
            BotaoLogin.TabIndex = 4;
            BotaoLogin.Text = "Login";
            BotaoLogin.UseVisualStyleBackColor = false;
            BotaoLogin.Click += BotaoLogin_Click;
            // 
            // BotaoSair
            // 
            BotaoSair.Anchor = AnchorStyles.None;
            BotaoSair.BackColor = Color.FromArgb(255, 69, 58);
            BotaoSair.FlatAppearance.BorderSize = 0;
            BotaoSair.FlatStyle = FlatStyle.Flat;
            BotaoSair.Font = new Font("Arial", 12F, FontStyle.Bold);
            BotaoSair.ForeColor = Color.White;
            BotaoSair.Location = new Point(578, 430);
            BotaoSair.Name = "BotaoSair";
            BotaoSair.Size = new Size(120, 45);
            BotaoSair.TabIndex = 5;
            BotaoSair.Text = "Sair";
            BotaoSair.UseVisualStyleBackColor = false;
            BotaoSair.Click += BotaoSair_Click;
            // 
            // lblUsername
            // 
            lblUsername.Anchor = AnchorStyles.None;
            lblUsername.Font = new Font("Arial", 12F);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(398, 260);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(300, 25);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Usuário";
            lblUsername.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.None;
            lblPassword.Font = new Font("Arial", 12F);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(398, 330);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(300, 25);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Senha";
            lblPassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.None;
            lblWelcome.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(348, 120);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(400, 40);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Bem-vindo, Administrador!";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubText
            // 
            lblSubText.Anchor = AnchorStyles.None;
            lblSubText.Font = new Font("Arial", 14F);
            lblSubText.ForeColor = Color.LightGray;
            lblSubText.Location = new Point(348, 160);
            lblSubText.Name = "lblSubText";
            lblSubText.Size = new Size(400, 30);
            lblSubText.TabIndex = 1;
            lblSubText.Text = "Faça login para continuar...";
            lblSubText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logotipo;
            pictureBox1.Location = new Point(29, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(237, 79);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // FormPrincipal
            // 
            BackColor = Color.FromArgb(18, 32, 47);
            ClientSize = new Size(1096, 600);
            Controls.Add(pictureBox1);
            Controls.Add(lblSubText);
            Controls.Add(lblWelcome);
            Controls.Add(CaixaTextoNomeDeUsuario);
            Controls.Add(CaixaTextoSenha);
            Controls.Add(BotaoLogin);
            Controls.Add(BotaoSair);
            Controls.Add(lblUsername);
            Controls.Add(lblPassword);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tela de Login";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Declaração dos controles
        private TextBox CaixaTextoNomeDeUsuario;
        private TextBox CaixaTextoSenha;
        private Button BotaoLogin;
        private Button BotaoSair;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblWelcome;
        private Label lblSubText;
        private PictureBox pictureBox1;
    }
}
