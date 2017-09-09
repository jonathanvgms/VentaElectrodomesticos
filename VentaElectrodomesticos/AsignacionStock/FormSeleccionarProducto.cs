using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.FormsComunes;

namespace VentaElectrodomesticos.AsignacionStock
{
    public partial class FormSeleccionarProducto : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        string un_producto = "";
        string un_producto_nombre_marca = "";

        public FormSeleccionarProducto()
        {
            InitializeComponent();
        }

        #region boton salir

        private void button_buscar_prod_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region boton buscar

        private void button_buscar_database_Click(object sender, EventArgs e)
        {
            string string_where = "";

            DataSet un_dataset;
            bool flag = false;

            if (estan_los_datos_correctos())
            {
                if (textBox_buscar_codprod.Text.Length != 0)
                {
                    string_where += "producto_id = " + textBox_buscar_codprod.Text;
                    flag = true;
                }
                if (textBox_buscar_nom_mar.Text.Length != 0)
                {
                    if (flag)
                    {
                        string_where += " and (producto_marca LIKE '%" + textBox_buscar_nom_mar.Text + "%' or producto_nombre LIKE '%" + textBox_buscar_nom_mar.Text + "%')";
                    }
                    else
                    {
                        string_where += "(producto_marca LIKE '%" + textBox_buscar_nom_mar.Text + "%' or producto_nombre LIKE '%" + textBox_buscar_nom_mar.Text + "%')";
                        flag = true;
                    }
                }
                if (textBox1.Text.Length != 0)
                {
                    /*if (flag)
                    {
                        string_where += " and producto_cate = GURP_SKYPE.obtener_id_categoria('" + textBox1.Text + "')";
                    }
                    else
                    {
                        string_where += "producto_cate = GURP_SKYPE.obtener_id_categoria('" + textBox1.Text + "')";
                        flag = true;
                    }*/

                    DataSet set_categoria = new DataSet();
                    con.nombre_tabla = "Categorias";
                    set_categoria = con.realizar_consulta("select GURP_SKYPE.obtener_id_categoria('" + textBox1.Text + "')");
                    string cate = set_categoria.Tables[0].Rows[0][0].ToString();
                    if (set_categoria != null)
                    {
                        if (flag)
                        {
                            //string_where += " and producto_cate = GURP_SKYPE.obtener_id_categoria('" + categoria + "')";
                            string_where += " and( producto_cate = " + con.subarbol_de_subcategorias(cate, con) + ")";
                        }
                        else
                        {
                            //string_where += " producto_cate = GURP_SKYPE.obtener_id_categoria('" + categoria + "')";
                            string_where += "  producto_cate = " + con.subarbol_de_subcategorias(cate, con);
                            flag = true;
                        }
                    }
                }

                con.nombre_tabla = "Producto";

                if (string_where.Length != 0)
                {
                    un_dataset = con.armar_query_dinamica_consulta("producto_id as ID, producto_nombre as Nombre, producto_precio as Precio, producto_marca as Marca", "Producto ", string_where + " and producto_hab = 1");
                }
                else
                {
                    un_dataset = con.armar_query_dinamica_consulta("producto_id as ID, producto_nombre as Nombre, producto_precio as Precio, producto_marca as Marca", "Producto ", "producto_hab = 1");
                }

                if (un_dataset.Tables["Producto"].Rows.Count != 0)
                {
                    //dataGridView1

                    dataGridView1.DataSource = un_dataset.Tables["Producto"];

                    if (!dataGridView1.Columns.Contains("Seleccionar"))
                    {
                        DataGridViewButtonColumn columnaSelec = new DataGridViewButtonColumn();

                        columnaSelec.Name = "Seleccionar";

                        columnaSelec.HeaderText = "Seleccionar";

                        //Agrego las columnas al grid                                        
                        this.dataGridView1.Columns.Add(columnaSelec);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados.");
                }
            }
        }

        #endregion

        #region accion de apretar el boton buscar categoria

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormSelecCategorias una_cat = new FormSelecCategorias();
            una_cat.ShowDialog(this);
            this.textBox1.Text = una_cat.get_categoria();
            this.textBox1.Enabled = false;
        }

        #endregion

        #region accion que se realiza cuando se selecciona un producto

        private void seleccionar_cliente(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["Seleccionar"].Index) && (e.RowIndex >= 0))
            {
                un_producto = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                un_producto_nombre_marca = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells["Marca"].Value.ToString();
            }
        }
        #endregion

        #region estan los datos correctos

        private bool estan_los_datos_correctos()
        {
            string datos_incompletos = "";

            datos_incompletos += u.verificar_campo_parcial(textBox_buscar_codprod.Text, "NUMEROS", "Codigo de producto");
            datos_incompletos += u.verificar_campo_parcial(textBox_buscar_nom_mar.Text, "LETRAS", "Nombre o Marca");

            if (datos_incompletos.Length != 0)
            {
                MessageBox.Show(datos_incompletos);
                return false;
            }
            return true;
        }

        #endregion

        #region boton limpiar

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_buscar_codprod.Clear();
            textBox_buscar_nom_mar.Clear();
            textBox1.Clear();
        }

        #endregion

        #region metodo getter del producto

        public string get_producto_selecionado()
        {
            return un_producto;
        }

        #endregion

        public string get_producto_nombre_selecionado()
        {
            return un_producto_nombre_marca;
        }

        private void FormSeleccionarProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
