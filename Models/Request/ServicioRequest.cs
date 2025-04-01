namespace almacen_samplag.Models.Request
{
    public class ServicioRequest
    {
        public int idCliente { get; set; }
        public string? descripcionServicio { get; set; }
        public DateTime fecha { get; set; }

        public List<int>? idColaboradores { get; set; }
    }
}
