namespace GestaoAlojamentosApp.App.Forms
{
    partial class FormGestaoAlojamentos
    {
        private void InitializeComponent()
        {
            BotaoAdicionarAlojamento = new Button();
            BotaoAtualizarAlojamento = new Button();
            BotaoRemoverAlojamento = new Button();
            DataGridViewAlojamentos = new DataGridView();
            TextoNome = new TextBox();
            TextoLocalizacao = new TextBox();
            TextoPreco = new TextBox();
            TextoCapacidade = new TextBox();
            TextoNumeroQuartos = new TextBox();
            ComboBoxStatus = new ComboBox();
            ComboBoxTipo = new ComboBox();
            PictureBoxImagem = new PictureBox();
            TextoImagemPath = new TextBox();
            BotaoAdicionarImagem = new Button();
            BotaoRemoverImagem = new Button();
            BotaoProximaImagem = new Button();
            BotaoImagemAnterior = new Button();
            BotaoSelecionarImagem = new Button();
            PanelImagem = new Panel();
            LabelTitulo = new Label();
            LabelNome = new Label();
            LabelLocalizacao = new Label();
            LabelPreco = new Label();
            LabelCapacidade = new Label();
            LabelNumeroQuartos = new Label();
            LabelStatus = new Label();
            LabelTipo = new Label();
            LabelImagem = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridViewAlojamentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxImagem).BeginInit();
            PanelImagem.SuspendLayout();
            SuspendLayout();
            // 
            // BotaoAdicionarAlojamento
            // 
            BotaoAdicionarAlojamento.BackColor = Color.SeaGreen;
            BotaoAdicionarAlojamento.FlatStyle = FlatStyle.Flat;
            BotaoAdicionarAlojamento.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoAdicionarAlojamento.ForeColor = Color.White;
            BotaoAdicionarAlojamento.Location = new Point(477, 635);
            BotaoAdicionarAlojamento.Name = "BotaoAdicionarAlojamento";
            BotaoAdicionarAlojamento.Size = new Size(226, 36);
            BotaoAdicionarAlojamento.TabIndex = 0;
            BotaoAdicionarAlojamento.Text = "Adicionar Alojamento";
            BotaoAdicionarAlojamento.UseVisualStyleBackColor = false;
            BotaoAdicionarAlojamento.Click += BotaoAdicionarAlojamento_Click;
            // 
            // BotaoAtualizarAlojamento
            // 
            BotaoAtualizarAlojamento.BackColor = Color.Gold;
            BotaoAtualizarAlojamento.FlatStyle = FlatStyle.Flat;
            BotaoAtualizarAlojamento.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoAtualizarAlojamento.ForeColor = Color.White;
            BotaoAtualizarAlojamento.Location = new Point(769, 635);
            BotaoAtualizarAlojamento.Name = "BotaoAtualizarAlojamento";
            BotaoAtualizarAlojamento.Size = new Size(223, 36);
            BotaoAtualizarAlojamento.TabIndex = 1;
            BotaoAtualizarAlojamento.Text = "Atualizar Alojamento";
            BotaoAtualizarAlojamento.UseVisualStyleBackColor = false;
            BotaoAtualizarAlojamento.Click += BotaoAtualizarAlojamento_Click;
            // 
            // BotaoRemoverAlojamento
            // 
            BotaoRemoverAlojamento.BackColor = Color.Crimson;
            BotaoRemoverAlojamento.FlatStyle = FlatStyle.Flat;
            BotaoRemoverAlojamento.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoRemoverAlojamento.ForeColor = Color.White;
            BotaoRemoverAlojamento.Location = new Point(1053, 635);
            BotaoRemoverAlojamento.Name = "BotaoRemoverAlojamento";
            BotaoRemoverAlojamento.Size = new Size(223, 36);
            BotaoRemoverAlojamento.TabIndex = 2;
            BotaoRemoverAlojamento.Text = "Remover Alojamento";
            BotaoRemoverAlojamento.UseVisualStyleBackColor = false;
            BotaoRemoverAlojamento.Click += BotaoRemoverAlojamento_Click;
            // 
            // DataGridViewAlojamentos
            // 
            DataGridViewAlojamentos.AllowUserToAddRows = false;
            DataGridViewAlojamentos.AllowUserToDeleteRows = false;
            DataGridViewAlojamentos.AllowUserToResizeRows = false;
            DataGridViewAlojamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewAlojamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewAlojamentos.Location = new Point(329, 350);
            DataGridViewAlojamentos.MultiSelect = false;
            DataGridViewAlojamentos.Name = "DataGridViewAlojamentos";
            DataGridViewAlojamentos.ReadOnly = true;
            DataGridViewAlojamentos.RowHeadersVisible = false;
            DataGridViewAlojamentos.RowHeadersWidth = 51;
            DataGridViewAlojamentos.RowTemplate.Height = 25;
            DataGridViewAlojamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewAlojamentos.Size = new Size(970, 249);
            DataGridViewAlojamentos.TabIndex = 3;
            DataGridViewAlojamentos.SelectionChanged += DataGridViewAlojamentos_SelectionChanged;
            // 
            // TextoNome
            // 
            TextoNome.Location = new Point(13, 50);
            TextoNome.Name = "TextoNome";
            TextoNome.Size = new Size(300, 27);
            TextoNome.TabIndex = 4;
            // 
            // TextoLocalizacao
            // 
            TextoLocalizacao.Location = new Point(360, 50);
            TextoLocalizacao.Name = "TextoLocalizacao";
            TextoLocalizacao.Size = new Size(300, 27);
            TextoLocalizacao.TabIndex = 5;
            // 
            // TextoPreco
            // 
            TextoPreco.Location = new Point(709, 50);
            TextoPreco.Name = "TextoPreco";
            TextoPreco.Size = new Size(300, 27);
            TextoPreco.TabIndex = 6;
            // 
            // TextoCapacidade
            // 
            TextoCapacidade.Location = new Point(13, 127);
            TextoCapacidade.Name = "TextoCapacidade";
            TextoCapacidade.Size = new Size(300, 27);
            TextoCapacidade.TabIndex = 7;
            // 
            // TextoNumeroQuartos
            // 
            TextoNumeroQuartos.Location = new Point(360, 127);
            TextoNumeroQuartos.Name = "TextoNumeroQuartos";
            TextoNumeroQuartos.Size = new Size(300, 27);
            TextoNumeroQuartos.TabIndex = 8;
            // 
            // ComboBoxStatus
            // 
            ComboBoxStatus.Location = new Point(709, 127);
            ComboBoxStatus.Name = "ComboBoxStatus";
            ComboBoxStatus.Size = new Size(300, 28);
            ComboBoxStatus.TabIndex = 9;
            // 
            // ComboBoxTipo
            // 
            ComboBoxTipo.Location = new Point(360, 208);
            ComboBoxTipo.Name = "ComboBoxTipo";
            ComboBoxTipo.Size = new Size(300, 28);
            ComboBoxTipo.TabIndex = 10;
            // 
            // PictureBoxImagem
            // 
            PictureBoxImagem.BackColor = Color.Silver;
            PictureBoxImagem.Dock = DockStyle.Fill;
            PictureBoxImagem.Location = new Point(0, 0);
            PictureBoxImagem.Name = "PictureBoxImagem";
            PictureBoxImagem.Size = new Size(298, 248);
            PictureBoxImagem.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxImagem.TabIndex = 0;
            PictureBoxImagem.TabStop = false;
            // 
            // TextoImagemPath
            // 
            TextoImagemPath.Location = new Point(13, 317);
            TextoImagemPath.Name = "TextoImagemPath";
            TextoImagemPath.Size = new Size(300, 27);
            TextoImagemPath.TabIndex = 11;
            // 
            // BotaoAdicionarImagem
            // 
            BotaoAdicionarImagem.BackColor = Color.Navy;
            BotaoAdicionarImagem.FlatStyle = FlatStyle.Flat;
            BotaoAdicionarImagem.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoAdicionarImagem.ForeColor = Color.White;
            BotaoAdicionarImagem.Location = new Point(12, 686);
            BotaoAdicionarImagem.Name = "BotaoAdicionarImagem";
            BotaoAdicionarImagem.Size = new Size(136, 36);
            BotaoAdicionarImagem.TabIndex = 12;
            BotaoAdicionarImagem.Text = "Adicionar Imagem";
            BotaoAdicionarImagem.UseVisualStyleBackColor = false;
            BotaoAdicionarImagem.Click += BotaoAdicionarImagem_Click;
            // 
            // BotaoRemoverImagem
            // 
            BotaoRemoverImagem.BackColor = Color.Navy;
            BotaoRemoverImagem.FlatStyle = FlatStyle.Flat;
            BotaoRemoverImagem.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoRemoverImagem.ForeColor = Color.White;
            BotaoRemoverImagem.Location = new Point(176, 686);
            BotaoRemoverImagem.Name = "BotaoRemoverImagem";
            BotaoRemoverImagem.Size = new Size(135, 37);
            BotaoRemoverImagem.TabIndex = 13;
            BotaoRemoverImagem.Text = "Remover Imagem";
            BotaoRemoverImagem.UseVisualStyleBackColor = false;
            BotaoRemoverImagem.Click += BotaoRemoverImagem_Click;
            // 
            // BotaoProximaImagem
            // 
            BotaoProximaImagem.BackColor = Color.BlueViolet;
            BotaoProximaImagem.FlatStyle = FlatStyle.Flat;
            BotaoProximaImagem.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoProximaImagem.ForeColor = Color.White;
            BotaoProximaImagem.Location = new Point(12, 635);
            BotaoProximaImagem.Name = "BotaoProximaImagem";
            BotaoProximaImagem.Size = new Size(136, 36);
            BotaoProximaImagem.TabIndex = 14;
            BotaoProximaImagem.Text = "Próxima ";
            BotaoProximaImagem.UseVisualStyleBackColor = false;
            BotaoProximaImagem.Click += BotaoProximaImagem_Click;
            // 
            // BotaoImagemAnterior
            // 
            BotaoImagemAnterior.BackColor = Color.BlueViolet;
            BotaoImagemAnterior.FlatStyle = FlatStyle.Flat;
            BotaoImagemAnterior.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoImagemAnterior.ForeColor = Color.White;
            BotaoImagemAnterior.Location = new Point(176, 635);
            BotaoImagemAnterior.Name = "BotaoImagemAnterior";
            BotaoImagemAnterior.Size = new Size(135, 36);
            BotaoImagemAnterior.TabIndex = 15;
            BotaoImagemAnterior.Text = "Anterior";
            BotaoImagemAnterior.UseVisualStyleBackColor = false;
            BotaoImagemAnterior.Click += BotaoImagemAnterior_Click;
            // 
            // BotaoSelecionarImagem
            // 
            BotaoSelecionarImagem.BackColor = Color.Indigo;
            BotaoSelecionarImagem.FlatStyle = FlatStyle.Flat;
            BotaoSelecionarImagem.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoSelecionarImagem.ForeColor = Color.White;
            BotaoSelecionarImagem.Location = new Point(12, 233);
            BotaoSelecionarImagem.Name = "BotaoSelecionarImagem";
            BotaoSelecionarImagem.Size = new Size(179, 36);
            BotaoSelecionarImagem.TabIndex = 16;
            BotaoSelecionarImagem.Text = "Selecionar Imagem";
            BotaoSelecionarImagem.UseVisualStyleBackColor = false;
            BotaoSelecionarImagem.Click += BotaoSelecionarImagem_Click;
            // 
            // PanelImagem
            // 
            PanelImagem.BackColor = Color.LightGray;
            PanelImagem.BorderStyle = BorderStyle.FixedSingle;
            PanelImagem.Controls.Add(PictureBoxImagem);
            PanelImagem.Location = new Point(12, 350);
            PanelImagem.Name = "PanelImagem";
            PanelImagem.Size = new Size(300, 250);
            PanelImagem.TabIndex = 8;
            // 
            // LabelTitulo
            // 
            LabelTitulo.AutoSize = true;
            LabelTitulo.Font = new Font("Arial", 20F, FontStyle.Bold);
            LabelTitulo.Location = new Point(12, 9);
            LabelTitulo.Name = "LabelTitulo";
            LabelTitulo.Size = new Size(250, 32);
            LabelTitulo.TabIndex = 17;
            LabelTitulo.Text = "Gestão de Alojamentos";
            // 
            // LabelNome
            // 
            LabelNome.AutoSize = true;
            LabelNome.Location = new Point(13, 27);
            LabelNome.Name = "LabelNome";
            LabelNome.Size = new Size(53, 20);
            LabelNome.TabIndex = 0;
            LabelNome.Text = "Nome:";
            // 
            // LabelLocalizacao
            // 
            LabelLocalizacao.AutoSize = true;
            LabelLocalizacao.Location = new Point(360, 27);
            LabelLocalizacao.Name = "LabelLocalizacao";
            LabelLocalizacao.Size = new Size(90, 20);
            LabelLocalizacao.TabIndex = 1;
            LabelLocalizacao.Text = "Localização:";
            // 
            // LabelPreco
            // 
            LabelPreco.AutoSize = true;
            LabelPreco.Location = new Point(709, 27);
            LabelPreco.Name = "LabelPreco";
            LabelPreco.Size = new Size(49, 20);
            LabelPreco.TabIndex = 2;
            LabelPreco.Text = "Preço:";
            // 
            // LabelCapacidade
            // 
            LabelCapacidade.AutoSize = true;
            LabelCapacidade.Location = new Point(13, 94);
            LabelCapacidade.Name = "LabelCapacidade";
            LabelCapacidade.Size = new Size(91, 20);
            LabelCapacidade.TabIndex = 3;
            LabelCapacidade.Text = "Capacidade:";
            // 
            // LabelNumeroQuartos
            // 
            LabelNumeroQuartos.AutoSize = true;
            LabelNumeroQuartos.Location = new Point(360, 94);
            LabelNumeroQuartos.Name = "LabelNumeroQuartos";
            LabelNumeroQuartos.Size = new Size(143, 20);
            LabelNumeroQuartos.TabIndex = 4;
            LabelNumeroQuartos.Text = "Número de Quartos:";
            // 
            // LabelStatus
            // 
            LabelStatus.AutoSize = true;
            LabelStatus.Location = new Point(709, 94);
            LabelStatus.Name = "LabelStatus";
            LabelStatus.Size = new Size(52, 20);
            LabelStatus.TabIndex = 5;
            LabelStatus.Text = "Status:";
            // 
            // LabelTipo
            // 
            LabelTipo.AutoSize = true;
            LabelTipo.Location = new Point(360, 171);
            LabelTipo.Name = "LabelTipo";
            LabelTipo.Size = new Size(42, 20);
            LabelTipo.TabIndex = 6;
            LabelTipo.Text = "Tipo:";
            // 
            // LabelImagem
            // 
            LabelImagem.AutoSize = true;
            LabelImagem.Location = new Point(12, 281);
            LabelImagem.Name = "LabelImagem";
            LabelImagem.Size = new Size(67, 20);
            LabelImagem.TabIndex = 7;
            LabelImagem.Text = "Imagem:";
            // 
            // FormGestaoAlojamentos
            // 
            ClientSize = new Size(1311, 812);
            Controls.Add(LabelNome);
            Controls.Add(LabelLocalizacao);
            Controls.Add(LabelPreco);
            Controls.Add(LabelCapacidade);
            Controls.Add(LabelNumeroQuartos);
            Controls.Add(LabelStatus);
            Controls.Add(LabelTipo);
            Controls.Add(LabelImagem);
            Controls.Add(DataGridViewAlojamentos);
            Controls.Add(PanelImagem);
            Controls.Add(TextoImagemPath);
            Controls.Add(BotaoAdicionarImagem);
            Controls.Add(BotaoRemoverImagem);
            Controls.Add(BotaoProximaImagem);
            Controls.Add(BotaoImagemAnterior);
            Controls.Add(BotaoSelecionarImagem);
            Controls.Add(TextoNome);
            Controls.Add(TextoLocalizacao);
            Controls.Add(TextoPreco);
            Controls.Add(TextoCapacidade);
            Controls.Add(TextoNumeroQuartos);
            Controls.Add(ComboBoxStatus);
            Controls.Add(ComboBoxTipo);
            Controls.Add(BotaoAdicionarAlojamento);
            Controls.Add(BotaoAtualizarAlojamento);
            Controls.Add(BotaoRemoverAlojamento);
            Name = "FormGestaoAlojamentos";
            Text = "Gestão de Alojamentos";
            ((System.ComponentModel.ISupportInitialize)DataGridViewAlojamentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)PictureBoxImagem).EndInit();
            PanelImagem.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        // Campos privados
        private DataGridView DataGridViewAlojamentos;
        private Button BotaoAdicionarAlojamento;
        private Button BotaoAtualizarAlojamento;
        private Button BotaoRemoverAlojamento;
        private TextBox TextoNome;
        private TextBox TextoLocalizacao;
        private TextBox TextoPreco;
        private TextBox TextoCapacidade;
        private TextBox TextoNumeroQuartos;
        private ComboBox ComboBoxStatus;
        private ComboBox ComboBoxTipo;
        private PictureBox PictureBoxImagem;
        private TextBox TextoImagemPath;
        private Button BotaoAdicionarImagem;
        private Button BotaoRemoverImagem;
        private Button BotaoProximaImagem;
        private Button BotaoImagemAnterior;
        private Button BotaoSelecionarImagem;
        private Panel PanelImagem;
        private Label LabelTitulo;
        private Label LabelNome;
        private Label LabelLocalizacao;
        private Label LabelPreco;
        private Label LabelCapacidade;
        private Label LabelNumeroQuartos;
        private Label LabelStatus;
        private Label LabelTipo;
        private Label LabelImagem;

    }
}
