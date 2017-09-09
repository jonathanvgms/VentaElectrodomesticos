using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.ClientesPremium
{
    public partial class FormSelecCliePrem : Form
    {
        Util u = new Util();
        DataSet a_dataset;

        public FormSelecCliePrem(DataSet mi_dataset)
        {
            a_dataset = mi_dataset;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSeleccionarClientesPremium_Load(object sender, EventArgs e)
        {          
            dataGrid_clientes_premium.DataSource = a_dataset.Tables["Cliente"];         
        }
    }
}
