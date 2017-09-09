using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.AbmRol
{
    public partial class FormAbmRol : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();

        public FormAbmRol()
        {
            InitializeComponent();
        }

        #region pestaña de crear rol

        #region accion de apretar el boton aceptar
        /*
         * metodo que realiza un insert de rol nuevo creado recientemente, en el enunciado no lo dice pero 
         * 
         * issues: no encontre una funcion de C# que cambie de bool a bit que es lo acepta la 
         * base de datos , o sea tiene que 0 o 1 y no true o false
         */ 
        private void button_crear_rol_aceptar_Click(object sender, EventArgs e)
        {            
            if (estan_los_datos_completos() && !existe_rol(this.textBox_rol_nombre_rol.Text))
            {
                con.armar_query_dinamica_insert("ROL " + con.rol_fila + "values ('', " +
                 con.agregar_com_sim(textBox_rol_nombre_rol.Text) + ", " + u.convertir_bool_a_bit(checkBox_rol_amb_emp.Checked) +
                 ", " + u.convertir_bool_a_bit(checkBox_rol_amb_rol.Checked) + ", " + u.convertir_bool_a_bit(checkBox_rol_amb_usu.Checked) +
                 ", " + u.convertir_bool_a_bit(checkBox_rol_amb_cli.Checked) + ", " + u.convertir_bool_a_bit(checkBox_rol_amb_prod.Checked) +
                 ", " + u.convertir_bool_a_bit(checkBox_rol_asigstock.Checked) + ", " + u.convertir_bool_a_bit(checkBox_rol_fact.Checked) +
                 ", " + u.convertir_bool_a_bit(checkBox_rol_efecpago.Checked) + ", " + u.convertir_bool_a_bit(checkBox_rol_tabcontrol.Checked) +
                 ", " + u.convertir_bool_a_bit(checkBox_rol_cli_prem.Checked) + ", " + u.convertir_bool_a_bit(checkBox_rol_mejcat.Checked) + ", 1)");

                MessageBox.Show("La Operación se Realizo Con Exito.");
            }
            
        }
        #endregion

        #region metodo existe rol
        /*
         * metodo que verifica si el nombre de un rol ya existe en la base de datos
         */ 
        private bool existe_rol(string nombre_rol)
        {
            DataTable mi_datatable;

            mi_datatable = con.armar_query_dinamica_consulta("*", "rol", "rol_nombre = " + con.agregar_com_sim(nombre_rol)).Tables[0];

            if (mi_datatable.Rows.Count != 0)
            {
                MessageBox.Show("El Nombre Del Rol Ya Existe. Ingrese otro Por Favor.");
                return true;
            }
            return false;
        }

        private bool existe_rol_repetido(string nombre_rol)
        {

            DataTable mi_datatable;



            mi_datatable = con.armar_query_dinamica_consulta("*", "rol", "rol_nombre = " + con.agregar_com_sim(nombre_rol)).Tables[0];



            if ((mi_datatable.Rows.Count == 0) || (mi_datatable.Rows.Count == 1))
            {

                MessageBox.Show("El Nombre Del Rol Esta Repetido. Ingrese otro Por Favor.");

                return true;

            }

            return false;

        }
        #endregion        

        #region accion de apretar el boton limpiar
        /*
         * limpiar el nombre del rol y setea todos los 
         * checkbox
         */ 
        private void button_crear_limpiar_Click(object sender, EventArgs e)
        {
            textBox_rol_nombre_rol.Clear();
            checkBox_rol_amb_cli.Checked = false;
            checkBox_rol_amb_emp.Checked = false;
            checkBox_rol_amb_prod.Checked = false;
            checkBox_rol_amb_rol.Checked = false;
            checkBox_rol_amb_usu.Checked = false;
            checkBox_rol_asigstock.Checked = false;
            checkBox_rol_cli_prem.Checked = false;
            checkBox_rol_efecpago.Checked = false;
            checkBox_rol_fact.Checked = false;
            checkBox_rol_mejcat.Checked = false;
            checkBox_rol_tabcontrol.Checked = false;
        }
        #endregion

        #region metodo estan los datos completos
        /*
         * verifica y muestra si algun dato o todos falta
         * para se termine la operacion
         */ 
        private bool estan_los_datos_completos()
        {
            string datos_faltantes = "";

            datos_faltantes = u.verificar_campo_completo(textBox_rol_nombre_rol.Text, "LETRAS", "Nombre de Rol.");
            datos_faltantes += this.verificar_checkbox(checkBox_rol_amb_emp.Checked, checkBox_rol_amb_rol.Checked, checkBox_rol_amb_usu.Checked, checkBox_rol_amb_cli.Checked, 
                checkBox_rol_amb_prod.Checked, checkBox_rol_asigstock.Checked, checkBox_rol_fact.Checked, checkBox_rol_efecpago.Checked, checkBox_rol_tabcontrol.Checked,
                checkBox_rol_cli_prem.Checked, checkBox_rol_mejcat.Checked);

            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }
        #endregion

        #region metodo verificar checkbox
        /*
         * es te metodo se encarga ppalmente de verificar de que por lo menos se haya 
         * seleccionado una funcionalidad dato que no tiene sentido crear un rol sin asignarle 
         * alguna funcionlidad
         */ 
        private string verificar_checkbox(bool c1, bool c2, bool c3, bool c4, bool c5, bool c6, bool c7, bool c8, bool c9, bool c10, bool c11)
        {
            if (!c1 && !c2 && !c3 && !c4 && !c5 && !c6 && !c7 && !c8 && !c9 && !c10 && !c11)
            {
                return "Seleccione al Menos una Funcionalidad. Por Favor.\n";
            }
            return "";
        }
        #endregion

        #endregion

        #region pestaña modificar - eliminar

        #region accion de apretar el boton salir
        /*
         * evento que cierra el form
         */ 
        private void button_model_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region metodo seleccionar rol
        /*
         * este metodo hace que se llenen los checkbox
         * cuando se selecciona un rol para su modificacion
         */ 
        private void seleccionar_un_rol(object sender, EventArgs e)
        {
            this.textBox_mod_nom.Text = comboBox_roles.SelectedItem.ToString();
            
            DataTable un_datatable;

            un_datatable = con.armar_query_dinamica_consulta("rol_abm_emp, rol_abm_rol, rol_abm_user, rol_abm_cli, rol_abm_prod, rol_asig_stock, rol_fact, rol_efec_pago, rol_tab_cont, rol_cli_prem, rol_mej_cat, rol_hab", "rol", "rol_nombre = " + con.agregar_com_sim(comboBox_roles.SelectedItem.ToString())).Tables[0];
              
            if (Convert.ToBoolean(un_datatable.Rows[0][11].ToString()))
            {
                this.checkBox__hab_rol.Enabled = false;
                this.checkBox__hab_rol.Checked = true;
                this.checkBox_mod_ambemp.Checked  = Convert.ToBoolean(un_datatable.Rows[0][0].ToString());
                this.checkBox_mod_ambrol.Checked  = Convert.ToBoolean(un_datatable.Rows[0][1].ToString());
                this.checkBox_mod_abmusu.Checked  = Convert.ToBoolean(un_datatable.Rows[0][2].ToString());
                this.checkBox_mod_abmcli.Checked  = Convert.ToBoolean(un_datatable.Rows[0][3].ToString());
                this.checkBox_mod_abmpro.Checked  = Convert.ToBoolean(un_datatable.Rows[0][4].ToString());
                this.checkBox_mod_asigsto.Checked = Convert.ToBoolean(un_datatable.Rows[0][5].ToString());
                this.checkBox_mod_fac.Checked     = Convert.ToBoolean(un_datatable.Rows[0][6].ToString());
                this.checkBox_mod_efecpag.Checked = Convert.ToBoolean(un_datatable.Rows[0][7].ToString());
                this.checkBox_mod_tabcon.Checked  = Convert.ToBoolean(un_datatable.Rows[0][8].ToString());
                this.checkBox_mod_cliprem.Checked = Convert.ToBoolean(un_datatable.Rows[0][9].ToString());
                this.checkBox_mod_cat.Checked     = Convert.ToBoolean(un_datatable.Rows[0][10].ToString());
            }
            else
            {
                this.checkBox__hab_rol.Enabled = true;
                this.checkBox_mod_ambemp.Checked = false;
                this.checkBox_mod_ambrol.Checked = false;
                this.checkBox_mod_abmusu.Checked = false;
                this.checkBox_mod_abmcli.Checked = false;
                this.checkBox_mod_abmpro.Checked = false;
                this.checkBox_mod_asigsto.Checked = false;
                this.checkBox_mod_fac.Checked = false;
                this.checkBox_mod_efecpag.Checked = false;
                this.checkBox_mod_tabcon.Checked = false;
                this.checkBox_mod_cliprem.Checked = false;
                this.checkBox_mod_cat.Checked = false;

                this.checkBox_mod_ambemp.Enabled = false;
                this.checkBox_mod_ambrol.Enabled = false;
                this.checkBox_mod_abmusu.Enabled = false;
                this.checkBox_mod_abmcli.Enabled = false;
                this.checkBox_mod_abmpro.Enabled = false;
                this.checkBox_mod_asigsto.Enabled = false;
                this.checkBox_mod_fac.Enabled = false;
                this.checkBox_mod_efecpag.Enabled = false;
                this.checkBox_mod_tabcon.Enabled = false;
                this.checkBox_mod_cliprem.Enabled = false;
                this.checkBox_mod_cat.Enabled = false;
            }

            this.textBox_elim_rol_selec.Text = this.textBox_mod_nom.Text;
        }
        #endregion

        #region accion de apretar el boton guardar de modificar
        /*
         * es este metedo se produce la actualizacion en la base de datos aplicando
         * la modificacion a cada usuario que tenga asignado al rol
         */ 
        private void button_mod_guardar_Click(object sender, EventArgs e)
        {
            DataTable un_datatable;

            //verifico que los datos esten ok, y que no exista otro rol con el mismo nombre
            if (estan_los_datos_completos_mod() && !existe_rol_repetido(this.textBox_mod_nom.Text))
            {
                con.insertar_datos("exec GURP_SKYPE.actualizar_roles @nom_viejo_rol = '" + this.textBox_elim_rol_selec.Text + "', @nom_nuevo_rol = '" + this.textBox_mod_nom.Text + "'" +
                ", @rol_1 = " + u.convertir_bool_a_bit(this.checkBox_mod_ambemp.Checked) + ", " + "@rol_2 =  " + u.convertir_bool_a_bit(this.checkBox_mod_ambrol.Checked) +
                ", @rol_3 = " + u.convertir_bool_a_bit(this.checkBox_mod_abmusu.Checked) + ", @rol_4 = " + u.convertir_bool_a_bit(this.checkBox_mod_abmcli.Checked) +
                ", @rol_5 = " + u.convertir_bool_a_bit(this.checkBox_mod_abmpro.Checked) + ", @rol_6 = " + u.convertir_bool_a_bit(this.checkBox_mod_asigsto.Checked) +
                ", @rol_7 = " + u.convertir_bool_a_bit(this.checkBox_mod_fac.Checked) + ", @rol_8 = " + u.convertir_bool_a_bit(this.checkBox_mod_efecpag.Checked) +
                ", @rol_9 = " + u.convertir_bool_a_bit(this.checkBox_mod_tabcon.Checked) + ", @rol_10 = " + u.convertir_bool_a_bit(this.checkBox_mod_cliprem.Checked) +
                ", @rol_11 = " + u.convertir_bool_a_bit(this.checkBox_mod_cat.Checked) + ", " + "@flag_hab = " + u.convertir_bool_a_bit(this.checkBox__hab_rol.Checked) + ";");

                MessageBox.Show("Se Modifico el Rol " + this.textBox_elim_rol_selec.Text + ".");

                this.comboBox_roles.Items.Clear();

                un_datatable = con.armar_query_dinamica_consulta("rol_nombre", "rol", "rol_nombre LIKE '%" + this.textBox_mod_nom.Text + "%' and (rol_usr_id = '')").Tables[0];                  

                foreach (DataRow row_nombre_rol in un_datatable.Rows)
                {
                    this.comboBox_roles.Items.Add(row_nombre_rol[0].ToString());
                }

                this.comboBox_roles.SelectedIndex = 0;
            }
        }
        #endregion

        #region metodo estan los datos completos ( modificar )
        /*
         * este metod hace exactamente los que hace la misma funcion arriba 
         * repeti el codigo debido a que si usaba una sola funcion queda muy 
         * engorroso el codigo en los ifs
         */
        private bool estan_los_datos_completos_mod()
        {
            string datos_faltantes = "";

            //datos_faltantes = u.verificar_campo_parcial(textBox_mod_nom.Text, "LETRAS", "Nombre de Rol.");
            if (this.textBox_mod_nom.Text.Length == 0)
            {
                datos_faltantes += "Nombre de Rol Vacio.\n";
            }
            else
            {
                if (!u.IsTextAllowed(this.textBox_mod_nom.Text))
                {
                    datos_faltantes += "Nombre de Rol Incorrecto.\n";
                }
            }
            datos_faltantes += this.verificar_checkbox(checkBox_mod_ambemp.Checked, checkBox_mod_ambrol.Checked, checkBox_mod_abmusu.Checked, 
                checkBox_mod_abmcli.Checked, checkBox_mod_abmpro.Checked, checkBox_mod_asigsto.Checked, checkBox_mod_fac.Checked, checkBox_mod_efecpag.Checked,
                checkBox_mod_tabcon.Checked, checkBox_mod_cliprem.Checked, checkBox_mod_cat.Checked);
                                                    
            if (datos_faltantes.Length != 0)
            {
                MessageBox.Show(datos_faltantes);
                return false;
            }
            return true;
        }
        #endregion

        #region accion de apretar el boton eliminar
        /*
         * metodo que realiza realiza la baja logica del rol, 
         * lo que solo altera la columna de habilitado y seteo todas la funcionalidad
         * a cero o sea las quito
         */
        private void button_elim_guardar_Click(object sender, EventArgs e)
        {
            con.insertar_datos("exec GURP_SKYPE.actualizar_roles @nom_viejo_rol = '" + this.textBox_elim_rol_selec.Text + "', @nom_nuevo_rol = '" + this.textBox_elim_rol_selec.Text + "', @rol_1 = 0, @rol_2 = 0, @rol_3 = 0, @rol_4 = 0, @rol_5 = 0, @rol_6 = 0, @rol_7 = 0, @rol_8 = 0, @rol_9 = 0, @rol_10 = 0, @rol_11 = 0, @flag_hab = 0;");
            MessageBox.Show("Se Elimino el Rol " + this.textBox_elim_rol_selec.Text + ".");

            this.actualizar_rol();
        }
        #endregion


        private void actualizar_rol()
        {
            this.textBox_mod_nom.Text = comboBox_roles.SelectedItem.ToString();

            DataTable un_datatable;

            un_datatable = con.armar_query_dinamica_consulta("rol_abm_emp, rol_abm_rol, rol_abm_user, rol_abm_cli, rol_abm_prod, rol_asig_stock, rol_fact, rol_efec_pago, rol_tab_cont, rol_cli_prem, rol_mej_cat, rol_hab", "rol", "rol_nombre = " + con.agregar_com_sim(comboBox_roles.SelectedItem.ToString())).Tables[0];

            this.checkBox__hab_rol.Checked = Convert.ToBoolean(un_datatable.Rows[0][11]);

            if (Convert.ToBoolean(un_datatable.Rows[0][11].ToString()))
            {
                this.checkBox__hab_rol.Enabled = false;                
                this.checkBox_mod_ambemp.Checked = Convert.ToBoolean(un_datatable.Rows[0][0].ToString());
                this.checkBox_mod_ambrol.Checked = Convert.ToBoolean(un_datatable.Rows[0][1].ToString());
                this.checkBox_mod_abmusu.Checked = Convert.ToBoolean(un_datatable.Rows[0][2].ToString());
                this.checkBox_mod_abmcli.Checked = Convert.ToBoolean(un_datatable.Rows[0][3].ToString());
                this.checkBox_mod_abmpro.Checked = Convert.ToBoolean(un_datatable.Rows[0][4].ToString());
                this.checkBox_mod_asigsto.Checked = Convert.ToBoolean(un_datatable.Rows[0][5].ToString());
                this.checkBox_mod_fac.Checked = Convert.ToBoolean(un_datatable.Rows[0][6].ToString());
                this.checkBox_mod_efecpag.Checked = Convert.ToBoolean(un_datatable.Rows[0][7].ToString());
                this.checkBox_mod_tabcon.Checked = Convert.ToBoolean(un_datatable.Rows[0][8].ToString());
                this.checkBox_mod_cliprem.Checked = Convert.ToBoolean(un_datatable.Rows[0][9].ToString());
                this.checkBox_mod_cat.Checked = Convert.ToBoolean(un_datatable.Rows[0][10].ToString());
            }
            else
            {               
                this.checkBox__hab_rol.Enabled = true;
                this.checkBox_mod_ambemp.Checked = false;
                this.checkBox_mod_ambrol.Checked = false;
                this.checkBox_mod_abmusu.Checked = false;
                this.checkBox_mod_abmcli.Checked = false;
                this.checkBox_mod_abmpro.Checked = false;
                this.checkBox_mod_asigsto.Checked = false;
                this.checkBox_mod_fac.Checked = false;
                this.checkBox_mod_efecpag.Checked = false;
                this.checkBox_mod_tabcon.Checked = false;
                this.checkBox_mod_cliprem.Checked = false;
                this.checkBox_mod_cat.Checked = false;

                this.checkBox_mod_ambemp.Enabled = false;
                this.checkBox_mod_ambrol.Enabled = false;
                this.checkBox_mod_abmusu.Enabled = false;
                this.checkBox_mod_abmcli.Enabled = false;
                this.checkBox_mod_abmpro.Enabled = false;
                this.checkBox_mod_asigsto.Enabled = false;
                this.checkBox_mod_fac.Enabled = false;
                this.checkBox_mod_efecpag.Enabled = false;
                this.checkBox_mod_tabcon.Enabled = false;
                this.checkBox_mod_cliprem.Enabled = false;
                this.checkBox_mod_cat.Enabled = false;
            }
        }

        private void checkBox__hab_rol_CheckedChanged(object sender, EventArgs e)
        {
            if (this.textBox_mod_nom.Text.Length != 0)
            {
                if (this.checkBox__hab_rol.Checked)
                {
                    this.checkBox_mod_ambemp.Enabled = true;
                    this.checkBox_mod_ambrol.Enabled = true;
                    this.checkBox_mod_abmusu.Enabled = true;
                    this.checkBox_mod_abmcli.Enabled = true;
                    this.checkBox_mod_abmpro.Enabled = true;
                    this.checkBox_mod_asigsto.Enabled = true;
                    this.checkBox_mod_fac.Enabled = true;
                    this.checkBox_mod_efecpag.Enabled = true;
                    this.checkBox_mod_tabcon.Enabled = true;
                    this.checkBox_mod_cliprem.Enabled = true;
                    this.checkBox_mod_cat.Enabled = true;
                }
                else
                {
                    this.checkBox__hab_rol.Enabled = true;
                    this.checkBox_mod_ambemp.Checked = false;
                    this.checkBox_mod_ambrol.Checked = false;
                    this.checkBox_mod_abmusu.Checked = false;
                    this.checkBox_mod_abmcli.Checked = false;
                    this.checkBox_mod_abmpro.Checked = false;
                    this.checkBox_mod_asigsto.Checked = false;
                    this.checkBox_mod_fac.Checked = false;
                    this.checkBox_mod_efecpag.Checked = false;
                    this.checkBox_mod_tabcon.Checked = false;
                    this.checkBox_mod_cliprem.Checked = false;
                    this.checkBox_mod_cat.Checked = false;

                    this.checkBox_mod_ambemp.Enabled = false;
                    this.checkBox_mod_ambrol.Enabled = false;
                    this.checkBox_mod_abmusu.Enabled = false;
                    this.checkBox_mod_abmcli.Enabled = false;
                    this.checkBox_mod_abmpro.Enabled = false;
                    this.checkBox_mod_asigsto.Enabled = false;
                    this.checkBox_mod_fac.Enabled = false;
                    this.checkBox_mod_efecpag.Enabled = false;
                    this.checkBox_mod_tabcon.Enabled = false;
                    this.checkBox_mod_cliprem.Enabled = false;
                    this.checkBox_mod_cat.Enabled = false;
                }
            }
        }

        #endregion

        private void button_busq_limpiar_Click(object sender, EventArgs e)
        {            
            this.comboBox_roles.Items.Clear();
            this.comboBox_roles.Enabled = false;
        }

        private void button_mod_limpiar_Click(object sender, EventArgs e)
        {
            this.textBox_mod_nom.Clear();

            this.checkBox_mod_ambemp.Checked = false;
            this.checkBox_mod_ambrol.Checked = false;
            this.checkBox_mod_abmusu.Checked = false;
            this.checkBox_mod_abmcli.Checked = false;
            this.checkBox_mod_abmpro.Checked = false;
            this.checkBox_mod_asigsto.Checked = false;
            this.checkBox_mod_fac.Checked = false;
            this.checkBox_mod_efecpag.Checked = false;
            this.checkBox_mod_tabcon.Checked = false;
            this.checkBox_mod_cliprem.Checked = false;
            this.checkBox_mod_cat.Checked = false;

            this.checkBox_mod_ambemp.Enabled = true;
            this.checkBox_mod_ambrol.Enabled = true;
            this.checkBox_mod_abmusu.Enabled = true;
            this.checkBox_mod_abmcli.Enabled = true;
            this.checkBox_mod_abmpro.Enabled = true;
            this.checkBox_mod_asigsto.Enabled = true;
            this.checkBox_mod_fac.Enabled = true;
            this.checkBox_mod_efecpag.Enabled = true;
            this.checkBox_mod_tabcon.Enabled = true;
            this.checkBox_mod_cliprem.Enabled = true;
            this.checkBox_mod_cat.Enabled = true;
        }

        /*
         * ambos metodos son para buscar el rol en el sistema
         * uso un metodo dentro de otro por la condicion de corte del return
         * 
         * issues: la tabla de los roles se guarda asi:
         * aquellos roles nuevos se crean tanto uno para el usuario y otro generico que contiene
         * las mismas funcionalidades, y cuando uno busca solo trae aquellos genericos o
         * sea los que no tienen id_usuario asignado ( lo que son null en resumen )
         * 
         */
        private void FormAbmRol_Load(object sender, EventArgs e)
        {
            DataTable un_datatable;

            this.comboBox_roles.Items.Clear();

            //el caso donde no ingreso nada a buscar y me trae todos los roles


            un_datatable = con.armar_query_dinamica_consulta("rol_nombre", "rol", "rol_usr_id = ''").Tables[0];

            if (un_datatable.Rows.Count == 0)
            {
                this.comboBox_roles.Enabled = false;
                MessageBox.Show("No se Encontraron Resultados.");                
            }

            //habilito el combobox
            this.comboBox_roles.Enabled = true;

            //cargo los roles
            foreach (DataRow row_nombre_rol in un_datatable.Rows)
            {
                this.comboBox_roles.Items.Add(row_nombre_rol[0].ToString());
            }
        }
    }
}

