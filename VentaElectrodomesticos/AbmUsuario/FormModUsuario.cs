using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace VentaElectrodomesticos.AbmUsuario
{
    public partial class FormModUsuario : Form
    {

        Conexion con = new Conexion();
        Util u = new Util();

        string usuario_modificado = "";
        
        public FormModUsuario()
        {
            InitializeComponent();
        }

        #region accion que se realiza al cargarse el formulario

        private void FormModUsuario_Load(object sender, EventArgs e)
        {
        }

        private void cargar_roles()
        {
            DataTable tabla_roles;
            tabla_roles = con.armar_query_dinamica_consulta("DISTINCT rol_nombre", "rol", "rol_hab = 1").Tables[0];

            foreach (DataRow row_rol in tabla_roles.Rows)
            {
                checkedListBox1.Items.Insert(0, (row_rol[0].ToString()));
            }
        }

        #endregion

        #region passwords coinciden
        private bool passwords_coinciden()
        {
            if (textBox2.Text.Equals(textBox_reing_password.Text))
                return true;
            return false;
        }
        #endregion

        #region metodo set propiedades Usuario
        /*
         * metodo constructor se encarga de asignar a los textbox correspondientes
         * los datos que me pasan al seleccionar un cliente del datagrid del form anterior
         */
        public void set_propiedades_usuario(string id)
        {
            DataTable a_datatable;

            usuario_modificado = id;

            cargar_roles();

            a_datatable = con.armar_query_dinamica_consulta("rol_nombre", con.rol_tabla, "rol_usr_id = " + con.agregar_com_sim(id)).Tables[0];

            foreach (DataRow row_rol in a_datatable.Rows)
            {
                checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(row_rol[0].ToString()), true);
            }

            a_datatable = con.armar_query_dinamica_consulta("usr_hab", con.usuario_tabla, "usr_id = " + con.agregar_com_sim(id)).Tables[0];

            if (a_datatable.Rows[0][0].ToString().Equals("False"))
            {
                checkBox_mod_hab_usuario.Enabled = true;
            }
            else
            {
                checkBox_mod_hab_usuario.Enabled = false;
            }
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

            if (textBox2.Text.Length != 0 && textBox_reing_password.Text.Length == 0)
            {
                datos_faltantes += "Error: Debe reingresar el password\n";
            }
            else if (!passwords_coinciden())
            {
                datos_faltantes += "Error: Los passwords ingresados no coinciden\n";
            }

            if (checkedListBox1.CheckedItems.Count == 0)
            {
                datos_faltantes += "Error: Debe seleccionar aunque sea un rol\n";
            }

            DataTable undatatable;
            DataTable undatatable2;

            

            undatatable = con.armar_query_dinamica_consulta("usr_empleado", "usuario ", con.agregar_com_sim(usuario_modificado) + " = usr_id").Tables[0];
            undatatable2 = con.armar_query_dinamica_consulta("usr_id", "usuario ", con.agregar_com_sim(undatatable.Rows[0][0].ToString()) + " = usr_empleado and usr_hab = 1").Tables[0];
            if (undatatable2.Rows.Count != 0)
            {
                if (!undatatable2.Rows[0][0].ToString().Equals(usuario_modificado))
                {
                    datos_faltantes += "Error: Este empleado ya posee un nombre de usuario activo en el sistema";
                }
            }

            datos_faltantes += u.verificar_campo_parcial(textBox2.Text, "USUPASS", "Password");
            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }
        #endregion

        #region apretar boton modificar

        private void button_mod_guardar_Click(object sender, EventArgs e)
        {
            if (estan_los_datos_completos_y_correctos())
            {                         
                if (textBox2.Text.Length != 0)
                {
                    con.armar_query_dinamica_update("Usuario ",
                        "usr_pass = '" + ComputarSHA256(this.textBox2.Text) + "'",
                        "usr_id = " + con.agregar_com_sim(usuario_modificado));
                }

                
                if(checkBox_mod_hab_usuario.Checked == true)
                {
                    con.armar_query_dinamica_update("Usuario ",
                        "usr_hab = 1",
                        "usr_id = " + con.agregar_com_sim(usuario_modificado));
                }

                con.armar_query_dinamica_delete("rol ", "rol_usr_id = '" + usuario_modificado + "'");

                foreach (object itemChecked in checkedListBox1.CheckedItems)
                {
                    DataTable a_datatable;

                    con.nombre_tabla = "rol";


                    a_datatable = con.armar_query_dinamica_consulta("rol_abm_emp, rol_abm_rol, rol_abm_user, rol_abm_cli, rol_abm_prod, rol_asig_stock, rol_fact, rol_efec_pago, rol_tab_cont, rol_cli_prem, rol_mej_cat", "rol", "rol_nombre = '" + itemChecked.ToString() + "' and rol_hab = 1").Tables[0];

                    con.armar_query_dinamica_insert(con.rol_tabla + con.rol_fila + con.values + con.par_abier + con.agregar_com_sim(usuario_modificado) + con.coma + con.agregar_com_sim(itemChecked.ToString()) + con.coma +
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][0].ToString())) + con.coma + u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][1].ToString())) + con.coma +
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][2].ToString())) + con.coma + u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][3].ToString())) + con.coma +
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][4].ToString())) + con.coma + u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][5].ToString())) + con.coma +
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][6].ToString())) + con.coma + u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][7].ToString())) + con.coma +
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][8].ToString())) + con.coma + u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][9].ToString())) + con.coma +
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][10].ToString())) + con.coma + "1" + con.par_cerra);
                }


                MessageBox.Show("La Operacion se Realizo con Exito.");
            }
        }

        #endregion

        #region boton limpiar
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            this.textBox2.Clear();
            foreach (int checkedItemIndex in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemChecked(checkedItemIndex, false);
            }

            DataTable a_datatable;

            a_datatable = con.armar_query_dinamica_consulta("rol_nombre", con.rol_tabla, "rol_usr_id = " + con.agregar_com_sim(usuario_modificado)).Tables[0];

            foreach (DataRow row_rol in a_datatable.Rows)
            {
                checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(row_rol[0].ToString()), true);
            }

            checkBox_mod_hab_usuario.Checked = false;
        }
        #endregion

        #region computar password a SHA256

        static string ComputarSHA256(string input)
        {

            SHA256 md5Hasher = SHA256.Create();

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }


        #endregion

        #region boton salir

        private void button_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion





    }
}
