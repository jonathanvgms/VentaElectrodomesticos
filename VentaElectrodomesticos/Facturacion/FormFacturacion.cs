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
    public partial class FormFacturacion : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        UsuarioApp usuario_actual = new UsuarioApp();
        DataTable tabla_carrito;                

        public FormFacturacion()
        {
            InitializeComponent();
        }

        #region accion de apretar el boton seleccionar cliente
        /*
         * evento que me lleva al form donde se encuentra el buscado de cliente
         * cuando se selcciona uno se se coloca en el textbox correspondiente
         * de la forma:
         * 
         * dni|nombre|apellido
         * 
         * porque es la fotma mas significante de identificar a un cliente en particular
         */ 
        private void button_selec_cliente_Click(object sender, EventArgs e)
        {
            textBox_cliente.Enabled = true;
            
            FormSeleccionarCliente buscar_cliente = new FormSeleccionarCliente();            
            
            buscar_cliente.ShowDialog(this);            
            
            this.textBox_cliente.Text = buscar_cliente.get_un_cliente();

            if (this.textBox_cliente.Text.Length != 0)
            {
                textBox_cliente.Enabled = false;
            }
        }
        #endregion

        #region accion de apretar el boton salir
        /*
         * evento que cierra el form
         */ 
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region accion de apretar el boton limpiar
        /*
         * este medoto limpiar los textbox correspondientes         
         */ 
        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox_cliente.Clear();
            this.textBox_descuento.Clear();
            this.textBox_productos.Clear();
        }
        #endregion

        #region accion de apretar el boton seleccionar productos
        /*
         * evento que se realiza cuando se va a seleccionar la lista de 
         * productos, una ves con la lista selecionar aparecera en el textbox
         * correpondiente la leyenda 'Listado de Productos Seleccionada'
         * y guardo dicha lista en un dataset ( tabla_carrito )
         */
        private void button_listado_procducto_Click(object sender, EventArgs e)
        {
            this.textBox_productos.Clear();

            this.textBox_productos.Enabled = true;

            FormSelecProductos unos_productos = new FormSelecProductos();
            
            unos_productos.ShowDialog(this);

            this.tabla_carrito = unos_productos.get_tabla_carrito();            

            if (this.tabla_carrito.Rows.Count != 0)
            {
                this.textBox_productos.Text = "Listado de Productos Seleccionados";
                this.textBox_productos.Enabled = false;
            }
            
        }
        #endregion

        #region accion que se hace cuando se carga el form
        /*
         * metodo que carga las provincias y sucursales en caso de que el usuario sea analista
         * 
         * falta preguntar que tipo de user esta en el sistema.
         */ 
        private void FormFacturacion_Load(object sender, EventArgs e)
        {
            this.cargar_formas_de_pago();
            //pregunto el user es de tipo analista
            if (this.usuario_actual.get_usuario_tipo_empleado().Equals("2"))
            {
                u.cargar_provincias_en_combobox(this.comboBox_provincias);
                this.comboBox_provincias.SelectedIndex = 0;
            }
            else
            {
                this.comboBox_provincias.Enabled = false;
                this.comboBox_sucursal.Enabled = false;
            }
            this.comboBox_forma_pago.SelectedIndex = 0;
        }
        #endregion

        #region metodo cargar forma de pago
        /*
         * este metodo se encarga de llenar el combobox correpondiene 
         * con las formas de pago, lo hice dedibo que en un futuro 
         * se podria agregar alguna otra forma de pago
         */
        private void cargar_formas_de_pago()
        {
            comboBox_forma_pago.Items.Add("Efectivo");
            comboBox_forma_pago.Items.Add("Cuotas");
        }
        #endregion

        #region accion de apretar el boton aceptar
        /*
         * es este evento se crea el objeto de la factura y se lo muestra 
         * hay dos casoa en que el pago en cuotas o efectivo ( que es un solo pago )
         */ 
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            DataTable a_datatable;

            a_datatable = con.armar_query_dinamica_consulta("provincia_nombre, suc_dir", "sucursal, GURP_SKYPE.provincia", "provincia_id = suc_provincia and suc_id = " + this.usuario_actual.get_usuario_suc_id()).Tables[0];
            
            if (verificar_consistencia_datos() && estan_todos_habilitados() && todos_los_productos_tienen_stock())
            {
                FormFactura fact = new FormFactura();

                if (this.comboBox_forma_pago.SelectedItem.ToString().Equals("Cuotas") == true)
                {
                    //este caso cuando se elije pagar la factura en cuotas
                    fact.set_listado_compra(this.tabla_carrito, Convert.ToDouble(this.textBox_descuento.Text), this.textBox_cliente.Text, obtener_prox_num_fact(), this.comboBox_cant_cuotas.SelectedItem.ToString(), a_datatable.Rows[0][0].ToString(), a_datatable.Rows[0][1].ToString(), this.usuario_actual.get_usuario_suc_id(), this.usuario_actual.get_id_empleado());
                }
                else
                {
                    //este caso cuando se elije pagar en efectivo ( o sea en una sola cuota )
                    fact.set_listado_compra(this.tabla_carrito, Convert.ToDouble(this.textBox_descuento.Text), this.textBox_cliente.Text, obtener_prox_num_fact(), "1", a_datatable.Rows[0][0].ToString(), a_datatable.Rows[0][1].ToString(), this.usuario_actual.get_usuario_suc_id(), this.usuario_actual.get_id_empleado());
                }
                fact.ShowDialog(this);
            }
        }
        #endregion

        #region metodo todos los productos tienen stock
        /*
         * este metodo recorre todo el datatable ( tabla_carrito )
         * y verifica que cada uno tenga stock para comprar lo
         * 
         * o sea verifica que sea mayor a 0 y que el monto de compra sea menor
         * al stock existente
         */ 
        private bool todos_los_productos_tienen_stock()
        {
            string sin_stock = "";
            DataTable a_datatable;
            int stock_actual = 0;
            int monto_a_comprar;

            foreach (DataRow fila_producto in this.tabla_carrito.Rows)
            {
                a_datatable = con.armar_query_dinamica_consulta("stock_sucursal_cant_actual", "stock_sucursal", "stock_sucursal_suc = " + this.obt_id_suc() + "and stock_sucursal_producto = " + fila_producto[0].ToString()).Tables[0];

                stock_actual = Convert.ToInt32(a_datatable.Rows[0][0].ToString());
                monto_a_comprar = Convert.ToInt32(fila_producto[2].ToString());

                if ((stock_actual < 0) || (stock_actual < monto_a_comprar))
                {
                    sin_stock += fila_producto[1].ToString() + ".\n";
                }

                a_datatable.Rows.Clear();
            }

            if (sin_stock.Length != 0)
            {
                MessageBox.Show("Los siguientes Productos NO tiene Stock Para efectuar la compra:.\n" + sin_stock);
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
            this.usuario_actual.set_UsuarioApp(nombre, tipo, sucursal, id);
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
            if (this.usuario_actual.get_usuario_tipo_empleado().Equals("2"))
            {
                return "GURP_SKYPE.obtener_sucursal_id('" + this.comboBox_sucursal.Text + "', '" + this.comboBox_provincias.Text + "')";
            }
            return this.usuario_actual.get_usuario_suc_id();
        }
        #endregion

        #region metodo estan todos habilitados
        /*
         * este metodo valida que tanto el usuario , producto y cliente esten habilitados para concretar la operacion, 
         * asi como tambien que exista stock en la sucursal
         */
        private bool estan_todos_habilitados()
        {
            string inhabilitados = "";
            DataTable a_datatable;

            con.nombre_tabla = "Cliente";

            a_datatable = con.armar_query_dinamica_consulta("cli_hab", "cliente", "cli_dni = " + u.obtener_calle_direccion(this.textBox_cliente.Text)).Tables[0];

            if (a_datatable.Rows[0][0].Equals("False"))
            {
                inhabilitados += "El cliente No esta Habilitado.\n";
            }
            a_datatable.Rows.Clear();

            a_datatable = con.armar_query_dinamica_consulta("usr_hab", "usuario", "usr_id = " + con.agregar_com_sim(this.usuario_actual.get_usuario_nombre())).Tables[0];

            if (a_datatable.Rows[0][0].Equals("False"))
            {
                inhabilitados += "El Usuario No esta Habilitado.\n";
            }

            foreach (DataRow fila_producto in this.tabla_carrito.Rows)
            {
                a_datatable.Rows.Clear();

                a_datatable = con.armar_query_dinamica_consulta("producto_hab", "producto", "producto_id = " + fila_producto[0].ToString()).Tables[0];

                if (a_datatable.Rows[0][0].Equals("False"))
                {
                    inhabilitados += "El Producto " + fila_producto[1].ToString() + " No esta Habilitado.\n";
                }
            }

            if (inhabilitados.Length != 0)
            {
                MessageBox.Show(inhabilitados);
                return false;
            }    
            return true;
        }
        #endregion
        
        #region accion que obtiene el numero de la proxima factura
        /*
         * es este metodo debo obtener el numero de la proxima factura en base 
         * a la provincia y sucursal, debido que un numero de factura se podria repetir en las provincias
         */
        private string obtener_prox_num_fact()
        {            
            DataTable a_datatable;

            con.nombre_tabla = "Factura";

            a_datatable = con.armar_query_dinamica_consulta("top 1 factura_nro + 1", "factura", "factura_suc = " + this.usuario_actual.get_usuario_suc_id(), "", "", "factura_nro desc").Tables[0];
            
            if (a_datatable.Rows.Count == 0)
            {
                return "1";
            }            
            return a_datatable.Rows[0][0].ToString();
        }
        #endregion

        #region metodo verificar consistencia datos
        /*
         * metodo que verifica la consistencia de los datos seleccionas e ingresados
         */
        private bool verificar_consistencia_datos()
        {
            string datos_faltantes = "";
            double dto;

            /* 
             * en caso de que el usuario sea analista
             * verifico provincia y sucursal seleccionas
             */
            if (this.usuario_actual.get_usuario_tipo_empleado().Equals("2"))
            {
                if (comboBox_provincias.Text.Length == 0)
                {
                    datos_faltantes += "Seleccione una Provincia.\n";
                }
                if (comboBox_sucursal.Text.Length == 0)
                {
                    datos_faltantes += "Seleccione una Sucursal.\n";
                }
            }
             
            if (textBox_descuento.Text.Length == 0)
            {
                datos_faltantes += "Ingrese Descuento.\n";
            }
            else
            {
                if (u.el_precio_es_aceptable(textBox_descuento.Text))
                {
                    if (this.textBox_descuento.Text.Contains('.'))
                    {
                        dto = Convert.ToDouble(this.textBox_descuento.Text.Replace('.',','));
                    }
                    else
                    {
                        dto = Convert.ToDouble(this.textBox_descuento.Text);
                    }
                    if ((dto < 0) || (dto > 30))
                    {
                        datos_faltantes += "Descuento es incorrecto. Número fuera de Rango. Ingreselo nuevamente.\n";
                    }
                }
                else
                {
                    datos_faltantes += "Descuento incorrecto. Ingreselo nuevamente.\n";
                }
            }
            if (textBox_cliente.Text.Length == 0)
            {
                datos_faltantes += "Seleccione un Cliente.\n";
            }
            if (this.textBox_productos.Text.Length != 0)
            {
                if (this.tabla_carrito.Rows.Count == 0)
                {
                    datos_faltantes += "Elija un Listado de Productos.\n";
                }
            }
            else
            {
                datos_faltantes += "Elija un Listado de Productos.\n";
            }            
            if (comboBox_forma_pago.SelectedIndex == -1)
            {
                datos_faltantes += "Seleccione una Forma de Pago.\n";
            }            
            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }
        #endregion
        
        #region evento obtener sucursal de provincia seleccionada
        /*
         * accion de cargar el combobox de sucursales segun la provincia que seleccione
         */
        private void obtener_suc_prov_selec(object sender, EventArgs e)
        {
            u.cargar_sucursales_segun_provincia(this.comboBox_sucursal, this.comboBox_provincias.SelectedItem.ToString());
            this.comboBox_sucursal.SelectedIndex = 0;
        }
        #endregion

        #region metodo selec forma pago
        /*
         * accion de seleccionar la forma de pago ( con cuotas o sin ) y
         * en base a esto se deteminar si se habilita o no el combobox de coutas a seleccionar
         * debido que si el pago es en efectivo en un solo pago, lo cual no se muesta en esta pantalla
         * pero si en la factura que en donde importa
         */
        private void selec_forma_pago(object sender, EventArgs e)
        {
            if (this.comboBox_forma_pago.SelectedItem.ToString().Equals("Cuotas") == true)
            {
                this.comboBox_cant_cuotas.Enabled = true;
                cargar_todas_las_cuotas();
                this.comboBox_cant_cuotas.SelectedIndex = 0;
            }
            else
            {
                this.comboBox_cant_cuotas.Enabled = false;
            }
        }
        #endregion

        #region accion de cargar las coutas en el combobox
        /*
         * metodo que calcula la cantidad de cuotas a pagar, a pagar, a pagar...
         * y lo inserta un combobox
         * 
         * los hice en un combo box debido a que las cuotas son fijas y no varias
         * y hay menos ambiguedad al seleccionar una.
         */ 
        private void cargar_todas_las_cuotas()
        {
            this.comboBox_cant_cuotas.Items.Clear();
            int i;
            for (i = 2; i <= 12; i++)
            {
                this.comboBox_cant_cuotas.Items.Add(i.ToString());
            }
        }
        #endregion
    }
}
