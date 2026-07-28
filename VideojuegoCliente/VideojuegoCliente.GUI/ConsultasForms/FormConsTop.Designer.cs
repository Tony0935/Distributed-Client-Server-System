namespace VideojuegoCliente.GUI.ConsultasForms
{
    partial class FormConsTop
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
            dataGVTop = new DataGridView();
            Jugador = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            FechaNacimiento = new DataGridViewTextBoxColumn();
            Nivel = new DataGridViewTextBoxColumn();
            Cristales = new DataGridViewTextBoxColumn();
            BatallasGanadas = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGVTop).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(12, 394);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(129, 39);
            btnVolver.TabIndex = 38;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // dataGVTop
            // 
            dataGVTop.AllowUserToAddRows = false;
            dataGVTop.AllowUserToDeleteRows = false;
            dataGVTop.BackgroundColor = Color.DarkSlateGray;
            dataGVTop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVTop.Columns.AddRange(new DataGridViewColumn[] { Jugador, ID, FechaNacimiento, Nivel, Cristales, BatallasGanadas });
            dataGVTop.GridColor = Color.DarkSlateGray;
            dataGVTop.Location = new Point(12, 13);
            dataGVTop.Name = "dataGVTop";
            dataGVTop.ReadOnly = true;
            dataGVTop.ScrollBars = ScrollBars.None;
            dataGVTop.Size = new Size(626, 361);
            dataGVTop.TabIndex = 37;
            // 
            // Jugador
            // 
            Jugador.HeaderText = "Jugador";
            Jugador.Name = "Jugador";
            Jugador.ReadOnly = true;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // FechaNacimiento
            // 
            FechaNacimiento.HeaderText = "Fecha de Nacimiento";
            FechaNacimiento.Name = "FechaNacimiento";
            FechaNacimiento.ReadOnly = true;
            // 
            // Nivel
            // 
            Nivel.HeaderText = "Nivel";
            Nivel.Name = "Nivel";
            Nivel.ReadOnly = true;
            // 
            // Cristales
            // 
            Cristales.HeaderText = "Cristales";
            Cristales.Name = "Cristales";
            Cristales.ReadOnly = true;
            // 
            // BatallasGanadas
            // 
            BatallasGanadas.HeaderText = "Batallas Ganadas";
            BatallasGanadas.Name = "BatallasGanadas";
            BatallasGanadas.ReadOnly = true;
            // 
            // FormConsTop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(650, 446);
            Controls.Add(btnVolver);
            Controls.Add(dataGVTop);
            Name = "FormConsTop";
            Text = "Top 10 Jugadores";
            ((System.ComponentModel.ISupportInitialize)dataGVTop).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnVolver;
        private DataGridView dataGVTop;
        private DataGridViewTextBoxColumn Jugador;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn FechaNacimiento;
        private DataGridViewTextBoxColumn Nivel;
        private DataGridViewTextBoxColumn Cristales;
        private DataGridViewTextBoxColumn BatallasGanadas;
    }
}