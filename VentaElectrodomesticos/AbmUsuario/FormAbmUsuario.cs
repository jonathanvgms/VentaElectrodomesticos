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
    public partial class FormAbmUsuario : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();

        string Empleado_id = "";

        public FormAbmUsuario()
        {
            InitializeComponent();
        }

        #region pestaña crear usuario

        #region accion de apretar el boton guardar

        private void button_crear_guardar_Click(object sender, EventArgs e)
        {
            if (estan_los_datos_completos() && !hay_usuario_repetido())
            {
                con.armar_query_dinamica_insert(con.usuario_tabla + con.usuario_fila + con.values + con.par_abier + con.agregar_com_sim(textBox_crear_username.Text) + con.coma + con.agregar_com_sim(ComputarSHA256(textBox_crear_password.Text)) + con.coma + Empleado_id + con.coma + "1" + con.par_cerra);
                
                foreach (object itemChecked in checkedListBox3.CheckedItems)
                {
                    DataTable a_datatable;

                    con.nombre_tabla = "rol";

                    
                    a_datatable = con.armar_query_dinamica_consulta("rol_abm_emp, rol_abm_rol, rol_abm_user, rol_abm_cli, rol_abm_prod, rol_asig_stock, rol_fact, rol_efec_pago, rol_tab_cont, rol_cli_prem, rol_mej_cat", "rol", "rol_nombre = '" + itemChecked.ToString() + "' and rol_hab = 1").Tables[0];

                    con.armar_query_dinamica_insert(con.rol_tabla + con.rol_fila + con.values + con.par_abier + con.agregar_com_sim(textBox_crear_username.Text) + con.coma + con.agregar_com_sim(itemChecked.ToString()) + con.coma + 
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][0].ToString())) + con.coma + u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][1].ToString())) + con.coma + 
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][2].ToString())) + con.coma + u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][3].ToString())) + con.coma + 
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][4].ToString())) + con.coma + u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][5].ToString())) + con.coma + 
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][6].ToString())) + con.coma + u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][7].ToString())) + con.coma + 
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][8].ToString())) + con.coma + u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][9].ToString())) + con.coma + 
                        u.convertir_bool_a_bit(Convert.ToBoolean(a_datatable.Rows[0][10].ToString())) + con.coma + "1" + con.par_cerra);
                }
                MessageBox.Show("Se guardo correctamente al usuario");
            }
        }

        #endregion

        #region accion de apretar el boton limpiar

        private void button_crear_limpiar_Click(object sender, EventArgs e)
        {
            textBox_crear_buscar_emp.Clear();
            Empleado_id = "";
            textBox_crear_username.Clear();
            textBox_crear_password.Clear();

            foreach (int checkedItemIndex in checkedListBox3.CheckedIndices)
            {
                checkedListBox3.SetItemChecked(checkedItemIndex, false);
            }
        }

        #endregion

        #region accion de apretar el boton seleccionar empleado

        private void button_crear_selec_emp_Click(object sender, EventArgs e)
        {
            FormSeleccionarEmplado buscar_empleado = new FormSeleccionarEmplado();
            buscar_empleado.ShowDialog(this);
            Empleado_id = buscar_empleado.get_empleado_selecionado();
            textBox_crear_buscar_emp.Text = buscar_empleado.get_empleado_seleccionado_nomape();
        }

        #endregion
        
        #region hay un usuario repetido
        private bool hay_usuario_repetido()
        {
            DataTable undatatable;
            undatatable = con.armar_query_dinamica_consulta("usr_id", "usuario", con.agregar_com_sim(textBox_crear_username.Text) + " = usr_id").Tables[0];
            if (undatatable.Rows.Count != 0)
            {
                MessageBox.Show("Error: Este username ya se encuentra registrado en el sistema. Ingrese otro por favor.");
                return true;
            }
            return false;
        }
        #endregion

        #region verificación de datos completos
        private bool estan_los_datos_completos()
        {
            string datos_faltantes = "";

            if (textBox_crear_buscar_emp.Text.Length == 0)
            {
                datos_faltantes += "Falta Seleccionar al empleado.\n";
            }
            datos_faltantes += u.verificar_campo_completo(textBox_crear_username.Text, "USUPASS", "Username");
            datos_faltantes += u.verificar_campo_completo(textBox_crear_password.Text, "USUPASS", "Password");

            if (textBox_crear_password.Text.Length != 0 && textBox_compr_password.Text.Length == 0)
            {
                datos_faltantes += "Error: Debe reingresar el password\n";
            }
            else if (textBox_crear_password.Text.Length > 0 && !textBox_crear_password.Text.Equals(textBox_compr_password.Text))
            {
                datos_faltantes += "Error: Los passwords ingresados no coinciden\n";
            }

            if (checkedListBox3.CheckedItems.Count == 0)
            {
                datos_faltantes += "Falta Seleccionar los roles.\n";
            }

            DataTable undatatable;
            undatatable = con.armar_query_dinamica_consulta(con.asterisco, "usuario ", con.agregar_com_sim(Empleado_id) + " = usr_empleado and usr_hab = 1").Tables[0];
            if (undatatable.Rows.Count != 0)
            {
                datos_faltantes += "Error: Este empleado ya posee un nombre de usuario activo en el sistema";                
            }

            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            } 

            return true;
        }
        #endregion

        #endregion

        #region pestaña modificar usuario
        
        #region apretar boton buscar
        private void button_buscar_database_Click(object sender, EventArgs e)
        {
            if (estan_los_datos_correctos())
            {
                realizar_busqueda();
            }
        }

        #endregion

        #region metodo estan los datos correctos
        /*
         * verifica los datos que se ingresaron en los textbox
         */

        private bool estan_los_datos_correctos()
        {
            string datos_incorrectos = "";

            datos_incorrectos = u.verificar_campo_parcial(this.textBox_selec_username.Text, "USUPASS", "Username");
            datos_incorrectos += u.verificar_campo_parcial(this.textBox_model_buscar_nombre.Text, "LETRAS", "Nombre");
            datos_incorrectos += u.verificar_campo_parcial(this.textBox_model_buscar_apellido.Text, "LETRAS", "Apellido");
            datos_incorrectos += u.verificar_campo_parcial(this.textBox_model_buscar_dni.Text, "NUMEROS", "Dni");

            if (datos_incorrectos.Length != 0)
            {
                MessageBox.Show(datos_incorrectos);
                return false;
            }
            return true;
        }
        #endregion

        #region accion de apretar el boton limpiar

        private void button_model_limpiar_Click(object sender, EventArgs e)
        {
            textBox_selec_username.Clear();
            textBox_model_buscar_nombre.Clear();
            textBox_model_buscar_apellido.Clear();
            textBox_model_buscar_dni.Clear();
            comboBox_model_buscar_provincia.SelectedIndex = -1;
            comboBox_model_buscar_sucursal.SelectedIndex = -1;
            comboBox__model_buscar_tipoemp.SelectedIndex = -1;
        }

        #endregion

        #region accion que se realiza al seleccionar una celda para modificar

        private void seleccionar_celda(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_resultado_busqueda.Columns["Modificar"].Index)
            {
                FormModUsuario mod_usr = new FormModUsuario();
                mod_usr.set_propiedades_usuario(dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Username"].Value.ToString());
                mod_usr.ShowDialog(this);
                realizar_busqueda();
            }

            /*
             * Solo se realiza un baja logica del cliente, lo que solo altera la columna de habilitado
             * si si quiere volver a habilitarlo se hace desde el chekbox del form modificacion
             */
            if (e.ColumnIndex == dataGridView_resultado_busqueda.Columns["Eliminar"].Index)
            {
                con.armar_query_dinamica_update("Usuario", "usr_hab = 0", "usr_id = " + con.agregar_com_sim(this.dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Username"].Value.ToString()));
                MessageBox.Show("El Usuario se Elimino con Exito.");
                realizar_busqueda();
            }
        }
        #endregion

        #endregion

        #region metodos comunes
        private void mostrar_mensaje(string una_cadena)
        {
            MessageBox.Show(una_cadena);
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

        #region accion de apretar el boton salir

        private void button_usu_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region accion que se hace cuando se carga el form

        private void FormAbmUsuario_Load(object sender, EventArgs e)
        {
            cargar_roles();
            u.cargar_provincias_en_combobox(this.comboBox_model_buscar_provincia);
            u.cargar_tipos_empleado_en_combobox(this.comboBox__model_buscar_tipoemp);
            
        }

        private void cargar_roles()
        {
            DataTable tabla_roles;
            tabla_roles = con.armar_query_dinamica_consulta("DISTINCT rol_nombre", "rol", "rol_hab = 1").Tables[0];

            foreach (DataRow row_rol in tabla_roles.Rows)
            {
                checkedListBox3.Items.Insert(0,(row_rol[0].ToString()));
            }

        }
        #endregion

        #region Cargo sucursales segun la provincia seleccionada
        private void comboBox_crear_provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSucursal(comboBox_model_buscar_provincia, comboBox_model_buscar_sucursal);
        }

        private void comboBox_model_buscar_provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSucursal(comboBox_model_buscar_provincia, comboBox_model_buscar_sucursal);
        }

        private void CargarSucursal(ComboBox provincia, ComboBox sucursales)
        {
            DataTable tabla_Sucursales;

            //Elimino todos los elementos del combo_box
            sucursales.Items.Clear();
            sucursales.Items.Add("");
            sucursales.SelectedIndex = 0;
            //Si lo que hice fue poner provincia en vacio, termino
            if (provincia.Text.Length == 0)
                return;
            //Busco las sucursales que pertenesca a la provincia seleccionada
            tabla_Sucursales = con.realizar_consulta("select suc_dir from GURP_SKYPE.sucursal where suc_provincia = GURP_SKYPE.obtener_provincia_id('"
                + provincia.Text + "')").Tables[0];

            //Las cargo en el combobox
            foreach (DataRow row_sucursal in tabla_Sucursales.Rows)
            {
                string una_sucursal = row_sucursal[0].ToString();
                sucursales.Items.Add(una_sucursal);
            }
            sucursales.SelectedIndex = 1;
        }

        #endregion

        #region verificar_campo
        /*
         * este metodo agilisa la cosa de verificar si un campo esta escrito y correctamente, retorna el error propimente dicho
         */
        private string verificar_campo(string caja_de_texto, string flag, string nombre_campo)
        {
            string datos_faltantes = "";

            if (caja_de_texto.Length == 0)
            {
                datos_faltantes += nombre_campo + ": Imcompleto. \n";
            }
            if (flag.Equals("LETRAS"))
            {
                if (!u.que_sean_letras(caja_de_texto))
                {
                    datos_faltantes += nombre_campo + ": Incorrecto. Los caracteres del campo NO son aceptables. \n";
                }
            }
            else if (flag.Equals("USUPASS"))
            {
                if (u.IsTextAllowed(caja_de_texto))
                {
                    datos_faltantes += nombre_campo + ": Incorrecto. Los caracteres del campo NO son aceptables. \n";
                }
            }
            else
            {
                if (!u.que_sean_numeros(caja_de_texto))
                {
                    datos_faltantes += nombre_campo + ": Incorrecto. Los caracteres del campo NO son aceptables. \n";
                }
            }
            return datos_faltantes;
        }
        #endregion

        private void realizar_busqueda()
        {
            string string_where = "";

            DataSet un_dataset;

            string_where = u.armar_where_query_usuario(this.comboBox_model_buscar_provincia, this.comboBox_model_buscar_sucursal, this.comboBox__model_buscar_tipoemp, this.textBox_selec_username.Text, this.textBox_model_buscar_nombre.Text, this.textBox_model_buscar_apellido.Text, this.textBox_model_buscar_dni.Text);

            con.nombre_tabla = "Usuario";

            if (string_where.Length != 0)
            {
                un_dataset = con.armar_query_dinamica_consulta("DISTINCT usr_id as Username, (select empleado_nombre from GURP_SKYPE.empleado where empleado_id = usr_empleado) as Nombre, usr_hab as Habilitado", "usuario, GURP_SKYPE.empleado ", string_where);
            }
            else
            {
                un_dataset = con.armar_query_dinamica_consulta("DISTINCT usr_id as Username, (select empleado_nombre from GURP_SKYPE.empleado where empleado_id = usr_empleado) as Nombre, usr_hab as Habilitado", "usuario, GURP_SKYPE.empleado ");
            }

            if (un_dataset.Tables["Usuario"].Rows.Count != 0)
            {
                this.dataGridView_resultado_busqueda.DataSource = un_dataset.Tables["Usuario"];

                if (!this.dataGridView_resultado_busqueda.Columns.Contains("Modificar"))
                {
                    DataGridViewButtonColumn columnaModificar = new DataGridViewButtonColumn();

                    columnaModificar.Name = "Modificar";

                    columnaModificar.HeaderText = "Modificar";

                    DataGridViewButtonColumn columnaEliminar = new DataGridViewButtonColumn();

                    columnaEliminar.Name = "Eliminar";

                    columnaEliminar.HeaderText = "Eliminar";

                    //Agrego las columnas al grid                    
                    this.dataGridView_resultado_busqueda.Columns.Add(columnaModificar);

                    this.dataGridView_resultado_busqueda.Columns.Add(columnaEliminar);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron resultados.");
            }
        }




    }
}
