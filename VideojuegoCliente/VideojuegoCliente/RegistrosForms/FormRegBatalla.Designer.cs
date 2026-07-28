
namespace Videojuego.GUI
{
    partial class FormRegBatalla
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
            txtIDequipo2 = new TextBox();
            lblfecha = new Label();
            lbl_IDequipo2 = new Label();
            lbl_IDequipo1 = new Label();
            lbl_IDj2 = new Label();
            txtIDJ1 = new TextBox();
            lbl_IDj1 = new Label();
            txtIDBatalla = new TextBox();
            lblIdbatalla = new Label();
            txtIDequipo1 = new TextBox();
            txtIDJ2 = new TextBox();
            cbAnio = new ComboBox();
            cbMes = new ComboBox();
            cbDia = new ComboBox();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(19, 376);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(162, 48);
            btnVolver.TabIndex = 32;
            btnVolver.Text = "Cancelar";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.DodgerBlue;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = SystemColors.HighlightText;
            btnGuardar.Location = new Point(187, 376);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(159, 48);
            btnGuardar.TabIndex = 31;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtIDequipo2
            // 
            txtIDequipo2.Location = new Point(187, 231);
            txtIDequipo2.Name = "txtIDequipo2";
            txtIDequipo2.Size = new Size(159, 23);
            txtIDequipo2.TabIndex = 26;
            // 
            // lblfecha
            // 
            lblfecha.AutoSize = true;
            lblfecha.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblfecha.ForeColor = Color.Sienna;
            lblfecha.Location = new Point(19, 279);
            lblfecha.Name = "lblfecha";
            lblfecha.Size = new Size(62, 25);
            lblfecha.TabIndex = 24;
            lblfecha.Text = "Fecha";
            // 
            // lbl_IDequipo2
            // 
            lbl_IDequipo2.AutoSize = true;
            lbl_IDequipo2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IDequipo2.ForeColor = Color.Sienna;
            lbl_IDequipo2.Location = new Point(19, 231);
            lbl_IDequipo2.Name = "lbl_IDequipo2";
            lbl_IDequipo2.Size = new Size(116, 25);
            lbl_IDequipo2.TabIndex = 23;
            lbl_IDequipo2.Text = "ID Equipo 2";
            // 
            // lbl_IDequipo1
            // 
            lbl_IDequipo1.AutoSize = true;
            lbl_IDequipo1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IDequipo1.ForeColor = Color.Sienna;
            lbl_IDequipo1.Location = new Point(19, 129);
            lbl_IDequipo1.Name = "lbl_IDequipo1";
            lbl_IDequipo1.Size = new Size(116, 25);
            lbl_IDequipo1.TabIndex = 22;
            lbl_IDequipo1.Text = "ID Equipo 1";
            // 
            // lbl_IDj2
            // 
            lbl_IDj2.AutoSize = true;
            lbl_IDj2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IDj2.ForeColor = Color.Sienna;
            lbl_IDj2.Location = new Point(19, 179);
            lbl_IDj2.Name = "lbl_IDj2";
            lbl_IDj2.Size = new Size(127, 25);
            lbl_IDj2.TabIndex = 21;
            lbl_IDj2.Text = "ID Jugador 2";
            // 
            // txtIDJ1
            // 
            txtIDJ1.Location = new Point(187, 79);
            txtIDJ1.Name = "txtIDJ1";
            txtIDJ1.Size = new Size(159, 23);
            txtIDJ1.TabIndex = 20;
            // 
            // lbl_IDj1
            // 
            lbl_IDj1.AutoSize = true;
            lbl_IDj1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_IDj1.ForeColor = Color.Sienna;
            lbl_IDj1.Location = new Point(19, 79);
            lbl_IDj1.Name = "lbl_IDj1";
            lbl_IDj1.Size = new Size(127, 25);
            lbl_IDj1.TabIndex = 19;
            lbl_IDj1.Text = "ID Jugador 1";
            // 
            // txtIDBatalla
            // 
            txtIDBatalla.Location = new Point(187, 28);
            txtIDBatalla.Name = "txtIDBatalla";
            txtIDBatalla.Size = new Size(159, 23);
            txtIDBatalla.TabIndex = 18;
            // 
            // lblIdbatalla
            // 
            lblIdbatalla.AutoSize = true;
            lblIdbatalla.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIdbatalla.ForeColor = Color.Sienna;
            lblIdbatalla.Location = new Point(19, 26);
            lblIdbatalla.Name = "lblIdbatalla";
            lblIdbatalla.Size = new Size(123, 25);
            lblIdbatalla.TabIndex = 17;
            lblIdbatalla.Text = "ID de Batalla";
            // 
            // txtIDequipo1
            // 
            txtIDequipo1.Location = new Point(187, 134);
            txtIDequipo1.Name = "txtIDequipo1";
            txtIDequipo1.Size = new Size(159, 23);
            txtIDequipo1.TabIndex = 33;
            // 
            // txtIDJ2
            // 
            txtIDJ2.Location = new Point(187, 179);
            txtIDJ2.Name = "txtIDJ2";
            txtIDJ2.Size = new Size(159, 23);
            txtIDJ2.TabIndex = 34;
            // 
            // cbAnio
            // 
            cbAnio.BackColor = Color.RosyBrown;
            cbAnio.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAnio.ForeColor = Color.White;
            cbAnio.FormattingEnabled = true;
            cbAnio.Location = new Point(288, 279);
            cbAnio.Name = "cbAnio";
            cbAnio.Size = new Size(58, 23);
            cbAnio.TabIndex = 42;
            // 
            // cbMes
            // 
            cbMes.BackColor = Color.RosyBrown;
            cbMes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMes.ForeColor = Color.White;
            cbMes.FormattingEnabled = true;
            cbMes.Location = new Point(133, 279);
            cbMes.Name = "cbMes";
            cbMes.Size = new Size(85, 23);
            cbMes.TabIndex = 41;
            // 
            // cbDia
            // 
            cbDia.BackColor = Color.RosyBrown;
            cbDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDia.ForeColor = Color.White;
            cbDia.FormattingEnabled = true;
            cbDia.Location = new Point(224, 279);
            cbDia.Name = "cbDia";
            cbDia.Size = new Size(58, 23);
            cbDia.TabIndex = 40;
            // 
            // FormRegBatalla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(365, 450);
            Controls.Add(cbAnio);
            Controls.Add(cbMes);
            Controls.Add(cbDia);
            Controls.Add(txtIDJ2);
            Controls.Add(txtIDequipo1);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardar);
            Controls.Add(txtIDequipo2);
            Controls.Add(lblfecha);
            Controls.Add(lbl_IDequipo2);
            Controls.Add(lbl_IDequipo1);
            Controls.Add(lbl_IDj2);
            Controls.Add(txtIDJ1);
            Controls.Add(lbl_IDj1);
            Controls.Add(txtIDBatalla);
            Controls.Add(lblIdbatalla);
            Name = "FormRegBatalla";
            Text = "Registrar Batalla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private Button btnGuardar;
        private TextBox txtIDequipo2;
        private Label lblfecha;
        private Label lbl_IDequipo2;
        private Label lbl_IDequipo1;
        private Label lbl_IDj2;
        private TextBox txtIDJ1;
        private Label lbl_IDj1;
        private TextBox txtIDBatalla;
        private Label lblIdbatalla;
        private TextBox txtIDequipo1;
        private TextBox txtIDJ2;
        private ComboBox cbAnio;
        private ComboBox cbMes;
        private ComboBox cbDia;
    }
}