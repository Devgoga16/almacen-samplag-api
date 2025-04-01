using System.ComponentModel.DataAnnotations;

namespace almacen_samplag.Models
{
    public class ServicioColaborador
    {
        [Key]
        public int idServicioColaborador { get; set; }
        public int idServicio { get; set; }
        public int idColaborador { get; set; }
    }
}
