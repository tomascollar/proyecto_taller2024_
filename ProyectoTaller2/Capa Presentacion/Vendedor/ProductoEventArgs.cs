namespace ProyectoTaller2
{
    public class ProductoEventArgs
    {

        public productos ProductoAgregado { get; }

        public ProductoEventArgs(productos producto)
        {
            ProductoAgregado = producto;
        }

    }
}