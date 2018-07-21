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
    public partial class punto_venta : Form
    {
        public punto_venta()
        {
            InitializeComponent();
        }

        private void lblFecha_Load(object sender, EventArgs e)
        {
            lblTitulo.Location = new Point(this.Width / 2 - lblTitulo.Width / 2, 10);
            lblVer.Location = new Point(this.Width / 2 - lblVer.Width / 2, lblTitulo.Height + 11);
            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblTitulo.Height + lblVer.Height + 22);
            dgv1.Width = this.Width - 2;
            dgv1.Height = int.Parse(this.Height * 0.75 + "");
            dgv1.Location = new Point(1, lblTitulo.Height + lblVer.Height + lblFecha.Height + 22);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString();
            lblFecha.Location = new Point(this.Width / 2 - lblFecha.Width / 2, lblTitulo.Height + lblVer.Height + 22);
        }
    }
}
