using System.ComponentModel.DataAnnotations;

namespace almacen_samplag.Models
{
    public class Servicio
    {
        [Key]
        public int idServicio { get; set; }
        public int idCliente { get; set; }
        public string? descripcionServicio { get; set; }
        public DateTime? fecha { get; set; }
    }
}
