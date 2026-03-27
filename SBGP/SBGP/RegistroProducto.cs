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
    public partial class RegistroProducto : Form
    {
        Form1 formPrincipal; // Variable para almacenar la referencia al formulario principal
        public RegistroProducto(Form1 frm)
        {
            InitializeComponent();
            formPrincipal = frm; // Asigna la referencia del formulario principal a la variable formPrincipal para poder llamar a sus métodos desde este formulario
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Cierra el formulario de registro si el usuario confirma que desea cancelar
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProduc.Text) || string.IsNullOrWhiteSpace(txtPrecioProduc.Text) || string.IsNullOrWhiteSpace(txtCategProduc.Text) || string.IsNullOrWhiteSpace(txtStockProduc.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // asignamos los valores de los campos a variables para luego pasarlas como parametros al metodo AgregarProducto del formulario principal
                string Nombre = txtNombreProduc.Text;
                string Categoria = txtCategProduc.Text;
                string Precio = txtPrecioProduc.Text;
                int Stock = int.Parse(txtStockProduc.Text);

                formPrincipal.AgregarProducto(Nombre, Categoria, Precio, Stock); // Llama al método AgregarProducto del formulario principal para agregar el producto al DataGridView

                this.Close(); // Cierra el formulario de registro después de agregar el producto
            }
        }

        private void txtStockProduc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStockProduc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) // Permitir solo dígitos y teclas de control
            {
                MessageBox.Show("Solo se permiten números en el campo de Stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }
    }
}
