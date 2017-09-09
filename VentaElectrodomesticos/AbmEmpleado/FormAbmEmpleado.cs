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
    public partial class FormAbmEmpleado : Form
    {
        Conexion conexion = new Conexion();
        Util u = new Util();

        public FormAbmEmpleado()
        {
            InitializeComponent();
        }

        /*================================================================*/
        
        #region pestaña crear
        

        #region accion de apretar el boton limpiar
        private void button_crear_limpiar_Click(object sender, EventArgs e)
        {
            textBox_crear_nombre.Clear();
            textBox_crear_apellido.Clear();
            textBox_crear_dni.Clear();
            textBox_crear_email.Clear();
            textBox_crear_tel.Clear();
            textBox_crear_dir_calle.Clear();
            textBox_crear_dir_numero.Clear();
            textBox_crear_dir_pisodepto.Clear();
            comboBox_crear_provincia.SelectedItem = 0;
            comboBox_crear_sucursal.SelectedItem = 0;
            comboBox_crear_tipo_emp.SelectedItem = 0;
        }
        #endregion

        #region accion de apreta el boton salir
        private void button_salir_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion  

        /*================================================================*/
        #region accion de apretar el boton Guardar

        private void button_crear_aceptar_Click(object sender, EventArgs e)
        {
            if (datosCorrectosParaAgregar() && !this.hay_dni_repetido_en_DB())
            {
                conexion.armar_query_dinamica_insert("Empleado (Empleado_Nombre, Empleado_Apellido, Empleado_DNI, Empleado_Mail, EMPLEADO_Tel,"+                          "Empleado_Dir, Empleado_Tipo, Empleado_Provincia, Empleado_Hab,Empleado_sucursal) values ('" +
                    this.textBox_crear_nombre.Text + "','" + this.textBox_crear_apellido.Text + "'," + this.textBox_crear_dni.Text + ",'" +
                    this.textBox_crear_email.Text + "','" + this.textBox_crear_tel.Text + "','" + this.textBox_crear_dir_calle.Text + "|" +
                    this.textBox_crear_dir_numero.Text + "|" + this.textBox_crear_dir_pisodepto.Text + "'," +
                    " GURP_SKYPE.obtener_tipo_empleado_id('" + comboBox_crear_tipo_emp.Text + "')," +
                    "GURP_SKYPE.obtener_provincia_id('" + this.comboBox_crear_provincia.Text + "')," + "1" + "," +
                    "GURP_SKYPE.obtener_sucursal_id('" + this.comboBox_crear_sucursal.Text + "','" + this.comboBox_crear_provincia.Text + "'))");
                MessageBox.Show("Se guardo correctamente al producto");
            } 
        }
        /*================================================================*/

        private bool datosCorrectosParaAgregar()
        {
            string errores;
            errores = estan_los_datos_completos();
            
            if (errores.Length == 0)
                return true;
            MessageBox.Show("Errores: \n" + errores);
            return false;
        }
        /*================================================================*/

        #region hay_dni_repetido()
        /*
         * Cheo que el DNI no este repetido y que no se encuentre fuera de rango, tiene un maximo de 8 digitos
         */ 
        private string hay_dni_repetido()
        {
            DataSet dni_empleado;
            string aux;
            if (this.textBox_crear_dni.Text.Length > 8)
                return "DNI: formato invalido, es hasta 8 digitos\n";
            aux = u.verificar_campo_completo(this.textBox_crear_dni.Text, "NUMEROS", "DNI");
            if (aux.Length != 0)
                return aux;



            dni_empleado = conexion.armar_query_dinamica_consulta("empleado_dni", "empleado", conexion.agregar_com_sim(textBox_crear_dni.Text)
                + " =   cli_dni");
            if (dni_empleado != null)
            {
                return "DNI repetido\n";
            }

            return "";
        }
        #endregion

        #region estan_los_datos_completos()
        /* Me fijo que el usuario haya completado correctamente todos los campos */
        private string estan_los_datos_completos()
        {
            string datos_faltantes = "";

            datos_faltantes += u.verificar_campo_completo(this.textBox_crear_nombre.Text, "LETRAS", "Nombre");
            datos_faltantes += u.verificar_campo_completo(this.textBox_crear_apellido.Text, "LETRAS", "Apellido");
            datos_faltantes += hay_dni_repetido();

            if (!u.IsValidEmail(this.textBox_crear_email.Text))
                datos_faltantes += "Formato de email invalido.\n";

            datos_faltantes += u.verificar_campo_completo(this.textBox_crear_tel.Text, "NUMEROS", "Teléfono");
            datos_faltantes += u.verificar_campo_completo(this.textBox_crear_dir_calle.Text, "LETRAS", "Direccion Calle");
            datos_faltantes += u.verificar_campo_completo(this.textBox_crear_dir_numero.Text, "NUMEROS", "Direccion Altura");
            datos_faltantes += u.verificar_campo_completo(this.textBox_crear_dir_pisodepto.Text, "NUMEROS", "Direccion Piso o Depto");
            
            /*No deberia suceder nunca*/
            if (comboBox_crear_sucursal.SelectedIndex == -1)
                datos_faltantes += " Falta Seleccionar la Sucursal.\n";
            if (comboBox_crear_tipo_emp.SelectedIndex == -1)
                datos_faltantes += (" Falta Seleccionar Tipo de Empleado.\n");
            if (comboBox_crear_provincia.SelectedIndex == -1)
                datos_faltantes += (" Falta Seleccionar la Provincia.\n");
            
            if (datos_faltantes.Length != 0)
            {
                return datos_faltantes;
            }
            return "";
        }

        #endregion //stan_los_datos_completos()


        #endregion //accion de apretar el boton aceptar
        /*================================================================*/

        #endregion

        /*================================================================*/

        #region pestaña modificar eliminar
        

        #region accion de apretar el boton buscar en la base de datos

        /* 
         * Metodo que se encarga de cargar los parametros de busqueda, en caso de que los haya,
         * y cagar el resultado en el datagrid
         */
        private void button_buscar_database_Click(object sender, EventArgs e)
        {
            
            if (validar_campos_requeridos_para_busqueda())
            {
                realizar_busqueda();
            }
        }
        

        /* 
         * Metodo para valir que los campos que se completaron tengan valores validos
         */
        private bool validar_campos_requeridos_para_busqueda()
        {
            string mensajeDeError = "";
            //Cheo si se ingreso algo de forma erronea
            mensajeDeError += u.verificar_campo_parcial(textBox_model_buscar_nombre.Text, "LETRAS", "Nombre");
            mensajeDeError += u.verificar_campo_parcial(textBox_model_buscar_apellido.Text, "LETRAS", "Apellido");
            mensajeDeError += u.verificar_campo_parcial(textBox_model_buscar_dni.Text, "NUMEROS", "DNI");

            //Si todo es Valido retorno True
            if (mensajeDeError.Length == 0)
                return true;
            //Si hubo errores los muestro y retorno false
            MessageBox.Show(mensajeDeError);
            return false;
            
                
        }

        /*
         * Metodo que genera el string con los filtros para la busqueda
         */
        private string agregarCampos()
        {
            string condicionesDeBusqueda = "";

            if (textBox_model_buscar_apellido.Text.Length != 0)
                condicionesDeBusqueda += conexion.empleado_apellido + " LIKE '%" + textBox_model_buscar_apellido.Text + "%'\n";
            if (textBox_model_buscar_nombre.Text.Length != 0)
            {
                if (condicionesDeBusqueda.Length != 0) condicionesDeBusqueda += " and ";
                condicionesDeBusqueda += conexion.empleado_nombre + " LIKE '%" + textBox_model_buscar_nombre.Text + "%'\n";
            }
            if (textBox_model_buscar_dni.Text.Length != 0)
            {
                if (condicionesDeBusqueda.Length != 0) condicionesDeBusqueda += " and ";
                condicionesDeBusqueda += conexion.empleado_dni + " = " + textBox_model_buscar_dni.Text + "\n";
            }
            if (comboBox_model_buscar_provincia.Text.Length != 0)
            {
                if (condicionesDeBusqueda.Length != 0) condicionesDeBusqueda += " and ";
                condicionesDeBusqueda += conexion.empleado_provincia + " = GURP_SKYPE.obtener_provincia_id('" + comboBox_model_buscar_provincia.Text + "')\n";
            }
            if (comboBox_model_buscar_sucursal.Text.Length != 0)
            {
                if (condicionesDeBusqueda.Length != 0) condicionesDeBusqueda += " and ";
                condicionesDeBusqueda += conexion.empleado_sucursal + "= GURP_SKYPE.obtener_sucursal_id('" + comboBox_model_buscar_sucursal.Text + "','" +
                comboBox_model_buscar_provincia.Text + "')\n";
            }
            if (comboBox__model_buscar_tipoemp.Text.Length != 0)
            {
                if (condicionesDeBusqueda.Length != 0) condicionesDeBusqueda += " and ";
                condicionesDeBusqueda += conexion.empleado_tipo + "= GURP_SKYPE.obtener_tipo_empleado_id('" + comboBox__model_buscar_tipoemp.Text + "')\n";
            }
        

            //si hay algo para poner en el where lo agrego
            if (condicionesDeBusqueda.Length != 0)
                return (" where " + condicionesDeBusqueda + "\n order by "+ conexion.empleado_nombre + "\n");
            //no hay anda para el where y retorno ""
            return ""; 
            
        }

        #endregion


        #region accion de apretar el boton limpiar

        /*
         * Metodo para limpiar la pestaña de modificaciones
         */
        private void button_model_limpiar_Click(object sender, EventArgs e)
        {
            textBox_model_buscar_nombre.Clear();
            textBox_model_buscar_apellido.Clear();
            textBox_model_buscar_dni.Clear();
            comboBox_model_buscar_sucursal.SelectedIndex = 0;
            comboBox__model_buscar_tipoemp.SelectedIndex = 0;
            comboBox_model_buscar_provincia.SelectedIndex = 0;

        }
        #endregion

        


        #endregion

        /*================================================================*/
        #region Al cargar el Formulario Cargo los combo box
        private void FormAbmEmpleado_Load(object sender, EventArgs e)
        {
            comboBox_crear_tipo_emp.Items.Add("Analista");
            comboBox_crear_tipo_emp.Items.Add("Vendedor");
            comboBox_crear_tipo_emp.SelectedIndex = 1;
            comboBox__model_buscar_tipoemp.Items.Add("");
            comboBox__model_buscar_tipoemp.Items.Add("Analista");
            comboBox__model_buscar_tipoemp.Items.Add("Vendedor");
            comboBox__model_buscar_tipoemp.SelectedIndex = 0;
            cargar_provincias_en_combobox();
        }

        
        #region cargar_provincias_en_combobox()
        private void cargar_provincias_en_combobox()
        {
            DataTable tabla_Sucursales;
            tabla_Sucursales = conexion.realizar_consulta("select provincia_nombre from GURP_SKYPE.provincia").Tables[0];

            //Carga la opcion nula para la busqueda, puede que no quiera buscar por provincia
            comboBox_model_buscar_provincia.Items.Add("");
            foreach (DataRow row_sucursal in tabla_Sucursales.Rows)
            {
                string una_sucursal = row_sucursal[0].ToString();
                comboBox_crear_provincia.Items.Add(una_sucursal);
                comboBox_model_buscar_provincia.Items.Add(una_sucursal);
            }
            comboBox_crear_provincia.SelectedIndex = 0;
            comboBox_model_buscar_provincia.SelectedIndex = 0;
        }
        #endregion

        #region Cargo sucursales segun la provincia seleccionada
        private void comboBox_crear_provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSucursal(comboBox_crear_provincia, comboBox_crear_sucursal);
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
            tabla_Sucursales = conexion.realizar_consulta("select suc_dir from GURP_SKYPE.sucursal where suc_provincia = GURP_SKYPE.obtener_provincia_id('"
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

        #endregion
        
        /*================================================================*/

        /*
         * Metodo que se encarga de crear el nuevo form para las modificaciones o validar 
         * la eliminacion(Logica) de un Empleado 
         */
        private void dataGridView_resultado_busqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Paso al form de modificacion
            if (e.ColumnIndex == dataGridView_resultado_busqueda.Columns["Modificar"].Index)
            {
                FormModEmpleado form_mod_empleado = new FormModEmpleado();
                form_mod_empleado.cargar_datos_cliente(dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["ID"].Value.ToString(),
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Apellido"].Value.ToString(),
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Direccion"].Value.ToString(),
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Provincia"].Value.ToString(),
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Telefono"].Value.ToString(),
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Mail"].Value.ToString(),
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Habilitado"].Value.ToString());
                form_mod_empleado.ShowDialog(this);
                realizar_busqueda();
            }
            //Deshabilito un empleado
            else if (e.ColumnIndex == dataGridView_resultado_busqueda.Columns["Eliminar"].Index)
            {
                if (conexion.armar_query_dinamica_update("Empleado", "EMPLEADO_Hab = 0", "EMPLEADO_ID = " + conexion.agregar_com_sim(this.dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["ID"].Value.ToString())) == 0)
                    MessageBox.Show("El Empleado se Elimino con Exito.");
                this.dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Habilitado"].Value = false;
                realizar_busqueda();
            }
        }

        /*================================================================*/

        #region metodo hay un dni repetido
        /*
         * verifica que no haya dni repetido tanto de cliente 
         * como de empleado
         */
        private bool hay_dni_repetido_en_DB()
        {
            DataTable undatatable;

            undatatable = conexion.armar_query_dinamica_consulta("cli_dni", "cliente", conexion.agregar_com_sim(textBox_crear_dni.Text) + " = cli_dni").Tables[0];

            if (undatatable.Rows.Count != 0)
            {
                MessageBox.Show("El DNI ya existe y pertenece a un cliente. Ingrese Otro Por Favor.");
                return true;
            }

            undatatable = conexion.armar_query_dinamica_consulta("empleado_dni", "empleado", conexion.agregar_com_sim(textBox_crear_dni.Text) + " = empleado_dni").Tables[0];

            if (undatatable.Rows.Count != 0)
            {
                MessageBox.Show("El DNI ya existe y pertenece a un empleado. Ingrese Otro Por Favor.");
                return true;
            }
            return false;
        }
        #endregion

        private void realizar_busqueda()
        {
            DataSet resultadoDeLaConsulta;
            //Consulta SQL con los datos que necesito que me devuelva
            string consulta = "select EMPLEADO_Id as ID, EMPLEADO_Nombre as Nombre, EMPLEADO_Apellido as Apellido, EMPLEADO_DNI as DNI," +
                "EMPLEADO_DIR as Direccion,EMPLEADO_Tel as Telefono, EMPLEADO_mail as Mail," +
            "(select provincia_nombre from GURP_SKYPE.provincia where provincia_id = EMPLEADO_Provincia) as Provincia," +
            "(select suc_dir from GURP_SKYPE.sucursal where suc_id = EMPLEADO_Sucursal)as Sucursal," +
            "(select tipo_emp_descripcion from GURP_SKYPE.Tipo_empleado where tipo_emp_id = EMPLEADO_tipo) as 'Tipo Empleado', " +
            "EMPLEADO_hab as Habilitado FROM GURP_SKYPE.Empleado\n";
            conexion.nombre_tabla = "Empleado";

            //Cargo los parametros por los cuales voy a filtrar a los empleados
            consulta += agregarCampos();
            resultadoDeLaConsulta = conexion.realizar_consulta(consulta);
            if (resultadoDeLaConsulta != null)
            {
                //Cargo los valores que me devuelve la base de datos
                this.dataGridView_resultado_busqueda.DataSource = resultadoDeLaConsulta.Tables["Empleado"];
                //this.dataGridView_resultado_busqueda.Columns["ID"].Visible = false;
                //this.dataGridView_resultado_busqueda.Columns["Mail"].Visible = false;
                //this.dataGridView_resultado_busqueda.Columns["Direccion"].Visible = false;
                //this.dataGridView_resultado_busqueda.Columns["Telefono"].Visible = false;
                //this.dataGridView_resultado_busqueda.Columns["Habilitado"].Visible = false;

                //Creo las columnas Para Modificar o eliminar una sola vez, por eso el if
                //Sino cada vez que busque voy a ir agregando más columnas
                if (!dataGridView_resultado_busqueda.Columns.Contains("Modificar"))
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
        
        /*================================================================*/
    }
}
