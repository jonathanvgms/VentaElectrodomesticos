namespace VentaElectrodomesticos.AsignacionStock
{
    partial class FormSeleccionarAnalista
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_buscar_prod_salir = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_buscar_dni_empleado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_buscar_nombre_emp = new System.Windows.Forms.TextBox();
            this.textBox_buscar_apellido_emp = new System.Windows.Forms.TextBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_buscar_database = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_buscar_prod_salir
            // 
            this.button_buscar_prod_salir.Location = new System.Drawing.Point(523, 474);
            this.button_buscar_prod_salir.Name = "button_buscar_prod_salir";
            this.button_buscar_prod_salir.Size = new System.Drawing.Size(137, 27);
            this.button_buscar_prod_salir.TabIndex = 64;
            this.button_buscar_prod_salir.Text = "Salir";
            this.button_buscar_prod_salir.UseVisualStyleBackColor = true;
            this.button_buscar_prod_salir.Click += new System.EventHandler(this.button_buscar_prod_salir_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 199);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(648, 258);
            this.dataGridView1.TabIndex = 63;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionar_cliente);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_buscar_dni_empleado);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_buscar_nombre_emp);
            this.groupBox2.Controls.Add(this.textBox_buscar_apellido_emp);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(648, 132);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterio de Busqueda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "DNI Empleado";
            // 
            // textBox_buscar_dni_empleado
            // 
            this.textBox_buscar_dni_empleado.Location = new System.Drawing.Point(435, 39);
            this.textBox_buscar_dni_empleado.Name = "textBox_buscar_dni_empleado";
            this.textBox_buscar_dni_empleado.Size = new System.Drawing.Size(187, 20);
            this.textBox_buscar_dni_empleado.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Nombre Empleado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Apellido Empleado";
            // 
            // textBox_buscar_nombre_emp
            // 
            this.textBox_buscar_nombre_emp.Location = new System.Drawing.Point(141, 39);
            this.textBox_buscar_nombre_emp.Name = "textBox_buscar_nombre_emp";
            this.textBox_buscar_nombre_emp.Size = new System.Drawing.Size(187, 20);
            this.textBox_buscar_nombre_emp.TabIndex = 27;
            // 
            // textBox_buscar_apellido_emp
            // 
            this.textBox_buscar_apellido_emp.Location = new System.Drawing.Point(141, 76);
            this.textBox_buscar_apellido_emp.Name = "textBox_buscar_apellido_emp";
            this.textBox_buscar_apellido_emp.Size = new System.Drawing.Size(187, 20);
            this.textBox_buscar_apellido_emp.TabIndex = 28;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(12, 166);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(110, 27);
            this.button_limpiar.TabIndex = 61;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_buscar_database
            // 
            this.button_buscar_database.Location = new System.Drawing.Point(523, 166);
            this.button_buscar_database.Name = "button_buscar_database";
            this.button_buscar_database.Size = new System.Drawing.Size(137, 27);
            this.button_buscar_database.TabIndex = 59;
            this.button_buscar_database.Text = "Buscar";
            this.button_buscar_database.UseVisualStyleBackColor = true;
            this.button_buscar_database.Click += new System.EventHandler(this.button_buscar_database_Click);
            // 
            // FormSeleccionarAnalista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 513);
            this.Controls.Add(this.button_buscar_prod_salir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button_buscar_database);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormSeleccionarAnalista";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Analista";
            this.Load += new System.EventHandler(this.FormSeleccionarAnalista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_buscar_prod_salir;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_buscar_dni_empleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_buscar_nombre_emp;
        private System.Windows.Forms.TextBox textBox_buscar_apellido_emp;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_buscar_database;
    }
}