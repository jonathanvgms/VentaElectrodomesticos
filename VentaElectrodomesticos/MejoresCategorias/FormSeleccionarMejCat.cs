using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VentaElectrodomesticos.MejoresCategorias
{
    public partial class FormSeleccionarMejCat : Form
    {
        DataSet a_dataset;

        public FormSeleccionarMejCat(DataSet mi_dataset)
        {
            a_dataset = mi_dataset;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSeleccionarMejCat_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = a_dataset.Tables[0];    
        }
    }
}
