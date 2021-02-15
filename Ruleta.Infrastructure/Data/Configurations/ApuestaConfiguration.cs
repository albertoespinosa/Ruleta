using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Ruleta.Core.Entities;

namespace Ruleta.Infrastructure.Data.Configurations
{
    class ApuestaConfiguration : IEntityTypeConfiguration<Apuesta>
    {
        public void Configure(EntityTypeBuilder<Apuesta> builder)
        {
            builder.ToTable("Apuestas");

            // LLAVE PRIMARIA
            builder.HasKey(a => a.Id);

            // PROPIEDADES

            builder.Property(a => a.Id);

            builder.Property(a => a.TipoApuesta)
             .IsRequired()
             .HasMaxLength(10);

            builder.Property(a => a.SeleccionApuesta)
              .IsRequired()
              .HasMaxLength(10);

            builder.Property(a => a.MontoDinero);

            builder.Property(a => a.JugadorId);

            builder.Property(a => a.JuegoRuletaId);           


            // RELACIONES

            builder.HasOne(a => a.Jugador)
                .WithMany(j => j.Apuestas)
                .HasForeignKey(a => a.JugadorId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.HasOne(a => a.JuegoRuleta)
                .WithMany(jr => jr.Apuestas)
                .HasForeignKey(a => a.JuegoRuletaId)
                .OnDelete(DeleteBehavior.ClientSetNull);



        }
    }
}
