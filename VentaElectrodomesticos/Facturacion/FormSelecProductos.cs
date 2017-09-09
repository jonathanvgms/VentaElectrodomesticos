using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.FormsComunes;

namespace VentaElectrodomesticos.Facturacion
{
    public partial class FormSelecProductos : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();        
        DataTable tabla_carrito = new DataTable ();

        public FormSelecProductos()
        {
            InitializeComponent();
        }

        #region accion de apretar el boton salir
        /*
         * aca se rechaza cualquier seleccion que se haya realizado
         * en el listado de productos
         */ 
        private void button_selec_emp_salir_Click(object sender, EventArgs e)
        {
            this.tabla_carrito.Rows.Clear();
            Close();
        }
        #endregion

        #region accion de apretar el boton buscar
        /*
         * buscar los productos en segun las especificaciones
         * si estan correctos procede a buscarlos
         */ 
        private void button_buscar_database_Click(object sender, EventArgs e)
        {            
            string string_where = "";

            if (u.estan_los_datos_correctos_productos(this.textBox_buscar_codprod.Text, this.textBox_buscar_nom_mar.Text, this.textBox_buscar_marca.Text, this.textBox_precion_init.Text, this.textBox_precion_end.Text))
            {
                DataTable a_datatable;

                string_where = u.armar_where_query_producto(this.textBox_buscar_codprod.Text, this.textBox_buscar_nom_mar.Text, this.textBox_buscar_marca.Text, this.textBox_precion_init.Text, this.textBox_precion_end.Text, this.textBox_buscar_categoria.Text);
              
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
                    this.dataGridView_busqueda.DataSource = a_datatable;

                    if (!this.dataGridView_busqueda.Columns.Contains("Seleccionar"))
                    {
                        DataGridViewButtonColumn columnaSeleccionar = new DataGridViewButtonColumn();

                        columnaSeleccionar.Name = "Seleccionar";

                        columnaSeleccionar.HeaderText = "Seleccionar";

                        this.dataGridView_busqueda.Columns.Add(columnaSeleccionar);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados.");
                }
            }
        }
        #endregion

        #region accion de apretar el boton limpiar
        /*
         * accion que limpiar los textbox
         */ 
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            textBox_buscar_codprod.Clear();
            textBox_buscar_marca.Clear();
            textBox_buscar_nom_mar.Clear();
            textBox_buscar_categoria.Clear();
            textBox_precion_end.Clear();
            textBox_precion_init.Clear();
        }
        #endregion
                
        #region accion de apretar el boton buscar categoria
        /*
         * evento que abre un nuevo form en donde el usuario puede buscar
         * categorias y subcategorias en forma de arbol
         */ 
        private void button_selec_categoria_Click(object sender, EventArgs e)
        {            
            FormSelecCategorias una_cat = new FormSelecCategorias();
            una_cat.ShowDialog(this);
            this.textBox_buscar_categoria.Text = una_cat.get_categoria();
            this.textBox_buscar_categoria.Enabled = false;
        }
        #endregion
 
        #region accion de cargar el producto seleccionado en el form de modificar
        private void seleccionar_producto(object sender, DataGridViewCellEventArgs e)
        {
            string cod_prod_seleccionado = "";
            int pos = 0;

            if ((e.ColumnIndex == dataGridView_busqueda.Columns["Seleccionar"].Index) && (e.RowIndex > -1))
            {
                cod_prod_seleccionado = dataGridView_busqueda.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();

                if (!codigo_prod_select(cod_prod_seleccionado))
                {
                    DataRow fila_tabla_carrito = tabla_carrito.NewRow();

                    fila_tabla_carrito["Codigo"] = dataGridView_busqueda.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
                    fila_tabla_carrito["Nombre"] = dataGridView_busqueda.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    fila_tabla_carrito["Precio"] = dataGridView_busqueda.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                    fila_tabla_carrito["Marca"] = dataGridView_busqueda.Rows[e.RowIndex].Cells["Marca"].Value.ToString();
                    fila_tabla_carrito["Cantidad"] = 1;

                    this.tabla_carrito.Rows.Add(fila_tabla_carrito);

                    dataGridView_carrito.DataSource = this.tabla_carrito;
                }
                else
                {
                    pos = pos_prod_cant(cod_prod_seleccionado);

                    this.tabla_carrito.Rows[pos]["Cantidad"] = (Convert.ToInt32(this.tabla_carrito.Rows[pos]["Cantidad"].ToString()) + 1).ToString();
                    
                    dataGridView_carrito.DataSource = this.tabla_carrito;                    
                }
                
                if (!this.dataGridView_carrito.Columns.Contains("Quitar"))
                {
                    DataGridViewButtonColumn col_quitar = new DataGridViewButtonColumn();

                    col_quitar.Name = "Quitar";

                    col_quitar.HeaderText = "Quitar";

                    this.dataGridView_carrito.Columns.Add(col_quitar);
                }
            }
        }
        #endregion

        #region metodo pos prod cant
        /*
         * en este metodo se calcula el indice en donde se va a insertar los productos 
         * seleccionado del primer datagrid
         */ 
        private int pos_prod_cant(string cod_prod_seleccionado)
        {
            int pos;
            for (pos = 0; pos < this.tabla_carrito.Rows.Count; pos++)
            {
                if (this.tabla_carrito.Rows[pos][0].ToString().Equals(cod_prod_seleccionado))
                {
                    return pos;
                }
            }
            return 0;
        }
        #endregion

        #region metodo codigo prod select
        /*
         * en este metodo busco en la tabla carrito
         * el codigo del elemento que quito
         */ 
        private bool codigo_prod_select(string cod_prod_seleccionado)
        {
            foreach (DataRow fila_car in this.tabla_carrito.Rows)
            {
                if (fila_car[0].ToString().Equals(cod_prod_seleccionado))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region accion que se hace cuando quito los productos de la tabla carrito
        /*
         * en este metodo se hace que cuando se seleccione o se quite un nuevo producto
         * se le sume o reste 1 al contador de cantidad y si llega a 0 se quita de la grilla
         * de productos seleccionados
         */ 
        private void quitar_productos(object sender, DataGridViewCellEventArgs e)
        {
            string cod_prod_seleccionado = "";
            int pos = 0;

            if (e.RowIndex > -1)
            {
                cod_prod_seleccionado = dataGridView_carrito.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();

                if ((e.ColumnIndex == dataGridView_carrito.Columns["Quitar"].Index) && (this.tabla_carrito.Rows.Count >= 1))
                {
                    pos = pos_prod_cant(cod_prod_seleccionado);

                    if (Convert.ToInt32(this.tabla_carrito.Rows[pos]["Cantidad"].ToString()) != 1)
                    {
                        this.tabla_carrito.Rows[pos]["Cantidad"] = (Convert.ToInt32(this.tabla_carrito.Rows[pos]["Cantidad"].ToString()) - 1).ToString();
                    }
                    else
                    {
                        this.tabla_carrito.Rows.Remove(this.tabla_carrito.Rows[e.RowIndex]);
                    }
                    dataGridView_carrito.DataSource = this.tabla_carrito;

                    if (!this.dataGridView_carrito.Columns.Contains("Quitar"))
                    {
                        DataGridViewButtonColumn col_quitar = new DataGridViewButtonColumn();

                        col_quitar.Name = "Quitar";

                        col_quitar.HeaderText = "Quitar";

                        this.dataGridView_carrito.Columns.Add(col_quitar);
                    }
                }
            }
        }
        #endregion

        #region metodo armar dataset carrito
        /*
         * en este metodo se arma en realidad en datatable
         * que contendra toda la info de los productos seleccionados
         * del primer datagrid ( donde se carga el resultado de la busqueda de los productos)
         */ 
        private void armar_dataset_carrito()
        {
            DataColumn col_codigo = new DataColumn("Codigo",typeof(string));
            DataColumn col_nombre = new DataColumn("Nombre", typeof(string));
            DataColumn col_precio = new DataColumn("Precio", typeof(double));
            DataColumn col_marca = new DataColumn("Marca", typeof(string));
            DataColumn col_cantidad = new DataColumn("Cantidad", typeof(int));            
            
            this.tabla_carrito.Columns.Add(col_codigo);
            this.tabla_carrito.Columns.Add(col_nombre);
            this.tabla_carrito.Columns.Add(col_precio);
            this.tabla_carrito.Columns.Add(col_marca);
            this.tabla_carrito.Columns.Add(col_cantidad);
                       
        }
        #endregion

        #region accio que se hace cuando se carga el form
        private void FormSeleccionarProductos_Load_1(object sender, EventArgs e)
        {
            this.armar_dataset_carrito();
        }
        #endregion

        #region metodo get tabla carrito
        /*
         * es un getter que retorna el dataset armado con 
         * los productos seleccionados que van en la factura
         */ 
        public DataTable get_tabla_carrito()
        {
            return this.tabla_carrito;
        }
        #endregion

        #region accion de apretar el boton aceptar
        /*
         * acepta el listado de compra
         */ 
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region accion de apretar el boton borrar listado
        /*
         * en este metodo se rechaza el listado de productos
         * 
         */        
        private void button_borrar_listado_Click(object sender, EventArgs e)
        {
            this.tabla_carrito.Rows.Clear();
            this.dataGridView_carrito.DataSource = this.tabla_carrito;
        }
        #endregion

        private void dataGridView_busqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_carrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
