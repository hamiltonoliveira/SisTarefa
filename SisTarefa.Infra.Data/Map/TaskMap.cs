using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisTarefa.Domain.Entities;

namespace SisTarefa.Infra.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Projects)
                   .WithMany(p => p.Tasks)
                   .IsRequired();

            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime");
            builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt").HasColumnType("datetime");
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
