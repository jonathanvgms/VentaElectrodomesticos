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
    public partial class FormSelecCategorias : Form
    {
        Conexion con = new Conexion();
        Util u = new Util();
        string categoria_seleccionada = "";

        public FormSelecCategorias()
        {
            InitializeComponent();
        }
        
        #region accion de cargar las categoria en una vista de arboleda =P
        /*
         * este metodo se encarga de llenar el treewiew con las categorias
         * y subcategorias correspondientes, creo aca el nodo padre 'categorias' o mejor dicho 
         * la raia del arbol.
         */
        private void cargar_categorias()
        {
            DataTable a_datatable;
            TreeNode nodo_categoria = new TreeNode("Categorias");
            string id_raiz;

            con.nombre_tabla = "Categoria";

            treeView_categoria.Nodes.Add(nodo_categoria);

            a_datatable = con.armar_query_dinamica_consulta("cat_id", "categoria", "cat_nombre = 'categoria'").Tables[0];

            id_raiz = a_datatable.Rows[0][0].ToString();

            this.agregar_subcategorias(nodo_categoria, id_raiz);
        }
        #endregion

        #region metodo agregar subcategorias
        /*
         * El mecanismo de este metodo recursivo es:
         *  
         * A un nodo llamado 'padre' se le buscan todos los hijos... o sea todos las filas de tabla
         * categoria que le tengan como padre despues a cada nodo hijo que encuentre
         * vuelo a llamar al mismo metodo siendo el hijo ahora padre y asi sucesivamente hasta que el nodo 'padre'
         * no tenga hijos..
         */

        private TreeNode agregar_subcategorias(TreeNode nodo_padre, string id_padre)
        {
            DataTable a_datable;

            //traigo de la base de datos los hijos del padre
            a_datable = con.armar_query_dinamica_consulta("cat_id, cat_nombre", "categoria", "cat_padre_id = " + id_padre).Tables[0];

            //me fijo si la tabla vino vacia en tal caso retorno el nodo actual
            if (a_datable.Rows.Count == 0)
            {
                return nodo_padre;
            }

            //para cada elemento de la tabla (o sea para cada hijo del padre)
            foreach (DataRow row_categoria in a_datable.Rows)
            {
                //obtengo el id 
                string a_id = row_categoria["cat_id"].ToString();

                //obtengo el nombre
                string a_cat = row_categoria["cat_nombre"].ToString();

                //creo un nuevo nodo hijo
                TreeNode nodo_hijo = new TreeNode(a_cat);

                //le endoso el hijo al padre
                nodo_padre.Nodes.Add(nodo_hijo);

                this.agregar_subcategorias(nodo_hijo, a_id);
            }

            return nodo_padre;
        }
        #endregion
        
        #region metodo getter categoria
        /*
         * metodo que retorna la categorias selecciona con toda su 'ruta'
         * y en forma de:
         * 
         * cat1|subcat1|...
         */
        public string get_categoria()
        {
            return u.armar_categoria(categoria_seleccionada);
        }
        #endregion

        #region obtengo el path de la categoria
        /*
         * en este evento se obtiene el 'camino' de la categoria seleccionada
         */
        private void elegir_subcategoria(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!e.Node.Text.Equals("Categorias"))
            {
                categoria_seleccionada = e.Node.FullPath;
            }
        }
        #endregion      

        #region accio de apretar el boton salir        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region accion que se hace cuando se carga el form
        private void FormSelecCategorias_Load(object sender, EventArgs e)
        {
            this.cargar_categorias();
        }
        #endregion
    }
}
