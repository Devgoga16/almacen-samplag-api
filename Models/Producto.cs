using System.ComponentModel.DataAnnotations;

namespace almacen_samplag.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        public string? nombreProducto { get; set; }
        public int idPresentacion { get; set; }
        public bool retornable { get; set; }
    }
}