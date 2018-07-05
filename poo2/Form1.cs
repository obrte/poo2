using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poo2
{
    public partial class Form1 : Form
    {
        private List<Productos> listaProductos = new List<Productos>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Productos producto = new Productos();
            //producto.pCodigo = 9123456789;
            //producto.pNombre = "Miller";
            //producto.pPrecio = 36.00f;
            //rtb1.Text += producto.pCodigo + Environment.NewLine + producto.pNombre + Environment.NewLine + producto.pPrecio;
            
        }
        private void cargaProducto()
        {

        }
    }

    class Productos
    {
        //Propiedades
        public long pCodigo = 0;
        public String pNombre = "";
        public float pPrecio = 0.00f;


    }
}
