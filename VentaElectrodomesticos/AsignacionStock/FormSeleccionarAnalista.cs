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
    public partial class FormSeleccionarAnalista : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        string un_analista = "";
        string un_analista_nombre = "";

        public FormSeleccionarAnalista()
        {
            InitializeComponent();
        }

        #region boton buscar

        private void button_buscar_database_Click(object sender, EventArgs e)
        {

            string string_where = "";

            DataSet un_dataset;

            if (estan_los_datos_correctos())
            {

                string_where += "empleado_tipo = tipo_emp_id and tipo_emp_descripcion = 'Analista'";
                if (textBox_buscar_dni_empleado.Text.Length != 0)
                {
                    string_where += " and empleado_dni = " + textBox_buscar_dni_empleado.Text;
                }
                if (textBox_buscar_nombre_emp.Text.Length != 0)
                {
                    string_where += " and empleado_nombre LIKE '%" + textBox_buscar_nombre_emp.Text + "%'";
                }
                if (textBox_buscar_apellido_emp.Text.Length != 0)
                {
                    string_where += " and empleado_apellido LIKE '%" + textBox_buscar_apellido_emp.Text + "%'";
                }

                con.nombre_tabla = "Empleado";

                un_dataset = con.armar_query_dinamica_consulta("DISTINCT empleado_id as ID, empleado_nombre as Nombre, empleado_apellido as Apellido, empleado_dni as DNI, empleado_tel as Telefono, empleado_mail as Email, empleado_dir as Dirección", "Empleado, GURP_SKYPE.Tipo_Empleado ", string_where + " and empleado_hab = 1");

                if (un_dataset.Tables["Empleado"].Rows.Count != 0)
                {
                    dataGridView1.DataSource = un_dataset.Tables["Empleado"];

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

        #region estan los datos correctos

        private bool estan_los_datos_correctos()
        {
            string datos_incompletos = "";

            datos_incompletos += u.verificar_campo_parcial(textBox_buscar_nombre_emp.Text, "LETRAS", "Nombre");
            datos_incompletos += u.verificar_campo_parcial(textBox_buscar_apellido_emp.Text, "LETRAS", "Apellido");
            datos_incompletos += u.verificar_campo_parcial(textBox_buscar_dni_empleado.Text, "NUMEROS", "Dni");

            if (datos_incompletos.Length != 0)
            {
                MessageBox.Show(datos_incompletos);
                return false;
            }
            return true;
        }

        #endregion

        #region accion que se realiza cuando se selecciona un analista

        private void seleccionar_cliente(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["Seleccionar"].Index) && (e.RowIndex >= 0))
            {
                un_analista = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                un_analista_nombre = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
            }
        }
        #endregion

        #region boton limpiar

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_buscar_nombre_emp.Clear();
            textBox_buscar_apellido_emp.Clear();
            textBox_buscar_dni_empleado.Clear();
        }

        #endregion

        #region boton salir

        private void button_buscar_prod_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region metodo getter de analista

        public string get_analista_selecionado()
        {
            return un_analista;
        }

        #endregion

        public string get_analista_selecionado_nombre()
        {
            return un_analista_nombre;
        }

        private void FormSeleccionarAnalista_Load(object sender, EventArgs e)
        {

        }
    }
}
