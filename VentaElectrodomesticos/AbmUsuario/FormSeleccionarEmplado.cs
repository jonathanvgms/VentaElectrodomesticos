using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.AbmUsuario
{
    public partial class FormSeleccionarEmplado : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        string empleado_seleccionado = "";
        string empleado_seleccionado_nomape = "";

        public FormSeleccionarEmplado()
        {
            InitializeComponent();
        }
        
        #region apretar boton buscar
        private void button_buscar_database_Click(object sender, EventArgs e)
        {
            string string_where = "";
            bool flag = false;

            DataSet un_dataset;

            if (estan_los_datos_correctos())
            {
                if (comboBox_model_buscar_provincia.SelectedIndex != -1)
                {
                    string_where += "empleado_provincia = (select provincia_id from GURP_SKYPE.Provincia where provincia_nombre = '" + comboBox_model_buscar_provincia.SelectedItem.ToString() + "')";
                    flag = true;
                }
                if (comboBox_model_buscar_sucursal.Text.Length != 0)
                {
                    if (flag)
                    {
                        string_where += " and empleado_sucursal = GURP_SKYPE.obtener_sucursal_id('" + comboBox_model_buscar_sucursal.SelectedItem.ToString() + "','" + comboBox_model_buscar_provincia.Text + "')";
                    }
                    else
                    {
                        string_where += "empleado_sucursal = GURP_SKYPE.obtener_sucursal_id('" + comboBox_model_buscar_sucursal.SelectedItem.ToString() + "','" + comboBox_model_buscar_provincia.Text + "')";
                        flag = true;
                    }
                }
                if (comboBox__model_buscar_tipoemp.SelectedIndex != -1)
                {
                    if (flag)
                    {
                        string_where += " and empleado_tipo = (select tipo_emp_id from GURP_SKYPE.Tipo_Empleado where tipo_emp_descripcion = '" + comboBox__model_buscar_tipoemp.SelectedItem.ToString() + "')";
                    }
                    else
                    {
                        string_where += "empleado_tipo = (select tipo_emp_id from GURP_SKYPE.Tipo_Empleado where tipo_emp_descripcion = '" + comboBox__model_buscar_tipoemp.SelectedItem.ToString() + "')";
                        flag = true;
                    }
                }
                if (textBox_model_buscar_dni.Text.Length != 0)
                {
                    if (flag)
                    {
                        string_where += " and empleado_dni = '" + textBox_model_buscar_dni.Text + "'";
                    }
                    else
                    {
                        string_where += " empleado_dni = '" + textBox_model_buscar_dni.Text + "'";
                        flag = true;
                    }
                }
                if (textBox_model_buscar_nombre.Text.Length != 0)
                {
                    if (flag)
                    {
                        string_where += " and empleado_nombre LIKE '%" + textBox_model_buscar_nombre.Text + "%'";
                    }
                    else
                    {
                        string_where += "empleado_nombre LIKE '%" + textBox_model_buscar_nombre.Text + "%'";
                        flag = true;
                    }
                }
                if (textBox_model_buscar_apellido.Text.Length != 0)
                {
                    if (flag)
                    {
                        string_where += " and empleado_apellido LIKE '%" + textBox_model_buscar_apellido.Text + "%'";
                    }
                    else
                    {
                        string_where += " empleado_apellido LIKE '%" + textBox_model_buscar_apellido.Text + "%'";
                        flag = true;
                    }
                }

                con.nombre_tabla = "Empleado";
                if (flag)
                {
                    un_dataset = con.armar_query_dinamica_consulta("empleado_id as ID, empleado_dni as DNI, empleado_nombre as Nombre, empleado_apellido as Apellido, (select provincia_nombre from GURP_SKYPE.provincia where provincia_id = empleado_provincia) as Provincia, empleado_mail as Email, empleado_dir as Dirección", "empleado", string_where + " and empleado_hab = 1");
                }
                else
                {
                    un_dataset = con.armar_query_dinamica_consulta("empleado_id as ID, empleado_dni as DNI, empleado_nombre as Nombre, empleado_apellido as Apellido, (select provincia_nombre from GURP_SKYPE.provincia where provincia_id = empleado_provincia) as Provincia, empleado_mail as Email, empleado_dir as Dirección", "empleado", "empleado_hab = 1");
                }
                if (un_dataset.Tables["Empleado"].Rows.Count != 0)
                {
                    dataGridView_resultado_busqueda.DataSource = un_dataset.Tables["Empleado"];

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

        #region cargar datos en comboboxes

        #region cargar_provincia_en_combobox()
        private void cargar_provincia_en_combobox()
        {
            DataTable tabla_provincias;
            tabla_provincias = con.armar_query_dinamica_consulta(con.asterisco, con.provincia_tabla).Tables[0];

            foreach (DataRow row_provincia in tabla_provincias.Rows)
            {
                string una_provincia = row_provincia[1].ToString();
                comboBox_model_buscar_provincia.Items.Add(una_provincia);
            }
        }
        #endregion

        #region cargar_sucursal_en_combobox()
        private void cargar_sucursal_en_combobox()
        {
            DataTable tabla_sucursal;
            tabla_sucursal = con.armar_query_dinamica_consulta(con.asterisco, con.sucursal_tabla).Tables[0];

            foreach (DataRow row_sucursal in tabla_sucursal.Rows)
            {
                string una_provincia = row_sucursal[0].ToString();
                comboBox_model_buscar_sucursal.Items.Add(una_provincia);
            }
        }
        #endregion

        #region cargar_tipo_empleado_en_combobox()
        private void cargar_tipo_empleado_en_combobox()
        {
            DataTable tabla_empleados;
            tabla_empleados = con.armar_query_dinamica_consulta(con.asterisco, con.tipo_empleado).Tables[0];

            foreach (DataRow row_tipo in tabla_empleados.Rows)
            {
                string un_tipo = row_tipo[1].ToString();
                comboBox__model_buscar_tipoemp.Items.Add(un_tipo);
            }
        }
        #endregion

        #endregion

        #region estan_los_datos_correctos()
        private bool estan_los_datos_correctos()
        {
            string datos_faltantes = "";

            datos_faltantes += u.verificar_campo_parcial(textBox_model_buscar_nombre.Text, "LETRAS", "Nombre");
            datos_faltantes += u.verificar_campo_parcial(textBox_model_buscar_apellido.Text, "LETRAS", "Apellido");
            datos_faltantes += u.verificar_campo_parcial(textBox_model_buscar_dni.Text, "NUMEROS", "DNI");

            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }
        #endregion

        #region seleccionar celda

        private void seleccionar_celda(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView_resultado_busqueda.Columns["Seleccionar"].Index) && (e.RowIndex >= 0))
            {
                empleado_seleccionado = dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                empleado_seleccionado_nomape = dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Nombre"].Value.ToString() + " " + dataGridView_resultado_busqueda.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
            }
        }

        #endregion

        #region metodo getter

        public string get_empleado_selecionado()
        {
            return empleado_seleccionado;
        }

        public string get_empleado_seleccionado_nomape()
        {
            return empleado_seleccionado_nomape;
        }

        #endregion

        #region boton limpiar

        private void button_model_limpiar_Click(object sender, EventArgs e)
        {
            textBox_model_buscar_nombre.Clear();
            textBox_model_buscar_apellido.Clear();
            textBox_model_buscar_dni.Clear();
            comboBox_model_buscar_provincia.SelectedIndex = -1;
            comboBox_model_buscar_sucursal.SelectedIndex = -1;
            comboBox__model_buscar_tipoemp.SelectedIndex = -1;
        }

        #endregion

        #region boton cerrar

        private void button_selec_emp_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void FormSeleccionarEmplado_Load(object sender, EventArgs e)
        {
            u.cargar_provincias_en_combobox(this.comboBox_model_buscar_provincia);
            u.cargar_tipos_empleado_en_combobox(this.comboBox__model_buscar_tipoemp);
        }

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


    }
}
