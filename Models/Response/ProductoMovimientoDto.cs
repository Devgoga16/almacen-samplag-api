using System.ComponentModel.DataAnnotations;

namespace almacen_samplag.Models.Response
{
    public class ProductoMovimientoDto
    {
        [Key]
        public int idMovimiento { get; set; }
        public int idProducto { get; set; }
        public decimal cantidad { get; set; }
        public int idServicio { get; set; }
        public int tipoMovimiento { get; set; }
        public DateTime fecha { get; set; }
        public string? nombreProducto { get; set; }
    }
}
