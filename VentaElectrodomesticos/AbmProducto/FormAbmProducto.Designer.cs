namespace VentaElectrodomesticos.AbmProducto
{
    partial class FormAbmProducto
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
            this.button_crear_limpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_categoria_seleccionada = new System.Windows.Forms.TextBox();
            this.button_seleccionar_categoria = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_crear_marca = new System.Windows.Forms.TextBox();
            this.textBox_codigo_producto = new System.Windows.Forms.TextBox();
            this.label_crear_nombre = new System.Windows.Forms.Label();
            this.label_crear_dni = new System.Windows.Forms.Label();
            this.label_crear_apellido = new System.Windows.Forms.Label();
            this.label_crear_dir_num = new System.Windows.Forms.Label();
            this.textBox_crear_precio = new System.Windows.Forms.TextBox();
            this.textBox_crear_descripcion = new System.Windows.Forms.TextBox();
            this.textBox_crear_nombre = new System.Windows.Forms.TextBox();
            this.button_crear_aceptar = new System.Windows.Forms.Button();
            this.tabPage__modeli_emp = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_precio_end = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_precio_init = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_buscar_marca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_buscar_categoria = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_buscar_codprod = new System.Windows.Forms.TextBox();
            this.textBox_buscar_nom_mar = new System.Windows.Forms.TextBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_buscar_database = new System.Windows.Forms.Button();
            this.button_crear_salir = new System.Windows.Forms.Button();
            this.tabControl_mod_eli.SuspendLayout();
            this.tabPage_crear_emp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage__modeli_emp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_mod_eli
            // 
            this.tabControl_mod_eli.Controls.Add(this.tabPage_crear_emp);
            this.tabControl_mod_eli.Controls.Add(this.tabPage__modeli_emp);
            this.tabControl_mod_eli.Location = new System.Drawing.Point(12, 12);
            this.tabControl_mod_eli.Name = "tabControl_mod_eli";
            this.tabControl_mod_eli.SelectedIndex = 0;
            this.tabControl_mod_eli.Size = new System.Drawing.Size(817, 635);
            this.tabControl_mod_eli.TabIndex = 1;
            // 
            // tabPage_crear_emp
            // 
            this.tabPage_crear_emp.Controls.Add(this.button_crear_limpiar);
            this.tabPage_crear_emp.Controls.Add(this.groupBox1);
            this.tabPage_crear_emp.Controls.Add(this.button_crear_aceptar);
            this.tabPage_crear_emp.Location = new System.Drawing.Point(4, 22);
            this.tabPage_crear_emp.Name = "tabPage_crear_emp";
            this.tabPage_crear_emp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_crear_emp.Size = new System.Drawing.Size(809, 609);
            this.tabPage_crear_emp.TabIndex = 0;
            this.tabPage_crear_emp.Text = "Crear";
            this.tabPage_crear_emp.UseVisualStyleBackColor = true;
            // 
            // button_crear_limpiar
            // 
            this.button_crear_limpiar.Location = new System.Drawing.Point(100, 459);
            this.button_crear_limpiar.Name = "button_crear_limpiar";
            this.button_crear_limpiar.Size = new System.Drawing.Size(137, 26);
            this.button_crear_limpiar.TabIndex = 27;
            this.button_crear_limpiar.Text = "Limpiar";
            this.button_crear_limpiar.UseVisualStyleBackColor = true;
            this.button_crear_limpiar.Click += new System.EventHandler(this.button_crear_limpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBox_categoria_seleccionada);
            this.groupBox1.Controls.Add(this.button_seleccionar_categoria);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox_crear_marca);
            this.groupBox1.Controls.Add(this.textBox_codigo_producto);
            this.groupBox1.Controls.Add(this.label_crear_nombre);
            this.groupBox1.Controls.Add(this.label_crear_dni);
            this.groupBox1.Controls.Add(this.label_crear_apellido);
            this.groupBox1.Controls.Add(this.label_crear_dir_num);
            this.groupBox1.Controls.Add(this.textBox_crear_precio);
            this.groupBox1.Controls.Add(this.textBox_crear_descripcion);
            this.groupBox1.Controls.Add(this.textBox_crear_nombre);
            this.groupBox1.Location = new System.Drawing.Point(100, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 334);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulario para un Nuevo Producto";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(82, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Categoria";
            // 
            // textBox_categoria_seleccionada
            // 
            this.textBox_categoria_seleccionada.Location = new System.Drawing.Point(158, 212);
            this.textBox_categoria_seleccionada.Name = "textBox_categoria_seleccionada";
            this.textBox_categoria_seleccionada.Size = new System.Drawing.Size(271, 20);
            this.textBox_categoria_seleccionada.TabIndex = 28;
            // 
            // button_seleccionar_categoria
            // 
            this.button_seleccionar_categoria.Location = new System.Drawing.Point(456, 209);
            this.button_seleccionar_categoria.Name = "button_seleccionar_categoria";
            this.button_seleccionar_categoria.Size = new System.Drawing.Size(99, 24);
            this.button_seleccionar_categoria.TabIndex = 27;
            this.button_seleccionar_categoria.Text = "Seleccionar ";
            this.button_seleccionar_categoria.UseVisualStyleBackColor = true;
            this.button_seleccionar_categoria.Click += new System.EventHandler(this.button_seleccionar_categoria_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(97, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Marca";
            // 
            // textBox_crear_marca
            // 
            this.textBox_crear_marca.Location = new System.Drawing.Point(158, 128);
            this.textBox_crear_marca.Name = "textBox_crear_marca";
            this.textBox_crear_marca.Size = new System.Drawing.Size(187, 20);
            this.textBox_crear_marca.TabIndex = 25;
            // 
            // textBox_codigo_producto
            // 
            this.textBox_codigo_producto.Enabled = false;
            this.textBox_codigo_producto.Location = new System.Drawing.Point(158, 49);
            this.textBox_codigo_producto.Name = "textBox_codigo_producto";
            this.textBox_codigo_producto.Size = new System.Drawing.Size(187, 20);
            this.textBox_codigo_producto.TabIndex = 24;
            // 
            // label_crear_nombre
            // 
            this.label_crear_nombre.AutoSize = true;
            this.label_crear_nombre.Location = new System.Drawing.Point(33, 52);
            this.label_crear_nombre.Name = "label_crear_nombre";
            this.label_crear_nombre.Size = new System.Drawing.Size(101, 13);
            this.label_crear_nombre.TabIndex = 0;
            this.label_crear_nombre.Text = "Codigo de Producto";
            // 
            // label_crear_dni
            // 
            this.label_crear_dni.AutoSize = true;
            this.label_crear_dni.Location = new System.Drawing.Point(71, 169);
            this.label_crear_dni.Name = "label_crear_dni";
            this.label_crear_dni.Size = new System.Drawing.Size(63, 13);
            this.label_crear_dni.TabIndex = 3;
            this.label_crear_dni.Text = "Descripcion";
            // 
            // label_crear_apellido
            // 
            this.label_crear_apellido.AutoSize = true;
            this.label_crear_apellido.Location = new System.Drawing.Point(90, 87);
            this.label_crear_apellido.Name = "label_crear_apellido";
            this.label_crear_apellido.Size = new System.Drawing.Size(44, 13);
            this.label_crear_apellido.TabIndex = 4;
            this.label_crear_apellido.Text = "Nombre";
            // 
            // label_crear_dir_num
            // 
            this.label_crear_dir_num.AutoSize = true;
            this.label_crear_dir_num.Location = new System.Drawing.Point(44, 261);
            this.label_crear_dir_num.Name = "label_crear_dir_num";
            this.label_crear_dir_num.Size = new System.Drawing.Size(90, 13);
            this.label_crear_dir_num.TabIndex = 7;
            this.label_crear_dir_num.Text = "Precio (en Pesos)";
            // 
            // textBox_crear_precio
            // 
            this.textBox_crear_precio.Location = new System.Drawing.Point(158, 258);
            this.textBox_crear_precio.Name = "textBox_crear_precio";
            this.textBox_crear_precio.Size = new System.Drawing.Size(98, 20);
            this.textBox_crear_precio.TabIndex = 19;
            // 
            // textBox_crear_descripcion
            // 
            this.textBox_crear_descripcion.Location = new System.Drawing.Point(158, 169);
            this.textBox_crear_descripcion.Name = "textBox_crear_descripcion";
            this.textBox_crear_descripcion.Size = new System.Drawing.Size(397, 20);
            this.textBox_crear_descripcion.TabIndex = 15;
            // 
            // textBox_crear_nombre
            // 
            this.textBox_crear_nombre.Location = new System.Drawing.Point(158, 84);
            this.textBox_crear_nombre.Name = "textBox_crear_nombre";
            this.textBox_crear_nombre.Size = new System.Drawing.Size(187, 20);
            this.textBox_crear_nombre.TabIndex = 14;
            // 
            // button_crear_aceptar
            // 
            this.button_crear_aceptar.Location = new System.Drawing.Point(571, 459);
            this.button_crear_aceptar.Name = "button_crear_aceptar";
            this.button_crear_aceptar.Size = new System.Drawing.Size(137, 26);
            this.button_crear_aceptar.TabIndex = 24;
            this.button_crear_aceptar.Text = "Aceptar";
            this.button_crear_aceptar.UseVisualStyleBackColor = true;
            this.button_crear_aceptar.Click += new System.EventHandler(this.button_crear_aceptar_Click);
            // 
            // tabPage__modeli_emp
            // 
            this.tabPage__modeli_emp.Controls.Add(this.dataGridView1);
            this.tabPage__modeli_emp.Controls.Add(this.groupBox2);
            this.tabPage__modeli_emp.Controls.Add(this.button_limpiar);
            this.tabPage__modeli_emp.Controls.Add(this.button_buscar_database);
            this.tabPage__modeli_emp.Location = new System.Drawing.Point(4, 22);
            this.tabPage__modeli_emp.Name = "tabPage__modeli_emp";
            this.tabPage__modeli_emp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage__modeli_emp.Size = new System.Drawing.Size(809, 609);
            this.tabPage__modeli_emp.TabIndex = 1;
            this.tabPage__modeli_emp.Text = "Modificar/ Eliminar";
            this.tabPage__modeli_emp.UseVisualStyleBackColor = true;
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
            this.dataGridView1.Location = new System.Drawing.Point(19, 233);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(771, 360);
            this.dataGridView1.TabIndex = 67;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionar_producto);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_precio_end);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_precio_init);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_buscar_marca);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox_buscar_categoria);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_buscar_codprod);
            this.groupBox2.Controls.Add(this.textBox_buscar_nom_mar);
            this.groupBox2.Location = new System.Drawing.Point(19, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(771, 151);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterio de Busqueda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(589, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "a";
            // 
            // textBox_precio_end
            // 
            this.textBox_precio_end.Location = new System.Drawing.Point(622, 67);
            this.textBox_precio_end.Name = "textBox_precio_end";
            this.textBox_precio_end.Size = new System.Drawing.Size(79, 20);
            this.textBox_precio_end.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(438, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Precio";
            // 
            // textBox_precio_init
            // 
            this.textBox_precio_init.Location = new System.Drawing.Point(493, 67);
            this.textBox_precio_init.Name = "textBox_precio_init";
            this.textBox_precio_init.Size = new System.Drawing.Size(79, 20);
            this.textBox_precio_init.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Marca";
            // 
            // textBox_buscar_marca
            // 
            this.textBox_buscar_marca.Location = new System.Drawing.Point(493, 27);
            this.textBox_buscar_marca.Name = "textBox_buscar_marca";
            this.textBox_buscar_marca.Size = new System.Drawing.Size(139, 20);
            this.textBox_buscar_marca.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Categoria";
            // 
            // textBox_buscar_categoria
            // 
            this.textBox_buscar_categoria.Enabled = false;
            this.textBox_buscar_categoria.Location = new System.Drawing.Point(141, 114);
            this.textBox_buscar_categoria.Name = "textBox_buscar_categoria";
            this.textBox_buscar_categoria.Size = new System.Drawing.Size(271, 20);
            this.textBox_buscar_categoria.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 24);
            this.button1.TabIndex = 30;
            this.button1.Text = "Seleccionar ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Código de Producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Nombre";
            // 
            // textBox_buscar_codprod
            // 
            this.textBox_buscar_codprod.Location = new System.Drawing.Point(141, 31);
            this.textBox_buscar_codprod.Name = "textBox_buscar_codprod";
            this.textBox_buscar_codprod.Size = new System.Drawing.Size(187, 20);
            this.textBox_buscar_codprod.TabIndex = 27;
            // 
            // textBox_buscar_nom_mar
            // 
            this.textBox_buscar_nom_mar.Location = new System.Drawing.Point(141, 71);
            this.textBox_buscar_nom_mar.Name = "textBox_buscar_nom_mar";
            this.textBox_buscar_nom_mar.Size = new System.Drawing.Size(187, 20);
            this.textBox_buscar_nom_mar.TabIndex = 28;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(19, 190);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(117, 29);
            this.button_limpiar.TabIndex = 65;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_buscar_database
            // 
            this.button_buscar_database.Location = new System.Drawing.Point(676, 190);
            this.button_buscar_database.Name = "button_buscar_database";
            this.button_buscar_database.Size = new System.Drawing.Size(115, 29);
            this.button_buscar_database.TabIndex = 64;
            this.button_buscar_database.Text = "Buscar ";
            this.button_buscar_database.UseVisualStyleBackColor = true;
            this.button_buscar_database.Click += new System.EventHandler(this.button_buscar_database_Click_1);
            // 
            // button_crear_salir
            // 
            this.button_crear_salir.Location = new System.Drawing.Point(692, 669);
            this.button_crear_salir.Name = "button_crear_salir";
            this.button_crear_salir.Size = new System.Drawing.Size(137, 26);
            this.button_crear_salir.TabIndex = 25;
            this.button_crear_salir.Text = "Salir";
            this.button_crear_salir.UseVisualStyleBackColor = true;
            this.button_crear_salir.Click += new System.EventHandler(this.button_crear_salir_Click);
            // 
            // FormAbmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 707);
            this.Controls.Add(this.tabControl_mod_eli);
            this.Controls.Add(this.button_crear_salir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormAbmProducto";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Producto";
            this.Load += new System.EventHandler(this.FormAbmProducto_Load);
            this.tabControl_mod_eli.ResumeLayout(false);
            this.tabPage_crear_emp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage__modeli_emp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_mod_eli;
        private System.Windows.Forms.TabPage tabPage_crear_emp;
        private System.Windows.Forms.Button button_crear_salir;
        private System.Windows.Forms.Button button_crear_aceptar;
        private System.Windows.Forms.TextBox textBox_crear_precio;
        private System.Windows.Forms.TextBox textBox_crear_descripcion;
        private System.Windows.Forms.TextBox textBox_crear_nombre;
        private System.Windows.Forms.Label label_crear_dir_num;
        private System.Windows.Forms.Label label_crear_apellido;
        private System.Windows.Forms.Label label_crear_dni;
        private System.Windows.Forms.TabPage tabPage__modeli_emp;
        private System.Windows.Forms.Button button_crear_limpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_codigo_producto;
        private System.Windows.Forms.Label label_crear_nombre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_crear_marca;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_categoria_seleccionada;
        private System.Windows.Forms.Button button_seleccionar_categoria;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_buscar_marca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_buscar_categoria;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_buscar_codprod;
        private System.Windows.Forms.TextBox textBox_buscar_nom_mar;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_buscar_database;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_precio_end;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_precio_init;
    }
}