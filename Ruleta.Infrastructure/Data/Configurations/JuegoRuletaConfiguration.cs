using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ruleta.Core.Entities;

namespace Ruleta.Infrastructure.Data.Configurations
{
    class JuegoRuletaConfiguration : IEntityTypeConfiguration<JuegoRuleta>
    {
        public void Configure(EntityTypeBuilder<JuegoRuleta> builder)
        {
            builder.ToTable("JuegoRuletas");

            // LLAVE PRIMARIA
            builder.HasKey(a => a.Id);

            // PROPIEDADES

            builder.Property(a => a.Id);

            builder.Property(a => a.Estado)
             .IsRequired()
             .HasMaxLength(10);
        }
    }
}
