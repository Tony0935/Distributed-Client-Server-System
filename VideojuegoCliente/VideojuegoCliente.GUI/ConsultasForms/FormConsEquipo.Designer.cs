namespace VideojuegoCliente.GUI.ConsultasForms
{
    partial class FormConsEquipo
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
            dataGVEquipo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGVEquipo).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(12, 310);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(129, 39);
            btnVolver.TabIndex = 37;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // dataGVEquipo
            // 
            dataGVEquipo.AllowUserToAddRows = false;
            dataGVEquipo.AllowUserToDeleteRows = false;
            dataGVEquipo.BackgroundColor = Color.SteelBlue;
            dataGVEquipo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVEquipo.Location = new Point(12, 12);
            dataGVEquipo.Name = "dataGVEquipo";
            dataGVEquipo.ReadOnly = true;
            dataGVEquipo.Size = new Size(626, 283);
            dataGVEquipo.TabIndex = 36;
            // 
            // FormConsEquipo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(650, 361);
            Controls.Add(btnVolver);
            Controls.Add(dataGVEquipo);
            Name = "FormConsEquipo";
            Text = "Consulta Equipo";
            ((System.ComponentModel.ISupportInitialize)dataGVEquipo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnVolver;
        private DataGridView dataGVEquipo;
    }
}