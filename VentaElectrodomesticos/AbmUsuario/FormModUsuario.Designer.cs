namespace VentaElectrodomesticos.AbmUsuario
{
    partial class FormModUsuario
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button_salir = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.checkBox_mod_hab_usuario = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_mod_guardar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox_reing_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(31, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 165);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado De Roles";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(346, 139);
            this.checkedListBox1.TabIndex = 3;
            // 
            // button_salir
            // 
            this.button_salir.Location = new System.Drawing.Point(358, 393);
            this.button_salir.Name = "button_salir";
            this.button_salir.Size = new System.Drawing.Size(122, 27);
            this.button_salir.TabIndex = 102;
            this.button_salir.Text = "Salir";
            this.button_salir.UseVisualStyleBackColor = true;
            this.button_salir.Click += new System.EventHandler(this.button_salir_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(23, 342);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(122, 27);
            this.button_limpiar.TabIndex = 101;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // checkBox_mod_hab_usuario
            // 
            this.checkBox_mod_hab_usuario.AutoSize = true;
            this.checkBox_mod_hab_usuario.Location = new System.Drawing.Point(31, 295);
            this.checkBox_mod_hab_usuario.Name = "checkBox_mod_hab_usuario";
            this.checkBox_mod_hab_usuario.Size = new System.Drawing.Size(103, 17);
            this.checkBox_mod_hab_usuario.TabIndex = 100;
            this.checkBox_mod_hab_usuario.Text = "Habilitar Usuario";
            this.checkBox_mod_hab_usuario.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(28, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 97;
            this.label2.Text = "Nueva Password";
            // 
            // button_mod_guardar
            // 
            this.button_mod_guardar.Location = new System.Drawing.Point(358, 342);
            this.button_mod_guardar.Name = "button_mod_guardar";
            this.button_mod_guardar.Size = new System.Drawing.Size(122, 27);
            this.button_mod_guardar.TabIndex = 99;
            this.button_mod_guardar.Text = "Modificar";
            this.button_mod_guardar.UseVisualStyleBackColor = true;
            this.button_mod_guardar.Click += new System.EventHandler(this.button_mod_guardar_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(133, 26);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(197, 20);
            this.textBox2.TabIndex = 96;
            // 
            // textBox_reing_password
            // 
            this.textBox_reing_password.Location = new System.Drawing.Point(133, 64);
            this.textBox_reing_password.Name = "textBox_reing_password";
            this.textBox_reing_password.PasswordChar = '*';
            this.textBox_reing_password.Size = new System.Drawing.Size(197, 20);
            this.textBox_reing_password.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Reingrese el password";
            // 
            // FormModUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_reing_password);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_salir);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.checkBox_mod_hab_usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_mod_guardar);
            this.Controls.Add(this.textBox2);
            this.Name = "FormModUsuario";
            this.Text = "Modificar Usuario";
            this.Load += new System.EventHandler(this.FormModUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button_salir;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.CheckBox checkBox_mod_hab_usuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_mod_guardar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox_reing_password;
        private System.Windows.Forms.Label label1;
    }
}