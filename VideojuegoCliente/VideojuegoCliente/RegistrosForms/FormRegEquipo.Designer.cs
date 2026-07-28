namespace Videojuego.GUI
{
    partial class FormRegEquipo
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
            txtIDCriatura1 = new TextBox();
            btnVolver = new Button();
            btnGuardar = new Button();
            txtIDCriatura2 = new TextBox();
            lbl_IDCriatura2 = new Label();
            lbl_IDCriatura1 = new Label();
            txtIDJ1 = new TextBox();
            lbl_IDjugador = new Label();
            txtIDCriatura3 = new TextBox();
            lbl_IDCriatura3 = new Label();
            txtEquipo = new TextBox();
            lbl_IdEquipo = new Label();
            SuspendLayout();
            // 
            // txtIDCriatura1
            // 
            txtIDCriatura1.Location = new Point(187, 137);
            txtIDCriatura1.Name = "txtIDCriatura1";
            txtIDCriatura1.Size = new Size(159, 23);
            txtIDCriatura1.TabIndex = 53;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(19, 321);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(162, 48);
            btnVolver.TabIndex = 52;
            btnVolver.Text = "Cancelar";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Highlight;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.HighlightText;
            btnGuardar.Location = new Point(187, 321);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(159, 48);
            btnGuardar.TabIndex = 51;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtIDCriatura2
            // 
            txtIDCriatura2.Location = new Point(187, 187);
            txtIDCriatura2.Name = "txtIDCriatura2";
            txtIDCriatura2.Size = new Size(159, 23);
            txtIDCriatura2.TabIndex = 50;
            // 
            // lbl_IDCriatura2
            // 
            lbl_IDCriatura2.AutoSize = true;
            lbl_IDCriatura2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IDCriatura2.ForeColor = Color.Sienna;
            lbl_IDCriatura2.Location = new Point(19, 185);
            lbl_IDCriatura2.Name = "lbl_IDCriatura2";
            lbl_IDCriatura2.Size = new Size(125, 25);
            lbl_IDCriatura2.TabIndex = 49;
            lbl_IDCriatura2.Text = "ID Criatura 2";
            // 
            // lbl_IDCriatura1
            // 
            lbl_IDCriatura1.AutoSize = true;
            lbl_IDCriatura1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IDCriatura1.ForeColor = Color.Sienna;
            lbl_IDCriatura1.Location = new Point(19, 132);
            lbl_IDCriatura1.Name = "lbl_IDCriatura1";
            lbl_IDCriatura1.Size = new Size(125, 25);
            lbl_IDCriatura1.TabIndex = 48;
            lbl_IDCriatura1.Text = "ID Criatura 1";
            // 
            // txtIDJ1
            // 
            txtIDJ1.Location = new Point(187, 82);
            txtIDJ1.Name = "txtIDJ1";
            txtIDJ1.Size = new Size(159, 23);
            txtIDJ1.TabIndex = 47;
            // 
            // lbl_IDjugador
            // 
            lbl_IDjugador.AutoSize = true;
            lbl_IDjugador.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IDjugador.ForeColor = Color.Sienna;
            lbl_IDjugador.Location = new Point(19, 82);
            lbl_IDjugador.Name = "lbl_IDjugador";
            lbl_IDjugador.Size = new Size(111, 25);
            lbl_IDjugador.TabIndex = 46;
            lbl_IDjugador.Text = "ID Jugador";
            // 
            // txtIDCriatura3
            // 
            txtIDCriatura3.Location = new Point(187, 235);
            txtIDCriatura3.Name = "txtIDCriatura3";
            txtIDCriatura3.Size = new Size(159, 23);
            txtIDCriatura3.TabIndex = 55;
            // 
            // lbl_IDCriatura3
            // 
            lbl_IDCriatura3.AutoSize = true;
            lbl_IDCriatura3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IDCriatura3.ForeColor = Color.Sienna;
            lbl_IDCriatura3.Location = new Point(19, 233);
            lbl_IDCriatura3.Name = "lbl_IDCriatura3";
            lbl_IDCriatura3.Size = new Size(125, 25);
            lbl_IDCriatura3.TabIndex = 54;
            lbl_IDCriatura3.Text = "ID Criatura 3";
            // 
            // txtEquipo
            // 
            txtEquipo.Location = new Point(187, 36);
            txtEquipo.Name = "txtEquipo";
            txtEquipo.Size = new Size(159, 23);
            txtEquipo.TabIndex = 57;
            // 
            // lbl_IdEquipo
            // 
            lbl_IdEquipo.AutoSize = true;
            lbl_IdEquipo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IdEquipo.ForeColor = Color.Sienna;
            lbl_IdEquipo.Location = new Point(19, 36);
            lbl_IdEquipo.Name = "lbl_IdEquipo";
            lbl_IdEquipo.Size = new Size(100, 25);
            lbl_IdEquipo.TabIndex = 56;
            lbl_IdEquipo.Text = "ID Equipo";
            // 
            // FormRegEquipo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(365, 394);
            Controls.Add(txtEquipo);
            Controls.Add(lbl_IdEquipo);
            Controls.Add(txtIDCriatura3);
            Controls.Add(lbl_IDCriatura3);
            Controls.Add(txtIDCriatura1);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardar);
            Controls.Add(txtIDCriatura2);
            Controls.Add(lbl_IDCriatura2);
            Controls.Add(lbl_IDCriatura1);
            Controls.Add(txtIDJ1);
            Controls.Add(lbl_IDjugador);
            Name = "FormRegEquipo";
            Text = "Registrar Equipo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIDCriatura1;
        private Button btnVolver;
        private Button btnGuardar;
        private TextBox txtIDCriatura2;
        private Label lbl_IDCriatura2;
        private Label lbl_IDCriatura1;
        private TextBox txtIDJ1;
        private Label lbl_IDjugador;
        private TextBox txtIDCriatura3;
        private Label lbl_IDCriatura3;
        private TextBox txtEquipo;
        private Label lbl_IdEquipo;
    }
}