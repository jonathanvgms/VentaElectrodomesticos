namespace VentaElectrodomesticos.AbmProducto
{
    partial class FormModPro
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_habilitar_producto = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_mod_precio = new System.Windows.Forms.TextBox();
            this.textBox_mod_descripcion = new System.Windows.Forms.TextBox();
            this.textBox_mod_nom_mar = new System.Windows.Forms.TextBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_salir = new System.Windows.Forms.Button();
            this.button_modificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(111, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(187, 20);
            this.textBox2.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "Marca";
            // 
            // checkBox_habilitar_producto
            // 
            this.checkBox_habilitar_producto.AutoSize = true;
            this.checkBox_habilitar_producto.Location = new System.Drawing.Point(20, 209);
            this.checkBox_habilitar_producto.Name = "checkBox_habilitar_producto";
            this.checkBox_habilitar_producto.Size = new System.Drawing.Size(110, 17);
            this.checkBox_habilitar_producto.TabIndex = 71;
            this.checkBox_habilitar_producto.Text = "Habilitar Producto";
            this.checkBox_habilitar_producto.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Descripcion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Nombre";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 67;
            this.label8.Text = "Precio (en Pesos)";
            // 
            // textBox_mod_precio
            // 
            this.textBox_mod_precio.Location = new System.Drawing.Point(111, 112);
            this.textBox_mod_precio.Name = "textBox_mod_precio";
            this.textBox_mod_precio.Size = new System.Drawing.Size(98, 20);
            this.textBox_mod_precio.TabIndex = 70;
            // 
            // textBox_mod_descripcion
            // 
            this.textBox_mod_descripcion.Location = new System.Drawing.Point(111, 161);
            this.textBox_mod_descripcion.Name = "textBox_mod_descripcion";
            this.textBox_mod_descripcion.Size = new System.Drawing.Size(438, 20);
            this.textBox_mod_descripcion.TabIndex = 69;
            // 
            // textBox_mod_nom_mar
            // 
            this.textBox_mod_nom_mar.Location = new System.Drawing.Point(111, 22);
            this.textBox_mod_nom_mar.Name = "textBox_mod_nom_mar";
            this.textBox_mod_nom_mar.Size = new System.Drawing.Size(187, 20);
            this.textBox_mod_nom_mar.TabIndex = 68;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(20, 279);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(142, 27);
            this.button_limpiar.TabIndex = 64;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_salir
            // 
            this.button_salir.Location = new System.Drawing.Point(407, 279);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(142, 27);
            this.button_salir.TabIndex = 74;
            this.button_salir.Text = "Salir";
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button_salir_Click);
            // 
            // button_modificar
            // 
            this.button_modificar.Location = new System.Drawing.Point(210, 279);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(142, 27);
            this.button_modificar.TabIndex = 75;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // FormModPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 324);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_salir);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_habilitar_producto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_mod_precio);
            this.Controls.Add(this.textBox_mod_descripcion);
            this.Controls.Add(this.textBox_mod_nom_mar);
            this.Controls.Add(this.button_limpiar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormModPro";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Producto";
            this.Load += new System.EventHandler(this.FormModPro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_habilitar_producto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_mod_precio;
        private System.Windows.Forms.TextBox textBox_mod_descripcion;
        private System.Windows.Forms.TextBox textBox_mod_nom_mar;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_salir;
        private System.Windows.Forms.Button button_modificar;
    }
}