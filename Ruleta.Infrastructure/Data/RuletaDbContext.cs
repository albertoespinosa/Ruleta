using Microsoft.EntityFrameworkCore;
using Ruleta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ruleta.Infrastructure.Data
{
    public class RuletaDbContext : DbContext
    {
        public RuletaDbContext(DbContextOptions<RuletaDbContext> options)
            : base(options)
        {

        }
        public DbSet<JuegoRuleta> JuegoRuletas { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
