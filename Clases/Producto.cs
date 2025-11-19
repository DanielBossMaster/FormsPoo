namespace FormsPoo.Clases
{
    public abstract class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        // Método polimórfico
        public abstract decimal CalcularDescuento();
    }
}
