using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace VentaElectrodomesticos
{
    class Util
    {
        Conexion con = new Conexion();

        public bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                    @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }
        
        public bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("^[a-zA-Z0-9_]*$"); //regex that matches disallowed text
            return regex.IsMatch(text);
        }

        #region que_sean_letras
        public bool que_sean_letras(string palabra)
        {/*
            int i;
            if (palabra.Length == 0) return true;
            
            for (i = 1; i < palabra.Length; i++)
                if (!((palabra[i] >= 'A' && palabra[i] <= 'Z') || (palabra[i] >= 'a' && palabra[i] <= 'z') || (!palabra[i].Equals(" ")) ||  "áéíóú".Contains(palabra[i]) ))
                    return false;
            return true;*/
            Regex regex = new Regex("^[a-zA-Z_ áéíóúÁÉÍÓÚ]*$"); //regex that matches disallowed text
            return regex.IsMatch(palabra);
        }
        #endregion

        #region que_sean_numeros
        public bool que_sean_numeros(string palabra)
        {
            if (palabra.Length == 0) return true;
            int i;
            for (i = 0; i < palabra.Length; i++)
                if (palabra[i] < '0' || palabra[i] > '9')
                    return false;
            return true;
        }
        #endregion

        #region que_sean_numeros
        public bool el_precio_es_aceptable(string palabra)
        {
            int i;

            if (palabra.Length == 0) return false;
            for (i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] < '0' || palabra[i] > '9')
                {
                    if (palabra[i] != '.' && palabra[i] != ',' && palabra[i] != '-')
                        return false;
                }
            }
            return true;
        }
        #endregion

        #region estos 3 metodos hacer el parseo de la cadena de direccion que esta almacenado en la base de datos
        /*
         * este metodo separa cadenas del estilo "abc|aaa|dasd" = cadena
         * obtener_calle_direccion(cadena) = abc
         * obtener_numero_direccion(cadena) = aaa
         * etc
         */
        public string obtener_calle_direccion(string buffer)
        {
            char[] delimiterChars = { '|' };

            string[] words = buffer.Split(delimiterChars);

            return words[0];
        }
        public string obtener_numero_direccion(string buffer)
        {
            char[] delimiterChars = { '|' };

            string[] words = buffer.Split(delimiterChars);

            return words[1];
        }
        public string obtener_piso_depto_direccion(string buffer)
        {
            char[] delimiterChars = { '|' };

            string[] words = buffer.Split(delimiterChars);

            return words[2];
        }

        public string obtener_cuarta_posicion(string buffer)
        {
            char[] delimiterChars = { '|' };

            string[] words = buffer.Split(delimiterChars);

            return words[3];
        }

        public string obtener_provincia(string buffer)
        {
            char[] delimiterChars = { '|' };

            string[] words = buffer.Split(delimiterChars);
            
            return words[0];
        }
        #endregion

        #region verificar campo
        /*
         * este metodo agilisa la cosa de verificar si un campo esta escrito y correctamente, retorna el error propimente dicho
         * donde el parcial solo retorna la integridad de lo q contiene la caja de texto
         * 
         * mientras que el completo aparte retorna si esta vacia
         */
        public string verificar_campo_parcial(string caja_de_texto, string flag, string nombre_campo)
        {
            string datos_faltantes = "";

            if (flag.Equals("LETRAS"))
            {
                if (!que_sean_letras(caja_de_texto))
                {
                    datos_faltantes += nombre_campo + ": Incorrecto. Los caracteres del campo NO son aceptables. \n";
                }
            }
            else if (flag.Equals("USUPASS"))
            {
                if (!IsTextAllowed(caja_de_texto))
                {
                    datos_faltantes += nombre_campo + ": Incorrecto. Los caracteres del campo NO son aceptables. \n";
                }
            }
            else
            {
                if (!que_sean_numeros(caja_de_texto))
                {
                    datos_faltantes += nombre_campo + ": Incorrecto. Los caracteres del campo NO son aceptables. \n";
                }
            }
            return datos_faltantes;
        }

        /*
         * este metodo agilisa la cosa de verificar si un campo esta escrito y correctamente, retorna el error propimente dicho
         * donde el parcial solo retorna la integridad de lo q contiene la caja de texto
         * 
         * mientras que el completo aparte retorna si esta vacia
         */
        public string verificar_campo_completo(string caja_de_texto, string flag, string nombre_campo)
        {
            string datos_faltantes = "";

            if (caja_de_texto.Length == 0)
            {
                datos_faltantes += nombre_campo + ": Incompleto. \n";
            }
            return datos_faltantes + this.verificar_campo_parcial(caja_de_texto, flag, nombre_campo);
        }
        #endregion

        #region convierte de bool a bit ( 0 o 1 )
        public string convertir_bool_a_bit(bool flag)
        {
            if (flag == true)
            {
                return "1";
            }
            return "0";
        }
        #endregion

        #region convierte de string a bool
        public bool convertir_string_a_bool(string buff)
        {
            if (buff.Equals("True"))
            {
                return true;
            }
            return false;
        }
        #endregion

        public string armar_categoria(string buffer)
        {
            string buf;

            if (buffer.Length != 0)
            {
                buf = buffer.Replace('\\', '¦');
                buf = buf.Substring(10 + 1);
                return buf;
            }
            return "";
        }
        
        /***************************************************** CLIENTE ********************************************************/
        #region dni repetido
        /*
         * metodo que verifica si el dni existe ya en la base de datos (ej: como en cliente o empleado)
         * donde dni_persona es el dni propiamente dicho         
         */
        private bool hay_dni_repetido(string dni_persona)
        {
            DataTable undatatable;

            undatatable = con.armar_query_dinamica_consulta("cli_dni", "cliente", con.agregar_com_sim(dni_persona) + " = cli_dni").Tables[0];
            if (undatatable.Rows.Count != 0)
            {
                MessageBox.Show("El DNI de ese Cliente ya existe. Ingrese Otro Por Favor.");
                return true;
            }
            undatatable = con.armar_query_dinamica_consulta("empleado_dni", "empleado", con.agregar_com_sim(dni_persona) + " = empleado_dni").Tables[0];
            if (undatatable.Rows.Count != 0)
            {
                MessageBox.Show("El DNI de ese Empleado ya existe. Ingrese Otro Por Favor.");
                return true;
            }
            return false;
        }
        #endregion

        public bool estan_los_datos_correctos_cliente(string nombre, string apellido, string dni)
        {
            string datos_incompletos = "";

            datos_incompletos += this.verificar_campo_parcial(nombre, "LETRAS", "Nombre");
            datos_incompletos += this.verificar_campo_parcial(apellido, "LETRAS", "Apellido");
            datos_incompletos += this.verificar_campo_parcial(dni, "NUMEROS", "Dni");

            if (datos_incompletos.Length != 0)
            {
                MessageBox.Show(datos_incompletos);
                return false;
            }
            return true;
        }

        #region metodo armar where query cliente
        /*
         * este metodo se encarga de armar la query basandose si se agrego 
         * un dato anterior
         * solo sirve para datos del cliente :P
         */
        public string armar_where_query_cliente(ComboBox lista_provincias, string nombre, string apellido, string dni)
        {
            string string_where = "";
            bool flag = false;

            if (lista_provincias.SelectedIndex > 0)
            {
                string_where += "cli_provincia = GURP_SKYPE.obtener_provincia_id('" + lista_provincias.SelectedItem.ToString() + "')";
                flag = true;
            }
            if (dni.Length != 0)
            {
                if (flag)
                {
                    string_where += " and cli_dni = '" + dni + "'";
                }
                else
                {
                    string_where += " cli_dni = '" + dni + "'";
                    flag = true;
                }
            }
            if (nombre.Length != 0)
            {
                if (flag)
                {
                    string_where += " and cli_nombre LIKE '%" + nombre + "%'";
                }
                else
                {
                    string_where += "cli_nombre LIKE '%" + nombre + "%'";
                    flag = true;
                }
            }
            if (apellido.Length != 0)
            {
                if (flag)
                {
                    string_where += "and cli_apellido LIKE '%" + apellido + "%'";
                }
                else
                {
                    string_where += " cli_apellido LIKE '%" + apellido + "%'";
                    flag = true;
                }
            }
            return string_where;
        }
        #endregion

        #region metodo armar where query Usuario
        /*
         * este metodo se encarga de armar la query basandose si se agrego 
         * un dato anterior
         * solo sirve para datos del usuario :P
         */
        public string armar_where_query_usuario(ComboBox lista_provincias, ComboBox lista_sucursales, ComboBox lista_tipo, string username, string nombre, string apellido, string dni)
        {
            string string_where = "";
            bool flag = false, flag2 = false;

            if (username.Length != 0)
            {
                string_where += "usr_id LIKE '%" + username + "%'";
                flag = true;
            }
            if (lista_provincias.SelectedIndex != -1)
            {
                if (flag)
                {
                    string_where += " and empleado_provincia = GURP_SKYPE.obtener_provincia_id('" + lista_provincias.SelectedItem.ToString() + "')";
                }
                else
                {
                    string_where += "empleado_provincia = GURP_SKYPE.obtener_provincia_id('" + lista_provincias.SelectedItem.ToString() + "')";
                    flag = true;
                }
                flag2 = true;
            }
            if (lista_sucursales.Text.Length != 0)
            {
                if (flag)
                {
                    string_where += " and empleado_sucursal = GURP_SKYPE.obtener_sucursal_id('" + lista_sucursales.SelectedItem.ToString() + "','" + lista_provincias.Text + "')";
                }
                else
                {
                    string_where += "empleado_sucursal = GURP_SKYPE.obtener_sucursal_id('" + lista_sucursales.SelectedItem.ToString() + "','" + lista_provincias.Text + "')";
                    flag = true;
                }
                flag2 = true;

            }
            if (lista_tipo.SelectedIndex != -1)
            {
                if (flag)
                {
                    string_where += "and empleado_tipo = (select tipo_emp_id from GURP_SKYPE.Tipo_Empleado where tipo_emp_descripcion = '" + lista_tipo.SelectedItem.ToString() + "')";
                }
                else
                {
                    string_where += "empleado_tipo = (select tipo_emp_id from GURP_SKYPE.Tipo_Empleado where tipo_emp_descripcion = '" + lista_tipo.SelectedItem.ToString() + "')";
                    flag = true;
                }
                flag2 = true;

            }
            if (nombre.Length != 0)
            {
                if (flag)
                {
                    string_where += "and empleado_nombre LIKE '%" + nombre + "%'";
                }
                else
                {
                    string_where += "empleado_nombre LIKE '%" + nombre + "%'";
                    flag = true;
                }
                flag2 = true;
            }
            if (apellido.Length != 0)
            {
                if (flag)
                {
                    string_where += " and empleado_apellido LIKE '%" + apellido + "%'";
                }
                else
                {
                    string_where += "empleado_apellido LIKE '%" + apellido + "%'";
                    flag = true;
                }
                flag2 = true;

            }
            if (dni.Length != 0)
            {
                if (flag)
                {
                    string_where += " and empleado_dni = " + dni;
                }
                else
                {
                    string_where += "empleado_dni = " + dni;
                    flag = true;
                }
                flag2 = true;

            }
            if (flag2)
            {
                string_where += " and usr_empleado = empleado_id";
            }
            return string_where;
        }
        #endregion

        #region cargar provincias en combobox
        /*
         * carga todas la provincias en a_combobox
         */
        public void cargar_provincias_en_combobox(ComboBox a_combobox)
        {
            DataTable tabla_provincias;

            tabla_provincias = con.armar_query_dinamica_consulta("provincia_nombre", con.provincia_tabla).Tables[0];
            
            foreach (DataRow fila_provincia in tabla_provincias.Rows)
            {
                a_combobox.Items.Add(fila_provincia[0].ToString());                
            }
        }
        #endregion

        #region cargar sucursales en combobox
        
        public void cargar_sucursales_en_combobox(ComboBox a_combobox)
        {
            DataTable tabla_sucursales;

            tabla_sucursales = con.armar_query_dinamica_consulta("suc_id", con.sucursal_tabla).Tables[0];

            foreach (DataRow fila_sucursal in tabla_sucursales.Rows)
            {
                a_combobox.Items.Add(fila_sucursal[0].ToString());
            }
        }
        #endregion

        #region cargar tipos_empleado en combobox

        public void cargar_tipos_empleado_en_combobox(ComboBox a_combobox)
        {
            DataTable tabla_tipos;

            tabla_tipos = con.armar_query_dinamica_consulta("tipo_emp_descripcion", "Tipo_Empleado ").Tables[0];

            foreach (DataRow fila_provincia in tabla_tipos.Rows)
            {
                a_combobox.Items.Add(fila_provincia[0].ToString());
            }
        }
        #endregion

        public void cargar_sucursales_segun_provincia(ComboBox a_combobox, string prov)
        {
            DataTable a_datatable;

            a_combobox.Items.Clear();

            con.nombre_tabla = "sucursal";

            a_datatable = con.armar_query_dinamica_consulta("suc_dir", "sucursal", "suc_provincia = GURP_SKYPE.obtener_provincia_id('" + prov + "')").Tables[0];

            if (a_datatable.Rows.Count == 0)
            {
                MessageBox.Show("Esta provincia no tiene sucursales.");
            }
            else
            {
                foreach (DataRow row_suc in a_datatable.Rows)
                {
                    string una_suc = row_suc[0].ToString();
                    a_combobox.Items.Add(una_suc);
                }
            }
        }

        public string armar_where_query_producto(string codigo, string nombre, string marca, string pre_init, string pre_fin, string categoria)
        {
            string string_where = "";
            bool flag = false;

            if (codigo.Length != 0)
            {
                string_where += " producto_id = '" + codigo + "'";
                flag = true;
            }
            if (nombre.Length != 0)
            {
                if (flag)
                {
                    string_where += " and producto_nombre LIKE '%" + nombre + "%'";
                }
                else
                {
                    string_where += " producto_nombre LIKE '%" + nombre + "%'";
                    flag = true;
                }
            }
            if (marca.Length != 0)
            {
                if (flag)
                {
                    string_where += " and producto_marca LIKE '%" + marca + "%'";
                }
                else
                {
                    string_where += " producto_marca LIKE '%" + marca + "%'";
                    flag = true;
                }
            }
            if (pre_init.Length != 0)
            {
                if (flag)
                {
                    string_where += " and producto_precio >= " + pre_init;
                }
                else
                {
                    string_where += " producto_precio >= " + pre_init;
                    flag = true;
                }
            }
            if (pre_fin.Length != 0)
            {
                if (flag)
                {
                    string_where += " and producto_precio <= " + pre_fin;
                }
                else
                {
                    string_where += " producto_precio <= " + pre_fin;
                    flag = true;
                }
            }
            if (categoria.Length != 0)
            {
                DataSet set_categoria = new DataSet();
                con.nombre_tabla= "Categorias";
                set_categoria=  con.realizar_consulta("select GURP_SKYPE.obtener_id_categoria('" + categoria + "')");
                string cate = set_categoria.Tables[0].Rows[0][0].ToString();
                if (set_categoria != null)
                {
                    if (flag)
                    {
                        //string_where += " and producto_cate = GURP_SKYPE.obtener_id_categoria('" + categoria + "')";
                        string_where += " and( producto_cate = " + con.subarbol_de_subcategorias(cate, con)+")";
                    }
                    else
                    {
                        //string_where += " producto_cate = GURP_SKYPE.obtener_id_categoria('" + categoria + "')";
                        string_where += "  producto_cate = " + con.subarbol_de_subcategorias(cate, con);
                        flag = true;
                    }
                }
            }
            return string_where;
        }

        #region verifica los datos ingresados
        /*
         * metodo que verifica los datos ingresado para
         * efectuar la busqueda de productos
         */ 
        public bool estan_los_datos_correctos_productos(string codigo, string nombre, string marca, string pre_init, string pre_fin)
        {
            string datos_incorrectos = "";

            datos_incorrectos = this.verificar_campo_parcial(codigo, "NUMEROS", "Código de Producto");
            datos_incorrectos += this.verificar_campo_parcial(nombre, "LETRAS", "Nombre");
            datos_incorrectos += this.verificar_campo_parcial(marca, "LETRAS", "Marca");

            if (pre_fin.Length != 0)
            {
                if (!this.que_sean_numeros(pre_fin))
                {
                    datos_incorrectos += "Precio Final: Incorrecto. Los caracteres del campo NO son aceptables.\n";
                }
            }
            if (pre_init.Length != 0)
            {
                if (!this.que_sean_numeros(pre_init))
                {
                    datos_incorrectos += "Precio Inicial: Incorrecto. Los caracteres del campo NO son aceptables.\n";
                }
            }

            if (datos_incorrectos.Length != 0)
            {
                MessageBox.Show(datos_incorrectos);
                return false;
            }
            return true;
        }
        #endregion
    }
}
