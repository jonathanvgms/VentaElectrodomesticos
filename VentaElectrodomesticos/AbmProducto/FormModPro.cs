using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.AbmProducto
{
    public partial class FormModPro : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        string codigo_producto = "";

        public FormModPro()
        {
            InitializeComponent();
        }

        #region metodo set propiedades producto
        /*
         * este metodo se encarga de cargar los datos al formulario para modificar un producto
         * selecciodano del datagrid
         */ 
        public void set_propiedades_producto(string cod_pro, string nom, string precio, string marca)
        {
            this.textBox_mod_precio.Text = precio;
            this.textBox_mod_nom_mar.Text = nom;
            this.textBox2.Text = marca;
            this.codigo_producto = cod_pro;
                       
            DataTable a_datatable;

            a_datatable = con.armar_query_dinamica_consulta("producto_desc, producto_hab", "producto", "producto_id = " + con.agregar_com_sim(cod_pro)).Tables[0];
            
            this.textBox_mod_descripcion.Text = a_datatable.Rows[0][0].ToString();
                        
            if (a_datatable.Rows[0][1].ToString().Equals("False"))
            {
                this.checkBox_habilitar_producto.Enabled = true;
            }
            else
            {
                this.checkBox_habilitar_producto.Enabled = false;
            }
        }
        #endregion

        #region accion de apretar el boton salir
        /*
         * cierra el form de modificar
         */ 
        private void button_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region accion de apretar el boton limpiar
        /*
         * borra todos los campos textbox del form modificar
         */ 
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            this.textBox_mod_descripcion.Clear();
            this.textBox_mod_nom_mar.Clear();
            this.textBox_mod_precio.Clear();
            this.textBox2.Clear();
        }
        #endregion

        #region accion que se hace cuando apreto el boton modificar
        /*
         * en este metodo se hacer la actualizacion correspondiente del producto modificado
         * se presentan dos casos:
         * 
         * el primero si el producto se encuentra eliminado ( deshabilitado )
         * 
         * y el segundo si el mismo esta habilitado
         */ 
        private void button_modificar_Click(object sender, EventArgs e)
        {
            if (estan_los_datos_completos_completos_y_correctos())
            {
                if ((this.checkBox_habilitar_producto.Enabled == false) || ((this.checkBox_habilitar_producto.Enabled == true) && (this.checkBox_habilitar_producto.Checked == false)))
                {
                    con.armar_query_dinamica_update("Producto",                        
                        "producto_nombre = " + con.agregar_com_sim(this.textBox_mod_nom_mar.Text) +
                        ", producto_desc = " + con.agregar_com_sim(this.textBox_mod_descripcion.Text) +
                        ", producto_precio = " + this.textBox_mod_precio.Text +
                        ", producto_marca = " + con.agregar_com_sim(this.textBox2.Text),
                        "producto_id = " + this.codigo_producto);

                }
                else
                {
                    con.armar_query_dinamica_update("Producto",
                        "producto_nombre = " + con.agregar_com_sim(this.textBox_mod_nom_mar.Text) +
                        ", producto_desc = " + con.agregar_com_sim(this.textBox_mod_descripcion.Text) +
                        ", producto_precio = " + this.textBox_mod_precio.Text +
                        ", producto_marca = " + con.agregar_com_sim(this.textBox2.Text) +
                        ", producto_hab = 1",
                        "producto_id = " + this.codigo_producto);
                }
                MessageBox.Show("La Operacion se Realizo con Exito.");
            }
        }
        #endregion

        #region metodo que verifica si los datos modificados estan completos y correctos
        /*
         * metodo que verifica si todos los datos ingresados son cosistentes y
         * no contienen ningun error
         */ 
        private bool estan_los_datos_completos_completos_y_correctos()
        {
            string datos_faltantes = "";
            double un_precio;

            datos_faltantes += u.verificar_campo_completo(this.textBox_mod_nom_mar.Text, "LETRAS", "Nombre");
            datos_faltantes += u.verificar_campo_completo(this.textBox2.Text, "LETRAS", "Marca");
            datos_faltantes += u.verificar_campo_completo(this.textBox_mod_descripcion.Text, "LETRAS", "Descripcion");

            if (u.el_precio_es_aceptable(this.textBox_mod_precio.Text))
            {
                un_precio = Convert.ToDouble(this.textBox_mod_precio.Text);
                if (un_precio <= 0)
                {
                    datos_faltantes += "Precio: Incorrecto! Debe ser un numero mayor a cero\n";
                }
            }
            else
            {
                datos_faltantes += "Precio: Incorrecto! Los caracteres NO son validos.\n";
            }

            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }
        #endregion 

        private void FormModPro_Load(object sender, EventArgs e)
        {

        }
    }
}
