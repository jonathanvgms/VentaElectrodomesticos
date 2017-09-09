using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.FormsComunes;

namespace VentaElectrodomesticos.AbmProducto
{
    public partial class FormAbmProducto : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        //string id_categoria_elegida = "";

        public FormAbmProducto()
        {
            InitializeComponent();
        }

        #region pestaña crear

        #region accion de apretar el boton salir
        /*
         * cierra el form
         */ 
        private void button_crear_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region accion de apretar el boton limpiar
        /*
         * borra el contenido de todos los textbox que estan en la pestaña crear
         */ 
        private void button_crear_limpiar_Click(object sender, EventArgs e)
        {
            this.textBox_codigo_producto.Clear();
            this.textBox_crear_nombre.Clear();
            this.textBox_crear_marca.Clear();
            this.textBox_categoria_seleccionada.Clear();
            this.textBox_categoria_seleccionada.Enabled = true;
            this.textBox_crear_descripcion.Clear();
            this.textBox_crear_precio.Clear();            
        }
        #endregion

        #region accion de apretar el boton aceptar
        /*
         * evento que se ejecuta cuando se presiona el boton aceptar
         * se verifica que todos los datos esten OK
         * y despues se genera por medio del metodo generar_codigo_producto()
         * el mimo ya verificado, para no tener errores en la base de datos
         */
        private void button_crear_aceptar_Click(object sender, EventArgs e)
        {
            if (estan_los_datos_completos_y_verificados())
            {
                this.textBox_codigo_producto.Text = generar_codigo_producto();
                            
                con.armar_query_dinamica_insert("producto " + con.producto_fila + con.values + con.par_abier +
                    this.textBox_codigo_producto.Text + con.coma +
                    con.agregar_com_sim(this.textBox_crear_nombre.Text) + con.coma +
                    con.agregar_com_sim(this.textBox_crear_descripcion.Text) + con.coma +
                    this.textBox_crear_precio.Text + con.coma +
                    con.agregar_com_sim(this.textBox_crear_marca.Text) + con.coma +
                    "1, GURP_SKYPE.obtener_id_categoria('" + this.textBox_categoria_seleccionada.Text + "')" + con.par_cerra);
                
                MessageBox.Show("La Operacion se Realizo con Exito.");
            }
        }
        #endregion

        #region metodo que genera el codigo del producto
        /*
         * este metodo genera el codigo y verifica, antes de retornarlo,
         * que esta disponible, no se puede pedir mas..=)
         */ 
        private string generar_codigo_producto()
        {
            DataTable a_datatable;
            string un_codigo;
            bool flag = false;
            
            Random numero_aleatorio = new Random();
            un_codigo = numero_aleatorio.Next(100000, 200000).ToString();

            con.nombre_tabla = "Producto";            

            while (!flag)
            {
                a_datatable = con.armar_query_dinamica_consulta("*", "producto", "producto_id = " + un_codigo).Tables[0];

                if (a_datatable.Rows.Count == 0)
                {
                    flag = true;                    
                }
            }
            return un_codigo;
        }
        #endregion

        #region metodo estan los datos completos y verificados
        /*
         * como su nombre lo indica se encarga de ver de que todos los campos 
         * esten completos y su contenido no presente inconsistencia ( valores no permitidos )
         */ 
        private bool estan_los_datos_completos_y_verificados()
        {            
            string datos_faltantes = "";
            double un_precio;
                                    
            datos_faltantes += u.verificar_campo_completo(textBox_crear_nombre.Text, "LETRAS", "Nombre");
            datos_faltantes += u.verificar_campo_completo(textBox_crear_marca.Text, "LETRAS", "Marca");
            datos_faltantes += u.verificar_campo_completo(textBox_crear_descripcion.Text, "LETRAS", "Descripcion");
                        
            if (u.el_precio_es_aceptable(textBox_crear_precio.Text))
            {
                un_precio = Convert.ToDouble(textBox_crear_precio.Text);
                if (un_precio <= 0)
                {
                    datos_faltantes += "Precio: Incorrecto! Debe ser un numero mayor a cero\n";
                }                
            }
            else
            {
                datos_faltantes += "Precio: Incorrecto! Los caracteres NO son validos.\n";
            }

            if (textBox_categoria_seleccionada.Text.Length == 0)
            {
                datos_faltantes += "Categoria: Debe seleccionar una Categoria.";
            }
            
            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);                
                return false;
            }
            return true;
        }
        #endregion

        #region accion de apretar el boton buscar categoria
        /*
         * evento que se ejecuta al presionar el boton buscar categoria
         * una ves que el usuario selecciona una se retorna la misma 
         * en la siguiente forma:
         * 
         * cat1|subcate1|subcate2....etc
         *          
         * con | intermedios
         */ 
        private void button_seleccionar_categoria_Click(object sender, EventArgs e)
        {            
            FormSelecCategorias una_cat = new FormSelecCategorias();
             
            una_cat.ShowDialog(this);
            
            this.textBox_categoria_seleccionada.Text = una_cat.get_categoria();
            
            if (this.textBox_categoria_seleccionada.Text.Length != 0)
            {
                this.textBox_categoria_seleccionada.Enabled = false;
            }
        }
        #endregion

        #endregion

        #region pestaña modificar-eliminar

        #region accion de apretar el boton buscar
        /*
         * metodo que busca un producto en la base de datos 
         * y si encuentra resultados los coloca y muestra en un datagrid
         * caso contrario muestra un mensaje de no existencia
         */
        private void button_buscar_database_Click_1(object sender, EventArgs e)
        {            

            if (u.estan_los_datos_correctos_productos(this.textBox_buscar_codprod.Text, this.textBox_buscar_nom_mar.Text, this.textBox_buscar_marca.Text, this.textBox_precio_init.Text, this.textBox_precio_end.Text))
            {
                realizar_busqueda();
            }

        }
        #endregion

        private void realizar_busqueda()
        {
            string string_where = "";

            DataTable a_datatable;

            string_where = u.armar_where_query_producto(this.textBox_buscar_codprod.Text, this.textBox_buscar_nom_mar.Text, this.textBox_buscar_marca.Text, this.textBox_precio_init.Text, this.textBox_precio_end.Text, this.textBox_buscar_categoria.Text);

            con.nombre_tabla = "Producto";

            if (string_where.Length != 0)
            {
                a_datatable = con.armar_query_dinamica_consulta("producto_id as 'Codigo', producto_nombre as 'Nombre', producto_precio as 'Precio', producto_marca as 'Marca', GURP_SKYPE.armar_categoria_producto(producto_cate) as 'Categoria'", "producto", string_where).Tables[0];
            }
            else
            {
                a_datatable = con.armar_query_dinamica_consulta("producto_id as 'Codigo', producto_nombre as 'Nombre', producto_precio as 'Precio', producto_marca as 'Marca', GURP_SKYPE.armar_categoria_producto(producto_cate) as 'Categoria'", "producto").Tables[0];

            }
            if (a_datatable.Rows.Count != 0)
            {
                this.dataGridView1.DataSource = a_datatable;

                DataGridViewButtonColumn columnaModificar = new DataGridViewButtonColumn();

                if (!this.dataGridView1.Columns.Contains("Modificar"))
                {
                    columnaModificar.Name = "Modificar";

                    columnaModificar.HeaderText = "Modificar";

                    DataGridViewButtonColumn columnaEliminar = new DataGridViewButtonColumn();

                    columnaEliminar.Name = "Eliminar";

                    columnaEliminar.HeaderText = "Eliminar";

                    //Agrego las columnas al grid                    
                    this.dataGridView1.Columns.Add(columnaModificar);

                    this.dataGridView1.Columns.Add(columnaEliminar);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron resultados.");
            }  
        }
        
        #region accion de apretar el boton limpiar
        /*
         * metodo que limpia los textbox de la parte de busqueda
         */ 
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_buscar_codprod.Clear();
            textBox_buscar_marca.Clear();
            textBox_buscar_nom_mar.Clear();
            textBox_buscar_categoria.Clear();
            textBox_precio_end.Clear();
            textBox_precio_init.Clear();
        }
        #endregion

        #region accion de apretar el boton buscar categoria
        /*
         * evento que se encarga de mostrar formulario 
         * de busqueda de una categoria
         */ 
        private void button1_Click(object sender, EventArgs e)
        {      
            FormSelecCategorias una_cat = new FormSelecCategorias();
            una_cat.ShowDialog(this);
            this.textBox_buscar_categoria.Text = una_cat.get_categoria();
            this.textBox_buscar_categoria.Enabled = false;
        }
        #endregion

        #region accion de cargar el producto seleccionado en el form de modificar
        /*
         * evento que carga los datos del producto seleccionado
         * en el form de modificacion, mediante un contructor o eliminar 
         * segun la columna selcionada
         */ 
        private void seleccionar_producto(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["Modificar"].Index) && (e.RowIndex > -1))
            {
                FormModPro mod_pro = new FormModPro();

                mod_pro.set_propiedades_producto(dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value.ToString(),
                    dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                    dataGridView1.Rows[e.RowIndex].Cells["Precio"].Value.ToString(),
                    dataGridView1.Rows[e.RowIndex].Cells["Marca"].Value.ToString());

                mod_pro.ShowDialog(this);
                realizar_busqueda();
            }

           /*
            * solo se realiza un baja logica del cliente, lo que solo altera la columna de habilitado
            */
            if ((e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index) && (e.RowIndex > -1))
            {
                con.armar_query_dinamica_update("Producto", "producto_hab = 0", "producto_id = " + con.agregar_com_sim(this.dataGridView1.Rows[e.RowIndex].Cells["Codigo"].Value.ToString()));
                MessageBox.Show("Se Elimino el Producto con Exito");
                realizar_busqueda();
            }
        }
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion

        private void FormAbmProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
