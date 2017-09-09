namespace VentaElectrodomesticos.ClientesPremium
{
    partial class FormSelecCliePrem
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
            this.dataGrid_clientes_premium = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_clientes_premium)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid_clientes_premium
            // 
            this.dataGrid_clientes_premium.AllowUserToAddRows = false;
            this.dataGrid_clientes_premium.AllowUserToDeleteRows = false;
            this.dataGrid_clientes_premium.AllowUserToResizeColumns = false;
            this.dataGrid_clientes_premium.AllowUserToResizeRows = false;
            this.dataGrid_clientes_premium.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid_clientes_premium.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGrid_clientes_premium.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_clientes_premium.GridColor = System.Drawing.Color.White;
            this.dataGrid_clientes_premium.Location = new System.Drawing.Point(12, 12);
            this.dataGrid_clientes_premium.Name = "dataGrid_clientes_premium";
            this.dataGrid_clientes_premium.ReadOnly = true;
            this.dataGrid_clientes_premium.RowHeadersVisible = false;
            this.dataGrid_clientes_premium.Size = new System.Drawing.Size(765, 427);
            this.dataGrid_clientes_premium.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(643, 458);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormSelecCliePrem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 498);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGrid_clientes_premium);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormSelecCliePrem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes Premiun";
            this.Load += new System.EventHandler(this.FormSeleccionarClientesPremium_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_clientes_premium)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid_clientes_premium;
        private System.Windows.Forms.Button button1;
    }
}