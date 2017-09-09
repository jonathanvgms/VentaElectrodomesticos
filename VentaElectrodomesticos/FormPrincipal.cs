using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VentaElectrodomesticos.Login;
using VentaElectrodomesticos.AbmEmpleado;
using VentaElectrodomesticos.AbmRol;
using VentaElectrodomesticos.AbmUsuario;
using VentaElectrodomesticos.AbmCliente;
using VentaElectrodomesticos.AbmProducto;
using VentaElectrodomesticos.AsignacionStock;
using VentaElectrodomesticos.Facturacion;
using VentaElectrodomesticos.EfectuarPago;
using VentaElectrodomesticos.TableroControl;
using VentaElectrodomesticos.ClientesPremium;
using VentaElectrodomesticos.MejoresCategorias;

namespace VentaElectrodomesticos
{
    public partial class FormPrincipal : Form
    {
        private UsuarioHab user_habs = new UsuarioHab();
        private UsuarioApp datos_usuario = new UsuarioApp();
        Conexion con = new Conexion();
        Util u = new Util();

        string user_id;

        public FormPrincipal()
        {
            InitializeComponent();

            FormLogin login = new FormLogin();
            login.ShowDialog(this);

            if (login.obtener_flag_logueo())
            {
                user_id = login.get_usuario_id();

                obtenerDatosUser();
                obtenerHabilidades();


                if (user_habs.get_amb_asig_stock()) asignaciónDeStockToolStripMenuItem.Visible = true;
                if (user_habs.get_amb_cli()) aBMDeClienteToolStripMenuItem.Visible = true;
                if (user_habs.get_amb_cli_prem()) clientesPremiumToolStripMenuItem.Visible = true;
                if (user_habs.get_amb_efec_pago()) efectuarPagoToolStripMenuItem.Visible = true;
                if (user_habs.get_amb_emp()) aBMToolStripMenuItem.Visible = true;
                if (user_habs.get_amb_fac()) facturaciónToolStripMenuItem.Visible = true;
                if (user_habs.get_amb_mej_cat()) mejoresCategoriasToolStripMenuItem.Visible = true;
                if (user_habs.get_amb_prod()) aBMDeProductoToolStripMenuItem.Visible = true;
                if (user_habs.get_amb_rol()) aBMDeRolToolStripMenuItem.Visible = true;
                if (user_habs.get_amb_tab_cont()) tableroDeControlToolStripMenuItem.Visible = true;
                if (user_habs.get_amb_user()) aBMDeUsuarioToolStripMenuItem.Visible = true;

            }
            else
            {
                MessageBox.Show("La Apilicación se Cerrará.");
                System.Environment.Exit(0);
            }
        }

        private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbmEmpleado form = new FormAbmEmpleado();
            form.ShowDialog(this);
        }

        private void aBMDeRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbmRol form = new FormAbmRol();
            form.ShowDialog(this);
        }

        private void aBMDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbmUsuario form = new FormAbmUsuario();
            form.ShowDialog(this);
        }

        private void aBMDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbmCliente form = new FormAbmCliente();
            form.ShowDialog(this);
        }

        private void aBMDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbmProducto form = new FormAbmProducto();
            form.ShowDialog(this);
        }

        private void asignaciónDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAsignacionStock form = new FormAsignacionStock();
            form.setear_id(datos_usuario.get_id_empleado());
            form.ShowDialog(this);
        }

        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFacturacion form = new FormFacturacion();
            form.set_usuario(datos_usuario.get_usuario_nombre(), datos_usuario.get_usuario_tipo_empleado(), datos_usuario.get_usuario_suc_id(), datos_usuario.get_id_empleado());
            form.ShowDialog(this);
        }

        private void efectuarPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEfectuarPago form = new FormEfectuarPago();
            form.set_usuario(datos_usuario.get_usuario_nombre(), datos_usuario.get_usuario_tipo_empleado(), datos_usuario.get_usuario_suc_id(), datos_usuario.get_id_empleado());
            form.ShowDialog(this);
        }

        private void tableroDeControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTableroControl form = new FormTableroControl();
            form.ShowDialog(this);
        }

        private void clientesPremiumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientesPremium form = new FormClientesPremium();
            form.ShowDialog(this);
        }

        private void mejoresCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMejoresCategorias form = new FormMejoresCategorias();
            form.ShowDialog(this);
        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        #region obtener datos de usuario

        private void obtenerDatosUser()
        {
            string string_where = "";
            DataTable un_datatable;

            string_where = "usr_id = '" + user_id + "' and empleado_id = usr_empleado";

            un_datatable = con.armar_query_dinamica_consulta("'" + user_id + "', empleado_tipo, empleado_sucursal, empleado_id", "usuario, GURP_SKYPE.empleado", string_where).Tables[0];
            
            if (un_datatable.Rows.Count != 0)
            {
                datos_usuario.set_UsuarioApp(un_datatable.Rows[0][0].ToString(), un_datatable.Rows[0][1].ToString(), un_datatable.Rows[0][2].ToString(), un_datatable.Rows[0][3].ToString());
            }
        }

        #endregion

        #region obtener habilidades del usuario

        private void obtenerHabilidades()
        {
            string string_where = "";
            DataTable un_datatable;

            string_where = "rol_usr_id = '" + user_id + "' and rol_hab = 1";
            con.nombre_tabla = "Rol";

            bool amb_emp = false;
            bool amb_rol = false;
            bool amb_user = false;
            bool amb_cli = false;
            bool amb_prod = false;
            bool asig_stock = false;
            bool fact = false;
            bool efec_pago = false;
            bool tab_cont = false;
            bool cli_prem = false;
            bool mej_cat = false;


            un_datatable = con.armar_query_dinamica_consulta("rol_abm_emp, rol_abm_rol, rol_abm_user, rol_abm_cli, rol_abm_prod, rol_asig_stock, rol_fact, rol_efec_pago, rol_tab_cont, rol_cli_prem, rol_mej_cat", "rol", string_where).Tables[0];

            if (un_datatable.Rows.Count != 0)
            {
                foreach (DataRow row_number in un_datatable.Rows)
                {
                    if (row_number[0].ToString().Equals("True")) amb_emp = true;
                    if (row_number[1].ToString().Equals("True")) amb_rol = true;
                    if (row_number[2].ToString().Equals("True")) amb_user = true;
                    if (row_number[3].ToString().Equals("True")) amb_cli = true;
                    if (row_number[4].ToString().Equals("True")) amb_prod = true;
                    if (row_number[5].ToString().Equals("True")) asig_stock = true;
                    if (row_number[6].ToString().Equals("True")) fact = true;
                    if (row_number[7].ToString().Equals("True")) efec_pago = true;
                    if (row_number[8].ToString().Equals("True")) tab_cont = true;
                    if (row_number[9].ToString().Equals("True")) cli_prem = true;
                    if (row_number[10].ToString().Equals("True")) mej_cat = true;
                }
                user_habs.set_UsuarioHab(amb_emp, amb_rol, amb_user, amb_cli, amb_prod, asig_stock, fact, efec_pago, tab_cont, cli_prem, mej_cat);
            }

        }

        #endregion
    }
}
