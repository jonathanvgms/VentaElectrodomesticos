using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.FormsComunes;

namespace VentaElectrodomesticos.EfectuarPago
{
    public partial class FormEfectuarPago : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        UsuarioApp user_app = new UsuarioApp();
        int cant_cuotas_pagas = 0; //cantidad coutas impagas de una factura       
        
        public FormEfectuarPago()
        {
            InitializeComponent();
        }

        #region accion de apretar el boton buscar cliente
        /*
         * este motodo crea y abre le form que permite 
         * buscar a un cliente para realizarle el cobro
         * de la cuota
         */
        private void button_selec_cliente_Click_1(object sender, EventArgs e)
        {
            this.textBox_cliente.Enabled = true;
            
            FormSeleccionarCliente un_cliente = new FormSeleccionarCliente();
            
            un_cliente.ShowDialog(this);
            
            this.textBox_cliente.Text = un_cliente.get_un_cliente();
            
            if (this.textBox_cliente.Text.Length != 0)
            {
                this.textBox_cliente.Enabled = false;
            }
        }
        #endregion

        #region accion de apretar el boton salir
        /*
         * metodo que cierra el form
         */ 
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region metodo buscar_facturas_del_cliente
        /*
         * metodo que se encarga de buscar todas la facturas del cliente impagas o con deuda de 
         * todas la sucursales de la cadena de electrodomesticos
         * 
         * y lo llena en el combobox inferior de la forma
         * 
         * factura_nro|provincia_nombre|suc_dir|factura_cant_cuotas - factura_cuotas_pagas
         * 
         * donde la ultima parte son la cantidad de coutas impagas
         */
        private void buscar_facturas_del_cliente(object sender, EventArgs e)
        {
            this.buscar_facturas();
            this.comboBox_facturas.SelectedIndex = 0;
        }

        private void buscar_facturas()
        {
            DataTable a_datatable;

            string string_where = "";

            if (this.textBox_cliente.Text.Length != 0)
            {
                //trae solo las facturas con deuda de la suc seleccionada
                //string_where = "factura_suc = suc_id and suc_dir = '" + this.comboBox_sucursal.Text + "' and suc_provincia = provincia_id and provincia_nombre = '" + this.comboBox_provincias.Text + "' and factura_cuotas_pagas != factura_cant_cuotas and factura_cliente_dni = " + u.obtener_calle_direccion(this.textBox_cliente.Text);
                
                //trae TODAS las facuturas con deuda en la empresa
                string_where = "factura_suc = suc_id and suc_provincia = provincia_id and factura_cuotas_pagas != factura_cant_cuotas and factura_cliente_dni = " + u.obtener_calle_direccion(this.textBox_cliente.Text);

                a_datatable = con.armar_query_dinamica_consulta("factura_nro, provincia_nombre, suc_dir, factura_cant_cuotas - factura_cuotas_pagas", "factura, GURP_SKYPE.sucursal, GURP_SKYPE.provincia", string_where).Tables[0];

                if (a_datatable.Rows.Count == 0)
                {
                    MessageBox.Show("El Cliente no tiene facturas Pendientes.");
                }
                else
                {
                    this.comboBox_facturas.Items.Clear();

                    foreach (DataRow fila_fact in a_datatable.Rows)
                    {
                        this.comboBox_facturas.Items.Add(fila_fact[0].ToString() + "|" + fila_fact[1].ToString() + "|" + fila_fact[2].ToString() + "|" + fila_fact[3].ToString());
                    }
                }
            }
        }
        #endregion

        #region metodos cuotas_impagas
        /*
         * accion que carga todas las cuotas impagas del cliente y factura seleccionada
         * en un combobox para que no hay ningun tipo de error con la cantidad de cuotas
         *  
         * donde uno puede seleccionar la cantidad de cuoutas que desea cancelar de la deuda
         * donde luego se vera reflejado el monto a pagar en un textbox
         */
        private void coutas_impagas(object sender, EventArgs e)
        {
            DataTable a_datatable;
            int pago, cant_fact_sin_pag;
            string nro_factura;
            string prov_factura;
            string dir_factura;
            
            nro_factura = u.obtener_calle_direccion(this.comboBox_facturas.SelectedItem.ToString());

            prov_factura = u.obtener_numero_direccion(this.comboBox_facturas.SelectedItem.ToString());

            dir_factura = u.obtener_piso_depto_direccion(this.comboBox_facturas.SelectedItem.ToString());

            a_datatable = con.armar_query_dinamica_consulta("factura_cant_cuotas, factura_cuotas_pagas", "factura", "factura_cuotas_pagas != factura_cant_cuotas and factura_nro = " + nro_factura 
                + " and factura_suc = GURP_SKYPE.obtener_sucursal_id('" + dir_factura + "', '" + prov_factura + "')").Tables[0];

            cant_fact_sin_pag = Convert.ToInt32(a_datatable.Rows[0][0].ToString()) - Convert.ToInt32(a_datatable.Rows[0][1].ToString());
            
            this.cant_cuotas_pagas = Convert.ToInt32(a_datatable.Rows[0][1].ToString());

            this.comboBox_cantidad_coutas.Items.Clear();

            for (pago = 1; pago <= cant_fact_sin_pag; pago++)
            {
                this.comboBox_cantidad_coutas.Items.Add(pago.ToString());
            }
            this.comboBox_cantidad_coutas.SelectedIndex = 0;
        }
        #endregion

        #region accion que se hace cuando se carga el form
        /*
         * carga todas la provincias en caso de que el user sea analista
         */ 
        private void FormEfectuarPago_Load(object sender, EventArgs e)
        {
            //pregunto el user es de tipo analista
            if (this.user_app.get_usuario_tipo_empleado().Equals("2"))
            {
                //si es asi cargo los combobox con la pcias y sucursales
                u.cargar_provincias_en_combobox(this.comboBox_provincias);

                this.comboBox_provincias.SelectedIndex = 0;
            }
            else
            {
                //sino los deshabilito
                this.comboBox_provincias.Enabled = false;

                this.comboBox_sucursal.Enabled = false;
            }
        }
        #endregion

        #region metodo obt id suc
        /*
         * retorna el id si el user es de tipo vendedor y
         * en caso contrario la funcion de sql que busca el id segun su direccion y provincia
         */
        private string obt_id_suc()
        {
            //pregunto el user es de tipo analista
            if (this.user_app.get_usuario_tipo_empleado().Equals("2"))
            {
                return "GURP_SKYPE.obtener_sucursal_id('" + this.comboBox_sucursal.Text + "', '" + this.comboBox_provincias.Text + "')";
            }
            return this.user_app.get_usuario_suc_id();
        }
        #endregion

        #region accion que buscar la sucursal segun la provincia seleccionada
        /*
         * en caso de que el usuario de la app sea un analista se carga 
         * las provinvias y las sucursales para que pueda seleccionar una
         */ 
        private void seleccionar_sucursal_seg_prov(object sender, EventArgs e)
        {
            u.cargar_sucursales_segun_provincia(this.comboBox_sucursal, this.comboBox_provincias.SelectedItem.ToString());
            this.comboBox_sucursal.SelectedIndex = 0;
        }
        #endregion

        #region metodo calcular el monto a pagar
        /*
         * en este metodo se calcula el monto a pagar en base
         * a las cantidad de coutas selecciodas y al valor de la factura divido 
         * por la cantidad de cuotas de la factura, y lo coloco en su textbox
         */ 
        private void calcular_monto_a_pagar(object sender, EventArgs e)
        {
            DataTable a_datatable;
            
            string nro_factura; //numero de la factura a pagar
            string prov_factura; //nombre de la provincia donde se realizo la factura   
            string dir_factura; //direccion de la sucursal en la provincia donde se realizo la factura   

            nro_factura = u.obtener_calle_direccion(this.comboBox_facturas.SelectedItem.ToString());
            prov_factura = u.obtener_numero_direccion(this.comboBox_facturas.SelectedItem.ToString());
            dir_factura = u.obtener_piso_depto_direccion(this.comboBox_facturas.SelectedItem.ToString());

            a_datatable = con.armar_query_dinamica_consulta("factura_cant_cuotas, factura_cuotas_pagas, factura_total_descu", "factura", "factura_cuotas_pagas != factura_cant_cuotas and factura_nro = " + nro_factura
                + " and factura_suc = GURP_SKYPE.obtener_sucursal_id('" + dir_factura + "', '" + prov_factura + "')").Tables[0];
            
            //aca calculo el monto a pagar y lo meto en su textbox correpondiente
            this.textBox_cantidad_a_pagar.Text = (Convert.ToInt32(this.comboBox_cantidad_coutas.Text)  * (Convert.ToDouble(a_datatable.Rows[0][2].ToString())) / Convert.ToDouble(a_datatable.Rows[0][0].ToString())).ToString();
            this.textBox_cantidad_a_pagar.Enabled = false;
        }
        #endregion

        #region accion que se realiza al apretar el boton limpiar
        /*
         * metodo que encarga de limpiar los campos correpondientes del formulario
         */ 
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            this.textBox_cliente.Clear();
            this.textBox_cantidad_a_pagar.Clear();            
            this.comboBox_facturas.Items.Clear();
            this.comboBox_facturas.Text = "";
            this.comboBox_cantidad_coutas.Items.Clear();
            this.comboBox_cantidad_coutas.Text = "";            
            this.textBox_cantidad_a_pagar.Enabled = true;
            this.textBox_cliente.Enabled = true;
        }
        #endregion

        #region accion de apretar el boton aceptar
        /*
         * en este metodo se realiza el impacto del pago en la base
         * de datos mediante 2 queys:
         * 
         * insert en la tabla pago para relejar que el pago se realizo
         * 
         * update en la tabla factura para actualizar la columna factura_coutas_pagas
         * donde si esta es igual a factura_cuotas_total la factura esta paga
         */ 
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            string pago_dinero = "0";

            if (verificar_datos())
            {
                /*
                 * como la cuota es unica es entonces se abono en efectivo o sea tengo que realizar el pago
                 */
                pago_dinero = this.textBox_cantidad_a_pagar.Text.Replace(',', '.'); //cambio la coma por un punto porque en sql la coma no la acepta como dato

                con.armar_query_dinamica_insert("Pago " + con.pago_fila + " VALUES " +
                    "(GURP_SKYPE.obtener_sucursal_id( '" + u.obtener_piso_depto_direccion(this.comboBox_facturas.SelectedItem.ToString()) +
                    "', '" + u.obtener_numero_direccion(this.comboBox_facturas.SelectedItem.ToString()) + "'), " +
                    u.obtener_calle_direccion(this.comboBox_facturas.SelectedItem.ToString()) +
                    ", " + this.user_app.get_id_empleado() + 
                    ", " + u.obtener_calle_direccion(this.textBox_cliente.Text) +
                    //", '" + DateTime.Now.ToString() +
                    ", getdate() "+
                    ", " + pago_dinero + ")");
                
                /*
                 * realizo un update en tabla factura
                 * o sea si se realizo un pago de una o varias coutas se tiene que anular la deuda en la factura
                 */
                con.armar_query_dinamica_update("Factura", "factura_cuotas_pagas = " + (this.cant_cuotas_pagas + Convert.ToInt32(this.comboBox_cantidad_coutas.SelectedItem.ToString())).ToString(),
                    "factura_nro = " + u.obtener_calle_direccion(this.comboBox_facturas.SelectedItem.ToString()) +
                    " and factura_suc = GURP_SKYPE.obtener_sucursal_id( '" + u.obtener_piso_depto_direccion(this.comboBox_facturas.SelectedItem.ToString()) +
                        "', '" + u.obtener_numero_direccion(this.comboBox_facturas.SelectedItem.ToString()) + "')");
                
                MessageBox.Show("La Operacion se Realizo con Exito.");

                this.buscar_facturas();
                this.comboBox_facturas.SelectedIndex = 0;
            }

        }
        #endregion

        #region metodo verifica datos
        /*
         * metodo que se encarga de verificar que todos los campos correspondiente
         * al pago esten completos y correctos
         */ 
        private bool verificar_datos()
        {
            string datos_faltantes = "";

            if (this.user_app.get_usuario_tipo_empleado().Equals("2"))
            {
                if (this.comboBox_provincias.SelectedIndex == -1)
                {
                    datos_faltantes += "Falta seleccionar una Provincia.\n";
                }
                if (this.comboBox_sucursal.SelectedIndex == -1)
                {
                    datos_faltantes += "Falta seleccionar una Sucursal.\n";
                }
            }
            if (this.textBox_cliente.Text.Length == 0)
            {
                datos_faltantes += "Falta seleccionar un Cliente.\n";
            }
            if (this.comboBox_facturas.SelectedIndex == -1)
            {
                datos_faltantes += "Falta seleccionar una Factura.\n";
            }
            if (this.comboBox_cantidad_coutas.SelectedIndex == -1)
            {
                datos_faltantes += "Falta seleccionar Cantidad de Cuotas a Pagar.\n";
            }
            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }
        #endregion

        #region metodo set usuario
        /*
         * este metodo se encarga de asignar toda la info 
         * de user que esta usando la app
         * 
         * en particulas
         * su nombre de usuario, el tipo de empleado, y el id de la sucursal donde trabaja
         */
        public void set_usuario(string nombre, string tipo, string sucursal, string id)
        {
            this.user_app.set_UsuarioApp(nombre, tipo, sucursal, id);
        }
        #endregion

  
    }
}
