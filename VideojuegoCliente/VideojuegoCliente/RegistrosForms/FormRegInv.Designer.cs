namespace Videojuego.GUI
{
    partial class FormRegInv
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            dataGVCriaturas = new DataGridView();
            ColIdCriatura = new DataGridViewTextBoxColumn();
            ColNombre = new DataGridViewTextBoxColumn();
            ColTipo = new DataGridViewTextBoxColumn();
            ColNivel = new DataGridViewTextBoxColumn();
            ColPoder = new DataGridViewTextBoxColumn();
            ColResistencia = new DataGridViewTextBoxColumn();
            ColCosto = new DataGridViewTextBoxColumn();
            cmbJugadores = new ComboBox();
            btnVolver = new Button();
            btnComprar = new Button();
            lblCristales = new Label();
            lblCristalesdisp = new Label();
            lblCriaturas = new Label();
            lblJugador = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGVCriaturas).BeginInit();
            SuspendLayout();
            // 
            // dataGVCriaturas
            // 
            dataGVCriaturas.AllowUserToAddRows = false;
            dataGVCriaturas.AllowUserToDeleteRows = false;
            dataGVCriaturas.BackgroundColor = Color.SeaGreen;
            dataGVCriaturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVCriaturas.Columns.AddRange(new DataGridViewColumn[] { ColIdCriatura, ColNombre, ColTipo, ColNivel, ColPoder, ColResistencia, ColCosto });
            dataGVCriaturas.GridColor = Color.SeaGreen;
            dataGVCriaturas.Location = new Point(45, 160);
            dataGVCriaturas.Name = "dataGVCriaturas";
            dataGVCriaturas.ReadOnly = true;
            dataGVCriaturas.Size = new Size(564, 283);
            dataGVCriaturas.TabIndex = 1;
            // 
            // ColIdCriatura
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColIdCriatura.DefaultCellStyle = dataGridViewCellStyle1;
            ColIdCriatura.HeaderText = "ID";
            ColIdCriatura.Name = "ColIdCriatura";
            ColIdCriatura.ReadOnly = true;
            ColIdCriatura.Resizable = DataGridViewTriState.True;
            ColIdCriatura.Width = 60;
            // 
            // ColNombre
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColNombre.DefaultCellStyle = dataGridViewCellStyle2;
            ColNombre.HeaderText = "Nombre";
            ColNombre.Name = "ColNombre";
            ColNombre.ReadOnly = true;
            ColNombre.Width = 80;
            // 
            // ColTipo
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColTipo.DefaultCellStyle = dataGridViewCellStyle3;
            ColTipo.HeaderText = "Tipo";
            ColTipo.Name = "ColTipo";
            ColTipo.ReadOnly = true;
            ColTipo.Width = 80;
            // 
            // ColNivel
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColNivel.DefaultCellStyle = dataGridViewCellStyle4;
            ColNivel.HeaderText = "Nivel";
            ColNivel.Name = "ColNivel";
            ColNivel.ReadOnly = true;
            ColNivel.Width = 80;
            // 
            // ColPoder
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColPoder.DefaultCellStyle = dataGridViewCellStyle5;
            ColPoder.HeaderText = "Poder";
            ColPoder.Name = "ColPoder";
            ColPoder.ReadOnly = true;
            ColPoder.Width = 70;
            // 
            // ColResistencia
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColResistencia.DefaultCellStyle = dataGridViewCellStyle6;
            ColResistencia.HeaderText = "Resistencia";
            ColResistencia.Name = "ColResistencia";
            ColResistencia.ReadOnly = true;
            ColResistencia.Width = 90;
            // 
            // ColCosto
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColCosto.DefaultCellStyle = dataGridViewCellStyle7;
            ColCosto.HeaderText = "Costo";
            ColCosto.Name = "ColCosto";
            ColCosto.ReadOnly = true;
            ColCosto.Width = 60;
            // 
            // cmbJugadores
            // 
            cmbJugadores.BackColor = Color.RosyBrown;
            cmbJugadores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJugadores.FormattingEnabled = true;
            cmbJugadores.Location = new Point(45, 80);
            cmbJugadores.Name = "cmbJugadores";
            cmbJugadores.Size = new Size(222, 23);
            cmbJugadores.TabIndex = 2;
            cmbJugadores.SelectedIndexChanged += cmbJugadores_SelectedIndexChanged_1;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(45, 481);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(159, 39);
            btnVolver.TabIndex = 34;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnComprar
            // 
            btnComprar.BackColor = SystemColors.Highlight;
            btnComprar.FlatStyle = FlatStyle.Popup;
            btnComprar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnComprar.ForeColor = SystemColors.Control;
            btnComprar.Location = new Point(450, 481);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(159, 39);
            btnComprar.TabIndex = 35;
            btnComprar.Text = "Comprar";
            btnComprar.UseVisualStyleBackColor = false;
            btnComprar.Click += btnComprar_Click;
            // 
            // lblCristales
            // 
            lblCristales.AutoSize = true;
            lblCristales.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCristales.ForeColor = Color.DarkViolet;
            lblCristales.Location = new Point(581, 31);
            lblCristales.Name = "lblCristales";
            lblCristales.Size = new Size(28, 32);
            lblCristales.TabIndex = 36;
            lblCristales.Text = "0";
            // 
            // lblCristalesdisp
            // 
            lblCristalesdisp.AutoSize = true;
            lblCristalesdisp.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCristalesdisp.ForeColor = Color.Sienna;
            lblCristalesdisp.Location = new Point(473, 38);
            lblCristalesdisp.Name = "lblCristalesdisp";
            lblCristalesdisp.Size = new Size(90, 25);
            lblCristalesdisp.TabIndex = 37;
            lblCristalesdisp.Text = "Cristales:";
            // 
            // lblCriaturas
            // 
            lblCriaturas.AutoSize = true;
            lblCriaturas.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCriaturas.ForeColor = Color.Sienna;
            lblCriaturas.Location = new Point(45, 122);
            lblCriaturas.Name = "lblCriaturas";
            lblCriaturas.Size = new Size(203, 25);
            lblCriaturas.TabIndex = 40;
            lblCriaturas.Text = "Criaturas disponibles:";
            // 
            // lblJugador
            // 
            lblJugador.AutoSize = true;
            lblJugador.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJugador.ForeColor = Color.Sienna;
            lblJugador.Location = new Point(45, 38);
            lblJugador.Name = "lblJugador";
            lblJugador.Size = new Size(210, 25);
            lblJugador.TabIndex = 39;
            lblJugador.Text = "Seleccione el Jugador:";
            // 
            // FormRegInv
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(650, 550);
            Controls.Add(lblCriaturas);
            Controls.Add(lblJugador);
            Controls.Add(lblCristalesdisp);
            Controls.Add(lblCristales);
            Controls.Add(btnComprar);
            Controls.Add(btnVolver);
            Controls.Add(cmbJugadores);
            Controls.Add(dataGVCriaturas);
            Name = "FormRegInv";
            Text = "Comprar Criaturas";
            ((System.ComponentModel.ISupportInitialize)dataGVCriaturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGVCriaturas;
        private DataGridViewTextBoxColumn ColIdCriatura;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn ColTipo;
        private DataGridViewTextBoxColumn ColNivel;
        private DataGridViewTextBoxColumn ColPoder;
        private DataGridViewTextBoxColumn ColResistencia;
        private DataGridViewTextBoxColumn ColCosto;
        private ComboBox cmbJugadores;
        private Button btnVolver;
        private Button btnComprar;
        private Label lblCristales;
        private Label lblCristalesdisp;
        private Label lblCriaturas;
        private Label lblJugador;
    }
}