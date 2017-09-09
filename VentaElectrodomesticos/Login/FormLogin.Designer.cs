namespace VentaElectrodomesticos.Login
{
    partial class FormLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_login_aceptar = new System.Windows.Forms.Button();
            this.textBox_login_usuario = new System.Windows.Forms.TextBox();
            this.textBox_login_password = new System.Windows.Forms.TextBox();
            this.button_login_salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // button_login_aceptar
            // 
            this.button_login_aceptar.Location = new System.Drawing.Point(54, 102);
            this.button_login_aceptar.Name = "button_login_aceptar";
            this.button_login_aceptar.Size = new System.Drawing.Size(133, 27);
            this.button_login_aceptar.TabIndex = 2;
            this.button_login_aceptar.Text = "Aceptar";
            this.button_login_aceptar.UseVisualStyleBackColor = true;
            this.button_login_aceptar.Click += new System.EventHandler(this.button_login_aceptar_Click);
            // 
            // textBox_login_usuario
            // 
            this.textBox_login_usuario.Location = new System.Drawing.Point(190, 24);
            this.textBox_login_usuario.Name = "textBox_login_usuario";
            this.textBox_login_usuario.Size = new System.Drawing.Size(158, 20);
            this.textBox_login_usuario.TabIndex = 5;
            // 
            // textBox_login_password
            // 
            this.textBox_login_password.Location = new System.Drawing.Point(190, 64);
            this.textBox_login_password.Name = "textBox_login_password";
            this.textBox_login_password.PasswordChar = '*';
            this.textBox_login_password.Size = new System.Drawing.Size(158, 20);
            this.textBox_login_password.TabIndex = 6;
            // 
            // button_login_salir
            // 
            this.button_login_salir.Location = new System.Drawing.Point(237, 102);
            this.button_login_salir.Name = "button_login_salir";
            this.button_login_salir.Size = new System.Drawing.Size(133, 27);
            this.button_login_salir.TabIndex = 7;
            this.button_login_salir.Text = "Salir";
            this.button_login_salir.UseVisualStyleBackColor = true;
            this.button_login_salir.Click += new System.EventHandler(this.button_login_salir_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(423, 152);
            this.Controls.Add(this.button_login_salir);
            this.Controls.Add(this.textBox_login_password);
            this.Controls.Add(this.textBox_login_usuario);
            this.Controls.Add(this.button_login_aceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_login_aceptar;
        private System.Windows.Forms.TextBox textBox_login_usuario;
        private System.Windows.Forms.TextBox textBox_login_password;
        private System.Windows.Forms.Button button_login_salir;
    }
}