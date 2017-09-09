using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace VentaElectrodomesticos.Login
{
    public partial class FormLogin : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        string usuario_actual = "";
        int intentos_login = 0;

        bool flag_login_correcto = false;

        public FormLogin()
        {
            InitializeComponent();
        }

        #region boton salir

        private void button_login_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region boton aceptar

        private void button_login_aceptar_Click(object sender, EventArgs e)
        {
            //ingresar a la base de datos
            if (estan_completos_user_pass())
            {
                if (this.usuario_actual != this.textBox_login_usuario.Text)
                {
                    intentos_login = 0;
                    this.usuario_actual = this.textBox_login_usuario.Text;
                }

                if (!esta_username_en_base_de_datos())
                {
                    MessageBox.Show("Acceso Denegado. El usuario no fue encontrado");
                    intentos_login++;                    
                }
                else
                {
                    if (!password_valido())
                    {
                        MessageBox.Show("Acceso Denegado. El password ingresado no es valido para este usuario");
                        intentos_login++;
                    }
                    else
                    {
                        intentos_login = 0;
                        this.usuario_actual = "";
                        flag_login_correcto = true;
                        Close();
                    }
                }
            }
            if ((intentos_login == 3) && (this.textBox_login_usuario.Text.Equals(this.usuario_actual)))
            {
                intentos_login = 0;
                textBox_login_usuario.Enabled = false;
                textBox_login_password.Enabled = false;
                button_login_aceptar.Enabled = false;
            }
        }

        #endregion

        #region usuario en base de datos

        private bool esta_username_en_base_de_datos()
        {
            string string_where = "";

            DataSet un_dataset;

            string_where += "usr_id = '" + textBox_login_usuario.Text + "' and usr_hab = 1";
            con.nombre_tabla = "Usuario";
            un_dataset = con.armar_query_dinamica_consulta("usr_id", "usuario", string_where);
            if (un_dataset == null)
            {
                MessageBox.Show("La base de datos no está disponible");
                Close();
                return false;
            }
            if (un_dataset.Tables["Usuario"].Rows.Count != 0)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region estan los datos completos

        private bool estan_completos_user_pass()
        {
            string datos_faltantes = "";

            datos_faltantes += u.verificar_campo_completo(textBox_login_usuario.Text, "USUPASS", "Username");
            datos_faltantes += u.verificar_campo_completo(textBox_login_password.Text, "USUPASS", "Password");
            
            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }

        #endregion

        #region comprobar password

        private bool password_valido()
        {
            string string_where = "";

            DataSet un_dataset;

            string_where += "usr_id = '" + textBox_login_usuario.Text + "' and usr_pass = '" + ComputarSHA256(textBox_login_password.Text) + "'";
            con.nombre_tabla = "Usuario";
            un_dataset = con.armar_query_dinamica_consulta("usr_id", "usuario", string_where);
            if (un_dataset.Tables["Usuario"].Rows.Count != 0)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region computar password a SHA256

        static string ComputarSHA256(string entrada)
        {
            SHA256 sha256Hasher = SHA256.Create();

            byte[] data = sha256Hasher.ComputeHash(Encoding.Default.GetBytes(entrada));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }


        #endregion
        
        #region obtener datos de usuario

        public string get_usuario_id()
        {
            return textBox_login_usuario.Text;
        }

        #endregion

        #region preguntar si el usuario se logueo

        public bool obtener_flag_logueo()
        {
            return flag_login_correcto;
        }

        #endregion

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

    }
}
