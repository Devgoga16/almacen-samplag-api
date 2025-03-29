﻿using System.Collections.Generic;
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
    }
}
