namespace VideojuegoServidor.GUI
{
    partial class FormServidor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnConexionClientes = new Button();
            lblBitacora = new Label();
            dgvClientes = new DataGridView();
            dgvBitacora = new DataGridView();
            lblDatosServ = new Label();
            btnGestionJugador = new Button();
            btnGestionCriatura = new Button();
            lblUsuariosCon = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Anchor = AnchorStyles.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.InfoText;
            lblTitulo.Location = new Point(104, 32);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(249, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Servidor Videojuego";
            // 
            // btnConexionClientes
            // 
            btnConexionClientes.BackColor = Color.ForestGreen;
            btnConexionClientes.FlatStyle = FlatStyle.Flat;
            btnConexionClientes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConexionClientes.ForeColor = SystemColors.ButtonFace;
            btnConexionClientes.Location = new Point(86, 116);
            btnConexionClientes.Name = "btnConexionClientes";
            btnConexionClientes.Size = new Size(267, 46);
            btnConexionClientes.TabIndex = 1;
            btnConexionClientes.Text = "Establecer conexión";
            btnConexionClientes.UseVisualStyleBackColor = false;
            btnConexionClientes.Click += btnConexionClientes_Click;
            // 
            // lblBitacora
            // 
            lblBitacora.Anchor = AnchorStyles.Top;
            lblBitacora.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBitacora.ForeColor = SystemColors.InfoText;
            lblBitacora.Location = new Point(12, 504);
            lblBitacora.Name = "lblBitacora";
            lblBitacora.Size = new Size(249, 32);
            lblBitacora.TabIndex = 4;
            lblBitacora.Text = "Bitácora";
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeColumns = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 320);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(408, 181);
            dgvClientes.TabIndex = 5;
            // 
            // dgvBitacora
            // 
            dgvBitacora.AllowUserToAddRows = false;
            dgvBitacora.AllowUserToDeleteRows = false;
            dgvBitacora.AllowUserToResizeColumns = false;
            dgvBitacora.AllowUserToResizeRows = false;
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBitacora.Location = new Point(12, 539);
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.Size = new Size(408, 181);
            dgvBitacora.TabIndex = 6;
            // 
            // lblDatosServ
            // 
            lblDatosServ.Anchor = AnchorStyles.Top;
            lblDatosServ.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosServ.ForeColor = SystemColors.InfoText;
            lblDatosServ.Location = new Point(86, 81);
            lblDatosServ.Name = "lblDatosServ";
            lblDatosServ.Size = new Size(291, 32);
            lblDatosServ.TabIndex = 7;
            lblDatosServ.Text = "IP: 127.0.0.1 | Puerto: 14100 | Máx clientes: 8";
            // 
            // btnGestionJugador
            // 
            btnGestionJugador.BackColor = Color.DodgerBlue;
            btnGestionJugador.BackgroundImageLayout = ImageLayout.None;
            btnGestionJugador.FlatStyle = FlatStyle.Flat;
            btnGestionJugador.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGestionJugador.ForeColor = SystemColors.ButtonFace;
            btnGestionJugador.Location = new Point(86, 168);
            btnGestionJugador.Name = "btnGestionJugador";
            btnGestionJugador.Size = new Size(267, 46);
            btnGestionJugador.TabIndex = 8;
            btnGestionJugador.Text = "Jugadores";
            btnGestionJugador.UseVisualStyleBackColor = false;
            btnGestionJugador.Click += btnGestionJugador_Click;
            // 
            // btnGestionCriatura
            // 
            btnGestionCriatura.BackColor = Color.DodgerBlue;
            btnGestionCriatura.BackgroundImageLayout = ImageLayout.None;
            btnGestionCriatura.FlatStyle = FlatStyle.Flat;
            btnGestionCriatura.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGestionCriatura.ForeColor = SystemColors.ButtonFace;
            btnGestionCriatura.Location = new Point(86, 220);
            btnGestionCriatura.Name = "btnGestionCriatura";
            btnGestionCriatura.Size = new Size(267, 46);
            btnGestionCriatura.TabIndex = 9;
            btnGestionCriatura.Text = "Criaturas";
            btnGestionCriatura.UseVisualStyleBackColor = false;
            btnGestionCriatura.Click += btnGestionCriatura_Click;
            // 
            // lblUsuariosCon
            // 
            lblUsuariosCon.Anchor = AnchorStyles.Top;
            lblUsuariosCon.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuariosCon.ForeColor = SystemColors.InfoText;
            lblUsuariosCon.Location = new Point(12, 285);
            lblUsuariosCon.Name = "lblUsuariosCon";
            lblUsuariosCon.Size = new Size(408, 32);
            lblUsuariosCon.TabIndex = 10;
            lblUsuariosCon.Text = "Usuarios conectados: 0/8";
            // 
            // FormServidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(432, 740);
            Controls.Add(lblUsuariosCon);
            Controls.Add(btnGestionCriatura);
            Controls.Add(btnGestionJugador);
            Controls.Add(lblDatosServ);
            Controls.Add(dgvBitacora);
            Controls.Add(dgvClientes);
            Controls.Add(lblBitacora);
            Controls.Add(btnConexionClientes);
            Controls.Add(lblTitulo);
            Name = "FormServidor";
            Text = "Servidor";
            Load += FormServidor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Button btnConexionClientes;
        private Label lblBitacora;
        private DataGridView dgvClientes;
        private DataGridView dgvBitacora;
        private Label lblDatosServ;
        private Button btnGestionJugador;
        private Button btnGestionCriatura;
        private Label lblUsuariosCon;
    }
}