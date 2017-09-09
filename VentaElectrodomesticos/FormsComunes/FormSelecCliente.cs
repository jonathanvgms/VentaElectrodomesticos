using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.FormsComunes
{
    public partial class FormSeleccionarCliente : Form
    {

        Conexion con = new Conexion();
        Util u = new Util();

        string un_cliente;

        public FormSeleccionarCliente()
        {
            InitializeComponent();
        }

        #region accion de apretar el boton salir
        private void button_selec_emp_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region accion de apretar el boton limpiar
        private void button_model_limpiar_Click(object sender, EventArgs e)
        {
            textBox_model_buscar_apellido.Clear();
            textBox_model_buscar_dni.Clear();
            textBox_model_buscar_nombre.Clear();
        }
        #endregion
        
        #region accion de apretar el boton buscar
        private void button_buscar_database_Click(object sender, EventArgs e)
        {
            string string_where = "";
            
            DataSet un_dataset;

            if (u.estan_los_datos_correctos_cliente(this.textBox_model_buscar_nombre.Text, this.textBox_model_buscar_apellido.Text, this.textBox_model_buscar_dni.Text))
            {
                string_where = u.armar_where_query_cliente(this.comboBox_buscar_provincias, this.textBox_model_buscar_nombre.Text, this.textBox_model_buscar_apellido.Text, this.textBox_model_buscar_dni.Text);
                
                con.nombre_tabla = "Cliente";

                if (string_where.Length != 0)
                {
                    un_dataset = con.armar_query_dinamica_consulta("cli_dni as DNI, cli_nombre as 'Nombre', cli_apellido as 'Apellido', (select provincia_nombre from GURP_SKYPE.provincia where provincia_id = cli_provincia) as 'Provincia', cli_telefono as 'Telefono', cli_mail as 'Email', cli_direccion as 'Dirección'", "cliente", string_where);
                }
                else
                {
                    un_dataset = con.armar_query_dinamica_consulta("cli_dni as DNI, cli_nombre as 'Nombre', cli_apellido as 'Apellido', (select provincia_nombre from GURP_SKYPE.provincia where provincia_id = cli_provincia) as 'Provincia', cli_telefono as 'Telefono', cli_mail as 'Email', cli_direccion as 'Dirección'", "cliente");
                }
                if (un_dataset.Tables["Cliente"].Rows.Count != 0)
                {
                    dataGridView_resultado_busqueda.DataSource = un_dataset.Tables["Cliente"];

                    if (!this.dataGridView_resultado_busqueda.Columns.Contains("Seleccionar"))
                    {
                        DataGridViewButtonColumn columnaSeleccionar = new DataGridViewButtonColumn();

                        columnaSeleccionar.Name = "Seleccionar";

                        columnaSeleccionar.HeaderText = "Seleccionar";

                        this.dataGridView_resultado_busqueda.Columns.Add(columnaSeleccionar);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados.");
                }                
            }
        }
        #endregion

        #region accion que se realiza cuando se carga el form
        private void FormSeleccionarCliente_Load(object sender, EventArgs e)
        {
            this.comboBox_buscar_provincias.Items.Add("");
            u.cargar_provincias_en_combobox(this.comboBox_buscar_provincias);
        }
        #endregion
        
        #region accion que se realiza cuando se selecciona un cliente
        /*
         * metodo que toma el dni nombre y apellido del ciente
         * y lo arma de la forma:
         * 
         * dni|nombre|apellido 
         * 
         * para enviarlo al form que lo llamo
         */ 
        private void seleccionar_cliente(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView_resultado_busqueda.Columns["Seleccionar"].Index) && (e.RowIndex >= 0))
            {
                un_cliente = dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["DNI"].Value.ToString();
                un_cliente += " | ";
                un_cliente += dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                un_cliente += " | ";
                un_cliente += dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
            }
        }
        #endregion

        #region metodo get un cliente
        /*
         * metodo que es un getter del cliente seleccionado
         */ 
        public string get_un_cliente()
        {
            return un_cliente;
        }
        #endregion        
    }
}
