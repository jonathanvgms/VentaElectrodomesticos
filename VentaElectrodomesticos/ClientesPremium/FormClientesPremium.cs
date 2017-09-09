using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.FormsComunes;

namespace VentaElectrodomesticos.ClientesPremium
{
    public partial class FormClientesPremium : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        QuerysPesadas qp = new QuerysPesadas();

        public FormClientesPremium()
        {
            InitializeComponent();
        }

        #region accion de apretar el boton buscar
        /*
         * en este metodo se armar la query
         * identificando a una sucursal de forma univoca con su provincia y direccion 
         * y tambien ingresando la fecha de busqueda
         */ 
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet clientes_dataset;

            if (verificar_seleccion())
            {
                con.nombre_tabla = "Cliente";

                clientes_dataset = con.realizar_consulta(qp.query_clientes_premiun(u.obtener_numero_direccion(this.comboBox_sucursales.Text), u.obtener_calle_direccion(this.comboBox_sucursales.Text), this.textBox_fecha_selec.Text));

                if (clientes_dataset.Tables["Cliente"].Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados.");
                }
                else
                {
                    FormSelecCliePrem un_cli_prem = new FormSelecCliePrem(clientes_dataset);
                    un_cli_prem.ShowDialog(this);
                }
            }
        }
        #endregion

        #region metodo verificar seleccion
        /*
         * este metodo verifica se seleccione una sucursal 
         * y un fecha para iniciar la busqueda
         */ 
        private bool verificar_seleccion()
        {
            string datos_faltantes = "";
            
            if (this.comboBox_sucursales.SelectedIndex == -1)
            {
                datos_faltantes += "Seleccione La Sucursal.\n";
            }

            if (this.textBox_fecha_selec.Text.Length == 0)
            {
                datos_faltantes += "Seleccione una Fecha.\n";
            }
            else
            {
                if (this.textBox_fecha_selec.Enabled == true)
                {
                    datos_faltantes += "Fecha Incorrecta.\n";
                }
            }

            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }
        #endregion

        #region accion que se hace cuando se cierra el form
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region accion que se hace cuando se carga el form
        private void FormClientesPremium_Load(object sender, EventArgs e)
        {
            DataTable a_datatable;

            a_datatable = con.armar_query_dinamica_consulta("provincia_nombre, suc_dir", "sucursal, GURP_SKYPE.provincia", "suc_provincia = provincia_id").Tables[0];

            if (a_datatable.Rows.Count != 0)
            {
                foreach (DataRow row in a_datatable.Rows)
                {
                    this.comboBox_sucursales.Items.Add(row[0].ToString() + "|" + row[1].ToString());
                }
                this.comboBox_sucursales.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No se encontraron Resultados.");
            }
        }
        #endregion

        #region accion que se hace cuando se apreta el boton seleccionar fecha
        private void button3_Click(object sender, EventArgs e)
        {
            FormSelecFecha una_fecha = new FormSelecFecha();
            una_fecha.ShowDialog(this);
            this.textBox_fecha_selec.Text = una_fecha.get_fecha();
            this.textBox_fecha_selec.Enabled = false;
        }
        #endregion

        #region accion que se hace cuando apreto el boton limpiar
        private void button_limpiar_Click(object sender, EventArgs e)
        {            
            this.comboBox_sucursales.Text = "";
            this.textBox_fecha_selec.Clear();
            this.textBox_fecha_selec.Enabled = true;
        }
        #endregion
    }
}
