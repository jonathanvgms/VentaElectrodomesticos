namespace VentaElectrodomesticos.Facturacion
{
    partial class FormFactura
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
            this.dataGridView_listado_prods = new System.Windows.Forms.DataGridView();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.textBox_subtotal = new System.Windows.Forms.TextBox();
            this.textBox_descuento = new System.Windows.Forms.TextBox();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_crear_nombre = new System.Windows.Forms.Label();
            this.label_crear_dni = new System.Windows.Forms.Label();
            this.label_crear_apellido = new System.Windows.Forms.Label();
            this.textBox_nombre = new System.Windows.Forms.TextBox();
            this.textBox_apellido = new System.Windows.Forms.TextBox();
            this.textBox_dni = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_factura_nro = new System.Windows.Forms.TextBox();
            this.textBox_vendedor = new System.Windows.Forms.TextBox();
            this.textBox_fecha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_cant_cuotas = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.Sucursal = new System.Windows.Forms.GroupBox();
            this.textBox_direccion = new System.Windows.Forms.TextBox();
            this.textBox_provincia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listado_prods)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Sucursal.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_listado_prods
            // 
            this.dataGridView_listado_prods.AllowUserToAddRows = false;
            this.dataGridView_listado_prods.AllowUserToDeleteRows = false;
            this.dataGridView_listado_prods.AllowUserToResizeRows = false;
            this.dataGridView_listado_prods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_listado_prods.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_listado_prods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_listado_prods.GridColor = System.Drawing.Color.White;
            this.dataGridView_listado_prods.Location = new System.Drawing.Point(17, 316);
            this.dataGridView_listado_prods.Name = "dataGridView_listado_prods";
            this.dataGridView_listado_prods.ReadOnly = true;
            this.dataGridView_listado_prods.RowHeadersVisible = false;
            this.dataGridView_listado_prods.Size = new System.Drawing.Size(647, 217);
            this.dataGridView_listado_prods.TabIndex = 0;
            this.dataGridView_listado_prods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_listado_prods_CellContentClick);
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(567, 608);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(97, 26);
            this.button_aceptar.TabIndex = 1;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // textBox_subtotal
            // 
            this.textBox_subtotal.Enabled = false;
            this.textBox_subtotal.Location = new System.Drawing.Point(285, 565);
            this.textBox_subtotal.Name = "textBox_subtotal";
            this.textBox_subtotal.Size = new System.Drawing.Size(100, 20);
            this.textBox_subtotal.TabIndex = 2;
            // 
            // textBox_descuento
            // 
            this.textBox_descuento.Enabled = false;
            this.textBox_descuento.Location = new System.Drawing.Point(423, 565);
            this.textBox_descuento.Name = "textBox_descuento";
            this.textBox_descuento.Size = new System.Drawing.Size(100, 20);
            this.textBox_descuento.TabIndex = 3;
            // 
            // textBox_total
            // 
            this.textBox_total.Enabled = false;
            this.textBox_total.Location = new System.Drawing.Point(564, 565);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.Size = new System.Drawing.Size(100, 20);
            this.textBox_total.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 550);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "SUBTOTAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 550);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "DESCUENTO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(564, 550);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "TOTAL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_crear_nombre);
            this.groupBox1.Controls.Add(this.label_crear_dni);
            this.groupBox1.Controls.Add(this.label_crear_apellido);
            this.groupBox1.Controls.Add(this.textBox_nombre);
            this.groupBox1.Controls.Add(this.textBox_apellido);
            this.groupBox1.Controls.Add(this.textBox_dni);
            this.groupBox1.Location = new System.Drawing.Point(17, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 132);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cliente";
            // 
            // label_crear_nombre
            // 
            this.label_crear_nombre.AutoSize = true;
            this.label_crear_nombre.Location = new System.Drawing.Point(19, 22);
            this.label_crear_nombre.Name = "label_crear_nombre";
            this.label_crear_nombre.Size = new System.Drawing.Size(44, 13);
            this.label_crear_nombre.TabIndex = 16;
            this.label_crear_nombre.Text = "Nombre";
            // 
            // label_crear_dni
            // 
            this.label_crear_dni.AutoSize = true;
            this.label_crear_dni.Location = new System.Drawing.Point(37, 97);
            this.label_crear_dni.Name = "label_crear_dni";
            this.label_crear_dni.Size = new System.Drawing.Size(26, 13);
            this.label_crear_dni.TabIndex = 17;
            this.label_crear_dni.Text = "DNI";
            // 
            // label_crear_apellido
            // 
            this.label_crear_apellido.AutoSize = true;
            this.label_crear_apellido.Location = new System.Drawing.Point(19, 59);
            this.label_crear_apellido.Name = "label_crear_apellido";
            this.label_crear_apellido.Size = new System.Drawing.Size(44, 13);
            this.label_crear_apellido.TabIndex = 18;
            this.label_crear_apellido.Text = "Apellido";
            // 
            // textBox_nombre
            // 
            this.textBox_nombre.Enabled = false;
            this.textBox_nombre.Location = new System.Drawing.Point(87, 19);
            this.textBox_nombre.Name = "textBox_nombre";
            this.textBox_nombre.Size = new System.Drawing.Size(187, 20);
            this.textBox_nombre.TabIndex = 19;
            // 
            // textBox_apellido
            // 
            this.textBox_apellido.Enabled = false;
            this.textBox_apellido.Location = new System.Drawing.Point(87, 56);
            this.textBox_apellido.Name = "textBox_apellido";
            this.textBox_apellido.Size = new System.Drawing.Size(187, 20);
            this.textBox_apellido.TabIndex = 20;
            // 
            // textBox_dni
            // 
            this.textBox_dni.Enabled = false;
            this.textBox_dni.Location = new System.Drawing.Point(87, 94);
            this.textBox_dni.Name = "textBox_dni";
            this.textBox_dni.Size = new System.Drawing.Size(187, 20);
            this.textBox_dni.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_factura_nro);
            this.groupBox2.Controls.Add(this.textBox_vendedor);
            this.groupBox2.Controls.Add(this.textBox_fecha);
            this.groupBox2.Location = new System.Drawing.Point(345, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 139);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Factura";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Vendedor";
            // 
            // textBox_factura_nro
            // 
            this.textBox_factura_nro.Enabled = false;
            this.textBox_factura_nro.Location = new System.Drawing.Point(98, 29);
            this.textBox_factura_nro.Name = "textBox_factura_nro";
            this.textBox_factura_nro.Size = new System.Drawing.Size(187, 20);
            this.textBox_factura_nro.TabIndex = 25;
            // 
            // textBox_vendedor
            // 
            this.textBox_vendedor.Enabled = false;
            this.textBox_vendedor.Location = new System.Drawing.Point(98, 62);
            this.textBox_vendedor.Name = "textBox_vendedor";
            this.textBox_vendedor.Size = new System.Drawing.Size(187, 20);
            this.textBox_vendedor.TabIndex = 26;
            // 
            // textBox_fecha
            // 
            this.textBox_fecha.Enabled = false;
            this.textBox_fecha.Location = new System.Drawing.Point(98, 98);
            this.textBox_fecha.Name = "textBox_fecha";
            this.textBox_fecha.Size = new System.Drawing.Size(187, 20);
            this.textBox_fecha.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 550);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "CANTIDAD CUOTAS";
            // 
            // textBox_cant_cuotas
            // 
            this.textBox_cant_cuotas.Enabled = false;
            this.textBox_cant_cuotas.Location = new System.Drawing.Point(17, 565);
            this.textBox_cant_cuotas.Name = "textBox_cant_cuotas";
            this.textBox_cant_cuotas.Size = new System.Drawing.Size(100, 20);
            this.textBox_cant_cuotas.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VentaElectrodomesticos.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(17, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(20, 608);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(97, 26);
            this.button_cancelar.TabIndex = 13;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // Sucursal
            // 
            this.Sucursal.Controls.Add(this.textBox_direccion);
            this.Sucursal.Controls.Add(this.textBox_provincia);
            this.Sucursal.Controls.Add(this.label9);
            this.Sucursal.Controls.Add(this.label8);
            this.Sucursal.Location = new System.Drawing.Point(345, 169);
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.Size = new System.Drawing.Size(319, 110);
            this.Sucursal.TabIndex = 14;
            this.Sucursal.TabStop = false;
            this.Sucursal.Text = "Sucursal";
            this.Sucursal.Enter += new System.EventHandler(this.Sucursal_Enter);
            // 
            // textBox_direccion
            // 
            this.textBox_direccion.Enabled = false;
            this.textBox_direccion.Location = new System.Drawing.Point(95, 66);
            this.textBox_direccion.Name = "textBox_direccion";
            this.textBox_direccion.Size = new System.Drawing.Size(187, 20);
            this.textBox_direccion.TabIndex = 35;
            // 
            // textBox_provincia
            // 
            this.textBox_provincia.Enabled = false;
            this.textBox_provincia.Location = new System.Drawing.Point(95, 24);
            this.textBox_provincia.Name = "textBox_provincia";
            this.textBox_provincia.Size = new System.Drawing.Size(187, 20);
            this.textBox_provincia.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Direccion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Provincia";
            // 
            // FormFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 651);
            this.Controls.Add(this.Sucursal);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_cant_cuotas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_total);
            this.Controls.Add(this.textBox_descuento);
            this.Controls.Add(this.textBox_subtotal);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.dataGridView_listado_prods);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormFactura";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.FormFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_listado_prods)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Sucursal.ResumeLayout(false);
            this.Sucursal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_listado_prods;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.TextBox textBox_subtotal;
        private System.Windows.Forms.TextBox textBox_descuento;
        private System.Windows.Forms.TextBox textBox_total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_crear_nombre;
        private System.Windows.Forms.Label label_crear_dni;
        private System.Windows.Forms.Label label_crear_apellido;
        private System.Windows.Forms.TextBox textBox_nombre;
        private System.Windows.Forms.TextBox textBox_apellido;
        private System.Windows.Forms.TextBox textBox_dni;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_factura_nro;
        private System.Windows.Forms.TextBox textBox_vendedor;
        private System.Windows.Forms.TextBox textBox_fecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_cant_cuotas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.GroupBox Sucursal;
        private System.Windows.Forms.TextBox textBox_direccion;
        private System.Windows.Forms.TextBox textBox_provincia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}