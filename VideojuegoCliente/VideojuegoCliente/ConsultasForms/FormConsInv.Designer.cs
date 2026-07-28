namespace Videojuego.GUI
{
    partial class FormConsInv
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
            dataGVInv = new DataGridView();
            btnVolver = new Button();
            cmbJugadores = new ComboBox();
            lblJugador = new Label();
            lblCriaturas = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGVInv).BeginInit();
            SuspendLayout();
            // 
            // dataGVInv
            // 
            dataGVInv.AllowUserToAddRows = false;
            dataGVInv.AllowUserToDeleteRows = false;
            dataGVInv.BackgroundColor = Color.SeaGreen;
            dataGVInv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVInv.Location = new Point(12, 146);
            dataGVInv.Name = "dataGVInv";
            dataGVInv.ReadOnly = true;
            dataGVInv.Size = new Size(626, 283);
            dataGVInv.TabIndex = 1;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(12, 459);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(129, 39);
            btnVolver.TabIndex = 35;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // cmbJugadores
            // 
            cmbJugadores.BackColor = Color.RosyBrown;
            cmbJugadores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJugadores.ForeColor = Color.White;
            cmbJugadores.FormattingEnabled = true;
            cmbJugadores.Location = new Point(12, 59);
            cmbJugadores.Name = "cmbJugadores";
            cmbJugadores.Size = new Size(222, 23);
            cmbJugadores.TabIndex = 36;
            cmbJugadores.SelectedIndexChanged += cmbJugadores_SelectedIndexChanged;
            // 
            // lblJugador
            // 
            lblJugador.AutoSize = true;
            lblJugador.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJugador.ForeColor = Color.Sienna;
            lblJugador.Location = new Point(12, 20);
            lblJugador.Name = "lblJugador";
            lblJugador.Size = new Size(210, 25);
            lblJugador.TabIndex = 37;
            lblJugador.Text = "Seleccione el Jugador:";
            // 
            // lblCriaturas
            // 
            lblCriaturas.AutoSize = true;
            lblCriaturas.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCriaturas.ForeColor = Color.Sienna;
            lblCriaturas.Location = new Point(12, 105);
            lblCriaturas.Name = "lblCriaturas";
            lblCriaturas.Size = new Size(220, 25);
            lblCriaturas.TabIndex = 38;
            lblCriaturas.Text = "Criaturas en inventario:";
            // 
            // FormConsInv
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(650, 510);
            Controls.Add(lblCriaturas);
            Controls.Add(lblJugador);
            Controls.Add(cmbJugadores);
            Controls.Add(btnVolver);
            Controls.Add(dataGVInv);
            Name = "FormConsInv";
            Text = "Consulta Inventario";
            ((System.ComponentModel.ISupportInitialize)dataGVInv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGVInv;
        private Button btnVolver;
        private ComboBox cmbJugadores;
        private Label lblJugador;
        private Label lblCriaturas;
    }
}