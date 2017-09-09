namespace VentaElectrodomesticos.FormsComunes
{
    partial class FormSeleccionarCliente
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
            this.button_selec_emp_salir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_model_buscar_nombre = new System.Windows.Forms.TextBox();
            this.textBox_model_buscar_apellido = new System.Windows.Forms.TextBox();
            this.textBox_model_buscar_dni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_buscar_provincias = new System.Windows.Forms.ComboBox();
            this.button_model_limpiar = new System.Windows.Forms.Button();
            this.dataGridView_resultado_busqueda = new System.Windows.Forms.DataGridView();
            this.button_buscar_database = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultado_busqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // button_selec_emp_salir
            // 
            this.button_selec_emp_salir.Location = new System.Drawing.Point(596, 602);
            this.button_selec_emp_salir.Name = "button_selec_emp_salir";
            this.button_selec_emp_salir.Size = new System.Drawing.Size(115, 28);
            this.button_selec_emp_salir.TabIndex = 65;
            this.button_selec_emp_salir.Text = "Salir";
            this.button_selec_emp_salir.UseVisualStyleBackColor = true;
            this.button_selec_emp_salir.Click += new System.EventHandler(this.button_selec_emp_salir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_model_buscar_nombre);
            this.groupBox2.Controls.Add(this.textBox_model_buscar_apellido);
            this.groupBox2.Controls.Add(this.textBox_model_buscar_dni);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox_buscar_provincias);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(699, 100);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterio de Busqueda";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "DNI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Apellido";
            // 
            // textBox_model_buscar_nombre
            // 
            this.textBox_model_buscar_nombre.Location = new System.Drawing.Point(103, 26);
            this.textBox_model_buscar_nombre.Name = "textBox_model_buscar_nombre";
            this.textBox_model_buscar_nombre.Size = new System.Drawing.Size(187, 20);
            this.textBox_model_buscar_nombre.TabIndex = 33;
            // 
            // textBox_model_buscar_apellido
            // 
            this.textBox_model_buscar_apellido.Location = new System.Drawing.Point(103, 58);
            this.textBox_model_buscar_apellido.Name = "textBox_model_buscar_apellido";
            this.textBox_model_buscar_apellido.Size = new System.Drawing.Size(187, 20);
            this.textBox_model_buscar_apellido.TabIndex = 34;
            // 
            // textBox_model_buscar_dni
            // 
            this.textBox_model_buscar_dni.Location = new System.Drawing.Point(378, 55);
            this.textBox_model_buscar_dni.Name = "textBox_model_buscar_dni";
            this.textBox_model_buscar_dni.Size = new System.Drawing.Size(276, 20);
            this.textBox_model_buscar_dni.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Provincia";
            // 
            // comboBox_buscar_provincias
            // 
            this.comboBox_buscar_provincias.FormattingEnabled = true;
            this.comboBox_buscar_provincias.Location = new System.Drawing.Point(378, 21);
            this.comboBox_buscar_provincias.Name = "comboBox_buscar_provincias";
            this.comboBox_buscar_provincias.Size = new System.Drawing.Size(276, 21);
            this.comboBox_buscar_provincias.TabIndex = 27;
            // 
            // button_model_limpiar
            // 
            this.button_model_limpiar.Location = new System.Drawing.Point(12, 131);
            this.button_model_limpiar.Name = "button_model_limpiar";
            this.button_model_limpiar.Size = new System.Drawing.Size(115, 27);
            this.button_model_limpiar.TabIndex = 62;
            this.button_model_limpiar.Text = "Limpiar";
            this.button_model_limpiar.UseVisualStyleBackColor = true;
            this.button_model_limpiar.Click += new System.EventHandler(this.button_model_limpiar_Click);
            // 
            // dataGridView_resultado_busqueda
            // 
            this.dataGridView_resultado_busqueda.AllowUserToAddRows = false;
            this.dataGridView_resultado_busqueda.AllowUserToDeleteRows = false;
            this.dataGridView_resultado_busqueda.AllowUserToResizeColumns = false;
            this.dataGridView_resultado_busqueda.AllowUserToResizeRows = false;
            this.dataGridView_resultado_busqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_resultado_busqueda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_resultado_busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultado_busqueda.GridColor = System.Drawing.Color.White;
            this.dataGridView_resultado_busqueda.Location = new System.Drawing.Point(12, 177);
            this.dataGridView_resultado_busqueda.Name = "dataGridView_resultado_busqueda";
            this.dataGridView_resultado_busqueda.ReadOnly = true;
            this.dataGridView_resultado_busqueda.RowHeadersVisible = false;
            this.dataGridView_resultado_busqueda.Size = new System.Drawing.Size(699, 406);
            this.dataGridView_resultado_busqueda.TabIndex = 61;
            this.dataGridView_resultado_busqueda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionar_cliente);
            // 
            // button_buscar_database
            // 
            this.button_buscar_database.Location = new System.Drawing.Point(596, 131);
            this.button_buscar_database.Name = "button_buscar_database";
            this.button_buscar_database.Size = new System.Drawing.Size(115, 27);
            this.button_buscar_database.TabIndex = 60;
            this.button_buscar_database.Text = "Buscar";
            this.button_buscar_database.UseVisualStyleBackColor = true;
            this.button_buscar_database.Click += new System.EventHandler(this.button_buscar_database_Click);
            // 
            // FormSeleccionarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 642);
            this.Controls.Add(this.button_selec_emp_salir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_model_limpiar);
            this.Controls.Add(this.dataGridView_resultado_busqueda);
            this.Controls.Add(this.button_buscar_database);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormSeleccionarCliente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Cliente";
            this.Load += new System.EventHandler(this.FormSeleccionarCliente_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultado_busqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_selec_emp_salir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_model_buscar_nombre;
        private System.Windows.Forms.TextBox textBox_model_buscar_apellido;
        private System.Windows.Forms.TextBox textBox_model_buscar_dni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_buscar_provincias;
        private System.Windows.Forms.Button button_model_limpiar;
        private System.Windows.Forms.DataGridView dataGridView_resultado_busqueda;
        private System.Windows.Forms.Button button_buscar_database;
    }
}