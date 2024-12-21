namespace GestaoAlojamentosApp.App.Forms
{
    partial class FormGestaoCheckIns
    {
        private void InitializeComponent()
        {
            DataGridViewReservasConfirmadas = new DataGridView();
            DataGridViewCheckIns = new DataGridView();
            ComboBoxStatus = new ComboBox();
            ComboBoxReservaId = new ComboBox();
            DateTimePickerDataHoraCheckIn = new DateTimePicker();
            NumericUpDownNumeroClientes = new NumericUpDown();
            BotaoAdicionarCheckIn = new Button();
            BotaoAtualizarStatusCheckIn = new Button();
            BotaoRemoverCheckIn = new Button();
            LabelStatusCheckIn = new Label();
            LabelReservaId = new Label();
            LabelDataHoraCheckIn = new Label();
            LabelNumeroClientes = new Label();
            LabelReservas = new Label();
            LabelCheckIns = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridViewReservasConfirmadas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridViewCheckIns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownNumeroClientes).BeginInit();
            SuspendLayout();
            // 
            // DataGridViewReservasConfirmadas
            // 
            DataGridViewReservasConfirmadas.AllowUserToAddRows = false;
            DataGridViewReservasConfirmadas.AllowUserToDeleteRows = false;
            DataGridViewReservasConfirmadas.AllowUserToResizeRows = false;
            DataGridViewReservasConfirmadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewReservasConfirmadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewReservasConfirmadas.Location = new Point(30, 554);
            DataGridViewReservasConfirmadas.Margin = new Padding(3, 4, 3, 4);
            DataGridViewReservasConfirmadas.Name = "DataGridViewReservasConfirmadas";
            DataGridViewReservasConfirmadas.ReadOnly = true;
            DataGridViewReservasConfirmadas.RowHeadersWidth = 51;
            DataGridViewReservasConfirmadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewReservasConfirmadas.Size = new Size(1146, 431);
            DataGridViewReservasConfirmadas.TabIndex = 1;
            // 
            // DataGridViewCheckIns
            // 
            DataGridViewCheckIns.AllowUserToAddRows = false;
            DataGridViewCheckIns.AllowUserToDeleteRows = false;
            DataGridViewCheckIns.AllowUserToResizeRows = false;
            DataGridViewCheckIns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewCheckIns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewCheckIns.Location = new Point(29, 260);
            DataGridViewCheckIns.Margin = new Padding(3, 4, 3, 4);
            DataGridViewCheckIns.Name = "DataGridViewCheckIns";
            DataGridViewCheckIns.ReadOnly = true;
            DataGridViewCheckIns.RowHeadersWidth = 51;
            DataGridViewCheckIns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewCheckIns.Size = new Size(619, 219);
            DataGridViewCheckIns.TabIndex = 3;
            // 
            // ComboBoxStatus
            // 
            ComboBoxStatus.BackColor = Color.LightGray;
            ComboBoxStatus.Font = new Font("Segoe UI", 10F);
            ComboBoxStatus.FormattingEnabled = true;
            ComboBoxStatus.Location = new Point(598, 85);
            ComboBoxStatus.Margin = new Padding(3, 4, 3, 4);
            ComboBoxStatus.Name = "ComboBoxStatus";
            ComboBoxStatus.Size = new Size(200, 31);
            ComboBoxStatus.TabIndex = 4;
            // 
            // ComboBoxReservaId
            // 
            ComboBoxReservaId.BackColor = Color.LightGray;
            ComboBoxReservaId.Font = new Font("Segoe UI", 10F);
            ComboBoxReservaId.FormattingEnabled = true;
            ComboBoxReservaId.Location = new Point(30, 85);
            ComboBoxReservaId.Margin = new Padding(3, 4, 3, 4);
            ComboBoxReservaId.Name = "ComboBoxReservaId";
            ComboBoxReservaId.Size = new Size(200, 31);
            ComboBoxReservaId.TabIndex = 5;
            // 
            // DateTimePickerDataHoraCheckIn
            // 
            DateTimePickerDataHoraCheckIn.Font = new Font("Segoe UI", 10F);
            DateTimePickerDataHoraCheckIn.Format = DateTimePickerFormat.Short;
            DateTimePickerDataHoraCheckIn.Location = new Point(307, 86);
            DateTimePickerDataHoraCheckIn.Margin = new Padding(3, 4, 3, 4);
            DateTimePickerDataHoraCheckIn.Name = "DateTimePickerDataHoraCheckIn";
            DateTimePickerDataHoraCheckIn.Size = new Size(200, 30);
            DateTimePickerDataHoraCheckIn.TabIndex = 6;
            // 
            // NumericUpDownNumeroClientes
            // 
            NumericUpDownNumeroClientes.Font = new Font("Segoe UI", 10F);
            NumericUpDownNumeroClientes.Location = new Point(865, 85);
            NumericUpDownNumeroClientes.Margin = new Padding(3, 4, 3, 4);
            NumericUpDownNumeroClientes.Name = "NumericUpDownNumeroClientes";
            NumericUpDownNumeroClientes.Size = new Size(157, 30);
            NumericUpDownNumeroClientes.TabIndex = 7;
            // 
            // BotaoAdicionarCheckIn
            // 
            BotaoAdicionarCheckIn.BackColor = Color.SeaGreen;
            BotaoAdicionarCheckIn.FlatStyle = FlatStyle.Flat;
            BotaoAdicionarCheckIn.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoAdicionarCheckIn.ForeColor = Color.White;
            BotaoAdicionarCheckIn.Location = new Point(773, 260);
            BotaoAdicionarCheckIn.Margin = new Padding(3, 4, 3, 4);
            BotaoAdicionarCheckIn.Name = "BotaoAdicionarCheckIn";
            BotaoAdicionarCheckIn.Size = new Size(272, 43);
            BotaoAdicionarCheckIn.TabIndex = 8;
            BotaoAdicionarCheckIn.Text = "Adicionar Check-in";
            BotaoAdicionarCheckIn.UseVisualStyleBackColor = false;
            // 
            // BotaoAtualizarStatusCheckIn
            // 
            BotaoAtualizarStatusCheckIn.BackColor = Color.Gold;
            BotaoAtualizarStatusCheckIn.FlatStyle = FlatStyle.Flat;
            BotaoAtualizarStatusCheckIn.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoAtualizarStatusCheckIn.ForeColor = Color.White;
            BotaoAtualizarStatusCheckIn.Location = new Point(773, 351);
            BotaoAtualizarStatusCheckIn.Margin = new Padding(3, 4, 3, 4);
            BotaoAtualizarStatusCheckIn.Name = "BotaoAtualizarStatusCheckIn";
            BotaoAtualizarStatusCheckIn.Size = new Size(272, 45);
            BotaoAtualizarStatusCheckIn.TabIndex = 9;
            BotaoAtualizarStatusCheckIn.Text = "Atualizar Status";
            BotaoAtualizarStatusCheckIn.UseVisualStyleBackColor = false;
            // 
            // BotaoRemoverCheckIn
            // 
            BotaoRemoverCheckIn.BackColor = Color.Crimson;
            BotaoRemoverCheckIn.FlatStyle = FlatStyle.Flat;
            BotaoRemoverCheckIn.Font = new Font("Arial", 14F, FontStyle.Bold);
            BotaoRemoverCheckIn.ForeColor = Color.White;
            BotaoRemoverCheckIn.Location = new Point(773, 436);
            BotaoRemoverCheckIn.Margin = new Padding(3, 4, 3, 4);
            BotaoRemoverCheckIn.Name = "BotaoRemoverCheckIn";
            BotaoRemoverCheckIn.Size = new Size(272, 43);
            BotaoRemoverCheckIn.TabIndex = 10;
            BotaoRemoverCheckIn.Text = "Remover Check-in";
            BotaoRemoverCheckIn.UseVisualStyleBackColor = false;
            // 
            // LabelStatusCheckIn
            // 
            LabelStatusCheckIn.AutoSize = true;
            LabelStatusCheckIn.Font = new Font("Arial", 10F);
            LabelStatusCheckIn.Location = new Point(598, 35);
            LabelStatusCheckIn.Name = "LabelStatusCheckIn";
            LabelStatusCheckIn.Size = new Size(130, 19);
            LabelStatusCheckIn.TabIndex = 11;
            LabelStatusCheckIn.Text = "Status Check-in:";
            // 
            // LabelReservaId
            // 
            LabelReservaId.AutoSize = true;
            LabelReservaId.Font = new Font("Arial", 10F);
            LabelReservaId.Location = new Point(30, 35);
            LabelReservaId.Name = "LabelReservaId";
            LabelReservaId.Size = new Size(73, 19);
            LabelReservaId.TabIndex = 12;
            LabelReservaId.Text = "Reserva:";
            // 
            // LabelDataHoraCheckIn
            // 
            LabelDataHoraCheckIn.AutoSize = true;
            LabelDataHoraCheckIn.Font = new Font("Arial", 10F);
            LabelDataHoraCheckIn.Location = new Point(307, 35);
            LabelDataHoraCheckIn.Name = "LabelDataHoraCheckIn";
            LabelDataHoraCheckIn.Size = new Size(173, 19);
            LabelDataHoraCheckIn.TabIndex = 13;
            LabelDataHoraCheckIn.Text = "Data e Hora Check-in:";
            // 
            // LabelNumeroClientes
            // 
            LabelNumeroClientes.AutoSize = true;
            LabelNumeroClientes.Font = new Font("Arial", 10F);
            LabelNumeroClientes.Location = new Point(865, 35);
            LabelNumeroClientes.Name = "LabelNumeroClientes";
            LabelNumeroClientes.Size = new Size(157, 19);
            LabelNumeroClientes.TabIndex = 14;
            LabelNumeroClientes.Text = "Número de Clientes:";
            // 
            // LabelReservas
            // 
            LabelReservas.AutoSize = true;
            LabelReservas.Font = new Font("Arial", 16F, FontStyle.Bold);
            LabelReservas.Location = new Point(29, 495);
            LabelReservas.Name = "LabelReservas";
            LabelReservas.Size = new Size(135, 32);
            LabelReservas.TabIndex = 15;
            LabelReservas.Text = "Reservas";
            // 
            // LabelCheckIns
            // 
            LabelCheckIns.AutoSize = true;
            LabelCheckIns.Font = new Font("Arial", 16F, FontStyle.Bold);
            LabelCheckIns.Location = new Point(29, 166);
            LabelCheckIns.Name = "LabelCheckIns";
            LabelCheckIns.Size = new Size(145, 32);
            LabelCheckIns.TabIndex = 16;
            LabelCheckIns.Text = "Check-ins";
            // 
            // FormGestaoCheckIns
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 1000);
            Controls.Add(LabelCheckIns);
            Controls.Add(LabelReservas);
            Controls.Add(LabelNumeroClientes);
            Controls.Add(LabelDataHoraCheckIn);
            Controls.Add(LabelReservaId);
            Controls.Add(LabelStatusCheckIn);
            Controls.Add(BotaoRemoverCheckIn);
            Controls.Add(BotaoAtualizarStatusCheckIn);
            Controls.Add(BotaoAdicionarCheckIn);
            Controls.Add(NumericUpDownNumeroClientes);
            Controls.Add(DateTimePickerDataHoraCheckIn);
            Controls.Add(ComboBoxReservaId);
            Controls.Add(ComboBoxStatus);
            Controls.Add(DataGridViewCheckIns);
            Controls.Add(DataGridViewReservasConfirmadas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormGestaoCheckIns";
            Text = "Gestão de Check-ins";
            ((System.ComponentModel.ISupportInitialize)DataGridViewReservasConfirmadas).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridViewCheckIns).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownNumeroClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView DataGridViewReservasConfirmadas;
        private DataGridView DataGridViewCheckIns;
        private ComboBox ComboBoxStatus;
        private ComboBox ComboBoxReservaId;
        private DateTimePicker DateTimePickerDataHoraCheckIn;
        private NumericUpDown NumericUpDownNumeroClientes;
        private Button BotaoAdicionarCheckIn;
        private Button BotaoAtualizarStatusCheckIn;
        private Button BotaoRemoverCheckIn;
        private Label LabelStatusCheckIn;
        private Label LabelReservaId;
        private Label LabelDataHoraCheckIn;
        private Label LabelNumeroClientes;
        private Label LabelReservas;
        private Label LabelCheckIns;
    }
}
