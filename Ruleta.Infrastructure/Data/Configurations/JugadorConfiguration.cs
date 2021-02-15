using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ruleta.Core.Entities;

namespace Ruleta.Infrastructure.Data.Configurations
{
    class JugadorConfiguration : IEntityTypeConfiguration<Jugador>
    {
        public void Configure(EntityTypeBuilder<Jugador> builder)
        {
            builder.ToTable("Jugadores");

            // LLAVE PRIMARIA
            builder.HasKey(a => a.Id);

            // PROPIEDADES

            builder.Property(a => a.Id);

            builder.Property(a => a.Nombre)
             .IsRequired()
             .HasMaxLength(25);

            builder.Property(a => a.Password)
             .IsRequired()
             .HasMaxLength(25);

            builder.Property(a => a.Dinero);           
        }
    }
}
