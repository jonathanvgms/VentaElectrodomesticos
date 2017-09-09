namespace VentaElectrodomesticos.EfectuarPago
{
    partial class FormEfectuarPago
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
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.textBox_cantidad_a_pagar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_cantidad_coutas = new System.Windows.Forms.ComboBox();
            this.comboBox_facturas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_selec_cliente = new System.Windows.Forms.Button();
            this.textBox_cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_sucursal = new System.Windows.Forms.ComboBox();
            this.Sucursal = new System.Windows.Forms.Label();
            this.comboBox_provincias = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(15, 295);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(144, 27);
            this.button_limpiar.TabIndex = 6;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(389, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 27);
            this.button2.TabIndex = 5;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(389, 295);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(144, 27);
            this.button_aceptar.TabIndex = 4;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // textBox_cantidad_a_pagar
            // 
            this.textBox_cantidad_a_pagar.Location = new System.Drawing.Point(105, 256);
            this.textBox_cantidad_a_pagar.Name = "textBox_cantidad_a_pagar";
            this.textBox_cantidad_a_pagar.Size = new System.Drawing.Size(252, 20);
            this.textBox_cantidad_a_pagar.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Monto a Abonar ";
            // 
            // comboBox_cantidad_coutas
            // 
            this.comboBox_cantidad_coutas.FormattingEnabled = true;
            this.comboBox_cantidad_coutas.Location = new System.Drawing.Point(105, 206);
            this.comboBox_cantidad_coutas.Name = "comboBox_cantidad_coutas";
            this.comboBox_cantidad_coutas.Size = new System.Drawing.Size(252, 21);
            this.comboBox_cantidad_coutas.TabIndex = 26;
            this.comboBox_cantidad_coutas.SelectedIndexChanged += new System.EventHandler(this.calcular_monto_a_pagar);
            // 
            // comboBox_facturas
            // 
            this.comboBox_facturas.FormattingEnabled = true;
            this.comboBox_facturas.Location = new System.Drawing.Point(105, 134);
            this.comboBox_facturas.Name = "comboBox_facturas";
            this.comboBox_facturas.Size = new System.Drawing.Size(428, 21);
            this.comboBox_facturas.TabIndex = 25;
            this.comboBox_facturas.SelectedIndexChanged += new System.EventHandler(this.coutas_impagas);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Factura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Cantidad de Cuotas a Pagar";
            // 
            // button_selec_cliente
            // 
            this.button_selec_cliente.Location = new System.Drawing.Point(376, 91);
            this.button_selec_cliente.Name = "button_selec_cliente";
            this.button_selec_cliente.Size = new System.Drawing.Size(133, 27);
            this.button_selec_cliente.TabIndex = 22;
            this.button_selec_cliente.Text = "Seleccionar Cliente";
            this.button_selec_cliente.UseVisualStyleBackColor = true;
            this.button_selec_cliente.Click += new System.EventHandler(this.button_selec_cliente_Click_1);
            // 
            // textBox_cliente
            // 
            this.textBox_cliente.Location = new System.Drawing.Point(105, 95);
            this.textBox_cliente.Name = "textBox_cliente";
            this.textBox_cliente.Size = new System.Drawing.Size(252, 20);
            this.textBox_cliente.TabIndex = 21;
            this.textBox_cliente.TextChanged += new System.EventHandler(this.buscar_facturas_del_cliente);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Cliente";
            // 
            // comboBox_sucursal
            // 
            this.comboBox_sucursal.FormattingEnabled = true;
            this.comboBox_sucursal.Location = new System.Drawing.Point(105, 58);
            this.comboBox_sucursal.Name = "comboBox_sucursal";
            this.comboBox_sucursal.Size = new System.Drawing.Size(252, 21);
            this.comboBox_sucursal.TabIndex = 19;
            // 
            // Sucursal
            // 
            this.Sucursal.AutoSize = true;
            this.Sucursal.Location = new System.Drawing.Point(38, 58);
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.Size = new System.Drawing.Size(48, 13);
            this.Sucursal.TabIndex = 18;
            this.Sucursal.Text = "Sucursal";
            // 
            // comboBox_provincias
            // 
            this.comboBox_provincias.FormattingEnabled = true;
            this.comboBox_provincias.Location = new System.Drawing.Point(105, 23);
            this.comboBox_provincias.Name = "comboBox_provincias";
            this.comboBox_provincias.Size = new System.Drawing.Size(252, 21);
            this.comboBox_provincias.TabIndex = 17;
            this.comboBox_provincias.SelectedIndexChanged += new System.EventHandler(this.seleccionar_sucursal_seg_prov);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Provincia";
            // 
            // FormEfectuarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 382);
            this.Controls.Add(this.textBox_cantidad_a_pagar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_cantidad_coutas);
            this.Controls.Add(this.comboBox_facturas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_selec_cliente);
            this.Controls.Add(this.textBox_cliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_sucursal);
            this.Controls.Add(this.Sucursal);
            this.Controls.Add(this.comboBox_provincias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_aceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormEfectuarPago";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Efectuar Pago";
            this.Load += new System.EventHandler(this.FormEfectuarPago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.TextBox textBox_cantidad_a_pagar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_cantidad_coutas;
        private System.Windows.Forms.ComboBox comboBox_facturas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_selec_cliente;
        private System.Windows.Forms.TextBox textBox_cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_sucursal;
        private System.Windows.Forms.Label Sucursal;
        private System.Windows.Forms.ComboBox comboBox_provincias;
        private System.Windows.Forms.Label label1;
    }
}