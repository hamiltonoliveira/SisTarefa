
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisTarefa.Domain.Entities;

namespace SisTarefa.Infra.Data.Map
{
    public class UsersMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime");
            builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt").HasColumnType("datetime");
            builder.Property(x => x.UserName).HasMaxLength(250).IsRequired(); 
            builder.Property(x => x.Password).HasMaxLength(512).IsRequired();
            builder.Property(x => x.GuidI).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Role).HasMaxLength(30).IsRequired();
        }
    }
}
