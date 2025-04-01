using System.ComponentModel.DataAnnotations.Schema;

namespace almacen_samplag.Models.Response
{
    public class ServicioResponseList
    {
        public int idServicio { get; set; }
        public int idCliente { get; set; }
        public string nombreCliente { get; set; }
        public string descripcionServicio { get; set; }
        public DateTime fecha { get; set; }
        [NotMapped]
        public List<Colaborador> colaboradores { get; set; }
    }
}
