﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace almacen_samplag.Models
{
    public class Movimiento
    {
        [Key]
        public int idMovimiento {  get; set; }
        public int idProducto { get; set; }
        public decimal cantidad { get; set; }
        public int idServicio { get; set; }
        public int tipoMovimiento { get; set; }
        public DateTime fecha { get; set; }
    }
}
