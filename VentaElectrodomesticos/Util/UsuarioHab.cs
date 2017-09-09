using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos
{
    class UsuarioHab
    {
        private bool amb_emp;
        private bool amb_rol;
        private bool amb_user;
        private bool amb_cli;
        private bool amb_prod;
        private bool amb_asig_stock;
        private bool amb_fac;
        private bool amb_efec_pago;
        private bool amb_tab_cont;
        private bool amb_cli_prem;
        private bool amb_mej_cat;

        public void set_UsuarioHab(bool emp, bool rol, bool user, bool cli, bool prod, bool asig_stock, bool fac, bool efec_pago, bool tab_con, bool cli_prem, bool mej_cat)
        {
            this.amb_emp = emp;
            this.amb_rol = rol;
            this.amb_user = user;
            this.amb_cli = cli;
            this.amb_prod = prod;
            this.amb_asig_stock = asig_stock;
            this.amb_fac = fac;
            this.amb_efec_pago = efec_pago;
            this.amb_tab_cont = tab_con;
            this.amb_cli_prem = cli_prem;
            this.amb_mej_cat = mej_cat;
        }

        public bool get_amb_emp()
        {
            return this.amb_emp;
        }
        public bool get_amb_rol()
        {
            return this.amb_rol;
        }
        public bool get_amb_user()
        {
            return this.amb_user;
        }
        public bool get_amb_cli()
        {
            return this.amb_cli;
        }
        public bool get_amb_prod()
        {
            return this.amb_prod;
        }
        public bool get_amb_asig_stock()
        {
            return this.amb_asig_stock;
        }
        public bool get_amb_fac()
        {
            return this.amb_fac;
        }
        public bool get_amb_efec_pago()
        {
            return this.amb_efec_pago;
        }
        public bool get_amb_tab_cont()
        {
            return this.amb_tab_cont;
        }
        public bool get_amb_cli_prem()
        {
            return this.amb_cli_prem;
        }
        public bool get_amb_mej_cat()
        {
            return this.amb_mej_cat;
        }
    }
}
