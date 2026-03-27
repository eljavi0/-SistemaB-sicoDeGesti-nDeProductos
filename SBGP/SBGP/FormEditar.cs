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
    public partial class FormEditar : Form
    {
        Form1 formPrincipal;
        int filaIndex;
        public FormEditar(Form1 frm, int fila, string Nombre, string Categoria, string Precio, int Stock)
        {
            InitializeComponent();
            formPrincipal = frm;
            filaIndex = fila;

            // Cargar datos en los textbox
            txtNombreProduc1.Text = Nombre;
            txtCategProduc1.Text = Categoria;
            txtPrecioProduc1.Text = Precio;
            txtStockProduc1.Text = Stock.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Cierra el formulario de registro si el usuario confirma que desea cancelar
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombreProduc1.Text;
            string Categoria = txtCategProduc1.Text;
            string Precio = txtPrecioProduc1.Text;
            int Stock = int.Parse(txtStockProduc1.Text);

            formPrincipal.ActualizarProducto(filaIndex, Nombre, Categoria, Precio, Stock);

            MessageBox.Show("Producto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void txtStockProduc1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStockProduc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Evita que se ingresen caracteres no numéricos
            }
        }
    }
}
