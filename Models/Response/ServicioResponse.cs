namespace almacen_samplag.Models.Response
{
    public class ServicioResponse
    {
        public int idServicio {  get; set; }
        public int idCliente { get; set; }
        public string descripcionServicio { get; set; }
        public DateTime fecha { get; set; }
    }
}
