namespace VentaElectrodomesticos.Facturacion
{
    partial class FormSelecProductos
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
            this.button_salir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_precion_end = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_precion_init = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_buscar_marca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_buscar_categoria = new System.Windows.Forms.TextBox();
            this.button_selec_categoria = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_buscar_codprod = new System.Windows.Forms.TextBox();
            this.textBox_buscar_nom_mar = new System.Windows.Forms.TextBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_buscar_database = new System.Windows.Forms.Button();
            this.dataGridView_busqueda = new System.Windows.Forms.DataGridView();
            this.dataGridView_carrito = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_borrar_listado = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_busqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_carrito)).BeginInit();
            this.SuspendLayout();
            // 
            // button_salir
            // 
            this.button_salir.Location = new System.Drawing.Point(12, 675);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(123, 28);
            this.button_salir.TabIndex = 71;
            this.button_salir.Text = "Salir";
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button_selec_emp_salir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_precion_end);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_precion_init);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_buscar_marca);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox_buscar_categoria);
            this.groupBox2.Controls.Add(this.button_selec_categoria);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_buscar_codprod);
            this.groupBox2.Controls.Add(this.textBox_buscar_nom_mar);
            this.groupBox2.Location = new System.Drawing.Point(12, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(752, 150);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterio de Busqueda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "a";
            // 
            // textBox_precion_end
            // 
            this.textBox_precion_end.Location = new System.Drawing.Point(628, 65);
            this.textBox_precion_end.Name = "textBox_precion_end";
            this.textBox_precion_end.Size = new System.Drawing.Size(79, 20);
            this.textBox_precion_end.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(444, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Precio";
            // 
            // textBox_precion_init
            // 
            this.textBox_precion_init.Location = new System.Drawing.Point(499, 65);
            this.textBox_precion_init.Name = "textBox_precion_init";
            this.textBox_precion_init.Size = new System.Drawing.Size(79, 20);
            this.textBox_precion_init.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Marca";
            // 
            // textBox_buscar_marca
            // 
            this.textBox_buscar_marca.Location = new System.Drawing.Point(499, 25);
            this.textBox_buscar_marca.Name = "textBox_buscar_marca";
            this.textBox_buscar_marca.Size = new System.Drawing.Size(139, 20);
            this.textBox_buscar_marca.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Categoria";
            // 
            // textBox_buscar_categoria
            // 
            this.textBox_buscar_categoria.Location = new System.Drawing.Point(147, 108);
            this.textBox_buscar_categoria.Name = "textBox_buscar_categoria";
            this.textBox_buscar_categoria.Size = new System.Drawing.Size(271, 20);
            this.textBox_buscar_categoria.TabIndex = 47;
            // 
            // button_selec_categoria
            // 
            this.button_selec_categoria.Location = new System.Drawing.Point(445, 105);
            this.button_selec_categoria.Name = "button_selec_categoria";
            this.button_selec_categoria.Size = new System.Drawing.Size(99, 24);
            this.button_selec_categoria.TabIndex = 46;
            this.button_selec_categoria.Text = "Seleccionar ";
            this.button_selec_categoria.UseVisualStyleBackColor = true;
            this.button_selec_categoria.Click += new System.EventHandler(this.button_selec_categoria_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Código de Producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Nombre";
            // 
            // textBox_buscar_codprod
            // 
            this.textBox_buscar_codprod.Location = new System.Drawing.Point(147, 25);
            this.textBox_buscar_codprod.Name = "textBox_buscar_codprod";
            this.textBox_buscar_codprod.Size = new System.Drawing.Size(187, 20);
            this.textBox_buscar_codprod.TabIndex = 44;
            // 
            // textBox_buscar_nom_mar
            // 
            this.textBox_buscar_nom_mar.Location = new System.Drawing.Point(147, 65);
            this.textBox_buscar_nom_mar.Name = "textBox_buscar_nom_mar";
            this.textBox_buscar_nom_mar.Size = new System.Drawing.Size(187, 20);
            this.textBox_buscar_nom_mar.TabIndex = 45;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(12, 188);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(123, 27);
            this.button_limpiar.TabIndex = 68;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_buscar_database
            // 
            this.button_buscar_database.Location = new System.Drawing.Point(641, 188);
            this.button_buscar_database.Name = "button_buscar_database";
            this.button_buscar_database.Size = new System.Drawing.Size(123, 27);
            this.button_buscar_database.TabIndex = 66;
            this.button_buscar_database.Text = "Buscar";
            this.button_buscar_database.UseVisualStyleBackColor = true;
            this.button_buscar_database.Click += new System.EventHandler(this.button_buscar_database_Click);
            // 
            // dataGridView_busqueda
            // 
            this.dataGridView_busqueda.AllowUserToAddRows = false;
            this.dataGridView_busqueda.AllowUserToDeleteRows = false;
            this.dataGridView_busqueda.AllowUserToResizeRows = false;
            this.dataGridView_busqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_busqueda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_busqueda.GridColor = System.Drawing.Color.White;
            this.dataGridView_busqueda.Location = new System.Drawing.Point(12, 221);
            this.dataGridView_busqueda.Name = "dataGridView_busqueda";
            this.dataGridView_busqueda.ReadOnly = true;
            this.dataGridView_busqueda.RowHeadersVisible = false;
            this.dataGridView_busqueda.Size = new System.Drawing.Size(752, 199);
            this.dataGridView_busqueda.TabIndex = 72;
            this.dataGridView_busqueda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.seleccionar_producto);
            this.dataGridView_busqueda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_busqueda_CellContentClick);
            // 
            // dataGridView_carrito
            // 
            this.dataGridView_carrito.AllowUserToAddRows = false;
            this.dataGridView_carrito.AllowUserToDeleteRows = false;
            this.dataGridView_carrito.AllowUserToResizeRows = false;
            this.dataGridView_carrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_carrito.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_carrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_carrito.GridColor = System.Drawing.Color.White;
            this.dataGridView_carrito.Location = new System.Drawing.Point(12, 461);
            this.dataGridView_carrito.Name = "dataGridView_carrito";
            this.dataGridView_carrito.ReadOnly = true;
            this.dataGridView_carrito.RowHeadersVisible = false;
            this.dataGridView_carrito.Size = new System.Drawing.Size(752, 202);
            this.dataGridView_carrito.TabIndex = 73;
            this.dataGridView_carrito.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.quitar_productos);
            this.dataGridView_carrito.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_carrito_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 442);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "Listado de Productos";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(641, 675);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(123, 28);
            this.button_aceptar.TabIndex = 75;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_borrar_listado
            // 
            this.button_borrar_listado.Location = new System.Drawing.Point(302, 675);
            this.button_borrar_listado.Name = "button_borrar_listado";
            this.button_borrar_listado.Size = new System.Drawing.Size(172, 28);
            this.button_borrar_listado.TabIndex = 76;
            this.button_borrar_listado.Text = "Borrar Listado de Productos";
            this.button_borrar_listado.UseVisualStyleBackColor = true;
            this.button_borrar_listado.Click += new System.EventHandler(this.button_borrar_listado_Click);
            // 
            // FormSelecProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 715);
            this.Controls.Add(this.button_borrar_listado);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView_carrito);
            this.Controls.Add(this.dataGridView_busqueda);
            this.Controls.Add(this.button_salir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button_buscar_database);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormSelecProductos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar Productos";
            this.Load += new System.EventHandler(this.FormSeleccionarProductos_Load_1);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_busqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_carrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_salir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_buscar_database;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_precion_end;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_precion_init;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_buscar_marca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_buscar_categoria;
        private System.Windows.Forms.Button button_selec_categoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_buscar_codprod;
        private System.Windows.Forms.TextBox textBox_buscar_nom_mar;
        private System.Windows.Forms.DataGridView dataGridView_busqueda;
        private System.Windows.Forms.DataGridView dataGridView_carrito;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_borrar_listado;
    }
}