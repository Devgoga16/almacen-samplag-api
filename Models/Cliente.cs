using System.ComponentModel.DataAnnotations;

namespace almacen_samplag.Models
{
    public class Cliente
    {
        [Key]
        public int idCliente {  get; set; }
        public string? nombreCliente { get; set; }
    }
}
