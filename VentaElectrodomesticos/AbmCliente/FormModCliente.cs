using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.AbmCliente
{
    public partial class FormModCliente : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        string cliente_dni_seleccionado;

        public FormModCliente()
        {
            InitializeComponent();
        }

        #region accion que se realiza al cargarse el formulario
        /*
         * evento que lo unico que hace es llamar al metodo
         * cargar provincias
         */
        private void FormModCliente_Load(object sender, EventArgs e)
        {
            u.cargar_provincias_en_combobox(this.comboBox_mod_provincias);
        }
        #endregion

        #region metodo set propiedades cliente
        /*
         * metodo constructor se encarga de asignar a los textbox correspondientes
         * los datos que me pasan al seleccionar un cliente del datagrid del form anterior
         */
        public void set_propiedades_cliente(string dni, string nom, string app, string dir, string mail, string tel)
        {
            DataTable a_datatable;

            this.cliente_dni_seleccionado = dni;
            this.textBox_mod_nombre.Text = nom;
            this.textBox_mod_apellido.Text = app;

            if (dir.Length != 0)
            {
                this.textBox_mod_dir_calle.Text = u.obtener_calle_direccion(dir);
                this.textBox_mod_dir_num.Text = u.obtener_numero_direccion(dir);
                this.textBox_mod_dir_pisdep.Text = u.obtener_piso_depto_direccion(dir);
            }

            this.textBox_mod_email.Text = mail;
            this.textBox_mod_telefono.Text = tel;

            a_datatable = con.armar_query_dinamica_consulta("cli_hab", "cliente", "cli_dni = " + con.agregar_com_sim(cliente_dni_seleccionado)).Tables[0];

            if (a_datatable.Rows[0][0].ToString().Equals("False"))
            {
                checkBox_mod_hab_cliente.Enabled = true;
            }
            else
            {
                checkBox_mod_hab_cliente.Enabled = false;
            }
        }
        #endregion

        #region accion de apretar el boton limpiar
        /*
         * accion de limpiar todos los textbox
         */
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            this.textBox_mod_nombre.Clear();
            this.textBox_mod_apellido.Clear();
            this.textBox_mod_dir_calle.Clear();
            this.textBox_mod_dir_num.Clear();
            this.textBox_mod_dir_pisdep.Clear();
            this.textBox_mod_email.Clear(); ;
            this.textBox_mod_telefono.Clear();
        }
        #endregion

        #region metodo que verifica si los datos modificados estan completos y correctos
        /*
         * metodo que se encarga de verificar si todos los datos estan completos y su 
         * contenido es correcto ( respecto al tipo de campo )
         */ 
        private bool estan_los_datos_completos_y_correctos()
        {
            string datos_faltantes = "";

            datos_faltantes += u.verificar_campo_completo(textBox_mod_nombre.Text, "LETRAS", "Nombre");
            datos_faltantes += u.verificar_campo_completo(textBox_mod_apellido.Text, "LETRAS", "Apellido");
            if (this.textBox_mod_email.Text.Length == 0)
            {
                datos_faltantes += "Falta Ingresar el Mail.\n";
            }
            else
            {
                if (!u.IsValidEmail(textBox_mod_email.Text))
                {
                    datos_faltantes += "Mail Incorrecto\n";
                }
            }
            datos_faltantes += u.verificar_campo_completo(textBox_mod_telefono.Text, "NUMEROS", "Teléfono");
            datos_faltantes += u.verificar_campo_completo(textBox_mod_dir_calle.Text, "LETRAS", "Direccion Calle");
            datos_faltantes += u.verificar_campo_completo(textBox_mod_dir_num.Text, "NUMEROS", "Direccion Altura");
            datos_faltantes += u.verificar_campo_completo(textBox_mod_dir_pisdep.Text, "NUMEROS", "Direccion Piso o Depto");

            if (this.comboBox_mod_provincias.Text.Length == 0)
            {
                datos_faltantes += "Falta Seleccionar la Provincia.\n";
            }
            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }
        #endregion

        #region accion que se realiza cuando apreto el boton modificar
        /*
         * evento que realiza la modificacion propiamente dicha en la base de datos
         * alterando todos los campos 
         * aqui se tomo en cuenta que cuando se modifica se deben estar TODOS los campos ingresados
         * 
         * en aqui se presentan dos casoa especiales:
         * 
         * en donde los clientes estan habilitados y en los que no
         * el primer caso del if si el cliente esta habilitado y el otro si en empleado se
         * encontraba desabilitado por ende su columna cliente_hab = 1
         */ 
        private void button_mod_guardar_Click_1(object sender, EventArgs e)
        {
            if (estan_los_datos_completos_y_correctos())
            {
                if ((checkBox_mod_hab_cliente.Enabled == false) || ((checkBox_mod_hab_cliente.Enabled == true) && (checkBox_mod_hab_cliente.Checked == false)))
                {
                    con.armar_query_dinamica_update("Cliente",
                        "cli_provincia = GURP_SKYPE.obtener_provincia_id('" + this.comboBox_mod_provincias.Text + "'), " +
                        "cli_nombre = " + con.agregar_com_sim(this.textBox_mod_nombre.Text) +
                        ", cli_apellido = " + con.agregar_com_sim(this.textBox_mod_apellido.Text) +
                        ", cli_telefono = " + con.agregar_com_sim(this.textBox_mod_telefono.Text) +
                        ", cli_mail = " + con.agregar_com_sim(this.textBox_mod_email.Text) +
                        ", cli_direccion = " + con.agregar_com_sim(this.textBox_mod_dir_calle.Text + "|" + this.textBox_mod_dir_num.Text + "|" + this.textBox_mod_dir_pisdep.Text),
                        "cli_dni = " + con.agregar_com_sim(this.cliente_dni_seleccionado));
                }
                else
                {
                    con.armar_query_dinamica_update("Cliente",
                        "cli_provincia = GURP_SKYPE.obtener_provincia_id('" + this.comboBox_mod_provincias.Text + "'), " +
                        "cli_nombre = " + con.agregar_com_sim(this.textBox_mod_nombre.Text) +
                        ", cli_apellido = " + con.agregar_com_sim(this.textBox_mod_apellido.Text) +
                        ", cli_telefono = " + con.agregar_com_sim(this.textBox_mod_telefono.Text) +
                        ", cli_mail = " + con.agregar_com_sim(this.textBox_mod_email.Text) +
                        ", cli_direccion = " + con.agregar_com_sim(this.textBox_mod_dir_calle.Text + "|" + this.textBox_mod_dir_num.Text + "|" + this.textBox_mod_dir_pisdep.Text) +
                        ", cli_hab = 1",
                        "cli_dni = " + con.agregar_com_sim(this.cliente_dni_seleccionado));
                }
                MessageBox.Show("La Operacion se Realizo con Exito.");
                this.Close();
            }
        }
        #endregion
       
        #region accion que se hace cuando apreto el boton salir
        /*
         * accion del evento que cierra el form
         */
        private void button_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion        
    }
}
