using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.FormsComunes
{
    public partial class FormSelecFecha : Form
    {
        string fecha = ""; 

        public FormSelecFecha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fecha_seleccionada(object sender, DateRangeEventArgs e)
        {
            this.fecha = e.Start.ToString("yyyy-M-d HH:mm:ss"); // + " " + e.Start.ToString("HH:mm:ss"); ;
        }

        private void FormSelecFecha_Load(object sender, EventArgs e)
        {            
            //aca debo definir el rango de la fecha
            this.calendario.MinDate = new DateTime(1995, 1, 1); // "01/01/1995 0:00:00";
            this.calendario.MaxDate = new DateTime(2100, 12, 31); //"31/12/2010 0:00:00";
        }

        public string get_fecha()
        {
            return this.fecha;
        }
    }
}
