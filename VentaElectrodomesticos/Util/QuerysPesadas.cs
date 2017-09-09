using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos
{
    class QuerysPesadas
    {
        /*
         * query que trae nn base a los valores elegidos se debe mostrar un listado en pantalla con los 30
         * clientes que más compraron, en monto, en la sucursal elegida durante el año elegido. El
         * listado se debe ordenar en forma descendente por el monto.
         * Se deben mostrar las siguientes columnas:
         * 
         • Nombre del cliente
         • Apellido del cliente
         • DNI del cliente
         • Monto total acumulado en ese año y sucursal
         • Total de productos adquiridos en ese año y sucursal
         • Fecha de la última compra realizada en ese año y sucursal
         • DNI del último empleado que le vendió, en ese año y sucursal.
         * 
         * donde los parametros son:
         * 
         * la direccion de la sucursal
         * la provincia de la surursal 
         * y la fecha
         * */
        public string query_clientes_premiun(string suc_dir, string suc_prov, string fecha)
        {
            string query = "";

            query = "select top 30 " +
                        "cli_nombre as 'Nombre', " +
                        "cli_apellido as 'Apellido', " +
                        "f.factura_cliente_dni as 'Dni', " +
                        "(select sum (f3.FACTURA_TOTAL_DESCU) from ((GURP_SKYPE.cliente right join GURP_SKYPE.factura f3 on cli_dni = f3.factura_cliente_dni) join GURP_SKYPE.sucursal on f3.factura_suc = suc_id and suc_dir = '" + suc_dir + "') join GURP_SKYPE.provincia on suc_provincia = provincia_id and provincia_nombre = '" + suc_prov + "' where year(factura_fecha) = year('" + fecha + "') and factura_cliente_dni = f.factura_cliente_dni group by cli_dni) as 'Monto Total Acumulado'," +
                        "sum(producto_factura_cantidad) as 'Total de Productos Adquiridos', " +
                        "(select top 1 f2.factura_fecha from GURP_SKYPE.factura f2 where cli_dni = f2.factura_cliente_dni and year(f2.factura_fecha) = year('" + fecha + "') order by f2.factura_fecha desc) as 'Fecha Ultima Compra', " +
                        "(select top 1 e.empleado_dni from GURP_SKYPE.factura f3, GURP_SKYPE.empleado e where cli_dni = f3.factura_cliente_dni and empleado_id = f3.factura_empleado_id order by f3.factura_fecha desc) as 'Dni Empleado Ultima Compra'" +
                    " from (((GURP_SKYPE.factura f join GURP_SKYPE.producto_factura on factura_nro = producto_factura_factura_nro and factura_suc = producto_factura_suc_id) join GURP_SKYPE.cliente on cli_dni = f.factura_cliente_dni) join GURP_SKYPE.sucursal on factura_suc = suc_id and suc_dir = '" + suc_dir + "') join GURP_SKYPE.provincia on suc_provincia = provincia_id and provincia_nombre = '" + suc_prov + "' " +
                    " where year(factura_fecha) = year('" + fecha + "')" +
                    " group by cli_nombre, cli_apellido, cli_dni, f.factura_cliente_dni" +
                    " order by sum(distinct (f.factura_total_descu)) desc";
            return query;
        }

        /**********************************************************/
        /*
         * esta parte son las consultas para el tablero de control
         * en orden de aparicion y como lo pide el enunciado
         */

        /*total de ventas*/
        public string query_tab_con_total_ventas_total_fact(string suc_dir, string suc_prov, string fecha)
        {
            string query = "";

            //query = "select count(*) " +
            /*
             *  Con los join del form traemos todas las facturas de una determinada sucursal 
             *  y con el where pedimos solo las de un determinado año. Luego con un simple count
             *  tenemos la cantidad de facturas de una sucursal en determinado año y 
             *  con un "sum(factura_total)" el monto total facturado
             *  Nota: se hace count de un escalar porque es más performante para la BD
             *  ya que no tiene que traer los valores de las tablas.
             */
            query = "select count(1),  sum(factura_total) " +
                    "from (GURP_SKYPE.factura join GURP_SKYPE.sucursal on factura_suc = suc_id and suc_dir = '" + suc_dir + "') join GURP_SKYPE.provincia on provincia_id = suc_provincia and provincia_nombre = '" + suc_prov + "' " +
                    "where year(factura_fecha) = year ('" + fecha + "')";
            return query;
        }

        //total de facturacion
        public string query_tab_con_total_fact(string suc_dir, string suc_prov, string fecha)
        {
            string query = "";
            /*
             * Query parecida a la de "query_tab_con_total_ventas()" unicamente que en el join se incluye a la tabla producto_factura
             * para traer todos los productos de todas las factura. Lugo se procede a sumar el precio de cada producto.
             */
            query = "select sum(producto_factura_precio*PRODUCTO_FACTURA_CANTIDAD)" +
                    "from (GURP_SKYPE.producto_factura join GURP_SKYPE.sucursal on producto_factura_suc_id = suc_id and suc_dir = '" + suc_dir + "') join GURP_SKYPE.provincia on provincia_id = suc_provincia and provincia_nombre = '" + suc_prov + "' " +
                    "where  year(producto_factura_fecha) = year ('" + fecha + "')" +
                    "group by producto_factura_precio";

            return query;
        }

        //proporcion forma de pago
        public string query_tab_con_prop_forma_pago(string suc_dir, string suc_prov, string fecha)
        {
            string query = "";

            query = "select GURP_SKYPE.calcular_proporcion('" + suc_dir + "', '" + suc_prov + "', '" + fecha + "')";

            return query;
        }

        //mayor factura
        public string query_tab_con_mayor_factura(string suc_dir, string suc_prov, string fecha)
        {
            string query = "";
            /*
             * Se trae el total de la primer factura que corresponde a la sucursal seleccionada en el periodo elegido
             */ 
            query = "select top 1 factura_total " +
                     "from (GURP_SKYPE.factura join GURP_SKYPE.sucursal on factura_suc = suc_id and suc_dir = '" + suc_dir + "') join GURP_SKYPE.provincia on provincia_id = suc_provincia and provincia_nombre = '" + suc_prov + "' " +
                     "where  year(factura_fecha) = year ('" + fecha + "') " +
                     "order by factura_total desc";           

            return query;
        }

        //mayor deudor
        public string query_tab_con_mayor_deudor(string suc_dir, string suc_prov, string fecha)
        {
            string query = "";
            /*
             * Se calcula cuanto debe cada cliente, se los ordena de forma descendente por la deuda y se trae el primero.
             */
            //en el order by del select tengo (total de coutas - coutas pagas = coutas impagas ) * ( el monto total de la factura  /  total de coutas = valor de una couta) = cantidad de deuda
            query = "select top 1 cli_nombre, cli_apellido, factura_cliente_dni " +
                    "from ((GURP_SKYPE.factura join GURP_SKYPE.sucursal on factura_suc = suc_id and suc_dir = '" + suc_dir + "') join GURP_SKYPE.provincia on provincia_id = suc_provincia and provincia_nombre = '" + suc_prov + "') join GURP_SKYPE.cliente on cli_dni = factura_cliente_dni " +
                    "where year(factura_fecha) = year ('" + fecha + "') and factura_cant_cuotas != factura_cuotas_pagas " +
                    "group by  cli_nombre, cli_apellido, factura_cliente_dni, factura_cant_cuotas, factura_cuotas_pagas, factura_total_descu " +
                    "order by ((factura_cant_cuotas - factura_cuotas_pagas) * (factura_total_descu / factura_cant_cuotas)) desc";

            return query;
        }

        //vendedor del año
        public string query_tab_con_vend_anio(string suc_dir, string suc_prov, string fecha)
        {
            string query = "";
            /*
             * Se calcula el monto total de lo que facturo cada empleado de la sucursal en el periodo elegido
             * ordenado de manera desendente por dicho monto y se muestra al primero
             */
            query = "select top 1 empleado_nombre, empleado_apellido, empleado_dni " +
                    "from ((GURP_SKYPE.factura join GURP_SKYPE.sucursal on factura_suc = suc_id and suc_dir = '" + suc_dir + "') join GURP_SKYPE.provincia on provincia_id = suc_provincia and provincia_nombre = '" + suc_prov + "') join GURP_SKYPE.empleado on empleado_id = factura_empleado_id " +
                    "where year(factura_fecha) = year ('" + fecha + "') " +                    
                    "group by empleado_nombre, empleado_apellido, empleado_dni "+
                    "order by sum (factura_total) desc";

            return query;
        }
        
        //producto del anio
        public string query_tab_con_prod_anio(string suc_dir, string suc_prov, string fecha)
        {
            string query = "";
            /*
             *Se podien los datos del primer producto que pertenesca a la sucursal y se encuentre dentro de los productos vendidos en determinado
             *periodo, ordenados descendentemente por monto total vendido en ese periodo
             */
            query = "select top 1 producto_id, producto_nombre, GURP_SKYPE.armar_categoria_producto(producto_cate) " +
                    "from ((GURP_SKYPE.producto_factura join GURP_SKYPE.sucursal on producto_factura_suc_id = suc_id and suc_dir = '" + suc_dir + "') join GURP_SKYPE.provincia on provincia_id = suc_provincia and provincia_nombre = '" + suc_prov + "') join GURP_SKYPE.producto on producto_id = producto_factura_producto_id " + 
                    "where year(producto_factura_fecha) = year ('" + fecha+ "') " + 
                    "group by producto_id, producto_nombre, producto_cate " +
                    "order by sum (PRODUCTO_FACTURA_CANTIDAD) desc"; 

            return query;
        }
        
        //faltante de stock
        public string query_tab_con_faltante_stock(string suc_dir, string suc_prov, string fecha)
        {
            string query = "";

            query = "select * from GURP_SKYPE.calcular_faltante_stock('" + suc_dir + "', '" + suc_prov + "', '" + fecha + "')";

            return query;
        } 
    }
}
