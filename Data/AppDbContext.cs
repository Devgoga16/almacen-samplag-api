using System.Collections.Generic;
using almacen_samplag.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Presentacion> Presentacion { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<ServicioColaborador> ServicioColaborador { get; set; }
    }
}
