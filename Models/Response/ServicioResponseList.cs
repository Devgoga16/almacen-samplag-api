using System.ComponentModel.DataAnnotations.Schema;

namespace almacen_samplag.Models.Response
{
    public class ServicioResponseList
    {
        public int idServicio { get; set; }
        public string? descripcionServicio { get; set; }
        public DateTime fecha { get; set; }
        public int idCliente { get; set; }
        public string? nombreCliente { get; set; }
        public int idSede {  get; set; }
        public string? nombreSede { get; set; }
        public string? direccionSede { get; set; }
        public string? rucSede { get; set; }

        [NotMapped]
        public List<Colaborador>? colaboradores { get; set; }
        [NotMapped]
        public List<ProductoMovimientoDto>? productos { get; set; }
    }
}
