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
            builder.HasOne(p => p.Users)
                   .WithOne(p => p.Colaborators)
                   .HasForeignKey<Colaborators>(p => p.UsersId);

            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime");
            builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt").HasColumnType("datetime");
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
        }
    }
}
