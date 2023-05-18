using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisTarefa.Domain.Entities;

namespace SisTarefa.Infra.Data.Map
{
    public class TimeTraCkersMap : IEntityTypeConfiguration<TimeTraCkers>
    {
        public void Configure(EntityTypeBuilder<TimeTraCkers> builder)
        {
            builder.ToTable("TimeTraCkers");
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Colaborators)
                   .WithMany(p => p.TimeTraCkers)
                   .IsRequired();

            builder.HasOne(p => p.Tasks)
                   .WithMany(p => p.TimeTraCkers)
                   .IsRequired();

            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime");
            builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt").HasColumnType("datetime");
            builder.Property(x => x.StartDate).HasColumnName("StartDate").HasColumnType("datetime");
            builder.Property(x => x.EndDate).HasColumnName("EndDate").HasColumnType("datetime");
            builder.Property(x => x.TimeZoneId).HasMaxLength(200);
        }
    }
}
