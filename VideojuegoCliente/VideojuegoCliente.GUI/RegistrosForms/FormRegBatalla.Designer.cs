namespace VideojuegoCliente.GUI.RegistrosForms
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
            lblEquipos = new Label();
            dataGVEquipos = new DataGridView();
            btnIniciarBatalla = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGVEquipos).BeginInit();
            SuspendLayout();
            // 
            // lblEquipos
            // 
            lblEquipos.AutoSize = true;
            lblEquipos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEquipos.ForeColor = Color.Sienna;
            lblEquipos.Location = new Point(12, 20);
            lblEquipos.Name = "lblEquipos";
            lblEquipos.Size = new Size(207, 25);
            lblEquipos.TabIndex = 68;
            lblEquipos.Text = "Seleccione un equipo:";
            // 
            // dataGVEquipos
            // 
            dataGVEquipos.AllowUserToAddRows = false;
            dataGVEquipos.AllowUserToDeleteRows = false;
            dataGVEquipos.BackgroundColor = Color.SeaGreen;
            dataGVEquipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVEquipos.Location = new Point(12, 61);
            dataGVEquipos.Name = "dataGVEquipos";
            dataGVEquipos.ReadOnly = true;
            dataGVEquipos.Size = new Size(626, 283);
            dataGVEquipos.TabIndex = 67;
            // 
            // btnIniciarBatalla
            // 
            btnIniciarBatalla.BackColor = Color.Crimson;
            btnIniciarBatalla.FlatStyle = FlatStyle.Popup;
            btnIniciarBatalla.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarBatalla.ForeColor = SystemColors.HighlightText;
            btnIniciarBatalla.Location = new Point(213, 381);
            btnIniciarBatalla.Name = "btnIniciarBatalla";
            btnIniciarBatalla.Size = new Size(207, 58);
            btnIniciarBatalla.TabIndex = 69;
            btnIniciarBatalla.Text = "Iniciar Batalla";
            btnIniciarBatalla.UseVisualStyleBackColor = false;
            btnIniciarBatalla.Click += btnIniciarBatalla_Click_1;
            // 
            // FormRegBatalla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(650, 451);
            Controls.Add(btnIniciarBatalla);
            Controls.Add(lblEquipos);
            Controls.Add(dataGVEquipos);
            Name = "FormRegBatalla";
            Text = "Registrar Batalla";
            ((System.ComponentModel.ISupportInitialize)dataGVEquipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblEquipos;
        private DataGridView dataGVEquipos;
        private Button btnIniciarBatalla;
    }
}