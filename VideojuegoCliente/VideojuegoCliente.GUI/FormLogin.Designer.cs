namespace VideojuegoCliente.GUI
{
    partial class FormLogin
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
            cbPuerto = new ComboBox();
            txtPassword = new TextBox();
            lblPuerto = new Label();
            lbl_password = new Label();
            txtUsuario = new TextBox();
            lbl_Usuario = new Label();
            label1 = new Label();
            cbIP = new ComboBox();
            btnEnviar = new Button();
            SuspendLayout();
            // 
            // cbPuerto
            // 
            cbPuerto.BackColor = Color.RosyBrown;
            cbPuerto.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPuerto.ForeColor = Color.White;
            cbPuerto.FormattingEnabled = true;
            cbPuerto.Items.AddRange(new object[] { "14100" });
            cbPuerto.Location = new Point(229, 196);
            cbPuerto.Name = "cbPuerto";
            cbPuerto.Size = new Size(159, 23);
            cbPuerto.TabIndex = 47;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(229, 88);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(159, 23);
            txtPassword.TabIndex = 46;
            // 
            // lblPuerto
            // 
            lblPuerto.AutoSize = true;
            lblPuerto.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPuerto.ForeColor = Color.Sienna;
            lblPuerto.Location = new Point(32, 196);
            lblPuerto.Name = "lblPuerto";
            lblPuerto.Size = new Size(79, 25);
            lblPuerto.TabIndex = 45;
            lblPuerto.Text = "Puerto:";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_password.ForeColor = Color.Sienna;
            lbl_password.Location = new Point(32, 88);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(118, 25);
            lbl_password.TabIndex = 44;
            lbl_password.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(229, 33);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(159, 23);
            txtUsuario.TabIndex = 43;
            // 
            // lbl_Usuario
            // 
            lbl_Usuario.AutoSize = true;
            lbl_Usuario.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Usuario.ForeColor = Color.Sienna;
            lbl_Usuario.Location = new Point(32, 33);
            lbl_Usuario.Name = "lbl_Usuario";
            lbl_Usuario.Size = new Size(86, 25);
            lbl_Usuario.TabIndex = 42;
            lbl_Usuario.Text = "Usuario:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Sienna;
            label1.Location = new Point(32, 144);
            label1.Name = "label1";
            label1.Size = new Size(124, 25);
            label1.TabIndex = 48;
            label1.Text = "Dirección IP:";
            // 
            // cbIP
            // 
            cbIP.BackColor = Color.RosyBrown;
            cbIP.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIP.ForeColor = Color.White;
            cbIP.FormattingEnabled = true;
            cbIP.Items.AddRange(new object[] { "127.0.0.1" });
            cbIP.Location = new Point(229, 144);
            cbIP.Name = "cbIP";
            cbIP.Size = new Size(159, 23);
            cbIP.TabIndex = 49;
            // 
            // btnEnviar
            // 
            btnEnviar.BackColor = Color.Teal;
            btnEnviar.FlatStyle = FlatStyle.Popup;
            btnEnviar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnviar.ForeColor = SystemColors.Control;
            btnEnviar.Location = new Point(229, 252);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(159, 39);
            btnEnviar.TabIndex = 50;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(400, 314);
            Controls.Add(btnEnviar);
            Controls.Add(cbIP);
            Controls.Add(label1);
            Controls.Add(cbPuerto);
            Controls.Add(txtPassword);
            Controls.Add(lblPuerto);
            Controls.Add(lbl_password);
            Controls.Add(txtUsuario);
            Controls.Add(lbl_Usuario);
            Name = "FormLogin";
            Text = "Inicio de sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbPuerto;
        private TextBox txtPassword;
        private Label lblPuerto;
        private Label lbl_password;
        private TextBox txtUsuario;
        private Label lbl_Usuario;
        private Label label1;
        private ComboBox cbIP;
        private Button btnEnviar;
    }
}