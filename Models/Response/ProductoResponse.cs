namespace almacen_samplag.Models.Response
{
    public class ProductoResponse
    {
        public int idProducto { get; set; }
        public string? nombreProducto { get; set; }
        public int idPresentacion { get; set; }
        public string? presentacion { get; set; }
        public bool retornable { get; set; }

        public static ProductoResponse FromProducto(Producto producto)
        {
            return new ProductoResponse
            {
                idProducto = producto.idProducto,
                nombreProducto = producto.nombreProducto,
                idPresentacion = producto.idPresentacion,
                retornable = producto.retornable,
                presentacion = ""
            };
        }
    }
}
