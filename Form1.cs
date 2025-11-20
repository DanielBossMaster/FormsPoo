using System;
using System.Windows.Forms;
using FormsPoo.Clases;

namespace FormsPoo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cbTipo.Items.Add("Tecnologia");
            cbTipo.Items.Add("Comida");
            cbTipo.Items.Add("Tienda");
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            decimal precio;

            // Validaciones
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese el nombre del producto.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio válido y mayor que 0.");
                return;
            }

            if (cbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de producto.");
                return;
            }

            Producto producto;

            // Instancia adecuada (polimorfismo)
            switch (cbTipo.SelectedItem.ToString())
            {
                case "Tecnologia":
                    producto = new Tecnologia(nombre, precio);
                    break;

                case "Comida":
                    producto = new Comida(nombre, precio);
                    break;

                default:
                    producto = new Tienda(nombre, precio);
                    break;
            }

            // Calcular descuento
            decimal precioFinal = producto.CalcularDescuento();

            lblResultado.Text = $"Precio final: {precioFinal:C}";
        }
    }
}
