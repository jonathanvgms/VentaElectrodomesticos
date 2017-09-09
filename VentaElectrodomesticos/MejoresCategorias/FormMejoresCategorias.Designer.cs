namespace VentaElectrodomesticos.MejoresCategorias
{
    partial class FormMejoresCategorias
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
            this.button_salir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.textBox_fecha_selec = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_seleccionar_fecha = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_buscar = new System.Windows.Forms.Button();
            this.comboBox_sucursales = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_salir
            // 
            this.button_salir.Location = new System.Drawing.Point(389, 236);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(134, 29);
            this.button_salir.TabIndex = 4;
            this.button_salir.Text = "Salir";
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_limpiar);
            this.groupBox1.Controls.Add(this.textBox_fecha_selec);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button_seleccionar_fecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button_buscar);
            this.groupBox1.Controls.Add(this.comboBox_sucursales);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterio de Busqueda";
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(15, 159);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(134, 29);
            this.button_limpiar.TabIndex = 11;
            this.button_limpiar.Text = "LImpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // textBox_fecha_selec
            // 
            this.textBox_fecha_selec.Location = new System.Drawing.Point(103, 99);
            this.textBox_fecha_selec.Name = "textBox_fecha_selec";
            this.textBox_fecha_selec.Size = new System.Drawing.Size(268, 20);
            this.textBox_fecha_selec.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha";
            // 
            // button_seleccionar_fecha
            // 
            this.button_seleccionar_fecha.Location = new System.Drawing.Point(377, 94);
            this.button_seleccionar_fecha.Name = "button_seleccionar_fecha";
            this.button_seleccionar_fecha.Size = new System.Drawing.Size(134, 29);
            this.button_seleccionar_fecha.TabIndex = 5;
            this.button_seleccionar_fecha.Text = "Seleccionar";
            this.button_seleccionar_fecha.UseVisualStyleBackColor = true;
            this.button_seleccionar_fecha.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sucursales";
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(377, 159);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(134, 29);
            this.button_buscar.TabIndex = 4;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // comboBox_sucursales
            // 
            this.comboBox_sucursales.FormattingEnabled = true;
            this.comboBox_sucursales.Location = new System.Drawing.Point(103, 43);
            this.comboBox_sucursales.Name = "comboBox_sucursales";
            this.comboBox_sucursales.Size = new System.Drawing.Size(408, 21);
            this.comboBox_sucursales.TabIndex = 1;
            // 
            // FormMejoresCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 279);
            this.Controls.Add(this.button_salir);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormMejoresCategorias";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mejores Categorías";
            this.Load += new System.EventHandler(this.FormMejoresCategorias_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_salir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.TextBox textBox_fecha_selec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_seleccionar_fecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.ComboBox comboBox_sucursales;

    }
}