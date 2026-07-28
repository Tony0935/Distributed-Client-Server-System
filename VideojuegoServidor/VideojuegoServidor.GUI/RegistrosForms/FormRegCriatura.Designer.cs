namespace Videojuego.GUI
{
    partial class FormRegCriatura
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
            lblIdcriatura = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            lblTipo = new Label();
            lblNivel = new Label();
            lblPoder = new Label();
            lblResistencia = new Label();
            lblCosto = new Label();
            cmbTipo = new ComboBox();
            cmbNivel = new ComboBox();
            btnGuardar = new Button();
            btnVolver = new Button();
            txtPoder = new TextBox();
            txtResistencia = new TextBox();
            txtCosto = new TextBox();
            SuspendLayout();
            // 
            // lblIdcriatura
            // 
            lblIdcriatura.AutoSize = true;
            lblIdcriatura.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIdcriatura.ForeColor = Color.Sienna;
            lblIdcriatura.Location = new Point(23, 40);
            lblIdcriatura.Name = "lblIdcriatura";
            lblIdcriatura.Size = new Size(0, 25);
            lblIdcriatura.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.Sienna;
            lblNombre.Location = new Point(17, 21);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(86, 25);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(185, 21);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(159, 23);
            txtNombre.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(40, 318);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 4;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipo.ForeColor = Color.Sienna;
            lblTipo.Location = new Point(17, 71);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(52, 25);
            lblTipo.TabIndex = 5;
            lblTipo.Text = "Tipo";
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNivel.ForeColor = Color.Sienna;
            lblNivel.Location = new Point(17, 121);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(57, 25);
            lblNivel.TabIndex = 6;
            lblNivel.Text = "Nivel";
            // 
            // lblPoder
            // 
            lblPoder.AutoSize = true;
            lblPoder.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPoder.ForeColor = Color.Sienna;
            lblPoder.Location = new Point(17, 173);
            lblPoder.Name = "lblPoder";
            lblPoder.Size = new Size(65, 25);
            lblPoder.TabIndex = 7;
            lblPoder.Text = "Poder";
            // 
            // lblResistencia
            // 
            lblResistencia.AutoSize = true;
            lblResistencia.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResistencia.ForeColor = Color.Sienna;
            lblResistencia.Location = new Point(17, 221);
            lblResistencia.Name = "lblResistencia";
            lblResistencia.Size = new Size(108, 25);
            lblResistencia.TabIndex = 8;
            lblResistencia.Text = "Resistencia";
            // 
            // lblCosto
            // 
            lblCosto.AutoSize = true;
            lblCosto.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCosto.ForeColor = Color.Sienna;
            lblCosto.Location = new Point(17, 271);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new Size(63, 25);
            lblCosto.TabIndex = 9;
            lblCosto.Text = "Costo";
            // 
            // cmbTipo
            // 
            cmbTipo.BackColor = Color.RosyBrown;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbTipo.ForeColor = Color.White;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Agua", "Tierra", "Aire", "Fuego" });
            cmbTipo.Location = new Point(185, 71);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(159, 33);
            cmbTipo.TabIndex = 13;
            // 
            // cmbNivel
            // 
            cmbNivel.BackColor = Color.RosyBrown;
            cmbNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNivel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbNivel.ForeColor = Color.White;
            cmbNivel.FormattingEnabled = true;
            cmbNivel.Items.AddRange(new object[] { "1 - iniciado", "2 - aprendiz", "3 - estudiante", "4 - avanzado", "5 - maestro" });
            cmbNivel.Location = new Point(185, 121);
            cmbNivel.Name = "cmbNivel";
            cmbNivel.Size = new Size(159, 33);
            cmbNivel.TabIndex = 14;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Teal;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.HighlightText;
            btnGuardar.Location = new Point(185, 318);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(159, 48);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(17, 318);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(162, 48);
            btnVolver.TabIndex = 16;
            btnVolver.Text = "Cancelar";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // txtPoder
            // 
            txtPoder.Location = new Point(185, 173);
            txtPoder.Name = "txtPoder";
            txtPoder.Size = new Size(159, 23);
            txtPoder.TabIndex = 17;
            // 
            // txtResistencia
            // 
            txtResistencia.Location = new Point(185, 221);
            txtResistencia.Name = "txtResistencia";
            txtResistencia.Size = new Size(159, 23);
            txtResistencia.TabIndex = 18;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(185, 271);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(159, 23);
            txtCosto.TabIndex = 19;
            // 
            // FormRegCriatura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(365, 382);
            Controls.Add(txtCosto);
            Controls.Add(txtResistencia);
            Controls.Add(txtPoder);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardar);
            Controls.Add(cmbNivel);
            Controls.Add(cmbTipo);
            Controls.Add(lblCosto);
            Controls.Add(lblResistencia);
            Controls.Add(lblPoder);
            Controls.Add(lblNivel);
            Controls.Add(lblTipo);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblIdcriatura);
            Name = "FormRegCriatura";
            Text = "Registrar Criatura";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIdcriatura;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label label1;
        private Label lblTipo;
        private Label lblNivel;
        private Label lblPoder;
        private Label lblResistencia;
        private Label lblCosto;
        private ComboBox cmbTipo;
        private ComboBox cmbNivel;
        private Button btnGuardar;
        private Button btnVolver;
        private TextBox txtPoder;
        private TextBox txtResistencia;
        private TextBox txtCosto;
    }
}