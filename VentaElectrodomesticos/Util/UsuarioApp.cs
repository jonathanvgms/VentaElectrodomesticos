using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos
{
    class UsuarioApp
    {
        private string usuario_nombre;
        private string usuario_tipo_empleado;
        private string usuario_suc_id;
        private string usuario_id_empleado;

        public void set_UsuarioApp(string nombre, string tipo_empleado, string suc_id, string id_emp)
        {
            this.usuario_nombre = nombre;
            this.usuario_tipo_empleado = tipo_empleado;
            this.usuario_suc_id = suc_id;
            this.usuario_id_empleado = id_emp;
        }

        public string get_usuario_nombre()
        {
            return this.usuario_nombre;
        }
        public string get_usuario_tipo_empleado()
        {
            return this.usuario_tipo_empleado;
        }
        public string get_usuario_suc_id()
        {
            return this.usuario_suc_id;
        }
        public string get_id_empleado()
        {
            return this.usuario_id_empleado;
        }
    }
}
