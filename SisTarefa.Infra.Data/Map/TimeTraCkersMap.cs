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
            builder.Property(x => x.CreatedAt).HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasColumnType("datetime");
            builder.Property(x => x.DeletedAt).HasColumnType("datetime");
            builder.Property(x => x.StartDate).HasColumnType("datetime");
            builder.Property(x => x.EndDate).HasColumnType("datetime");
            builder.Property(x => x.TimeZoneId).HasMaxLength(200);
        }
    }
}
