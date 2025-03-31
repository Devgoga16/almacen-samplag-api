using System.ComponentModel.DataAnnotations;

namespace almacen_samplag.Models
{
    public class Colaborador
    {
        [Key]
        public int idColaborador {  get; set; }
        public string? nombreColaborador { get; set; }
    }
}
