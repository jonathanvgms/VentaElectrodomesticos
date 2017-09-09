using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.FormsComunes;

namespace VentaElectrodomesticos.TableroControl
{
    public partial class FormTableroControl : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        QuerysPesadas qp = new QuerysPesadas();

        public FormTableroControl()
        {
            InitializeComponent();
        }
        #region accion de apretar el boton salir
        /*
         * este metodo se encarga de cerrar el form
         */ 
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region accion de apretar el boton buscar
        /*
         * es este se encarga de buscar cada resultado del tablero de control 
         * por medio de una query para cada campo especifico,
         * las mismas se almacenar en el archivo QuerysPesadas.cs
         * 
         * y luego con los resultados los carga en sus respectivos textbox
         * 
         */
        private void button_buscar_Click(object sender, EventArgs e)
        {
            DataTable a_datatable;
            DataSet aux;
            if (verificar_seleccion())
            {
                con.nombre_tabla = "Nombre";

                /*traigo el total del ventas y el de total de facturacion*/
                aux = con.realizar_consulta(qp.query_tab_con_total_ventas_total_fact(u.obtener_numero_direccion(this.comboBox_sucursales.Text), u.obtener_calle_direccion(this.comboBox_sucursales.Text), this.textBox_fecha_selec.Text));
                if (aux == null)
                {
                    this.textBox_total_ventas.Text = "No Se Encontraron resultados.";
                    this.textBox_total_fact.Text = "No Se Encontraron resultados.";
                }
                else
                {
                    a_datatable = aux.Tables[0];

                    if (a_datatable.Rows.Count == 0)
                    {
                        this.textBox_total_ventas.Text = "No Se Encontraron resultados.";
                        textBox_total_fact.Text = "No Se Encontraron resultados.";
                    }
                    else
                    {
                        this.textBox_total_ventas.Text = a_datatable.Rows[0][0].ToString();
                        this.textBox_total_fact.Text = a_datatable.Rows[0][1].ToString();
                    }

                    a_datatable.Rows.Clear();                    
                }

                /*--------------------------------- //Deshabilitado// ---------------------------------*/
                 /*traigo el total de facturacion*/
               /* aux = con.realizar_consulta(qp.query_tab_con_total_fact(u.obtener_numero_direccion(this.comboBox_sucursales.Text), u.obtener_calle_direccion(this.comboBox_sucursales.Text), this.textBox_fecha_selec.Text));
                if (aux == null)
                    this.textBox_total_fact.Text = "No Se Encontraron resultados.";
                else
                {
                    a_datatable = aux.Tables[0];
                    this.escribir_resultado_en_textbox(this.textBox_total_fact, a_datatable);
                    a_datatable.Rows.Clear();
                }*/
                /*--------------------------------- //Deshabilitado// ---------------------------------*/


                /*traigo proporcion forma de pago*/
                aux = con.realizar_consulta(qp.query_tab_con_prop_forma_pago(u.obtener_numero_direccion(this.comboBox_sucursales.Text), u.obtener_calle_direccion(this.comboBox_sucursales.Text), this.textBox_fecha_selec.Text));
                if (aux == null)
                    this.textBox_prop_forma_pago.Text = "No Se Encontraron resultados.";
                else
                {
                    a_datatable = aux.Tables[0];
                    this.escribir_resultado_en_textbox(this.textBox_prop_forma_pago, a_datatable);
                    a_datatable.Rows.Clear();
                }
                /*traigo la mayor factura*/
                aux = con.realizar_consulta(qp.query_tab_con_mayor_factura(u.obtener_numero_direccion(this.comboBox_sucursales.Text), u.obtener_calle_direccion(this.comboBox_sucursales.Text), this.textBox_fecha_selec.Text));
                if (aux == null)
                    this.textBox_may_factura.Text = "No Se Encontraron resultados.";
                else
                {
                    a_datatable = aux.Tables[0];
                    this.escribir_resultado_en_textbox(this.textBox_may_factura, a_datatable);
                    a_datatable.Rows.Clear();
                }
                /*traigo el mayor deudor*/
                aux = con.realizar_consulta(qp.query_tab_con_mayor_deudor(u.obtener_numero_direccion(this.comboBox_sucursales.Text), u.obtener_calle_direccion(this.comboBox_sucursales.Text), this.textBox_fecha_selec.Text));

                if (aux == null)
                    this.textBox_may_deudor.Text = "Ninguno";
                else
                {
                    a_datatable = aux.Tables[0];
                    if (a_datatable.Rows.Count == 0)
                    {
                        this.textBox_may_deudor.Text = "Ninguno.";
                    }
                    else
                    {
                        this.escribir_resultados_en_textbox(this.textBox_may_deudor, a_datatable, "Nombre", "Apellido", "Dni");
                    }
                    a_datatable.Rows.Clear();
                }
                /*traigo el vendedor estrella*/
                aux = con.realizar_consulta(qp.query_tab_con_vend_anio(u.obtener_numero_direccion(this.comboBox_sucursales.Text), u.obtener_calle_direccion(this.comboBox_sucursales.Text), this.textBox_fecha_selec.Text));
                if (aux == null)
                    this.textBox_vededor_año.Text = "No Se Encontraron resultados.";
                else
                {
                    a_datatable = aux.Tables[0];
                    this.escribir_resultados_en_textbox(this.textBox_vededor_año, a_datatable, "Nombre", "Apellido", "Dni");               
                    a_datatable.Rows.Clear();
                }
                /*producto del año*/
                aux = con.realizar_consulta(qp.query_tab_con_prod_anio(u.obtener_numero_direccion(this.comboBox_sucursales.Text), u.obtener_calle_direccion(this.comboBox_sucursales.Text), this.textBox_fecha_selec.Text));
                if (aux == null)
                    this.textBox_product_año.Text = "No Se Encontraron resultados.";
                else
                {
                    a_datatable = aux.Tables[0];
                    this.escribir_resultados_en_textbox(this.textBox_product_año, a_datatable, "Cod. Prod.", "Nombre Prod.", "Categoría");
                    a_datatable.Rows.Clear();
                }
                //faltante de stock
                aux = con.realizar_consulta(qp.query_tab_con_faltante_stock(u.obtener_numero_direccion(this.comboBox_sucursales.Text), u.obtener_calle_direccion(this.comboBox_sucursales.Text), this.textBox_fecha_selec.Text));
                if (aux == null)
                    this.textBox_faltante_stock.Text = "No Se Encontraron resultados.";
                else
                {
                    a_datatable = aux.Tables[0];
                    this.escribir_resultados_en_textbox(this.textBox_faltante_stock, a_datatable, "Cod. Prod.", "Días sin Stock", "");                
                }
            }
        }
        #endregion

        #region metodos escribir resultado/s en textbox
        /*
         * ambos metodos encribe en resultados del los querys del tablero de control
         * en sus respectivos textbox
         */

        private void escribir_resultados_en_textbox(TextBox textBox, DataTable a_datatable, string c1, string c2, string c3)
        {            
            if (a_datatable.Rows.Count == 0)
            {
                textBox.Text = "No Se Encontraron resultados.";
            }
            else
            {
                /*for (col = 0; col < a_datatable.Columns.Count; col++)
                {
                    aux += a_datatable.Rows[0][col].ToString() + ", ";
                }*/                
                textBox.Text = c1 + ": " + a_datatable.Rows[0][0].ToString();

                if (c2.Length != 0)
                {
                    textBox.Text += ", " + c2 + ": " + a_datatable.Rows[0][1].ToString();
                    if (c3.Length != 0)
                    {
                        textBox.Text += ", " + c3 + ": " + a_datatable.Rows[0][2].ToString();
                    }
                }

            }          
        }

        private void escribir_resultado_en_textbox(TextBox box, DataTable a_datatable)
        {
            if (a_datatable.Rows.Count == 0)
            {
                box.Text = "No Se Encontraron resultados.";
            }
            else
            {
                box.Text = a_datatable.Rows[0][0].ToString();
            }
        }
        #endregion

        #region accion de apretar el boton limpiar
        /*
         * este metodo se encarga de limpiar todo el forn de una busqueda anterior
         */
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            this.comboBox_sucursales.Text = "";            
            this.textBox_fecha_selec.Clear();

            this.textBox_faltante_stock.Clear();
            this.textBox_fecha_selec.Clear();
            this.textBox_may_deudor.Clear();
            this.textBox_may_factura.Clear();
            this.textBox_product_año.Clear();
            this.textBox_prop_forma_pago.Clear();
            this.textBox_total_fact.Clear();
            this.textBox_total_ventas.Clear();
            this.textBox_vededor_año.Clear();
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
                datos_faltantes = "Seleccione la Sucursal.\n";
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

        #region accion de apretar el boton seleccionar fecha
        /*
         * abre el form de seleccionar fecha y retorna la fecha seleccionada
         */ 
        private void button_seleccionar_fecha_Click(object sender, EventArgs e)
        {
            FormSelecFecha una_fecha = new FormSelecFecha();
            una_fecha.ShowDialog(this);
            this.textBox_fecha_selec.Text = una_fecha.get_fecha();
            this.textBox_fecha_selec.Enabled = false;
        }
        #endregion

        #region accion que se realiza cuando se carga el form
        private void FormTableroControl_Load(object sender, EventArgs e)
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

    }
}
