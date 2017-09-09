namespace VentaElectrodomesticos.AbmCliente
{
    partial class FormAbmCliente
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
            this.tabControl_mod_eli = new System.Windows.Forms.TabControl();
            this.tabPage_crear_emp = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_crear_nombre = new System.Windows.Forms.Label();
            this.label_crear_email = new System.Windows.Forms.Label();
            this.label_crear_dni = new System.Windows.Forms.Label();
            this.label_crear_apellido = new System.Windows.Forms.Label();
            this.textBox_crear_dir_pisodepto = new System.Windows.Forms.TextBox();
            this.comboBox_crear_provincia = new System.Windows.Forms.ComboBox();
            this.textBox_crear_dir_numero = new System.Windows.Forms.TextBox();
            this.label_crear_telefono = new System.Windows.Forms.Label();
            this.textBox_crear_dir_calle = new System.Windows.Forms.TextBox();
            this.label_crear_provincia = new System.Windows.Forms.Label();
            this.label1_crear_pisodep = new System.Windows.Forms.Label();
            this.textBox_crear_nombre = new System.Windows.Forms.TextBox();
            this.label_crear_dir_calle = new System.Windows.Forms.Label();
            this.textBox_crear_apellido = new System.Windows.Forms.TextBox();
            this.label_crear_dir_num = new System.Windows.Forms.Label();
            this.textBox_crear_tel = new System.Windows.Forms.TextBox();
            this.label_crear_direccion = new System.Windows.Forms.Label();
            this.textBox_crear_dni = new System.Windows.Forms.TextBox();
            this.textBox_crear_email = new System.Windows.Forms.TextBox();
            this.button_crear_limpliar = new System.Windows.Forms.Button();
            this.button_crear_aceptar = new System.Windows.Forms.Button();
            this.tabPage_model_emp = new System.Windows.Forms.TabPage();
            this.dataGridView_resultado_busqueda = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_model_buscar_nombre = new System.Windows.Forms.TextBox();
            this.textBox_model_buscar_apellido = new System.Windows.Forms.TextBox();
            this.textBox_model_buscar_dni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_model_buscar_provincias = new System.Windows.Forms.ComboBox();
            this.button_model_limpiar = new System.Windows.Forms.Button();
            this.button_model_buscar_database = new System.Windows.Forms.Button();
            this.button_crear_salir = new System.Windows.Forms.Button();
            this.tabControl_mod_eli.SuspendLayout();
            this.tabPage_crear_emp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_model_emp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultado_busqueda)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_mod_eli
            // 
            this.tabControl_mod_eli.Controls.Add(this.tabPage_crear_emp);
            this.tabControl_mod_eli.Controls.Add(this.tabPage_model_emp);
            this.tabControl_mod_eli.Location = new System.Drawing.Point(12, 12);
            this.tabControl_mod_eli.Name = "tabControl_mod_eli";
            this.tabControl_mod_eli.SelectedIndex = 0;
            this.tabControl_mod_eli.Size = new System.Drawing.Size(927, 600);
            this.tabControl_mod_eli.TabIndex = 1;
            // 
            // tabPage_crear_emp
            // 
            this.tabPage_crear_emp.Controls.Add(this.groupBox1);
            this.tabPage_crear_emp.Controls.Add(this.button_crear_limpliar);
            this.tabPage_crear_emp.Controls.Add(this.button_crear_aceptar);
            this.tabPage_crear_emp.Location = new System.Drawing.Point(4, 22);
            this.tabPage_crear_emp.Name = "tabPage_crear_emp";
            this.tabPage_crear_emp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_crear_emp.Size = new System.Drawing.Size(919, 574);
            this.tabPage_crear_emp.TabIndex = 0;
            this.tabPage_crear_emp.Text = "Crear";
            this.tabPage_crear_emp.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_crear_nombre);
            this.groupBox1.Controls.Add(this.label_crear_email);
            this.groupBox1.Controls.Add(this.label_crear_dni);
            this.groupBox1.Controls.Add(this.label_crear_apellido);
            this.groupBox1.Controls.Add(this.textBox_crear_dir_pisodepto);
            this.groupBox1.Controls.Add(this.comboBox_crear_provincia);
            this.groupBox1.Controls.Add(this.textBox_crear_dir_numero);
            this.groupBox1.Controls.Add(this.label_crear_telefono);
            this.groupBox1.Controls.Add(this.textBox_crear_dir_calle);
            this.groupBox1.Controls.Add(this.label_crear_provincia);
            this.groupBox1.Controls.Add(this.label1_crear_pisodep);
            this.groupBox1.Controls.Add(this.textBox_crear_nombre);
            this.groupBox1.Controls.Add(this.label_crear_dir_calle);
            this.groupBox1.Controls.Add(this.textBox_crear_apellido);
            this.groupBox1.Controls.Add(this.label_crear_dir_num);
            this.groupBox1.Controls.Add(this.textBox_crear_tel);
            this.groupBox1.Controls.Add(this.label_crear_direccion);
            this.groupBox1.Controls.Add(this.textBox_crear_dni);
            this.groupBox1.Controls.Add(this.textBox_crear_email);
            this.groupBox1.Location = new System.Drawing.Point(57, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 327);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulario para un Nuevo Cliente";
            // 
            // label_crear_nombre
            // 
            this.label_crear_nombre.AutoSize = true;
            this.label_crear_nombre.Location = new System.Drawing.Point(51, 31);
            this.label_crear_nombre.Name = "label_crear_nombre";
            this.label_crear_nombre.Size = new System.Drawing.Size(44, 13);
            this.label_crear_nombre.TabIndex = 0;
            this.label_crear_nombre.Text = "Nombre";
            // 
            // label_crear_email
            // 
            this.label_crear_email.AutoSize = true;
            this.label_crear_email.Location = new System.Drawing.Point(63, 136);
            this.label_crear_email.Name = "label_crear_email";
            this.label_crear_email.Size = new System.Drawing.Size(32, 13);
            this.label_crear_email.TabIndex = 2;
            this.label_crear_email.Text = "Email";
            // 
            // label_crear_dni
            // 
            this.label_crear_dni.AutoSize = true;
            this.label_crear_dni.Location = new System.Drawing.Point(69, 99);
            this.label_crear_dni.Name = "label_crear_dni";
            this.label_crear_dni.Size = new System.Drawing.Size(26, 13);
            this.label_crear_dni.TabIndex = 3;
            this.label_crear_dni.Text = "DNI";
            // 
            // label_crear_apellido
            // 
            this.label_crear_apellido.AutoSize = true;
            this.label_crear_apellido.Location = new System.Drawing.Point(51, 63);
            this.label_crear_apellido.Name = "label_crear_apellido";
            this.label_crear_apellido.Size = new System.Drawing.Size(44, 13);
            this.label_crear_apellido.TabIndex = 4;
            this.label_crear_apellido.Text = "Apellido";
            // 
            // textBox_crear_dir_pisodepto
            // 
            this.textBox_crear_dir_pisodepto.Location = new System.Drawing.Point(318, 262);
            this.textBox_crear_dir_pisodepto.Name = "textBox_crear_dir_pisodepto";
            this.textBox_crear_dir_pisodepto.Size = new System.Drawing.Size(98, 20);
            this.textBox_crear_dir_pisodepto.TabIndex = 20;
            // 
            // comboBox_crear_provincia
            // 
            this.comboBox_crear_provincia.FormattingEnabled = true;
            this.comboBox_crear_provincia.Location = new System.Drawing.Point(390, 27);
            this.comboBox_crear_provincia.Name = "comboBox_crear_provincia";
            this.comboBox_crear_provincia.Size = new System.Drawing.Size(354, 21);
            this.comboBox_crear_provincia.TabIndex = 21;
            // 
            // textBox_crear_dir_numero
            // 
            this.textBox_crear_dir_numero.Location = new System.Drawing.Point(119, 265);
            this.textBox_crear_dir_numero.Name = "textBox_crear_dir_numero";
            this.textBox_crear_dir_numero.Size = new System.Drawing.Size(98, 20);
            this.textBox_crear_dir_numero.TabIndex = 19;
            // 
            // label_crear_telefono
            // 
            this.label_crear_telefono.AutoSize = true;
            this.label_crear_telefono.Location = new System.Drawing.Point(46, 171);
            this.label_crear_telefono.Name = "label_crear_telefono";
            this.label_crear_telefono.Size = new System.Drawing.Size(49, 13);
            this.label_crear_telefono.TabIndex = 5;
            this.label_crear_telefono.Text = "Teléfono";
            // 
            // textBox_crear_dir_calle
            // 
            this.textBox_crear_dir_calle.Location = new System.Drawing.Point(119, 228);
            this.textBox_crear_dir_calle.Name = "textBox_crear_dir_calle";
            this.textBox_crear_dir_calle.Size = new System.Drawing.Size(187, 20);
            this.textBox_crear_dir_calle.TabIndex = 18;
            // 
            // label_crear_provincia
            // 
            this.label_crear_provincia.AutoSize = true;
            this.label_crear_provincia.Location = new System.Drawing.Point(333, 31);
            this.label_crear_provincia.Name = "label_crear_provincia";
            this.label_crear_provincia.Size = new System.Drawing.Size(51, 13);
            this.label_crear_provincia.TabIndex = 10;
            this.label_crear_provincia.Text = "Provincia";
            // 
            // label1_crear_pisodep
            // 
            this.label1_crear_pisodep.AutoSize = true;
            this.label1_crear_pisodep.Location = new System.Drawing.Point(245, 265);
            this.label1_crear_pisodep.Name = "label1_crear_pisodep";
            this.label1_crear_pisodep.Size = new System.Drawing.Size(61, 13);
            this.label1_crear_pisodep.TabIndex = 9;
            this.label1_crear_pisodep.Text = "Piso/Depto";
            // 
            // textBox_crear_nombre
            // 
            this.textBox_crear_nombre.Location = new System.Drawing.Point(119, 28);
            this.textBox_crear_nombre.Name = "textBox_crear_nombre";
            this.textBox_crear_nombre.Size = new System.Drawing.Size(187, 20);
            this.textBox_crear_nombre.TabIndex = 13;
            // 
            // label_crear_dir_calle
            // 
            this.label_crear_dir_calle.AutoSize = true;
            this.label_crear_dir_calle.Location = new System.Drawing.Point(65, 231);
            this.label_crear_dir_calle.Name = "label_crear_dir_calle";
            this.label_crear_dir_calle.Size = new System.Drawing.Size(30, 13);
            this.label_crear_dir_calle.TabIndex = 8;
            this.label_crear_dir_calle.Text = "Calle";
            // 
            // textBox_crear_apellido
            // 
            this.textBox_crear_apellido.Location = new System.Drawing.Point(119, 60);
            this.textBox_crear_apellido.Name = "textBox_crear_apellido";
            this.textBox_crear_apellido.Size = new System.Drawing.Size(187, 20);
            this.textBox_crear_apellido.TabIndex = 14;
            // 
            // label_crear_dir_num
            // 
            this.label_crear_dir_num.AutoSize = true;
            this.label_crear_dir_num.Location = new System.Drawing.Point(51, 268);
            this.label_crear_dir_num.Name = "label_crear_dir_num";
            this.label_crear_dir_num.Size = new System.Drawing.Size(44, 13);
            this.label_crear_dir_num.TabIndex = 7;
            this.label_crear_dir_num.Text = "Número";
            // 
            // textBox_crear_tel
            // 
            this.textBox_crear_tel.Location = new System.Drawing.Point(119, 168);
            this.textBox_crear_tel.Name = "textBox_crear_tel";
            this.textBox_crear_tel.Size = new System.Drawing.Size(187, 20);
            this.textBox_crear_tel.TabIndex = 17;
            // 
            // label_crear_direccion
            // 
            this.label_crear_direccion.AutoSize = true;
            this.label_crear_direccion.Location = new System.Drawing.Point(43, 203);
            this.label_crear_direccion.Name = "label_crear_direccion";
            this.label_crear_direccion.Size = new System.Drawing.Size(52, 13);
            this.label_crear_direccion.TabIndex = 6;
            this.label_crear_direccion.Text = "Direccion";
            // 
            // textBox_crear_dni
            // 
            this.textBox_crear_dni.Location = new System.Drawing.Point(119, 96);
            this.textBox_crear_dni.Name = "textBox_crear_dni";
            this.textBox_crear_dni.Size = new System.Drawing.Size(187, 20);
            this.textBox_crear_dni.TabIndex = 15;
            // 
            // textBox_crear_email
            // 
            this.textBox_crear_email.Location = new System.Drawing.Point(119, 133);
            this.textBox_crear_email.Name = "textBox_crear_email";
            this.textBox_crear_email.Size = new System.Drawing.Size(187, 20);
            this.textBox_crear_email.TabIndex = 16;
            // 
            // button_crear_limpliar
            // 
            this.button_crear_limpliar.Location = new System.Drawing.Point(57, 426);
            this.button_crear_limpliar.Name = "button_crear_limpliar";
            this.button_crear_limpliar.Size = new System.Drawing.Size(137, 26);
            this.button_crear_limpliar.TabIndex = 26;
            this.button_crear_limpliar.Text = "Limpiar";
            this.button_crear_limpliar.UseVisualStyleBackColor = true;
            this.button_crear_limpliar.Click += new System.EventHandler(this.button_crear_limpliar_Click);
            // 
            // button_crear_aceptar
            // 
            this.button_crear_aceptar.Location = new System.Drawing.Point(711, 426);
            this.button_crear_aceptar.Name = "button_crear_aceptar";
            this.button_crear_aceptar.Size = new System.Drawing.Size(137, 26);
            this.button_crear_aceptar.TabIndex = 24;
            this.button_crear_aceptar.Text = "Aceptar";
            this.button_crear_aceptar.UseVisualStyleBackColor = true;
            this.button_crear_aceptar.Click += new System.EventHandler(this.button_crear_aceptar_Click);
            // 
            // tabPage_model_emp
            // 
            this.tabPage_model_emp.Controls.Add(this.dataGridView_resultado_busqueda);
            this.tabPage_model_emp.Controls.Add(this.groupBox2);
            this.tabPage_model_emp.Controls.Add(this.button_model_limpiar);
            this.tabPage_model_emp.Controls.Add(this.button_model_buscar_database);
            this.tabPage_model_emp.Location = new System.Drawing.Point(4, 22);
            this.tabPage_model_emp.Name = "tabPage_model_emp";
            this.tabPage_model_emp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_model_emp.Size = new System.Drawing.Size(919, 574);
            this.tabPage_model_emp.TabIndex = 1;
            this.tabPage_model_emp.Text = "Modificar/ Eliminar";
            this.tabPage_model_emp.UseVisualStyleBackColor = true;
            this.tabPage_model_emp.Click += new System.EventHandler(this.tabPage_model_emp_Click);
            // 
            // dataGridView_resultado_busqueda
            // 
            this.dataGridView_resultado_busqueda.AllowUserToAddRows = false;
            this.dataGridView_resultado_busqueda.AllowUserToDeleteRows = false;
            this.dataGridView_resultado_busqueda.AllowUserToResizeRows = false;
            this.dataGridView_resultado_busqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_resultado_busqueda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_resultado_busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resultado_busqueda.GridColor = System.Drawing.Color.White;
            this.dataGridView_resultado_busqueda.Location = new System.Drawing.Point(19, 186);
            this.dataGridView_resultado_busqueda.Name = "dataGridView_resultado_busqueda";
            this.dataGridView_resultado_busqueda.ReadOnly = true;
            this.dataGridView_resultado_busqueda.RowHeadersVisible = false;
            this.dataGridView_resultado_busqueda.Size = new System.Drawing.Size(877, 382);
            this.dataGridView_resultado_busqueda.TabIndex = 53;
            this.dataGridView_resultado_busqueda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionar_celda);
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
            this.groupBox2.Controls.Add(this.comboBox_model_buscar_provincias);
            this.groupBox2.Location = new System.Drawing.Point(19, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(877, 104);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterio de Busqueda";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "DNI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Apellido";
            // 
            // textBox_model_buscar_nombre
            // 
            this.textBox_model_buscar_nombre.Location = new System.Drawing.Point(93, 27);
            this.textBox_model_buscar_nombre.Name = "textBox_model_buscar_nombre";
            this.textBox_model_buscar_nombre.Size = new System.Drawing.Size(187, 20);
            this.textBox_model_buscar_nombre.TabIndex = 33;
            // 
            // textBox_model_buscar_apellido
            // 
            this.textBox_model_buscar_apellido.Location = new System.Drawing.Point(93, 59);
            this.textBox_model_buscar_apellido.Name = "textBox_model_buscar_apellido";
            this.textBox_model_buscar_apellido.Size = new System.Drawing.Size(187, 20);
            this.textBox_model_buscar_apellido.TabIndex = 34;
            // 
            // textBox_model_buscar_dni
            // 
            this.textBox_model_buscar_dni.Location = new System.Drawing.Point(416, 62);
            this.textBox_model_buscar_dni.Name = "textBox_model_buscar_dni";
            this.textBox_model_buscar_dni.Size = new System.Drawing.Size(187, 20);
            this.textBox_model_buscar_dni.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Provincia";
            // 
            // comboBox_model_buscar_provincias
            // 
            this.comboBox_model_buscar_provincias.FormattingEnabled = true;
            this.comboBox_model_buscar_provincias.Location = new System.Drawing.Point(416, 24);
            this.comboBox_model_buscar_provincias.Name = "comboBox_model_buscar_provincias";
            this.comboBox_model_buscar_provincias.Size = new System.Drawing.Size(311, 21);
            this.comboBox_model_buscar_provincias.TabIndex = 27;
            // 
            // button_model_limpiar
            // 
            this.button_model_limpiar.Location = new System.Drawing.Point(19, 152);
            this.button_model_limpiar.Name = "button_model_limpiar";
            this.button_model_limpiar.Size = new System.Drawing.Size(98, 27);
            this.button_model_limpiar.TabIndex = 51;
            this.button_model_limpiar.Text = "Limpiar";
            this.button_model_limpiar.UseVisualStyleBackColor = true;
            this.button_model_limpiar.Click += new System.EventHandler(this.button_model_limpiar_Click);
            // 
            // button_model_buscar_database
            // 
            this.button_model_buscar_database.Location = new System.Drawing.Point(798, 152);
            this.button_model_buscar_database.Name = "button_model_buscar_database";
            this.button_model_buscar_database.Size = new System.Drawing.Size(98, 27);
            this.button_model_buscar_database.TabIndex = 36;
            this.button_model_buscar_database.Text = "Buscar";
            this.button_model_buscar_database.UseVisualStyleBackColor = true;
            this.button_model_buscar_database.Click += new System.EventHandler(this.button_model_buscar_database_Click);
            // 
            // button_crear_salir
            // 
            this.button_crear_salir.Location = new System.Drawing.Point(798, 620);
            this.button_crear_salir.Name = "button_crear_salir";
            this.button_crear_salir.Size = new System.Drawing.Size(137, 26);
            this.button_crear_salir.TabIndex = 25;
            this.button_crear_salir.Text = "Salir";
            this.button_crear_salir.UseVisualStyleBackColor = true;
            this.button_crear_salir.Click += new System.EventHandler(this.button_crear_salir_Click);
            // 
            // FormAbmCliente
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 658);
            this.Controls.Add(this.tabControl_mod_eli);
            this.Controls.Add(this.button_crear_salir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAbmCliente";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM de Cliente";
            this.Load += new System.EventHandler(this.FormAmbClienteLoad);
            this.tabControl_mod_eli.ResumeLayout(false);
            this.tabPage_crear_emp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage_model_emp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resultado_busqueda)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_mod_eli;
        private System.Windows.Forms.TabPage tabPage_crear_emp;
        private System.Windows.Forms.Button button_crear_salir;
        private System.Windows.Forms.Button button_crear_aceptar;
        private System.Windows.Forms.ComboBox comboBox_crear_provincia;
        private System.Windows.Forms.TextBox textBox_crear_dir_pisodepto;
        private System.Windows.Forms.TextBox textBox_crear_dir_numero;
        private System.Windows.Forms.TextBox textBox_crear_dir_calle;
        private System.Windows.Forms.TextBox textBox_crear_tel;
        private System.Windows.Forms.TextBox textBox_crear_email;
        private System.Windows.Forms.TextBox textBox_crear_dni;
        private System.Windows.Forms.TextBox textBox_crear_apellido;
        private System.Windows.Forms.TextBox textBox_crear_nombre;
        private System.Windows.Forms.Label label_crear_provincia;
        private System.Windows.Forms.Label label1_crear_pisodep;
        private System.Windows.Forms.Label label_crear_dir_calle;
        private System.Windows.Forms.Label label_crear_dir_num;
        private System.Windows.Forms.Label label_crear_direccion;
        private System.Windows.Forms.Label label_crear_telefono;
        private System.Windows.Forms.Label label_crear_apellido;
        private System.Windows.Forms.Label label_crear_dni;
        private System.Windows.Forms.Label label_crear_email;
        private System.Windows.Forms.Label label_crear_nombre;
        private System.Windows.Forms.TabPage tabPage_model_emp;
        private System.Windows.Forms.Button button_model_buscar_database;
        private System.Windows.Forms.TextBox textBox_model_buscar_dni;
        private System.Windows.Forms.TextBox textBox_model_buscar_apellido;
        private System.Windows.Forms.TextBox textBox_model_buscar_nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_model_buscar_provincias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_crear_limpliar;
        private System.Windows.Forms.Button button_model_limpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_resultado_busqueda;

    }
}