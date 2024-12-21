namespace GestaoAlojamentosApp.App.Forms
{
    partial class FormGestaoClientes
    {
        private void InitializeComponent()
        {
            BotaoAdicionarCliente = new Button();
            BotaoAtualizarCliente = new Button();
            BotaoRemoverCliente = new Button();
            DataGridViewClientes = new DataGridView();
            TextBoxNomeCliente = new TextBox();
            TextBoxEmailCliente = new TextBox();
            TextBoxTelefoneCliente = new TextBox();
            TextBoxIdadeCliente = new TextBox();
            LabelTitulo = new Label();
            LabelNome = new Label();
            LabelEmail = new Label();
            LabelTelefone = new Label();
            LabelIdade = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridViewClientes).BeginInit();
            SuspendLayout();
            // 
            // BotaoAdicionarCliente
            // 
            BotaoAdicionarCliente.BackColor = Color.SeaGreen;
            BotaoAdicionarCliente.FlatStyle = FlatStyle.Flat;
            BotaoAdicionarCliente.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoAdicionarCliente.ForeColor = Color.White;
            BotaoAdicionarCliente.Location = new Point(118, 541);
            BotaoAdicionarCliente.Name = "BotaoAdicionarCliente";
            BotaoAdicionarCliente.Size = new Size(180, 50);
            BotaoAdicionarCliente.TabIndex = 0;
            BotaoAdicionarCliente.Text = "Adicionar Cliente";
            BotaoAdicionarCliente.UseVisualStyleBackColor = false;
            BotaoAdicionarCliente.Click += BotaoAdicionarCliente_Click;
            // 
            // BotaoAtualizarCliente
            // 
            BotaoAtualizarCliente.BackColor = Color.Gold;
            BotaoAtualizarCliente.FlatStyle = FlatStyle.Flat;
            BotaoAtualizarCliente.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoAtualizarCliente.ForeColor = Color.White;
            BotaoAtualizarCliente.Location = new Point(480, 541);
            BotaoAtualizarCliente.Name = "BotaoAtualizarCliente";
            BotaoAtualizarCliente.Size = new Size(180, 50);
            BotaoAtualizarCliente.TabIndex = 1;
            BotaoAtualizarCliente.Text = "Atualizar Cliente";
            BotaoAtualizarCliente.UseVisualStyleBackColor = false;
            BotaoAtualizarCliente.Click += BotaoAtualizarCliente_Click;
            // 
            // BotaoRemoverCliente
            // 
            BotaoRemoverCliente.BackColor = Color.Crimson;
            BotaoRemoverCliente.FlatStyle = FlatStyle.Flat;
            BotaoRemoverCliente.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoRemoverCliente.ForeColor = Color.White;
            BotaoRemoverCliente.Location = new Point(892, 541);
            BotaoRemoverCliente.Name = "BotaoRemoverCliente";
            BotaoRemoverCliente.Size = new Size(180, 50);
            BotaoRemoverCliente.TabIndex = 2;
            BotaoRemoverCliente.Text = "Remover Cliente";
            BotaoRemoverCliente.UseVisualStyleBackColor = false;
            BotaoRemoverCliente.Click += BotaoRemoverCliente_Click;
            // 
            // DataGridViewClientes
            // 
            DataGridViewClientes.AllowUserToAddRows = false;
            DataGridViewClientes.AllowUserToDeleteRows = false;
            DataGridViewClientes.AllowUserToResizeRows = false;
            DataGridViewClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewClientes.Location = new Point(28, 295);
            DataGridViewClientes.MultiSelect = false;
            DataGridViewClientes.Name = "DataGridViewClientes";
            DataGridViewClientes.ReadOnly = true;
            DataGridViewClientes.RowHeadersVisible = false;
            DataGridViewClientes.RowHeadersWidth = 51;
            DataGridViewClientes.RowTemplate.Height = 25;
            DataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewClientes.Size = new Size(1180, 200);
            DataGridViewClientes.TabIndex = 3;
            DataGridViewClientes.SelectionChanged += DataGridViewClientes_SelectionChanged;
            // 
            // TextBoxNomeCliente
            // 
            TextBoxNomeCliente.Location = new Point(28, 147);
            TextBoxNomeCliente.Name = "TextBoxNomeCliente";
            TextBoxNomeCliente.Size = new Size(300, 27);
            TextBoxNomeCliente.TabIndex = 4;
            // 
            // TextBoxEmailCliente
            // 
            TextBoxEmailCliente.Location = new Point(402, 147);
            TextBoxEmailCliente.Name = "TextBoxEmailCliente";
            TextBoxEmailCliente.Size = new Size(300, 27);
            TextBoxEmailCliente.TabIndex = 5;
            // 
            // TextBoxTelefoneCliente
            // 
            TextBoxTelefoneCliente.Location = new Point(758, 147);
            TextBoxTelefoneCliente.Name = "TextBoxTelefoneCliente";
            TextBoxTelefoneCliente.Size = new Size(300, 27);
            TextBoxTelefoneCliente.TabIndex = 6;
            // 
            // TextBoxIdadeCliente
            // 
            TextBoxIdadeCliente.Location = new Point(28, 235);
            TextBoxIdadeCliente.Name = "TextBoxIdadeCliente";
            TextBoxIdadeCliente.Size = new Size(300, 27);
            TextBoxIdadeCliente.TabIndex = 7;
            // 
            // LabelTitulo
            // 
            LabelTitulo.AutoSize = true;
            LabelTitulo.Font = new Font("Arial", 20F, FontStyle.Bold);
            LabelTitulo.Location = new Point(12, 9);
            LabelTitulo.Name = "LabelTitulo";
            LabelTitulo.Size = new Size(321, 40);
            LabelTitulo.TabIndex = 8;
            LabelTitulo.Text = "Gestão de Clientes";
            // 
            // LabelNome
            // 
            LabelNome.AutoSize = true;
            LabelNome.Location = new Point(28, 109);
            LabelNome.Name = "LabelNome";
            LabelNome.Size = new Size(53, 20);
            LabelNome.TabIndex = 9;
            LabelNome.Text = "Nome:";
            // 
            // LabelEmail
            // 
            LabelEmail.AutoSize = true;
            LabelEmail.Location = new Point(402, 109);
            LabelEmail.Name = "LabelEmail";
            LabelEmail.Size = new Size(55, 20);
            LabelEmail.TabIndex = 10;
            LabelEmail.Text = "E-mail:";
            // 
            // LabelTelefone
            // 
            LabelTelefone.AutoSize = true;
            LabelTelefone.Location = new Point(758, 109);
            LabelTelefone.Name = "LabelTelefone";
            LabelTelefone.Size = new Size(69, 20);
            LabelTelefone.TabIndex = 11;
            LabelTelefone.Text = "Telefone:";
            // 
            // LabelIdade
            // 
            LabelIdade.AutoSize = true;
            LabelIdade.Location = new Point(31, 199);
            LabelIdade.Name = "LabelIdade";
            LabelIdade.Size = new Size(50, 20);
            LabelIdade.TabIndex = 12;
            LabelIdade.Text = "Idade:";
            // 
            // FormGestaoClientes
            // 
            ClientSize = new Size(1204, 625);
            Controls.Add(LabelIdade);
            Controls.Add(LabelTelefone);
            Controls.Add(LabelEmail);
            Controls.Add(LabelNome);
            Controls.Add(LabelTitulo);
            Controls.Add(TextBoxIdadeCliente);
            Controls.Add(TextBoxTelefoneCliente);
            Controls.Add(TextBoxEmailCliente);
            Controls.Add(TextBoxNomeCliente);
            Controls.Add(DataGridViewClientes);
            Controls.Add(BotaoRemoverCliente);
            Controls.Add(BotaoAtualizarCliente);
            Controls.Add(BotaoAdicionarCliente);
            Name = "FormGestaoClientes";
            ((System.ComponentModel.ISupportInitialize)DataGridViewClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button BotaoAdicionarCliente;
        private Button BotaoAtualizarCliente;
        private Button BotaoRemoverCliente;
        private DataGridView DataGridViewClientes;
        private TextBox TextBoxNomeCliente;
        private TextBox TextBoxEmailCliente;
        private TextBox TextBoxTelefoneCliente;
        private TextBox TextBoxIdadeCliente;
        private Label LabelTitulo;
        private Label LabelNome;
        private Label LabelEmail;
        private Label LabelTelefone;
        private Label LabelIdade;
    }
}
