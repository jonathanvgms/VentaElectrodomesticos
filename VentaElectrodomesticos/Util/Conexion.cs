using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace VentaElectrodomesticos
{
    class Conexion
    {
        /*
         * un monton de palabras reservadas del sql 
         */ 
        public string asterisco = " * ";
        public string par_abier = " (";
        public string par_cerra = ") ";
        public string coma = ", ";
        public string o_logico = " OR ";
        public string y_logico = " AND ";
        public string no_logico = " NOT ";
        public string igual = " = ";
        public string menor_igual = " <= ";
        public string mayor_igual = " >= ";
        public string distinto = " != ";
        public string values = "VALUES ";
        public string into = "INTO ";

        public string provincia_tabla = "Provincia ";
        public string cliente_tabla = "Cliente ";
        public string usuario_tabla = "Usuario ";
        public string sucursal_tabla = "Sucursal ";
        public string empleado_tabla = "Empleado ";
        public string rol_tabla = "Rol ";
        public string tipo_empleado = "Tipo_Empleado ";
        public string asignacion_stock_tabla = "Asignacion_Stock ";

        public string nombre_tabla;

        public string cliente_fila = "(cli_provincia, cli_dni, cli_nombre, cli_apellido, cli_telefono, cli_mail, cli_direccion, cli_hab) ";
        public string factura_fila = "(factura_nro, factura_cliente_dni, factura_descuento, factura_fecha, factura_total, factura_total_descu, factura_cant_cuotas, factura_suc, factura_cuotas_pagas, factura_empleado_id)";
        public string pago_fila = "(pago_suc, pago_factura, pago_empleado, pago_cliente_dni, pago_fecha, pago_monto)";
        public string producto_fila = "(producto_id, producto_nombre, producto_desc, producto_precio, producto_marca, producto_hab, producto_cate) ";
        public string producto_factura_fila = "(producto_factura_suc_id, producto_factura_factura_nro, producto_factura_producto_id, producto_factura_cantidad, producto_factura_precio, producto_factura_fecha)";
        public string rol_fila = "(rol_usr_id, rol_nombre, rol_abm_emp, rol_abm_rol, rol_abm_user, rol_abm_cli, rol_abm_prod, rol_asig_stock, rol_fact, rol_efec_pago, rol_tab_cont, rol_cli_prem, rol_mej_cat, rol_hab) ";
        public string rol_fila_usuario = "(rol_nombre, rol_usr_id, rol_abm_emp, rol_abm_rol, rol_abm_user, rol_abm_cli, rol_abm_prod, rol_asig_stock, rol_fact, rol_efec_pago, rol_tab_cont, rol_cli_prem, rol_mej_cat, rol_hab) ";
        public string usuario_fila = "(usr_id, usr_pass, usr_empleado, usr_hab) ";
        public string tipo_empleado_fila = "(tipo_empleado_id, tipo_descripcion) ";
        public string asignacion_stock_fila = "(asig_stock_prod, asig_stock_cant, asig_stock_empleado, asig_stock_auditor, asig_stock_fecha, asig_stock_suc) ";

        public string empleado_id = "empleado_id";
        public string empleado_nombre = "empleado_Nombre";
        public string empleado_apellido = "empleado_apellido";
        public string empleado_dni = "empleado_dni";
        public string empleado_mail = "empleado_mail";
        public string empleado_dir = "empleado_dir";
        public string empleado_tipo = "empleado_tipo";
        public string empleado_provincia = "empleado_provincia";
        public string empleado_hab = "empleado_hab";
        public string empleado_sucursal = "empleado_sucursal";
        public string empleado_tel = "empleado_tel";

        public string empleado_fila()
        {
            return empleado_id + " " + empleado_nombre + " " + empleado_apellido + " " + empleado_dni + " " + empleado_mail + " " + empleado_dir + " " + empleado_tel + " " + empleado_tipo + " " + empleado_provincia + " " + empleado_hab + " " + empleado_sucursal + " ";
        }
        
        public string agregar_com_sim(string buffer)
        {
            return ("'" + buffer + "'");
        }

        /*
         * solo sirve esta dos sobre cargas cuando se insertan nuevas files en la tablas
         */ 
        public int armar_query_dinamica_insert(string insert_string, string select_string, string from_string, string where_string)
        {
            return insertar_datos("INSERT GURP_SKYPE." + insert_string + "SELECT " + select_string + " FROM GURP_SKYPE." + from_string + " WHERE " + where_string);
        }

        public int armar_query_dinamica_insert(string insert_string)
        {
            return insertar_datos("INSERT INTO GURP_SKYPE." + insert_string);
        }

        public int armar_query_dinamica_update(string nombre_tabla, string nombre_columnas, string where_string)
        {
            return insertar_datos("UPDATE GURP_SKYPE." + nombre_tabla + " SET " + nombre_columnas + " WHERE " + where_string);
        }

        public DataSet armar_query_dinamica_delete(string delete_string, string from_string, string where_string)
        {
            return realizar_consulta("DELETE " + delete_string + " FROM GURP_SKYPE." + from_string + " WHERE " + where_string);
        }

        public int armar_query_dinamica_delete(string nombre_tabla, string string_where)
        {
            SqlConnection una_conexion = new SqlConnection();
            una_conexion.ConnectionString = direccion_de_conexion();
            SqlCommand un_comando_sql = new SqlCommand();
            un_comando_sql.CommandText = "delete GURP_SKYPE." + nombre_tabla + " where " + string_where;
            un_comando_sql.Connection = una_conexion;
            try
            {
                una_conexion.Open();
                un_comando_sql.ExecuteNonQuery();
                una_conexion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error con la Base de Datos.");
                return 1;
            }
            return 0;
            
        }
                
        public int insertar_datos(string una_fila)
        {    
            SqlConnection una_conexion = new SqlConnection();
            una_conexion.ConnectionString = direccion_de_conexion();
            SqlCommand un_comando_sql = new SqlCommand();
            un_comando_sql.CommandText = una_fila;
            un_comando_sql.Connection = una_conexion;
            try
            {
                una_conexion.Open();
                un_comando_sql.ExecuteNonQuery();
                una_conexion.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error con la Base de Datos.");
                return 1;
            }
            //MessageBox.Show("Los Datos se Guardaron Satisfactoriamente.");
            return 0;
        }


        /*
         * este metodo realiza el armado de la query
         * 
         * en una consulta sql normal, por ejemplo tenemos:
         * 
         * SELECT COLUMNA1, COLUMNA2 FROM TABLA1 WHERE CONDICION1=ALGO AND CONDICION2=OTRA COSA
         * 
         * se invoca asi:
         * 
         * realizar_consulta("columna1, columna2", "tabla1", "condicion1=algo AND condicion2", "", "", "");
         * 
         * como el nombre de la columnas y las tablas las conocemos por el der, yo diria hardcodear los nombres asi:
         * 
         * public string tabla = "tabla";
         * 
         * para no estar poniendo las malditas comillas todo el tiempo, entonces las consulta quedaria asi, usando directamente 
         * los datos de los textbox correspondientes:
         * 
         * instanciamos un objeto del tipo conexion:
         * 
         * Conexion una_conexion = new Conexion();
         * 
         * una_conexion.armar_query_dinamica(una_conexion.columna1 + una_conexion.coma + una_conexion.columna2, una_conexion.tabla1, una_conexion.columna1 + una_conexion.distinto + textbox.text ...,"", "", "");
         *
         * se que parece demasiado larga pero la mayoria se autocompleta, aparte es bastante flexible a la hora de armar querys dinamicas, y le agrege dos sobrecargas 
         * para no poner las comillas otra vez...
         * 
         * todavia no se probo con alias
         */
                
        public DataSet armar_query_dinamica_consulta(string select_string, string from_string)
        {
            return realizar_consulta("SELECT " + select_string + " FROM GURP_SKYPE." + from_string);            
        }

        public DataSet armar_query_dinamica_consulta(string select_string, string from_string, string where_string)
        {
            return realizar_consulta("SELECT " + select_string + " FROM GURP_SKYPE." + from_string + " WHERE " + where_string);
        }

        public DataSet armar_query_dinamica_consulta(string select_string, string from_string, string where_string, string groupby_string, string having_string, string orderby_string)
        {
            string una_query = "SELECT " + select_string + " FROM GURP_SKYPE." + from_string;

            if (where_string.Length != 0)
            {
                una_query += " WHERE " + where_string;
            }
            if (groupby_string.Length != 0)
            {
                una_query += " GROUPBY " + groupby_string;
            }
            if (having_string.Length != 0)
            {
                una_query += " HAVING " + having_string;
            }
            if (orderby_string.Length != 0)
            {
                una_query += " ORDER BY " + orderby_string;
            }

            return realizar_consulta(una_query);            
        }

        /*
         * motodo que se conecta a la base de datos, y trae los datos a un datatable en caso de exito
         */ 
        public DataSet realizar_consulta(string una_query)
        {
            DataTable buffer_tabla = new DataTable(nombre_tabla);
            DataSet un_dataset = new DataSet();
            un_dataset.Tables.Add(buffer_tabla);
            SqlConnection una_conexion = new SqlConnection();
            una_conexion.ConnectionString = direccion_de_conexion();
            SqlCommand un_comando_sql = new SqlCommand();

            un_comando_sql.CommandText = "SET DATEFORMAT ymd " + una_query  ;
            //un_comando_sql.CommandText =  una_query ;
            un_comando_sql.Connection = una_conexion;
            try
            {
                una_conexion.Open();
                SqlDataReader mydr = un_comando_sql.ExecuteReader();
                buffer_tabla.Load(mydr);
                una_conexion.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show("Ocurrio un error con la Base de Datos.");
                return null;
            }
            return un_dataset;
        }

        private string direccion_de_conexion()
        {
            return "Data Source=localhost\\SQLSERVER2005;Initial Catalog=GD1C2011;User ID=gd;Pwd=gd2011";
        }

        /*
         * Método que se encarga de recorrer el árbol de categorías buscando todas las subcategorías de
         * una categoría dada
         */
        public  string subarbol_de_subcategorias(string categoria,Conexion conexion)
        {
            DataSet tablas = new DataSet() ;
           
            //guardo esta categoria en el string que se usará para hacer una consulta SQL
            string subcategorias = categoria;
            //busco posibles hijos
            tablas = conexion.realizar_consulta("Select cat_id from GURP_SKYPE.Categoria where cat_padre_id = " + categoria);
            //Si no tiene hijos quiere decir que es hoja y llegue al final de la rama. Corto la recursividad
            if (tablas == null)
                return subcategorias;
            
            //Si tiene hijos los recorro todos
            foreach (DataRow categoria_hija in tablas.Tables[0].Rows)
            {
                //guardo el id del hijo
                string cat_id_hijo = categoria_hija["cat_id"].ToString();
              
                //llamo recursivamente a la funcion pasandole el hijo
                subcategorias += " or producto_cate = " + subarbol_de_subcategorias(cat_id_hijo, conexion);
                
            }
            //retorno todas las subcategorias de la categoria resivida como parametro.
            return subcategorias;
        }
    
    }
}
