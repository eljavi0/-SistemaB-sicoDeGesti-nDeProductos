using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBGP
{
    public partial class Form1 : Form
    {
        int idActual = 1;  // Variable para llevar el seguimiento del ID actual del producto, se inicia en 1
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e) // Evento del botón Salir para confirmar si el usuario desea salir de la aplicación
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            RegistroProducto frm = new RegistroProducto(this); // Crea una instancia del formulario RegistroProducto y le pasa una referencia a este formulario para que pueda llamar al método AgregarProducto
            frm.Show();
        }

        public void AgregarProducto(string Nombre, string Categoria, string Precio, int Stock) // Método con parametros para agregar un producto al DataGridView
        {
            dataGridView1.Rows.Add(idActual, Nombre, Categoria, Precio, Stock); // Agrega una nueva fila al DataGridView con los datos del producto
            idActual++; // Incrementa el ID para el siguiente producto y asi no repetir el mismo ID en el DataGridView
        }

        public void ActualizarProducto(int fila, string Nombre, string Categoria, string Precio, int Stock)
        {
            dataGridView1.Rows[fila].Cells[1].Value = Nombre;
            dataGridView1.Rows[fila].Cells[2].Value = Categoria;
            dataGridView1.Rows[fila].Cells[4].Value = Stock;
            dataGridView1.Rows[fila].Cells[3].Value = Precio;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para editar");
                return;
            }
            else if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un producto para editar");
                return;
            }

            // ❗ Validar si es la fila vacía (nueva fila)
            else if (dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("El registro seleccionado está vacío");
                return;
            }

            // También puedes validar que tenga datos
            else if (dataGridView1.CurrentRow.Cells[1].Value == null)
            {
                MessageBox.Show("El registro seleccionado está vacío");
                return;
            }

            else// Obtener datos de la fila seleccionada
            {
                int fila = dataGridView1.CurrentRow.Index;

                string Nombre = dataGridView1.Rows[fila].Cells[1].Value.ToString();
                string Categoria = dataGridView1.Rows[fila].Cells[3].Value.ToString();
                string Precio = dataGridView1.Rows[fila].Cells[2].Value.ToString();
                int Stock = Convert.ToInt32(dataGridView1.Rows[fila].Cells[4].Value);

                // Abrir FormEditar
                FormEditar frm = new FormEditar(this, fila, Nombre, Categoria, Precio, Stock);
                frm.ShowDialog();
            }
        }
    }
}
