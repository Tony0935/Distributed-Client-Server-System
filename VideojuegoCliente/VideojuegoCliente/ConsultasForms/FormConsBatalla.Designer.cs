namespace Videojuego.GUI
{
    partial class FormConsBatalla
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
            dataGVBatalla = new DataGridView();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGVBatalla).BeginInit();
            SuspendLayout();
            // 
            // dataGVBatalla
            // 
            dataGVBatalla.AllowUserToAddRows = false;
            dataGVBatalla.AllowUserToDeleteRows = false;
            dataGVBatalla.BackgroundColor = Color.DarkSalmon;
            dataGVBatalla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVBatalla.Location = new Point(12, 12);
            dataGVBatalla.Name = "dataGVBatalla";
            dataGVBatalla.ReadOnly = true;
            dataGVBatalla.Size = new Size(626, 283);
            dataGVBatalla.TabIndex = 2;
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
            btnVolver.TabIndex = 33;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormConsBatalla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(650, 361);
            Controls.Add(btnVolver);
            Controls.Add(dataGVBatalla);
            Name = "FormConsBatalla";
            Text = "Consultar Batallas";
            ((System.ComponentModel.ISupportInitialize)dataGVBatalla).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGVBatalla;
        private Button btnVolver;
    }
}