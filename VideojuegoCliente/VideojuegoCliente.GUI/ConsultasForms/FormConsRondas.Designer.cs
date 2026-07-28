namespace VideojuegoCliente.GUI.ConsultasForms
{
    partial class FormConsRondas
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
            dataGVRondas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGVRondas).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(12, 359);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(129, 39);
            btnVolver.TabIndex = 37;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // dataGVRondas
            // 
            dataGVRondas.AllowUserToAddRows = false;
            dataGVRondas.AllowUserToDeleteRows = false;
            dataGVRondas.BackgroundColor = Color.RosyBrown;
            dataGVRondas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVRondas.GridColor = Color.RosyBrown;
            dataGVRondas.Location = new Point(12, 12);
            dataGVRondas.Name = "dataGVRondas";
            dataGVRondas.ReadOnly = true;
            dataGVRondas.Size = new Size(883, 327);
            dataGVRondas.TabIndex = 36;
            // 
            // FormConsRondas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(907, 412);
            Controls.Add(btnVolver);
            Controls.Add(dataGVRondas);
            Name = "FormConsRondas";
            Text = "Consulta Rondas";
            ((System.ComponentModel.ISupportInitialize)dataGVRondas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnVolver;
        private DataGridView dataGVRondas;
    }
}