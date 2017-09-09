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
    public partial class FormAbmCliente : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();        
        
        public FormAbmCliente()
        {
            InitializeComponent();            
        }

        #region pestaña crear cliente

        #region accion de apretar el boton aceptar
        /*
         * una vez verificado que todos loa campos sean validos y no se encuentren el dni
         * tanto del cliente repetido como de empleado se procede a insertar a un nuevo
         * cliente
         */ 
        private void button_crear_aceptar_Click(object sender, EventArgs e)
        {            
            if (estan_los_datos_completos() && !hay_dni_repetido())
            {                
                con.armar_query_dinamica_insert(con.cliente_tabla + con.cliente_fila + con.values +
                    con.par_abier + "GURP_SKYPE.obtener_provincia_id ('" + comboBox_crear_provincia.Text + "')" + con.coma +
                    con.agregar_com_sim(textBox_crear_dni.Text) + con.coma + con.agregar_com_sim(textBox_crear_nombre.Text) + con.coma +
                    con.agregar_com_sim(textBox_crear_apellido.Text) + con.coma + con.agregar_com_sim(textBox_crear_tel.Text) + con.coma +
                    con.agregar_com_sim(textBox_crear_email.Text) + con.coma + con.agregar_com_sim(textBox_crear_dir_calle.Text + "|" + textBox_crear_dir_numero.Text + "|" + textBox_crear_dir_pisodepto.Text) + con.coma + "1" + con.par_cerra);
                    MessageBox.Show("Se guardo correctamente al cliente");
            }

        }
        #endregion

        #region accion de apretar el boton limpiar
        /*
         * metodo que se encarga de limpiar todos los campos del form
         * en particular de la parte de crear cliente
         */ 
        private void button_crear_limpliar_Click(object sender, EventArgs e)
        {            
            this.comboBox_crear_provincia.Text = "";            
            textBox_crear_nombre.Clear();
            textBox_crear_apellido.Clear();
            textBox_crear_dni.Clear();
            textBox_crear_email.Clear();
            textBox_crear_tel.Clear();
            textBox_crear_dir_calle.Clear();
            textBox_crear_dir_numero.Clear();
            textBox_crear_dir_pisodepto.Clear();            
        }
        #endregion

        #region accion de apretar el boton salir 
        private void button_crear_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region metodo hay un dni repetido
        /*
         * verifica que no haya dni repetido tanto de cliente 
         * como de empleado
         */ 
        private bool hay_dni_repetido()
        {                 
            DataTable undatatable;

            undatatable = con.armar_query_dinamica_consulta("cli_dni", "cliente", con.agregar_com_sim(textBox_crear_dni.Text) + " = cli_dni").Tables[0];
            
            if (undatatable.Rows.Count != 0)
            {
                MessageBox.Show("El DNI de ese cliente ya existe. Ingrese Otro Por Favor.");
                return true;
            }

            undatatable = con.armar_query_dinamica_consulta("empleado_dni", "empleado", con.agregar_com_sim(textBox_crear_dni.Text) + " = empleado_dni").Tables[0];
            
            if (undatatable.Rows.Count != 0)
            {
                MessageBox.Show("El DNI de ese empleado ya existe. Ingrese Otro Por Favor.");
                return true;
            }
            return false;
        }
        #endregion

        #region metodo estan los datos completos
        /*
         * este metodo verifica que ningun campo quede vacio y la intergridad de los mismos
         * o sea que el texto es texto, etc...
         * y que se selecciona el combobox de provincias         
         */
        private bool estan_los_datos_completos()
        {            
            string datos_faltantes = "";
         
            datos_faltantes += u.verificar_campo_completo(textBox_crear_nombre.Text, "LETRAS", "Nombre");
            datos_faltantes += u.verificar_campo_completo(textBox_crear_apellido.Text, "LETRAS", "Apellido");
            datos_faltantes += u.verificar_campo_completo(textBox_crear_dni.Text, "NUMEROS", "DNI");
            if (this.textBox_crear_email.Text.Length == 0)
            {
                datos_faltantes += "Falta Ingresar el Mail.\n";
            }
            else
            {
                if (!u.IsValidEmail(this.textBox_crear_email.Text))
                {
                    datos_faltantes += "Mail Incorrecto\n";
                }
            }
            datos_faltantes += u.verificar_campo_completo(textBox_crear_tel.Text, "NUMEROS", "Teléfono");
            datos_faltantes += u.verificar_campo_completo(textBox_crear_dir_calle.Text, "LETRAS", "Direccion Calle");
            datos_faltantes += u.verificar_campo_completo(textBox_crear_dir_numero.Text, "NUMEROS", "Direccion Altura");
            datos_faltantes += u.verificar_campo_completo(textBox_crear_dir_pisodepto.Text, "NUMEROS", "Direccion Piso o Depto");
            
            
            if (comboBox_crear_provincia.Text.Length == 0)
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

        #endregion

        #region pestaña modificar-eliminar

        #region accion de apretar el boton salir
        /*
         * cierra el form
         */ 
        private void button_model_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region accion de apretar el boton buscar
        /*
         * metodo que encarga una vez hecha la parte del where del select
         * realizar la busqueda y añadirlo al datagrid
         */ 
        private void button_model_buscar_database_Click(object sender, EventArgs e)
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

            datos_incorrectos = u.verificar_campo_parcial(this.textBox_model_buscar_nombre.Text, "LETRAS", "Nombre");
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
        /*
         * limpia los textbox en la parte del form modificar
         */ 
        private void button_model_limpiar_Click(object sender, EventArgs e)
        {
            textBox_model_buscar_nombre.Clear();
            textBox_model_buscar_apellido.Clear();
            textBox_model_buscar_dni.Clear();                       
        }
        #endregion
                
        #endregion

        #region accion que se hace cuando se carga el form
        /*
         * evento que solamente se encarga de que cuaando se carga el metodo 
         * llamar al metodo cargar provincias
         */ 
        private void FormAmbClienteLoad(object sender, EventArgs e)
        {            
            u.cargar_provincias_en_combobox(this.comboBox_crear_provincia);
            
            //agrego la opcion vacia
            this.comboBox_model_buscar_provincias.Items.Add("");
            u.cargar_provincias_en_combobox(this.comboBox_model_buscar_provincias);
        }
        #endregion

        #region accion que se realiza al seleccionar una celda para modificar
        /*
         * evento que crea el form de modificacion e inicializa por 
         * medio de su constructor los datos que apareceran en el form
         */ 
        private void seleccionar_celda(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView_resultado_busqueda.Columns["Modificar"].Index) && (e.RowIndex > -1))
            {                
                FormModCliente mod_cli = new FormModCliente();                
                mod_cli.set_propiedades_cliente(dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["DNI"].Value.ToString(),
                    this.dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Apellido"].Value.ToString(),                    
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Dirección"].Value.ToString(),
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Email"].Value.ToString(),
                    dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Teléfono"].Value.ToString());
                mod_cli.ShowDialog(this);
                realizar_busqueda();
                
            }

            /*
             * Solo se realiza un baja logica del cliente, lo que solo altera la columna de habilitado
             * si si quiere volver a habilitarlo se hace desde el chekbox del form modificacion
             */
            if ((e.ColumnIndex == dataGridView_resultado_busqueda.Columns["Eliminar"].Index) && (e.RowIndex > -1))
            {
                con.armar_query_dinamica_update("Cliente", "cli_hab = 0", "cli_dni = " + con.agregar_com_sim(this.dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["DNI"].Value.ToString()));
                MessageBox.Show("El Cliente se Elimino con Exito.");
                realizar_busqueda();
            }
        }
        #endregion

        private void realizar_busqueda()
        {
            string string_where = "";

            DataSet un_dataset;

            string_where = u.armar_where_query_cliente(this.comboBox_model_buscar_provincias, this.textBox_model_buscar_nombre.Text, this.textBox_model_buscar_apellido.Text, this.textBox_model_buscar_dni.Text);

            con.nombre_tabla = "Cliente";

            if (string_where.Length != 0)
            {
                un_dataset = con.armar_query_dinamica_consulta("cli_dni as DNI, cli_nombre as 'Nombre', cli_apellido as 'Apellido', (select provincia_nombre from GURP_SKYPE.provincia where provincia_id = cli_provincia) as 'Provincia', cli_telefono as 'Teléfono', cli_mail as 'Email', cli_direccion as 'Dirección', cli_hab as 'Habilitado'", "cliente", string_where);
            }
            else
            {
                un_dataset = con.armar_query_dinamica_consulta("cli_dni as DNI, cli_nombre as 'Nombre', cli_apellido as 'Apellido', (select provincia_nombre from GURP_SKYPE.provincia where provincia_id = cli_provincia) as 'Provincia', cli_telefono as 'Teléfono', cli_mail as 'Email', cli_direccion as 'Dirección', cli_hab as 'Habilitado'", "cliente");
            }

            if (un_dataset.Tables["Cliente"].Rows.Count != 0)
            {
                this.dataGridView_resultado_busqueda.DataSource = un_dataset.Tables["Cliente"];

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

        private void tabPage_model_emp_Click(object sender, EventArgs e)
        {

        }
    }
}
