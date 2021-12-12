using Entidad;
using Microsoft.EntityFrameworkCore;
using System;

namespace Datos
{
    public class PruebaFinalContext:DbContext
    {
        public PruebaFinalContext(DbContextOptions contextOptions) : base(contextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
    }
}
