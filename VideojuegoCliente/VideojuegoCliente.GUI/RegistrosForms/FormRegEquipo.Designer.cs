namespace VideojuegoCliente.GUI.RegistrosForms
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
            lblCriaturas = new Label();
            dataGVInv = new DataGridView();
            btnVolver = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGVInv).BeginInit();
            SuspendLayout();
            // 
            // lblCriaturas
            // 
            lblCriaturas.AutoSize = true;
            lblCriaturas.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCriaturas.ForeColor = Color.Sienna;
            lblCriaturas.Location = new Point(12, 29);
            lblCriaturas.Name = "lblCriaturas";
            lblCriaturas.Size = new Size(208, 25);
            lblCriaturas.TabIndex = 66;
            lblCriaturas.Text = "Seleccione 3 criaturas:";
            // 
            // dataGVInv
            // 
            dataGVInv.AllowUserToAddRows = false;
            dataGVInv.AllowUserToDeleteRows = false;
            dataGVInv.BackgroundColor = Color.SeaGreen;
            dataGVInv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVInv.Location = new Point(12, 70);
            dataGVInv.Name = "dataGVInv";
            dataGVInv.ReadOnly = true;
            dataGVInv.Size = new Size(626, 283);
            dataGVInv.TabIndex = 65;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(12, 391);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(162, 48);
            btnVolver.TabIndex = 68;
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
            btnGuardar.Location = new Point(197, 391);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(159, 48);
            btnGuardar.TabIndex = 67;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormRegEquipo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(650, 451);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardar);
            Controls.Add(lblCriaturas);
            Controls.Add(dataGVInv);
            Name = "FormRegEquipo";
            Text = "FormRegEquipo";
            ((System.ComponentModel.ISupportInitialize)dataGVInv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblCriaturas;
        private DataGridView dataGVInv;
        private Button btnVolver;
        private Button btnGuardar;
    }
}