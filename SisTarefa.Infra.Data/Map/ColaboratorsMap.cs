using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisTarefa.Domain.Entities;

namespace SisTarefa.Infra.Data.Map
{
    public class ColaboratorsMap : IEntityTypeConfiguration<Colaborators>
    {
        public void Configure(EntityTypeBuilder<Colaborators> builder)
        {
            builder.ToTable("Colaborators");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasColumnType("datetime");
            builder.Property(x => x.DeletedAt).HasColumnType("datetime");
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
        }
    }
}
