using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.AsignacionStock
{
    public partial class FormAsignacionStock : Form
    {

        Conexion con = new Conexion();
        Util u = new Util();

        string empleado_id = "";
        string producto_id = "";
        string analista_id = "";
        
        public FormAsignacionStock()
        {
            InitializeComponent();
        }

        #region botón salir

        private void button_asig_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region boton buscar producto

        private void button_buscar_producto_Click(object sender, EventArgs e)
        {
            FormSeleccionarProducto buscar_producto = new FormSeleccionarProducto();
            buscar_producto.ShowDialog(this);
            producto_id = buscar_producto.get_producto_selecionado();
            textBox_asig_prod_selec.Text = buscar_producto.get_producto_nombre_selecionado();
        }

        #endregion

        #region boton buscar analista

        private void button_buscar_auditor_Click(object sender, EventArgs e)
        {
            FormSeleccionarAnalista buscar_analista = new FormSeleccionarAnalista();
            buscar_analista.ShowDialog(this);
            analista_id = buscar_analista.get_analista_selecionado();
            textBox_asig_analista_selec.Text = buscar_analista.get_analista_selecionado_nombre();
        }

        #endregion

        #region buscar stock

        private void button_buscar_stock_Click(object sender, EventArgs e)
        {
            string string_where = "";

            DataSet un_dataset;

            if (estan_los_datos_correctos())
            {
                string_where += "stock_sucursal_suc = GURP_SKYPE.obtener_sucursal_id('" + u.obtener_numero_direccion(comboBox1.Text) + "', '" + u.obtener_provincia(comboBox1.Text) + "') and stock_sucursal_producto = " + producto_id;

                con.nombre_tabla = "Stock_Sucursal";

                un_dataset = con.armar_query_dinamica_consulta("stock_sucursal_cant_actual", "Stock_Sucursal ", string_where);

                textBox_asig_stock_disponible.Enabled = true;
                button_asig_guardar.Enabled = true;

                button_buscar_producto.Enabled = false;
                comboBox1.Enabled = false;
                button_buscar_auditor.Enabled = false;
                button_buscar_stock.Enabled = false;
                textBox_asig_prod_selec.Enabled = false;
                textBox_asig_analista_selec.Enabled = false;

                textBox_asig_stock_disponible.Text = un_dataset.Tables["Stock_Sucursal"].Rows[0][0].ToString();
            }
        }

        #endregion

        #region estan los datos correctos

        private bool estan_los_datos_correctos()
        {
            string datos_faltantes = "";

            if (textBox_asig_prod_selec.Text.Length == 0)
            {
                datos_faltantes += "Falta Seleccionar el producto.\n";
            }

            if (textBox_asig_analista_selec.Text.Length == 0)
            {
                datos_faltantes += "Falta seleccionar al analista.\n";
            }

            if (comboBox1.SelectedIndex == -1)
            {
                datos_faltantes += "Falta Seleccionar la Sucursal.\n";
            }
        
            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }

        #endregion

        #region guardar nuevo stock

        private void button_asig_guardar_Click(object sender, EventArgs e)
        {
            if (verificar_stock_modificado())
            {  int comprob = con.armar_query_dinamica_insert(con.asignacion_stock_tabla + con.asignacion_stock_fila + con.values +
                                    con.par_abier + producto_id + con.coma +
                                    textBox_asig_stock_disponible.Text + con.coma + empleado_id + con.coma + analista_id + con.coma + "getdate()" + con.coma + "GURP_SKYPE.obtener_sucursal_id('" + u.obtener_numero_direccion(comboBox1.Text) + "', '" + u.obtener_provincia(comboBox1.Text) + "')" + con.par_cerra);
            if (comprob == 0)
            {
                MessageBox.Show("Se realizó correctamnete la operacion.");
            }
            }
      
        }

        #endregion

        #region verificar stock modificado

        private bool verificar_stock_modificado()
        {
            if (textBox_asig_stock_disponible.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un valor para el stock");
                return false;
            }
            if (!u.que_sean_numeros(textBox_asig_stock_disponible.Text))
            {
                MessageBox.Show("Debe ingresar solo un valor numerico, igual o mayor que cero");
                return false;
            }
            if (Convert.ToInt32(textBox_asig_stock_disponible.Text) < 0)
            {
                MessageBox.Show("Valor de stock incorrecto. El valor debe ser mayor o igual a 0");
                return false;
            }
            return true;
        }

        #endregion

        #region cargar_sucursal_en_combobox()
        private void cargar_sucursal_en_combobox()
        {
            DataTable a_datatable;
            a_datatable = con.armar_query_dinamica_consulta("provincia_nombre, suc_dir", "sucursal, GURP_SKYPE.provincia", "suc_provincia = provincia_id").Tables[0];

            if (a_datatable.Rows.Count != 0)
            {
                foreach (DataRow row in a_datatable.Rows)
                {
                    this.comboBox1.Items.Add(row[0].ToString() + "|" + row[1].ToString());
                }
                this.comboBox1.SelectedIndex = 0;
            }
        }
        #endregion

        #region boton limpiar

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_asig_stock_disponible.Clear();
            textBox_asig_stock_disponible.Enabled = false;
            button_asig_guardar.Enabled = false;
            textBox_asig_prod_selec.Clear();
            button_buscar_producto.Enabled = true;
            comboBox1.Enabled = true;
            textBox_asig_analista_selec.Clear();
            button_buscar_auditor.Enabled = true;
            button_buscar_stock.Enabled = true;
            comboBox1.SelectedIndex = -1;
        }

        #endregion

        #region seter del id de empleado
        public void setear_id(string id)
        {
            empleado_id = id;
        }
        #endregion

        private void FormAsignacionStock_Load(object sender, EventArgs e)
        {
            cargar_sucursal_en_combobox();
        }


    }
}
