using System.ComponentModel.DataAnnotations;

namespace almacen_samplag.Models
{
    public class Presentacion
    {
        [Key]
        public int idPresentacion {  get; set; }
        public string? nombrePresentacion { get; set; }
    }
}
