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
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGVCriaturas).BeginInit();
            SuspendLayout();
            // 
            // dataGVCriaturas
            // 
            dataGVCriaturas.AllowUserToAddRows = false;
            dataGVCriaturas.AllowUserToDeleteRows = false;
            dataGVCriaturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGVCriaturas.BackgroundColor = Color.SeaGreen;
            dataGVCriaturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGVCriaturas.Columns.AddRange(new DataGridViewColumn[] { ColIdCriatura, ColNombre, ColTipo, ColNivel, ColPoder, ColResistencia, ColCosto });
            dataGVCriaturas.Location = new Point(14, 16);
            dataGVCriaturas.Margin = new Padding(3, 4, 3, 4);
            dataGVCriaturas.Name = "dataGVCriaturas";
            dataGVCriaturas.ReadOnly = true;
            dataGVCriaturas.RowHeadersWidth = 51;
            dataGVCriaturas.ScrollBars = ScrollBars.None;
            dataGVCriaturas.Size = new Size(645, 377);
            dataGVCriaturas.TabIndex = 0;
            // 
            // ColIdCriatura
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColIdCriatura.DefaultCellStyle = dataGridViewCellStyle1;
            ColIdCriatura.HeaderText = "ID";
            ColIdCriatura.MinimumWidth = 6;
            ColIdCriatura.Name = "ColIdCriatura";
            ColIdCriatura.ReadOnly = true;
            ColIdCriatura.Resizable = DataGridViewTriState.True;
            // 
            // ColNombre
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColNombre.DefaultCellStyle = dataGridViewCellStyle2;
            ColNombre.HeaderText = "Nombre";
            ColNombre.MinimumWidth = 6;
            ColNombre.Name = "ColNombre";
            ColNombre.ReadOnly = true;
            // 
            // ColTipo
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColTipo.DefaultCellStyle = dataGridViewCellStyle3;
            ColTipo.HeaderText = "Tipo";
            ColTipo.MinimumWidth = 6;
            ColTipo.Name = "ColTipo";
            ColTipo.ReadOnly = true;
            // 
            // ColNivel
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColNivel.DefaultCellStyle = dataGridViewCellStyle4;
            ColNivel.HeaderText = "Nivel";
            ColNivel.MinimumWidth = 6;
            ColNivel.Name = "ColNivel";
            ColNivel.ReadOnly = true;
            // 
            // ColPoder
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColPoder.DefaultCellStyle = dataGridViewCellStyle5;
            ColPoder.HeaderText = "Poder";
            ColPoder.MinimumWidth = 6;
            ColPoder.Name = "ColPoder";
            ColPoder.ReadOnly = true;
            // 
            // ColResistencia
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColResistencia.DefaultCellStyle = dataGridViewCellStyle6;
            ColResistencia.HeaderText = "Resistencia";
            ColResistencia.MinimumWidth = 6;
            ColResistencia.Name = "ColResistencia";
            ColResistencia.ReadOnly = true;
            // 
            // ColCosto
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColCosto.DefaultCellStyle = dataGridViewCellStyle7;
            ColCosto.HeaderText = "Costo";
            ColCosto.MinimumWidth = 6;
            ColCosto.Name = "ColCosto";
            ColCosto.ReadOnly = true;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Crimson;
            btnVolver.Cursor = Cursors.No;
            btnVolver.FlatStyle = FlatStyle.Popup;
            btnVolver.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnVolver.ForeColor = SystemColors.ButtonFace;
            btnVolver.Location = new Point(14, 413);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(147, 52);
            btnVolver.TabIndex = 34;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(339, 424);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 35;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // FormConsCriatura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(674, 481);
            Controls.Add(label1);
            Controls.Add(btnVolver);
            Controls.Add(dataGVCriaturas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormConsCriatura";
            Text = "Consultar Criaturas";
            ((System.ComponentModel.ISupportInitialize)dataGVCriaturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label label1;
    }
}