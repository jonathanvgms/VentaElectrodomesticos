namespace VentaElectrodomesticos.AsignacionStock
{
    partial class FormAsignacionStock
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
            this.button_buscar_producto = new System.Windows.Forms.Button();
            this.button_buscar_auditor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Sucursal = new System.Windows.Forms.Label();
            this.textBox_asig_analista_selec = new System.Windows.Forms.TextBox();
            this.textBox_asig_prod_selec = new System.Windows.Forms.TextBox();
            this.button_asig_salir = new System.Windows.Forms.Button();
            this.button_buscar_stock = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_asig_stock_disponible = new System.Windows.Forms.TextBox();
            this.button_asig_guardar = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_buscar_producto
            // 
            this.button_buscar_producto.Location = new System.Drawing.Point(316, 21);
            this.button_buscar_producto.Name = "button_buscar_producto";
            this.button_buscar_producto.Size = new System.Drawing.Size(161, 25);
            this.button_buscar_producto.TabIndex = 0;
            this.button_buscar_producto.Text = "Selecionar Producto";
            this.button_buscar_producto.UseVisualStyleBackColor = true;
            this.button_buscar_producto.Click += new System.EventHandler(this.button_buscar_producto_Click);
            // 
            // button_buscar_auditor
            // 
            this.button_buscar_auditor.Location = new System.Drawing.Point(316, 107);
            this.button_buscar_auditor.Name = "button_buscar_auditor";
            this.button_buscar_auditor.Size = new System.Drawing.Size(161, 26);
            this.button_buscar_auditor.TabIndex = 2;
            this.button_buscar_auditor.Text = "Seleccionar Auditor";
            this.button_buscar_auditor.UseVisualStyleBackColor = true;
            this.button_buscar_auditor.Click += new System.EventHandler(this.button_buscar_auditor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Auditor";
            // 
            // Sucursal
            // 
            this.Sucursal.AutoSize = true;
            this.Sucursal.Location = new System.Drawing.Point(47, 71);
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.Size = new System.Drawing.Size(48, 13);
            this.Sucursal.TabIndex = 5;
            this.Sucursal.Text = "Sucursal";
            // 
            // textBox_asig_analista_selec
            // 
            this.textBox_asig_analista_selec.Enabled = false;
            this.textBox_asig_analista_selec.Location = new System.Drawing.Point(125, 111);
            this.textBox_asig_analista_selec.Name = "textBox_asig_analista_selec";
            this.textBox_asig_analista_selec.Size = new System.Drawing.Size(165, 20);
            this.textBox_asig_analista_selec.TabIndex = 6;
            // 
            // textBox_asig_prod_selec
            // 
            this.textBox_asig_prod_selec.Enabled = false;
            this.textBox_asig_prod_selec.Location = new System.Drawing.Point(125, 24);
            this.textBox_asig_prod_selec.Name = "textBox_asig_prod_selec";
            this.textBox_asig_prod_selec.Size = new System.Drawing.Size(165, 20);
            this.textBox_asig_prod_selec.TabIndex = 8;
            // 
            // button_asig_salir
            // 
            this.button_asig_salir.Location = new System.Drawing.Point(338, 340);
            this.button_asig_salir.Name = "button_asig_salir";
            this.button_asig_salir.Size = new System.Drawing.Size(139, 29);
            this.button_asig_salir.TabIndex = 9;
            this.button_asig_salir.Text = "Salir";
            this.button_asig_salir.UseVisualStyleBackColor = true;
            this.button_asig_salir.Click += new System.EventHandler(this.button_asig_salir_Click);
            // 
            // button_buscar_stock
            // 
            this.button_buscar_stock.Location = new System.Drawing.Point(26, 166);
            this.button_buscar_stock.Name = "button_buscar_stock";
            this.button_buscar_stock.Size = new System.Drawing.Size(161, 24);
            this.button_buscar_stock.TabIndex = 10;
            this.button_buscar_stock.Text = "Buscar Stock";
            this.button_buscar_stock.UseVisualStyleBackColor = true;
            this.button_buscar_stock.Click += new System.EventHandler(this.button_buscar_stock_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(125, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(165, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Stock Disponible";
            // 
            // textBox_asig_stock_disponible
            // 
            this.textBox_asig_stock_disponible.Enabled = false;
            this.textBox_asig_stock_disponible.Location = new System.Drawing.Point(125, 226);
            this.textBox_asig_stock_disponible.Name = "textBox_asig_stock_disponible";
            this.textBox_asig_stock_disponible.Size = new System.Drawing.Size(165, 20);
            this.textBox_asig_stock_disponible.TabIndex = 15;
            // 
            // button_asig_guardar
            // 
            this.button_asig_guardar.Enabled = false;
            this.button_asig_guardar.Location = new System.Drawing.Point(316, 222);
            this.button_asig_guardar.Name = "button_asig_guardar";
            this.button_asig_guardar.Size = new System.Drawing.Size(161, 24);
            this.button_asig_guardar.TabIndex = 16;
            this.button_asig_guardar.Text = "Guardar";
            this.button_asig_guardar.UseVisualStyleBackColor = true;
            this.button_asig_guardar.Click += new System.EventHandler(this.button_asig_guardar_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(26, 340);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(139, 29);
            this.button_limpiar.TabIndex = 17;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // FormAsignacionStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 384);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button_asig_guardar);
            this.Controls.Add(this.textBox_asig_stock_disponible);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button_buscar_stock);
            this.Controls.Add(this.button_asig_salir);
            this.Controls.Add(this.textBox_asig_prod_selec);
            this.Controls.Add(this.textBox_asig_analista_selec);
            this.Controls.Add(this.Sucursal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_buscar_auditor);
            this.Controls.Add(this.button_buscar_producto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormAsignacionStock";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de Stock";
            this.Load += new System.EventHandler(this.FormAsignacionStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_buscar_producto;
        private System.Windows.Forms.Button button_buscar_auditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Sucursal;
        private System.Windows.Forms.TextBox textBox_asig_analista_selec;
        private System.Windows.Forms.TextBox textBox_asig_prod_selec;
        private System.Windows.Forms.Button button_asig_salir;
        private System.Windows.Forms.Button button_buscar_stock;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_asig_stock_disponible;
        private System.Windows.Forms.Button button_asig_guardar;
        private System.Windows.Forms.Button button_limpiar;

    }
}