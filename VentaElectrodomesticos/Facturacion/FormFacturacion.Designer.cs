namespace VentaElectrodomesticos.Facturacion
{
    partial class FormFacturacion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_productos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_cant_cuotas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_forma_pago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_descuento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_listado_procducto = new System.Windows.Forms.Button();
            this.button_selec_cliente = new System.Windows.Forms.Button();
            this.textBox_cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_sucursal = new System.Windows.Forms.ComboBox();
            this.Sucursal = new System.Windows.Forms.Label();
            this.comboBox_provincias = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_salir = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_productos);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox_cant_cuotas);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBox_forma_pago);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_descuento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button_listado_procducto);
            this.groupBox1.Controls.Add(this.button_selec_cliente);
            this.groupBox1.Controls.Add(this.textBox_cliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_sucursal);
            this.groupBox1.Controls.Add(this.Sucursal);
            this.groupBox1.Controls.Add(this.comboBox_provincias);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 332);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Realizar una Factura";
            // 
            // textBox_productos
            // 
            this.textBox_productos.Location = new System.Drawing.Point(112, 163);
            this.textBox_productos.Name = "textBox_productos";
            this.textBox_productos.Size = new System.Drawing.Size(254, 20);
            this.textBox_productos.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Productos";
            // 
            // comboBox_cant_cuotas
            // 
            this.comboBox_cant_cuotas.FormattingEnabled = true;
            this.comboBox_cant_cuotas.Location = new System.Drawing.Point(212, 286);
            this.comboBox_cant_cuotas.Name = "comboBox_cant_cuotas";
            this.comboBox_cant_cuotas.Size = new System.Drawing.Size(154, 21);
            this.comboBox_cant_cuotas.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Cantidad Cuotas";
            // 
            // comboBox_forma_pago
            // 
            this.comboBox_forma_pago.FormattingEnabled = true;
            this.comboBox_forma_pago.Location = new System.Drawing.Point(212, 248);
            this.comboBox_forma_pago.Name = "comboBox_forma_pago";
            this.comboBox_forma_pago.Size = new System.Drawing.Size(154, 21);
            this.comboBox_forma_pago.TabIndex = 12;
            this.comboBox_forma_pago.SelectedIndexChanged += new System.EventHandler(this.selec_forma_pago);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Forma de Pago";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "%";
            // 
            // textBox_descuento
            // 
            this.textBox_descuento.Location = new System.Drawing.Point(212, 210);
            this.textBox_descuento.Name = "textBox_descuento";
            this.textBox_descuento.Size = new System.Drawing.Size(79, 20);
            this.textBox_descuento.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Poncentaje de Descuento";
            // 
            // button_listado_procducto
            // 
            this.button_listado_procducto.Location = new System.Drawing.Point(386, 158);
            this.button_listado_procducto.Name = "button_listado_procducto";
            this.button_listado_procducto.Size = new System.Drawing.Size(140, 28);
            this.button_listado_procducto.TabIndex = 7;
            this.button_listado_procducto.Text = "Seleccionar";
            this.button_listado_procducto.UseVisualStyleBackColor = true;
            this.button_listado_procducto.Click += new System.EventHandler(this.button_listado_procducto_Click);
            // 
            // button_selec_cliente
            // 
            this.button_selec_cliente.Location = new System.Drawing.Point(386, 117);
            this.button_selec_cliente.Name = "button_selec_cliente";
            this.button_selec_cliente.Size = new System.Drawing.Size(140, 27);
            this.button_selec_cliente.TabIndex = 6;
            this.button_selec_cliente.Text = "Seleccionar";
            this.button_selec_cliente.UseVisualStyleBackColor = true;
            this.button_selec_cliente.Click += new System.EventHandler(this.button_selec_cliente_Click);
            // 
            // textBox_cliente
            // 
            this.textBox_cliente.Location = new System.Drawing.Point(112, 121);
            this.textBox_cliente.Name = "textBox_cliente";
            this.textBox_cliente.Size = new System.Drawing.Size(254, 20);
            this.textBox_cliente.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cliente";
            // 
            // comboBox_sucursal
            // 
            this.comboBox_sucursal.FormattingEnabled = true;
            this.comboBox_sucursal.Location = new System.Drawing.Point(112, 84);
            this.comboBox_sucursal.Name = "comboBox_sucursal";
            this.comboBox_sucursal.Size = new System.Drawing.Size(254, 21);
            this.comboBox_sucursal.TabIndex = 3;
            // 
            // Sucursal
            // 
            this.Sucursal.AutoSize = true;
            this.Sucursal.Location = new System.Drawing.Point(38, 84);
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.Size = new System.Drawing.Size(48, 13);
            this.Sucursal.TabIndex = 2;
            this.Sucursal.Text = "Sucursal";
            // 
            // comboBox_provincias
            // 
            this.comboBox_provincias.FormattingEnabled = true;
            this.comboBox_provincias.Location = new System.Drawing.Point(112, 49);
            this.comboBox_provincias.Name = "comboBox_provincias";
            this.comboBox_provincias.Size = new System.Drawing.Size(254, 21);
            this.comboBox_provincias.TabIndex = 1;
            this.comboBox_provincias.SelectedIndexChanged += new System.EventHandler(this.obtener_suc_prov_selec);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Provincia";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(426, 362);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(144, 33);
            this.button_aceptar.TabIndex = 1;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_salir
            // 
            this.button_salir.Location = new System.Drawing.Point(426, 423);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(144, 33);
            this.button_salir.TabIndex = 2;
            this.button_salir.Text = "Salir";
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(12, 362);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(144, 33);
            this.button_limpiar.TabIndex = 3;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 471);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button_salir);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormFacturacion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturación";
            this.Load += new System.EventHandler(this.FormFacturacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_provincias;
        private System.Windows.Forms.ComboBox comboBox_sucursal;
        private System.Windows.Forms.Label Sucursal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_selec_cliente;
        private System.Windows.Forms.TextBox textBox_cliente;
        private System.Windows.Forms.Button button_listado_procducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_descuento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_forma_pago;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_salir;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.ComboBox comboBox_cant_cuotas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_productos;
        private System.Windows.Forms.Label label7;
    }
}