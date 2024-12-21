using System.ComponentModel;

namespace GestaoAlojamentosApp.App.Forms
{
    partial class FormMenuAdministrador
    {
        #region Código gerado pelo Designer

        /// <summary>
        /// Método necessário para a inicialização do designer.
        /// Não modifique o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlMenu = new System.Windows.Forms.Panel();
            Sair = new System.Windows.Forms.Button();
            GestaoPagamentos = new System.Windows.Forms.Button();
            GestaoCheckin = new System.Windows.Forms.Button();
            GestaoReservas = new System.Windows.Forms.Button();
            GestaoClientes = new System.Windows.Forms.Button();
            GestaoAlojamentos = new System.Windows.Forms.Button();
            pnlContent = new System.Windows.Forms.Panel();

            pnlMenu.SuspendLayout();
            SuspendLayout();

            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            pnlMenu.Controls.Add(Sair);
            pnlMenu.Controls.Add(GestaoPagamentos);
            pnlMenu.Controls.Add(GestaoCheckin);
            pnlMenu.Controls.Add(GestaoReservas);
            pnlMenu.Controls.Add(GestaoClientes);
            pnlMenu.Controls.Add(GestaoAlojamentos);
            pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            pnlMenu.Location = new System.Drawing.Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new System.Drawing.Size(250, 600);
            pnlMenu.TabIndex = 0;

            // 
            // GestaoAlojamentos
            // 
            GestaoAlojamentos.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            GestaoAlojamentos.FlatAppearance.BorderSize = 0;
            GestaoAlojamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            GestaoAlojamentos.ForeColor = System.Drawing.Color.White;
            GestaoAlojamentos.Location = new System.Drawing.Point(20, 100);
            GestaoAlojamentos.Name = "GestaoAlojamentos";
            GestaoAlojamentos.Size = new System.Drawing.Size(220, 50);
            GestaoAlojamentos.TabIndex = 0;
            GestaoAlojamentos.Text = "Gestão de Alojamentos";
            GestaoAlojamentos.UseVisualStyleBackColor = false;
            GestaoAlojamentos.Click += new System.EventHandler(GestaoAlojamentos_Click);

            // 
            // GestaoClientes
            // 
            GestaoClientes.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            GestaoClientes.FlatAppearance.BorderSize = 0;
            GestaoClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            GestaoClientes.ForeColor = System.Drawing.Color.White;
            GestaoClientes.Location = new System.Drawing.Point(20, 160);
            GestaoClientes.Name = "GestaoClientes";
            GestaoClientes.Size = new System.Drawing.Size(220, 50);
            GestaoClientes.TabIndex = 1;
            GestaoClientes.Text = "Gestão de Clientes";
            GestaoClientes.UseVisualStyleBackColor = false;
            GestaoClientes.Click += new System.EventHandler(GestaoClientes_Click);

            // 
            // GestaoReservas
            // 
            GestaoReservas.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            GestaoReservas.FlatAppearance.BorderSize = 0;
            GestaoReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            GestaoReservas.ForeColor = System.Drawing.Color.White;
            GestaoReservas.Location = new System.Drawing.Point(20, 220);
            GestaoReservas.Name = "GestaoReservas";
            GestaoReservas.Size = new System.Drawing.Size(220, 50);
            GestaoReservas.TabIndex = 2;
            GestaoReservas.Text = "Gestão de Reservas";
            GestaoReservas.UseVisualStyleBackColor = false;
            GestaoReservas.Click += new System.EventHandler(GestaoReservas_Click);

            // 
            // GestaoCheckin
            // 
            GestaoCheckin.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            GestaoCheckin.FlatAppearance.BorderSize = 0;
            GestaoCheckin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            GestaoCheckin.ForeColor = System.Drawing.Color.White;
            GestaoCheckin.Location = new System.Drawing.Point(20, 280);
            GestaoCheckin.Name = "GestaoCheckin";
            GestaoCheckin.Size = new System.Drawing.Size(220, 50);
            GestaoCheckin.TabIndex = 3;
            GestaoCheckin.Text = "Gestão de Check-in";
            GestaoCheckin.UseVisualStyleBackColor = false;
            GestaoCheckin.Click += new System.EventHandler(GestaoCheckin_Click);

            // 
            // GestaoPagamentos
            // 
            GestaoPagamentos.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            GestaoPagamentos.FlatAppearance.BorderSize = 0;
            GestaoPagamentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            GestaoPagamentos.ForeColor = System.Drawing.Color.White;
            GestaoPagamentos.Location = new System.Drawing.Point(20, 340);
            GestaoPagamentos.Name = "GestaoPagamentos";
            GestaoPagamentos.Size = new System.Drawing.Size(220, 50);
            GestaoPagamentos.TabIndex = 4;
            GestaoPagamentos.Text = "Gestão de Pagamentos";
            GestaoPagamentos.UseVisualStyleBackColor = false;
            GestaoPagamentos.Click += new System.EventHandler(GestaoPagamentos_Click);

            // 
            // Sair
            // 
            Sair.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            Sair.FlatAppearance.BorderSize = 0;
            Sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Sair.ForeColor = System.Drawing.Color.White;
            Sair.Location = new System.Drawing.Point(20, 400);
            Sair.Name = "Sair";
            Sair.Size = new System.Drawing.Size(220, 50);
            Sair.TabIndex = 5;
            Sair.Text = "Sair";
            Sair.UseVisualStyleBackColor = false;
            Sair.Click += new System.EventHandler(Sair_Click);

            // 
            // pnlContent
            // 
            pnlContent.BackColor = System.Drawing.Color.White;
            pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContent.Location = new System.Drawing.Point(250, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new System.Drawing.Size(800, 600);
            pnlContent.TabIndex = 1;

            // 
            // FormMenuAdministrador
            // 
            ClientSize = new System.Drawing.Size(1050, 600);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormMenuAdministrador";
            Text = "Menu do Administrador";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;

            pnlMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        #region Campos privados

        private IContainer components = null;
        private Button GestaoAlojamentos;
        private Button GestaoClientes;
        private Button GestaoReservas;
        private Button GestaoCheckin;
        private Button GestaoPagamentos;
        private Button Sair;
        private Panel pnlContent;
        private Panel pnlMenu;


        #endregion
    }
}
