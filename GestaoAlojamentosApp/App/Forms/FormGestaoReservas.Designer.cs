namespace GestaoAlojamentosApp.App.Forms
{
    partial class FormGestaoReservas
    {
        private void InitializeComponent()
        {
            BotaoAdicionarReserva = new Button();
            BotaoAtualizarReserva = new Button();
            BotaoRemoverReserva = new Button();
            DataGridViewReservas = new DataGridView();
            ComboBoxClienteEmail = new ComboBox();
            ComboBoxAlojamentoNome = new ComboBox();
            DateTimePickerDataInicio = new DateTimePicker();
            DateTimePickerDataFim = new DateTimePicker();
            NumericUpDownNumeroPessoas = new NumericUpDown();
            LabelTitulo = new Label();
            LabelClienteEmail = new Label();
            LabelAlojamentoNome = new Label();
            LabelDataInicio = new Label();
            LabelDataFim = new Label();
            LabelNumeroPessoas = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridViewReservas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownNumeroPessoas).BeginInit();
            SuspendLayout();
            // 
            // BotaoAdicionarReserva
            // 
            BotaoAdicionarReserva.BackColor = Color.SeaGreen;
            BotaoAdicionarReserva.FlatStyle = FlatStyle.Flat;
            BotaoAdicionarReserva.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoAdicionarReserva.ForeColor = Color.White;
            BotaoAdicionarReserva.Location = new Point(79, 758);
            BotaoAdicionarReserva.Margin = new Padding(3, 4, 3, 4);
            BotaoAdicionarReserva.Name = "BotaoAdicionarReserva";
            BotaoAdicionarReserva.Size = new Size(185, 48);
            BotaoAdicionarReserva.TabIndex = 0;
            BotaoAdicionarReserva.Text = "Adicionar Reserva";
            BotaoAdicionarReserva.UseVisualStyleBackColor = false;
            BotaoAdicionarReserva.Click += AdicionarReserva_Click;
            // 
            // BotaoAtualizarReserva
            // 
            BotaoAtualizarReserva.BackColor = Color.Gold;
            BotaoAtualizarReserva.FlatStyle = FlatStyle.Flat;
            BotaoAtualizarReserva.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoAtualizarReserva.ForeColor = Color.White;
            BotaoAtualizarReserva.Location = new Point(475, 754);
            BotaoAtualizarReserva.Margin = new Padding(3, 4, 3, 4);
            BotaoAtualizarReserva.Name = "BotaoAtualizarReserva";
            BotaoAtualizarReserva.Size = new Size(215, 52);
            BotaoAtualizarReserva.TabIndex = 1;
            BotaoAtualizarReserva.Text = "Atualizar Reserva";
            BotaoAtualizarReserva.UseVisualStyleBackColor = false;
            BotaoAtualizarReserva.Click += AtualizarReserva_Click;
            // 
            // BotaoRemoverReserva
            // 
            BotaoRemoverReserva.BackColor = Color.Crimson;
            BotaoRemoverReserva.FlatStyle = FlatStyle.Flat;
            BotaoRemoverReserva.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoRemoverReserva.ForeColor = Color.White;
            BotaoRemoverReserva.Location = new Point(950, 754);
            BotaoRemoverReserva.Margin = new Padding(3, 4, 3, 4);
            BotaoRemoverReserva.Name = "BotaoRemoverReserva";
            BotaoRemoverReserva.Size = new Size(217, 48);
            BotaoRemoverReserva.TabIndex = 2;
            BotaoRemoverReserva.Text = "Remover Reserva";
            BotaoRemoverReserva.UseVisualStyleBackColor = false;
            BotaoRemoverReserva.Click += RemoverReserva_Click;
            // 
            // DataGridViewReservas
            // 
            DataGridViewReservas.AllowUserToAddRows = false;
            DataGridViewReservas.AllowUserToDeleteRows = false;
            DataGridViewReservas.AllowUserToResizeRows = false;
            DataGridViewReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewReservas.Location = new Point(18, 359);
            DataGridViewReservas.Margin = new Padding(3, 4, 3, 4);
            DataGridViewReservas.Name = "DataGridViewReservas";
            DataGridViewReservas.ReadOnly = true;
            DataGridViewReservas.RowHeadersWidth = 51;
            DataGridViewReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewReservas.Size = new Size(1250, 353);
            DataGridViewReservas.TabIndex = 3;
            DataGridViewReservas.SelectionChanged += DataGridViewReservas_SelectionChanged;
            // 
            // ComboBoxClienteEmail
            // 
            ComboBoxClienteEmail.BackColor = Color.LightGray;
            ComboBoxClienteEmail.Font = new Font("Segoe UI", 10F);
            ComboBoxClienteEmail.FormattingEnabled = true;
            ComboBoxClienteEmail.Location = new Point(12, 109);
            ComboBoxClienteEmail.Margin = new Padding(3, 4, 3, 4);
            ComboBoxClienteEmail.Name = "ComboBoxClienteEmail";
            ComboBoxClienteEmail.Size = new Size(200, 31);
            ComboBoxClienteEmail.TabIndex = 4;
            // 
            // ComboBoxAlojamentoNome
            // 
            ComboBoxAlojamentoNome.BackColor = Color.LightGray;
            ComboBoxAlojamentoNome.Font = new Font("Segoe UI", 10F);
            ComboBoxAlojamentoNome.FormattingEnabled = true;
            ComboBoxAlojamentoNome.Location = new Point(12, 200);
            ComboBoxAlojamentoNome.Margin = new Padding(3, 4, 3, 4);
            ComboBoxAlojamentoNome.Name = "ComboBoxAlojamentoNome";
            ComboBoxAlojamentoNome.Size = new Size(200, 31);
            ComboBoxAlojamentoNome.TabIndex = 5;
            // 
            // DateTimePickerDataInicio
            // 
            DateTimePickerDataInicio.Font = new Font("Segoe UI", 10F);
            DateTimePickerDataInicio.Format = DateTimePickerFormat.Short;
            DateTimePickerDataInicio.Location = new Point(310, 110);
            DateTimePickerDataInicio.Margin = new Padding(3, 4, 3, 4);
            DateTimePickerDataInicio.Name = "DateTimePickerDataInicio";
            DateTimePickerDataInicio.Size = new Size(200, 30);
            DateTimePickerDataInicio.TabIndex = 6;
            // 
            // DateTimePickerDataFim
            // 
            DateTimePickerDataFim.Font = new Font("Segoe UI", 10F);
            DateTimePickerDataFim.Format = DateTimePickerFormat.Short;
            DateTimePickerDataFim.Location = new Point(310, 200);
            DateTimePickerDataFim.Margin = new Padding(3, 4, 3, 4);
            DateTimePickerDataFim.Name = "DateTimePickerDataFim";
            DateTimePickerDataFim.Size = new Size(200, 30);
            DateTimePickerDataFim.TabIndex = 7;
            // 
            // NumericUpDownNumeroPessoas
            // 
            NumericUpDownNumeroPessoas.Font = new Font("Segoe UI", 10F);
            NumericUpDownNumeroPessoas.Location = new Point(590, 110);
            NumericUpDownNumeroPessoas.Margin = new Padding(3, 4, 3, 4);
            NumericUpDownNumeroPessoas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDownNumeroPessoas.Name = "NumericUpDownNumeroPessoas";
            NumericUpDownNumeroPessoas.Size = new Size(200, 30);
            NumericUpDownNumeroPessoas.TabIndex = 8;
            NumericUpDownNumeroPessoas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // LabelTitulo
            // 
            LabelTitulo.AutoSize = true;
            LabelTitulo.Font = new Font("Arial", 20F, FontStyle.Bold);
            LabelTitulo.Location = new Point(12, 11);
            LabelTitulo.Name = "LabelTitulo";
            LabelTitulo.Size = new Size(343, 40);
            LabelTitulo.TabIndex = 9;
            LabelTitulo.Text = "Gestão de Reservas";
            // 
            // LabelClienteEmail
            // 
            LabelClienteEmail.AutoSize = true;
            LabelClienteEmail.Location = new Point(12, 66);
            LabelClienteEmail.Name = "LabelClienteEmail";
            LabelClienteEmail.Size = new Size(121, 20);
            LabelClienteEmail.TabIndex = 10;
            LabelClienteEmail.Text = "Email do Cliente:";
            // 
            // LabelAlojamentoNome
            // 
            LabelAlojamentoNome.AutoSize = true;
            LabelAlojamentoNome.Location = new Point(12, 175);
            LabelAlojamentoNome.Name = "LabelAlojamentoNome";
            LabelAlojamentoNome.Size = new Size(157, 20);
            LabelAlojamentoNome.TabIndex = 11;
            LabelAlojamentoNome.Text = "Nome do Alojamento:";
            // 
            // LabelDataInicio
            // 
            LabelDataInicio.AutoSize = true;
            LabelDataInicio.Location = new Point(310, 72);
            LabelDataInicio.Name = "LabelDataInicio";
            LabelDataInicio.Size = new Size(84, 20);
            LabelDataInicio.TabIndex = 12;
            LabelDataInicio.Text = "Data Início:";
            // 
            // LabelDataFim
            // 
            LabelDataFim.AutoSize = true;
            LabelDataFim.Location = new Point(310, 175);
            LabelDataFim.Name = "LabelDataFim";
            LabelDataFim.Size = new Size(72, 20);
            LabelDataFim.TabIndex = 13;
            LabelDataFim.Text = "Data Fim:";
            // 
            // LabelNumeroPessoas
            // 
            LabelNumeroPessoas.AutoSize = true;
            LabelNumeroPessoas.Location = new Point(590, 72);
            LabelNumeroPessoas.Name = "LabelNumeroPessoas";
            LabelNumeroPessoas.Size = new Size(141, 20);
            LabelNumeroPessoas.TabIndex = 14;
            LabelNumeroPessoas.Text = "Número de Pessoas:";
            // 
            // FormGestaoReservas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 1050);
            Controls.Add(LabelNumeroPessoas);
            Controls.Add(LabelDataFim);
            Controls.Add(LabelDataInicio);
            Controls.Add(LabelAlojamentoNome);
            Controls.Add(LabelClienteEmail);
            Controls.Add(LabelTitulo);
            Controls.Add(NumericUpDownNumeroPessoas);
            Controls.Add(DateTimePickerDataFim);
            Controls.Add(DateTimePickerDataInicio);
            Controls.Add(ComboBoxAlojamentoNome);
            Controls.Add(ComboBoxClienteEmail);
            Controls.Add(DataGridViewReservas);
            Controls.Add(BotaoRemoverReserva);
            Controls.Add(BotaoAtualizarReserva);
            Controls.Add(BotaoAdicionarReserva);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormGestaoReservas";
            Text = "Gestão de Reservas";
            ((System.ComponentModel.ISupportInitialize)DataGridViewReservas).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownNumeroPessoas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button BotaoAdicionarReserva;
        private Button BotaoAtualizarReserva;
        private Button BotaoRemoverReserva;
        private DataGridView DataGridViewReservas;
        private ComboBox ComboBoxClienteEmail;
        private ComboBox ComboBoxAlojamentoNome;
        private DateTimePicker DateTimePickerDataInicio;
        private DateTimePicker DateTimePickerDataFim;
        private NumericUpDown NumericUpDownNumeroPessoas;
        private Label LabelTitulo;
        private Label LabelClienteEmail;
        private Label LabelAlojamentoNome;
        private Label LabelDataInicio;
        private Label LabelDataFim;
        private Label LabelNumeroPessoas;
    }
}
