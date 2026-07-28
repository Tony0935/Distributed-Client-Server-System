namespace Videojuego.GUI
{
    partial class FormRegJugador
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
            btnVolver = new Button();
            btnGuardar = new Button();
            lblNivel = new Label();
            lblFechaN = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            lblCristales = new Label();
            lblVictorias = new Label();
            lblNivelShow = new Label();
            lblCostoShow = new Label();
            lblVictShow = new Label();
            cbDia = new ComboBox();
            cbMes = new ComboBox();
            cbAnio = new ComboBox();
            txtUsuario = new TextBox();
            label1 = new Label();
            txtPwrd = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(24, 569);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(185, 64);
            btnVolver.TabIndex = 30;
            btnVolver.Text = "Cancelar";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Teal;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.HighlightText;
            btnGuardar.Location = new Point(271, 569);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(182, 64);
            btnGuardar.TabIndex = 29;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNivel.ForeColor = Color.Sienna;
            lblNivel.Location = new Point(24, 329);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(73, 32);
            lblNivel.TabIndex = 22;
            lblNivel.Text = "Nivel";
            // 
            // lblFechaN
            // 
            lblFechaN.AutoSize = true;
            lblFechaN.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaN.ForeColor = Color.Sienna;
            lblFechaN.Location = new Point(23, 237);
            lblFechaN.Name = "lblFechaN";
            lblFechaN.Size = new Size(142, 64);
            lblFechaN.TabIndex = 21;
            lblFechaN.Text = "Fecha de \r\nnacimiento";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(215, 51);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(237, 27);
            txtNombre.TabIndex = 20;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.Sienna;
            lblNombre.Location = new Point(23, 48);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 32);
            lblNombre.TabIndex = 19;
            lblNombre.Text = "Nombre";
            // 
            // lblCristales
            // 
            lblCristales.AutoSize = true;
            lblCristales.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCristales.ForeColor = Color.Sienna;
            lblCristales.Location = new Point(23, 393);
            lblCristales.Name = "lblCristales";
            lblCristales.Size = new Size(110, 32);
            lblCristales.TabIndex = 31;
            lblCristales.Text = "Cristales";
            // 
            // lblVictorias
            // 
            lblVictorias.AutoSize = true;
            lblVictorias.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVictorias.ForeColor = Color.Sienna;
            lblVictorias.Location = new Point(24, 460);
            lblVictorias.Name = "lblVictorias";
            lblVictorias.Size = new Size(114, 32);
            lblVictorias.TabIndex = 32;
            lblVictorias.Text = "Victorias";
            // 
            // lblNivelShow
            // 
            lblNivelShow.AutoSize = true;
            lblNivelShow.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNivelShow.ForeColor = Color.GreenYellow;
            lblNivelShow.Location = new Point(295, 324);
            lblNivelShow.Name = "lblNivelShow";
            lblNivelShow.Size = new Size(113, 37);
            lblNivelShow.TabIndex = 34;
            lblNivelShow.Text = "Novato";
            // 
            // lblCostoShow
            // 
            lblCostoShow.AutoSize = true;
            lblCostoShow.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCostoShow.ForeColor = Color.DarkViolet;
            lblCostoShow.Location = new Point(313, 387);
            lblCostoShow.Name = "lblCostoShow";
            lblCostoShow.Size = new Size(65, 37);
            lblCostoShow.TabIndex = 35;
            lblCostoShow.Text = "100";
            // 
            // lblVictShow
            // 
            lblVictShow.AutoSize = true;
            lblVictShow.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVictShow.ForeColor = Color.DarkKhaki;
            lblVictShow.Location = new Point(325, 453);
            lblVictShow.Name = "lblVictShow";
            lblVictShow.Size = new Size(33, 37);
            lblVictShow.TabIndex = 36;
            lblVictShow.Text = "0";
            // 
            // cbDia
            // 
            cbDia.BackColor = Color.RosyBrown;
            cbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDia.Font = new Font("Segoe UI", 9.75F);
            cbDia.ForeColor = Color.White;
            cbDia.FormattingEnabled = true;
            cbDia.Location = new Point(326, 244);
            cbDia.Margin = new Padding(3, 4, 3, 4);
            cbDia.Name = "cbDia";
            cbDia.Size = new Size(53, 29);
            cbDia.TabIndex = 37;
            // 
            // cbMes
            // 
            cbMes.BackColor = Color.RosyBrown;
            cbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMes.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbMes.ForeColor = Color.White;
            cbMes.FormattingEnabled = true;
            cbMes.Location = new Point(215, 244);
            cbMes.Margin = new Padding(3, 4, 3, 4);
            cbMes.Name = "cbMes";
            cbMes.Size = new Size(103, 29);
            cbMes.TabIndex = 38;
            cbMes.SelectedIndexChanged += cbMes_SelectedIndexChanged_1;
            // 
            // cbAnio
            // 
            cbAnio.BackColor = Color.RosyBrown;
            cbAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAnio.Font = new Font("Segoe UI", 9.75F);
            cbAnio.ForeColor = Color.White;
            cbAnio.FormattingEnabled = true;
            cbAnio.Location = new Point(386, 244);
            cbAnio.Margin = new Padding(3, 4, 3, 4);
            cbAnio.Name = "cbAnio";
            cbAnio.Size = new Size(66, 29);
            cbAnio.TabIndex = 39;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(215, 112);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(237, 27);
            txtUsuario.TabIndex = 41;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Sienna;
            label1.Location = new Point(23, 109);
            label1.Name = "label1";
            label1.Size = new Size(102, 32);
            label1.TabIndex = 40;
            label1.Text = "Usuario";
            // 
            // txtPwrd
            // 
            txtPwrd.Location = new Point(215, 176);
            txtPwrd.Margin = new Padding(3, 4, 3, 4);
            txtPwrd.Name = "txtPwrd";
            txtPwrd.Size = new Size(237, 27);
            txtPwrd.TabIndex = 43;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Sienna;
            label2.Location = new Point(23, 173);
            label2.Name = "label2";
            label2.Size = new Size(143, 32);
            label2.TabIndex = 42;
            label2.Text = "Contraseña";
            // 
            // FormRegJugador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(465, 659);
            Controls.Add(txtPwrd);
            Controls.Add(label2);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            Controls.Add(cbAnio);
            Controls.Add(cbMes);
            Controls.Add(cbDia);
            Controls.Add(lblVictShow);
            Controls.Add(lblCostoShow);
            Controls.Add(lblNivelShow);
            Controls.Add(lblVictorias);
            Controls.Add(lblCristales);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardar);
            Controls.Add(lblNivel);
            Controls.Add(lblFechaN);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormRegJugador";
            Text = "Registrar Jugador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private Button btnGuardar;
        private Label lblNivel;
        private Label lblFechaN;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblCristales;
        private Label lblVictorias;
        private Label lblNivelShow;
        private Label lblCostoShow;
        private Label lblVictShow;
        private ComboBox cbDia;
        private ComboBox cbMes;
        private ComboBox cbAnio;
        private TextBox txtUsuario;
        private Label label1;
        private TextBox txtPwrd;
        private Label label2;
    }
}