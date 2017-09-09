namespace VentaElectrodomesticos.AbmUsuario
{
    partial class FormSeleccionarEmplado
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_model_buscar_nombre = new System.Windows.Forms.TextBox();
            this.textBox_model_buscar_apellido = new System.Windows.Forms.TextBox();
            this.textBox_model_buscar_dni = new System.Windows.Forms.TextBox();
            this.comboBox__model_buscar_tipoemp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_model_buscar_sucursal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_model_buscar_provincia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_model_limpiar = new System.Windows.Forms.Button();
            this.dataGridView_resultado_busqueda = new System.Windows.Forms.DataGridView();
            this.button_buscar_database = new System.Windows.Forms.Button();
            this.button_selec_emp_salir = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultado_busqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_model_buscar_nombre);
            this.groupBox2.Controls.Add(this.textBox_model_buscar_apellido);
            this.groupBox2.Controls.Add(this.textBox_model_buscar_dni);
            this.groupBox2.Controls.Add(this.comboBox__model_buscar_tipoemp);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox_model_buscar_sucursal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBox_model_buscar_provincia);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(24, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 136);
            this.groupBox2.TabIndex = 57;
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
            this.label5.Location = new System.Drawing.Point(45, 94);
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
            this.textBox_model_buscar_dni.Location = new System.Drawing.Point(103, 94);
            this.textBox_model_buscar_dni.MaxLength = 8;
            this.textBox_model_buscar_dni.Name = "textBox_model_buscar_dni";
            this.textBox_model_buscar_dni.Size = new System.Drawing.Size(187, 20);
            this.textBox_model_buscar_dni.TabIndex = 35;
            // 
            // comboBox__model_buscar_tipoemp
            // 
            this.comboBox__model_buscar_tipoemp.FormattingEnabled = true;
            this.comboBox__model_buscar_tipoemp.Location = new System.Drawing.Point(442, 97);
            this.comboBox__model_buscar_tipoemp.Name = "comboBox__model_buscar_tipoemp";
            this.comboBox__model_buscar_tipoemp.Size = new System.Drawing.Size(160, 21);
            this.comboBox__model_buscar_tipoemp.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Provincia";
            // 
            // comboBox_model_buscar_sucursal
            // 
            this.comboBox_model_buscar_sucursal.FormattingEnabled = true;
            this.comboBox_model_buscar_sucursal.Location = new System.Drawing.Point(442, 61);
            this.comboBox_model_buscar_sucursal.Name = "comboBox_model_buscar_sucursal";
            this.comboBox_model_buscar_sucursal.Size = new System.Drawing.Size(160, 21);
            this.comboBox_model_buscar_sucursal.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tipo Empleado";
            // 
            // comboBox_model_buscar_provincia
            // 
            this.comboBox_model_buscar_provincia.FormattingEnabled = true;
            this.comboBox_model_buscar_provincia.Location = new System.Drawing.Point(442, 26);
            this.comboBox_model_buscar_provincia.Name = "comboBox_model_buscar_provincia";
            this.comboBox_model_buscar_provincia.Size = new System.Drawing.Size(160, 21);
            this.comboBox_model_buscar_provincia.TabIndex = 27;
            this.comboBox_model_buscar_provincia.SelectedIndexChanged += new System.EventHandler(this.comboBox_model_buscar_provincia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Sucursal";
            // 
            // button_model_limpiar
            // 
            this.button_model_limpiar.Location = new System.Drawing.Point(731, 111);
            this.button_model_limpiar.Name = "button_model_limpiar";
            this.button_model_limpiar.Size = new System.Drawing.Size(187, 27);
            this.button_model_limpiar.TabIndex = 56;
            this.button_model_limpiar.Text = "Limpiar";
            this.button_model_limpiar.UseVisualStyleBackColor = true;
            this.button_model_limpiar.Click += new System.EventHandler(this.button_model_limpiar_Click);
            // 
            // dataGridView_resultado_busqueda
            // 
            this.dataGridView_resultado_busqueda.AllowUserToAddRows = false;
            this.dataGridView_resultado_busqueda.AllowUserToDeleteRows = false;
            this.dataGridView_resultado_busqueda.AllowUserToResizeRows = false;
            this.dataGridView_resultado_busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultado_busqueda.Location = new System.Drawing.Point(20, 180);
            this.dataGridView_resultado_busqueda.Name = "dataGridView_resultado_busqueda";
            this.dataGridView_resultado_busqueda.Size = new System.Drawing.Size(898, 165);
            this.dataGridView_resultado_busqueda.TabIndex = 55;
            this.dataGridView_resultado_busqueda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionar_celda);
            // 
            // button_buscar_database
            // 
            this.button_buscar_database.Location = new System.Drawing.Point(731, 34);
            this.button_buscar_database.Name = "button_buscar_database";
            this.button_buscar_database.Size = new System.Drawing.Size(187, 27);
            this.button_buscar_database.TabIndex = 54;
            this.button_buscar_database.Text = "Buscar en Base de Datos";
            this.button_buscar_database.UseVisualStyleBackColor = true;
            this.button_buscar_database.Click += new System.EventHandler(this.button_buscar_database_Click);
            // 
            // button_selec_emp_salir
            // 
            this.button_selec_emp_salir.Location = new System.Drawing.Point(731, 365);
            this.button_selec_emp_salir.Name = "button_selec_emp_salir";
            this.button_selec_emp_salir.Size = new System.Drawing.Size(187, 28);
            this.button_selec_emp_salir.TabIndex = 59;
            this.button_selec_emp_salir.Text = "Salir";
            this.button_selec_emp_salir.UseVisualStyleBackColor = true;
            this.button_selec_emp_salir.Click += new System.EventHandler(this.button_selec_emp_salir_Click);
            // 
            // FormSeleccionarEmplado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 405);
            this.Controls.Add(this.button_selec_emp_salir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_model_limpiar);
            this.Controls.Add(this.dataGridView_resultado_busqueda);
            this.Controls.Add(this.button_buscar_database);
            this.Name = "FormSeleccionarEmplado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Emplado";
            this.Load += new System.EventHandler(this.FormSeleccionarEmplado_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultado_busqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_model_buscar_nombre;
        private System.Windows.Forms.TextBox textBox_model_buscar_apellido;
        private System.Windows.Forms.TextBox textBox_model_buscar_dni;
        private System.Windows.Forms.ComboBox comboBox__model_buscar_tipoemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_model_buscar_sucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_model_buscar_provincia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_model_limpiar;
        private System.Windows.Forms.DataGridView dataGridView_resultado_busqueda;
        private System.Windows.Forms.Button button_buscar_database;
        private System.Windows.Forms.Button button_selec_emp_salir;
    }
}