using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.AbmEmpleado
{
    public partial class FormModEmpleado : Form
    {
        Conexion conexion = new Conexion();
        Util u = new Util();
        string empleadoId;
        bool empleadoHabilitado;

        public FormModEmpleado()
        {
            InitializeComponent();
        }

        public void cargar_datos_cliente(string empleado_id, string nombre, string apellido, string direccion, 
            string provincia,string telefono,string mail,string habilitado)
        {
            int i = 0;
            this.empleadoId = empleado_id;
            textBox_mod_nombre.Text = nombre;
            textBox_mod_apellido.Text = apellido;
            textBox_mod_mail.Text = mail;
            textBox_mod_Telefono.Text = telefono;

            string[] dir = direccion.Split('|');
            
            foreach(string partes in dir )
            {
                if (i==0)
                    this.textBox_mod_calle.Text = partes;
                else if(i==1)
                    this.textBox_mod_numero.Text = partes;
                else
                    this.textBox_mod_piso.Text = partes;
                i++;
            }
            if (i > 3)
                this.textBox_mod_piso.Text = "0";

            if (habilitado != "False")
            {
                empleadoHabilitado = true;                
            }
            else
            {
                empleadoHabilitado = false;                
            }
        }


        /*================================================================*/
        #region Apretar el boton Limpiar
        private void button_mod_limpiar_Click(object sender, EventArgs e)
        {
            textBox_mod_nombre.Clear();
            textBox_mod_apellido.Clear();
            textBox_mod_calle.Clear();
            textBox_mod_numero.Clear();
            textBox_mod_piso.Clear();
            textBox_mod_mail.Clear();
            textBox_mod_Telefono.Clear();
        }
        #endregion
        /*================================================================*/

        /*================================================================*/
        #region accion de apretar el boton guardar (modificar)
        private void button_mod_guardar_Click(object sender, EventArgs e)
        {
            string modificacion = "";
            modificacion = cargar_datos_a_modificar();
            if (modificacion.Length != 0)
            {
                if (conexion.insertar_datos(modificacion) == 0)
                    MessageBox.Show("Datos Guardados Con Exito");
            }
        }
        
        #region Cargar datos a modificar
        private string cargar_datos_a_modificar()
        {
            //verifico que todos los campos sea validos
            string datosAModificar = "Update GURP_SKYPE.Empleado \n Set ";
            string datosErroneos = "", direccion="";

            if ((datosErroneos = u.verificar_campo_completo(textBox_mod_nombre.Text, "LETRAS", "Nombre")).Length == 0)
            {
                datosAModificar += conexion.empleado_nombre + " = '" + this.textBox_mod_nombre.Text + "',\n";
            }
            if ((datosErroneos += u.verificar_campo_completo(textBox_mod_apellido.Text, "LETRAS", "Apellido")).Length == 0)
            {
                datosAModificar += conexion.empleado_apellido + " = '" + this.textBox_mod_apellido.Text + "',\n";
            }
            if ((datosErroneos += u.verificar_campo_completo(textBox_mod_calle.Text, "LETRAS", "Calle")).Length == 0)
            {
                direccion += this.textBox_mod_calle.Text + "|";
            }
            if ((datosErroneos += u.verificar_campo_completo(textBox_mod_numero.Text, "NUMEROS", "Número")).Length == 0)
            {
                direccion += this.textBox_mod_numero.Text + "|";
            }
            if ((datosErroneos += u.verificar_campo_completo(textBox_mod_piso.Text, "NUMEROS", "Piso")).Length == 0)
            {
                datosAModificar += conexion.empleado_dir + " = '" + direccion + this.textBox_mod_piso.Text + "',\n";
            }
            if (u.IsValidEmail(textBox_mod_mail.Text))
            {
                datosAModificar += conexion.empleado_mail + " = '" + this.textBox_mod_mail.Text + "',\n";
            }
            else
            {
                datosErroneos += "Mail: Formato incorrecto.";
            }
            if ((datosErroneos += u.verificar_campo_completo(textBox_mod_Telefono.Text, "NUMEROS", "Teléfono")).Length == 0)
            {
                datosAModificar += conexion.empleado_tel + " = '" + this.textBox_mod_Telefono.Text + "',\n";
            }
            //Si hubo algo erroneo muestro los errores y retorno un string vacio
            if (datosErroneos.Length != 0)
            { 
                MessageBox.Show(datosErroneos);
                return "";
            }
            //si no hubo errores devuelvo el string con todos los datos cargados
            if (checkBox_mod_empleadoHabilitado.Enabled == true && !checkBox_mod_empleadoHabilitado.Checked)
            {
                datosAModificar += conexion.empleado_hab + " = 0 \n";
            }
            else 
                datosAModificar += conexion.empleado_hab + " = 1 \n";
            datosAModificar += "where empleado_id = " + this.empleadoId;

            return datosAModificar;
        }
        #endregion              

        #endregion

        /*================================================================*/
        private void FormModEmpleado_Load(object sender, EventArgs e)
        {
            if (this.empleadoHabilitado)
            {
                this.checkBox_mod_empleadoHabilitado.Enabled = true;
                this.checkBox_mod_empleadoHabilitado.CheckState = CheckState.Checked;
                this.checkBox_mod_empleadoHabilitado.Enabled = false;
            }   
        }

        private void button_mod_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*================================================================*/

    }
}
