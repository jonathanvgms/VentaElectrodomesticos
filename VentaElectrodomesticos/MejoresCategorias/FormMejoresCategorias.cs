using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.FormsComunes;

namespace VentaElectrodomesticos.MejoresCategorias
{
    public partial class FormMejoresCategorias : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        QuerysPesadas qp = new QuerysPesadas();        

        public FormMejoresCategorias()
        {
            InitializeComponent();
        }

        #region accion de apretar el boton buscar fecha
        /*
         * abre el form para la busqueda de fecha
         * y almacena la misma en el textbox correspondiente 
         * en formato datetime
         */ 
        private void button3_Click(object sender, EventArgs e)
        {
            FormSelecFecha una_fecha = new FormSelecFecha();            
            una_fecha.ShowDialog(this);
            this.textBox_fecha_selec.Text = una_fecha.get_fecha();
            this.textBox_fecha_selec.Enabled = false;
        }
        #endregion

        #region accion de apretar el boton SALIR
        /*
         * cierra el form
         */ 
        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region accion de apretar el boton limpiar
        /*
         * seteea el contenido de los combobox
         * por default
         */ 
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            this.textBox_fecha_selec.Clear();
            this.comboBox_sucursales.SelectedIndex = 0;
            this.textBox_fecha_selec.Enabled = true;
        }
        #endregion

        #region accion que se realiza cuando se carga el form
        /*
         * este metodo trae el las provincias los carga al combobox
         * y lo setea
         */ 
        private void FormMejoresCategorias_Load(object sender, EventArgs e)
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

        #region accion de apretar el boton buscar
        /*
         * en este metodo se realiza la busqueda propiamante dicha
         * donde en realidad se hacen los calculos en la funcion [GURP_SKYPE.mejores_categorias]
         * y la misma retorna la tabla con los resultados
         */ 
        private void button_buscar_Click(object sender, EventArgs e)
        {
            DataSet categorias_dataset;

            if (verificar_seleccion())
            {
                con.nombre_tabla = "Categoria";

                categorias_dataset = con.realizar_consulta("select nombre_cat as 'Nombre Categoria', cant_total_sub_cat as 'Cantidad Total Subacategorias', " + 
                    "monto_total_facturado as 'Monto Total Facturado', prod_vend as 'Producto Mas Vendido', prod_fact as 'Producto Mas Facturado', prod_caro as 'Producto Mas Caro', " + 
                    "gran_vend as 'Vendedor Que Mas Vendio' from GURP_SKYPE.mejores_categorias('" + u.obtener_numero_direccion(this.comboBox_sucursales.Text) + "', '" + u.obtener_calle_direccion(this.comboBox_sucursales.Text) + "', '" + this.textBox_fecha_selec.Text + "')");

                if (categorias_dataset == null)
                {
                    MessageBox.Show("No se encontraron resultados.");
                }
                else
                {
                    if (categorias_dataset.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron resultados.");
                    }
                    else
                    {
                    FormSeleccionarMejCat mej_cats = new FormSeleccionarMejCat(categorias_dataset);
                    mej_cats.ShowDialog(this);
                    }
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

            if (comboBox_sucursales.SelectedIndex == -1)
            {
                datos_faltantes = "Seleccione una Sucursal.\n";
            }          

            if (this.textBox_fecha_selec.Text.Length == 0)
            {
                datos_faltantes += "Seleccione una Fecha.\n";
            }

            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }
        #endregion
    }
}
