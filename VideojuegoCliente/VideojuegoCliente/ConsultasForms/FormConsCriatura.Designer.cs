namespace Videojuego.GUI
{
    partial class FormConsCriatura
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
            btnVolver = new Button();
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
            dataGVCriaturas.Location = new Point(12, 12);
            dataGVCriaturas.Name = "dataGVCriaturas";
            dataGVCriaturas.ReadOnly = true;
            dataGVCriaturas.ScrollBars = ScrollBars.None;
            dataGVCriaturas.Size = new Size(564, 283);
            dataGVCriaturas.TabIndex = 0;
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
            btnVolver.TabIndex = 34;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormConsCriatura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(590, 361);
            Controls.Add(btnVolver);
            Controls.Add(dataGVCriaturas);
            Name = "FormConsCriatura";
            Text = "Consultar Criaturas";
            ((System.ComponentModel.ISupportInitialize)dataGVCriaturas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGVCriaturas;
        private Button btnVolver;
        private DataGridViewTextBoxColumn ColIdCriatura;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn ColTipo;
        private DataGridViewTextBoxColumn ColNivel;
        private DataGridViewTextBoxColumn ColPoder;
        private DataGridViewTextBoxColumn ColResistencia;
        private DataGridViewTextBoxColumn ColCosto;
    }
}