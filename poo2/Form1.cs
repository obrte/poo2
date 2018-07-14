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
    public partial class Form1 : Form
    {

        private List<Productos> listaProductos = new List<Productos>();
        Productos[] producto = new Productos[3];
        private int rowSelect;
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
            //Comentario nuevo
            producto[0] = new Productos(1, "producto 1", 35.00f);
            producto[1] = new Productos(2, "producto 2", 35.02f);
            producto[2] = new Productos(3, "producto 3", 35.08f);
            cargaProducto();

        }
        private void cargaProducto()
        {
            dgv1.Columns[2].DefaultCellStyle.Format = "N2";
            
            try
            {
                int counter = 0;
                string line;
                StreamReader file = new StreamReader("productos.csv");
                while ((line = file.ReadLine()) != null)
                {
                    rtb1.Text += (line + Environment.NewLine);
                    dgv1.Rows.Add(line.Split(','));
                    counter++;
                }
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            numerar();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if(dgv1[0,i].Value.ToString() == txtCod.Text)
                {
                   if(MessageBox.Show("el Codigo que ya existe, desea corregir?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        existe = true;
                        break;
                    }
                    else
                    {
                        existe = true;
                        limpiar();
                        break;
                    }

                }
            }
            if (!existe)
            {
                dgv1.Rows.Add(txtCod.Text, txtNombre.Text, txtPrecio.Text);
                limpiar();
            }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea eliminar el siguiente producto?" 
                + Environment.NewLine + "Nombre: " 
                + txtNombre.Text 
                + Environment.NewLine 
                + "Precio: $"
                + txtPrecio.Text, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgv1.Rows.RemoveAt(rowSelect);
            }
            limpiar();
        }

        private void btnRel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea modificar los siguinetes valores?"
                + Environment.NewLine
                + "Nombre: "
                + dgv1[1, rowSelect].Value.ToString()
                + " --> "
                + txtNombre.Text
                + Environment.NewLine
                + "Precio: $"
                + dgv1[2, rowSelect].Value.ToString()
                + " --> $" 
                + txtPrecio.Text
                + Environment.NewLine, "Update",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgv1[1, rowSelect].Value = txtNombre.Text;
                dgv1[2, rowSelect].Value = txtPrecio.Text;
                limpiar();
            }
            

        }

        private void limpiar()
        {
            txtCod.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtCod.Focus();
        }

        private void numerar()
        {
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                dgv1.Rows[i].HeaderCell.Value = (i+1).ToString();
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowSelect = e.RowIndex;
            txtCod.Text = dgv1[0, rowSelect].Value.ToString();
            txtNombre.Text = dgv1[1, rowSelect].Value.ToString();
            txtPrecio.Text = dgv1[2, rowSelect].Value.ToString();
        }
    }

    class Productos
    {
        //Propiedades
        public long pCodigo = 0;
        public String pNombre = "";
        public float pPrecio = 0.00f;

        public Productos()
        {
            MessageBox.Show("Me llamaron sin parametros");
        }
        public Productos(long pCodigo, String pNombre, float pPrecio)
        {
            this.pCodigo = pCodigo;
            this.pNombre = pNombre;
            this.pPrecio = pPrecio;
        }
    }
}
