using System.ComponentModel.DataAnnotations;

namespace almacen_samplag.Models
{
    public class Sede
    {
        [Key]
        public int idSede { get; set; }
        public int idCliente { get; set; }
        public string? nombreSede { get; set; }
        public string? rucSede { get; set; }
        public string? direccionSede { get; set; }
    }
}
