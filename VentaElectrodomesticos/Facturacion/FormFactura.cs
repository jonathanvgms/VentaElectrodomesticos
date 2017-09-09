using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.Facturacion
{
    public partial class FormFactura : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        DataTable datatable_listado_productos;
        Double descuento;
        string clie_nom;
        string clie_app;
        string clie_dni;
        string num_fact;
        string id_vendedor;
        string cant_cuotas;
        string suc_prov;
        string suc_dir;
        string suc_id;

        public FormFactura()
        {
            InitializeComponent();
        }
        #region accion que se hace cuando apreto el boton aceptar
        /*
         * 
         * en caso de estar bien..se acepta la operacion si se cancela con el boton cancelar
         */ 
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            string monto_factura = "";

            monto_factura = this.textBox_total.Text.Replace(',', '.');

            //si el pago es uno solo ( o sea el modo de pago es efectivo)
            if (this.textBox_cant_cuotas.Text.Equals("1") == true)
            {
                /*
                * realizo un insert en tabla factura
                * agrego la nueva factura
                */
                con.armar_query_dinamica_insert("Factura " + con.factura_fila + " VALUES " +
                    " (" + this.textBox_factura_nro.Text +
                    ", " + this.textBox_dni.Text +
                    ", " + this.textBox_descuento.Text + " * 0.01"+
                    ", " + con.agregar_com_sim(this.textBox_fecha.Text) +
                    ", " + this.textBox_subtotal.Text.Replace(',', '.') +
                    ", " + this.textBox_total.Text.Replace(',', '.') +                    
                    ", " + this.textBox_cant_cuotas.Text +
                    ", " + this.suc_id +
                    ", 1" + //en este caso cuando compro en efectivo solo se realiza pago en el momento ( o sea que pague la unica cuota) 
                    ", " + this.textBox_vendedor.Text + ")"); 

                /*
                 * o sea si la cuota es unica es que se abono en efectivo o sea tengo que realizar el pago
                 */
                con.armar_query_dinamica_insert("Pago " + con.pago_fila + " VALUES " + 
                    "(GURP_SKYPE.obtener_sucursal_id( '" + suc_dir + "', '" + suc_prov + "'), " + 
                    this.textBox_factura_nro.Text + 
                    ", " + this.textBox_vendedor.Text + 
                    ", " + this.textBox_dni.Text + 
                    ", '" + this.textBox_fecha.Text + "'"+
                    ", " + monto_factura + ")" );              
            }
            else
            {
                /*
               * realizo un insert en tabla factura
               * agrego la nueva factura
               */
                con.armar_query_dinamica_insert("Factura " + con.factura_fila + " VALUES " +
                    " (" + this.textBox_factura_nro.Text +
                    ", " + this.textBox_dni.Text +
                    ", " + this.textBox_descuento.Text + " * 0.01" +
                    ", " + con.agregar_com_sim(this.textBox_fecha.Text) +
                    ", " + this.textBox_subtotal.Text.Replace(',', '.') +
                    ", " + this.textBox_total.Text.Replace(',', '.') +
                    ", " + this.textBox_cant_cuotas.Text +
                    ", " + this.suc_id +
                    ", 0" + //en este caso cuando compro en cuotas no realizo ningun pago en el momento ( o sea no pague ninguna couta)
                    ", " + this.textBox_vendedor.Text + ")");          
            }
            /*
             * realizo un insert en la tabla factura_producto
             * agrego por cada producto
             */
            foreach (DataRow fila_factura in this.datatable_listado_productos.Rows)
            {
                con.armar_query_dinamica_insert("producto_factura " + con.producto_factura_fila + " VALUES " +
                    "("+ this.suc_id +
                    ", " + this.textBox_factura_nro.Text +
                    ", " + fila_factura["Codigo"].ToString() +
                    ", " + fila_factura["Cantidad"].ToString() + 
                    ", " + fila_factura["Precio"].ToString().Replace(',','.') +
                    ", " + con.agregar_com_sim(this.textBox_fecha.Text) + ")");
            }

            MessageBox.Show("La Operacion Se Realizo con Exito.");
            Close();
        }
        #endregion

        #region metodo set listando compra
        /*
         * este metodo se encarga de cargar los campos seleccionados
         * del form anterior en variable privadas al objeto
         */ 
        public void set_listado_compra(DataTable a_datatable, double dto, string cliente, string id_factura, string cantcuotas, string prov_suc, string dir_suc, string sucid, string id_emp)
        {            
            this.datatable_listado_productos = a_datatable;
            this.descuento = dto;
            this.clie_dni = u.obtener_calle_direccion(cliente);
            this.clie_nom = u.obtener_numero_direccion(cliente);
            this.clie_app = u.obtener_piso_depto_direccion(cliente);
            this.num_fact = id_factura;
            this.cant_cuotas = cantcuotas;
            this.suc_prov = prov_suc;
            this.suc_dir = dir_suc;
            this.suc_id = sucid;
            this.id_vendedor = id_emp;
        }
        #endregion

        #region accion que se realiza cuando se carga el form
        /*
         * en este metodo se asigna a los campos correpondiente las
         * variables privadas del objeto
         * lo hice asi debido a que voy a necesitar cierto datos para calcular
         * el total etc..
         */ 
        private void FormFactura_Load(object sender, EventArgs e)
        {
            armar_listado_de_productos();
            calcular_subtotales();
            this.textBox_apellido.Text = this.clie_app;
            this.textBox_dni.Text = this.clie_dni;
            this.textBox_nombre.Text = this.clie_nom;
            this.textBox_factura_nro.Text = this.num_fact;
            this.textBox_fecha.Text = DateTime.Now.ToString("yyyy-M-d HH:mm:ss");
            this.textBox_cant_cuotas.Text = this.cant_cuotas;
            this.textBox_provincia.Text = this.suc_prov;
            this.textBox_direccion.Text = this.suc_dir;
            this.textBox_vendedor.Text = this.id_vendedor;
        }
        #endregion

        #region metodo calcular subtotales
        /*
         * este metodo calcula el monto subtotal de toda la factura junto con 
         * el total aplicado en descuento
         */ 
        private void calcular_subtotales()
        {
            double subtotal = 0;

            foreach (DataRow fila in this.datatable_listado_productos.Rows)
            {
                subtotal += (Convert.ToDouble(fila["Precio"].ToString()) * Convert.ToDouble(fila["Cantidad"].ToString()));
            }
            this.textBox_subtotal.Text = subtotal.ToString();
            if (this.descuento != 0)
            {
                this.textBox_descuento.Text = this.descuento.ToString();
                this.textBox_total.Text = (subtotal - (subtotal * (this.descuento / 100))).ToString();
            }
            else
            {
                this.textBox_descuento.Text = "0";
                this.textBox_total.Text = subtotal.ToString();
            }            
        }
        #endregion

        #region metodo armar listado de productos
        /*
         * aca arma cada fila de la factura,
         * reduciendo las cantidad de columnas a mostrar 
         * a solo nombre, marca, cantidad, precio
         */ 
        private void armar_listado_de_productos()
        {
            DataTable a_datatable = new DataTable();

            DataColumn col_nombre = new DataColumn("Nombre", typeof(string));
            DataColumn col_marca = new DataColumn("Marca", typeof(string));
            DataColumn col_precio = new DataColumn("Precio", typeof(double));            
            DataColumn col_cantidad = new DataColumn("Cantidad", typeof(int));
                        
            a_datatable.Columns.Add(col_nombre);
            a_datatable.Columns.Add(col_marca);
            a_datatable.Columns.Add(col_precio);            
            a_datatable.Columns.Add(col_cantidad);

            foreach (DataRow fila in this.datatable_listado_productos.Rows)
            {
                DataRow fila_tabla_carrito = a_datatable.NewRow();

                fila_tabla_carrito["Nombre"] = fila["Nombre"].ToString();
                fila_tabla_carrito["Marca"] = fila["Marca"].ToString();
                fila_tabla_carrito["Cantidad"] = fila["Cantidad"];
                fila_tabla_carrito["Precio"] = fila["Precio"];         

                a_datatable.Rows.Add(fila_tabla_carrito);
            }
            this.dataGridView_listado_prods.DataSource = a_datatable;
        }
        #endregion

        #region accion de apretar el boton cancelar
        /*
         * en caso de que la factura tenga algun dato erroreo
         * esta es la opcion para cancelarla
         */ 
        private void button_cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void dataGridView_listado_prods_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Sucursal_Enter(object sender, EventArgs e)
        {

        }
    }
}
