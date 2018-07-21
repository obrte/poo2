using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace poo2
{
    public partial class verificador : Form
    {
        private string codigo = "";
        private int conTimer = 0;
        public verificador()
        {
            InitializeComponent();
        }

        private void verificador_Load(object sender, EventArgs e)
        {
            lblZV.Location = new Point(this.Width / 2 - lblZV.Width / 2, 10);
            lblVer.Location = new Point(this.Width / 2 - lblVer.Width / 2, lblZV.Height + 11);
            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblZV.Height + lblVer.Height + 11);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblZV.Height + lblVer.Height + 11);
            if(conTimer == 2)
            {
                lblNombre.Text = "";
                lblPrecio.Text = "";
            }
            conTimer++;
        }

        private void buscar(string codigo)
        {
            conTimer = 0;
            string[] infoProducto;
            string line;
            StreamReader file = new StreamReader("productos.csv");
            
            while ((line = file.ReadLine()) != null)
            {
                
                infoProducto = line.Split(',');
                if (codigo == infoProducto[0])
                {
                    lblNombre.Text = "Nombre: " + infoProducto[1];
                    lblPrecio.Text = "Precio: $" + infoProducto[2];
                    lblNombre.ForeColor = Color.Black;
                    lblNombre.Location = new Point(this.Width / 2 - lblNombre.Width / 2, this.Height / 2 - lblNombre.Height - 20);
                    lblPrecio.Location = new Point(this.Width / 2 - lblPrecio.Width / 2, (this.Height / 2 - lblPrecio.Height) + lblNombre.Height);
                    break;
                }
                else
                {
                    lblNombre.Text = "Producto no encontrado";
                    lblNombre.Location = new Point(this.Width / 2 - lblNombre.Width / 2, this.Height / 2 - lblNombre.Height - 20);
                    lblNombre.ForeColor = Color.Red;
                }
                
            }
            file.Close();
        }

        private void verificador_KeyPress(object sender, KeyPressEventArgs e)
        {
            codigo += e.KeyChar;
            if (e.KeyChar == 13)
            {
               // MessageBox.Show(codigo.Trim());
                buscar(codigo.Trim());
                codigo = "";
            }
        }
    }
}
