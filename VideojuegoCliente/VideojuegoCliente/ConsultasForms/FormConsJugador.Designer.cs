namespace Videojuego.GUI
{
    partial class FormConsJugador
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
            dataGVJugadores = new DataGridView();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGVJugadores).BeginInit();
            SuspendLayout();
            // 
            // dataGVJugadores
            // 
            dataGVJugadores.AllowUserToAddRows = false;
            dataGVJugadores.AllowUserToDeleteRows = false;
            dataGVJugadores.BackgroundColor = Color.DarkSlateGray;
            dataGVJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVJugadores.Location = new Point(12, 12);
            dataGVJugadores.Name = "dataGVJugadores";
            dataGVJugadores.ReadOnly = true;
            dataGVJugadores.Size = new Size(626, 283);
            dataGVJugadores.TabIndex = 0;
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
            btnVolver.TabIndex = 35;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormConsJugador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(650, 361);
            Controls.Add(btnVolver);
            Controls.Add(dataGVJugadores);
            Name = "FormConsJugador";
            Text = "Consulta Jugadores";
            ((System.ComponentModel.ISupportInitialize)dataGVJugadores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGVJugadores;
        private Button btnVolver;
    }
}