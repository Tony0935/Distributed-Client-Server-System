namespace VideojuegoCliente.GUI.ConsultasForms
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
            lblCriaturas = new Label();
            lblNombreJugador = new Label();
            btnVolver = new Button();
            dataGVInv = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGVInv).BeginInit();
            SuspendLayout();
            // 
            // lblCriaturas
            // 
            lblCriaturas.AutoSize = true;
            lblCriaturas.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCriaturas.ForeColor = Color.Sienna;
            lblCriaturas.Location = new Point(12, 65);
            lblCriaturas.Name = "lblCriaturas";
            lblCriaturas.Size = new Size(220, 25);
            lblCriaturas.TabIndex = 43;
            lblCriaturas.Text = "Criaturas en inventario:";
            // 
            // lblNombreJugador
            // 
            lblNombreJugador.AutoSize = true;
            lblNombreJugador.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreJugador.ForeColor = Color.Sienna;
            lblNombreJugador.Location = new Point(12, 16);
            lblNombreJugador.Name = "lblNombreJugador";
            lblNombreJugador.Size = new Size(92, 25);
            lblNombreJugador.TabIndex = 42;
            lblNombreJugador.Text = "Jugador:";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(12, 419);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(129, 39);
            btnVolver.TabIndex = 40;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // dataGVInv
            // 
            dataGVInv.AllowUserToAddRows = false;
            dataGVInv.AllowUserToDeleteRows = false;
            dataGVInv.BackgroundColor = Color.SeaGreen;
            dataGVInv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVInv.Location = new Point(12, 106);
            dataGVInv.Name = "dataGVInv";
            dataGVInv.ReadOnly = true;
            dataGVInv.Size = new Size(626, 283);
            dataGVInv.TabIndex = 39;
            // 
            // FormConsInv
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(650, 473);
            Controls.Add(lblCriaturas);
            Controls.Add(lblNombreJugador);
            Controls.Add(btnVolver);
            Controls.Add(dataGVInv);
            Name = "FormConsInv";
            Text = "Consulta Inventario";
            ((System.ComponentModel.ISupportInitialize)dataGVInv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCriaturas;
        private Label lblNombreJugador;
        private Button btnVolver;
        private DataGridView dataGVInv;
    }
}