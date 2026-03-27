using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq; // Agregar esta línea para usar LINQ

namespace SBGP
{
    public partial class Form1 : Form // Formulario principal

    {
        List<Producto> listaProductos = new List<Producto>(); // Lista para almacenar los productos
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e) // Botón "Salir"
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Agregar categorías al ComboBox
            comboCategoria.Items.Add("Tecnología");
            comboCategoria.Items.Add("Papelería");
            comboCategoria.Items.Add("Todos");

            listaProductos.Add(new Producto { ID = 1, Nombre = "Mouse", Categoria = "Tecnología", Precio = 50, Stock = 10 });
            listaProductos.Add(new Producto { ID = 2, Nombre = "Teclado", Categoria = "Tecnología", Precio = 80, Stock = 5 });
            listaProductos.Add(new Producto { ID = 3, Nombre = "Cuaderno", Categoria = "Papelería", Precio = 10, Stock = 20 });
            listaProductos.Add(new Producto { ID = 4, Nombre = "Monitor", Categoria = "Tecnología", Precio = 500, Stock = 3 });
            listaProductos.Add(new Producto { ID = 5, Nombre = "Lapicero", Categoria = "Papelería", Precio = 2, Stock = 50 });
            listaProductos.Add(new Producto { ID = 6, Nombre = "Cuaderno grande", Categoria = "Papelería", Precio = 15, Stock = 25 });
            listaProductos.Add(new Producto { ID = 7, Nombre = "Audífonos", Categoria = "Tecnología", Precio = 120, Stock = 8 });
            listaProductos.Add(new Producto { ID = 8, Nombre = "USB 32GB", Categoria = "Tecnología", Precio = 30, Stock = 15 });
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = listaProductos.OrderBy(p => p.ID).ToList(); // Ordenar la lista por ID antes de mostrarla en el DataGridView
        }

        private void button1_Click(object sender, EventArgs e) // Botón "Filtrar"
        {
            string categoria = comboCategoria.Text;

            if (categoria == "Todos")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listaProductos;
            }
            else
            {
                var filtrados = listaProductos.Where(p => p.Categoria == categoria).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = filtrados;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) // Botón "Eliminar"
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["ID"].Value;

                listaProductos.RemoveAll(p => p.ID == id);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listaProductos;
            }
            else
            {
                MessageBox.Show("Seleccione un producto");
            }
        }
    }
}



    



