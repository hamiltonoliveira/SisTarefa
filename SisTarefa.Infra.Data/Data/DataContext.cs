using Microsoft.EntityFrameworkCore;
using SisTarefa.Domain.Entities;
using SisTarefa.Domain.Interface;
using SisTarefa.Infra.Data.Map;

namespace SisTarefa.Infra.Data.Data
{
   
    public class DataContext : DbContext, ISalvar
    {
      
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext()
        {
        }

        public DbSet<Users>? Users { get; set; }
        public DbSet<TimeTraCkers>? TimeTraCkers { get; set; }
        public DbSet<Colaborators>? Colaborators { get; set; }
        public DbSet<Projects>? Projects { get; set; }
        public DbSet<Tasks>? Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new ColaboratorsMap());
            modelBuilder.ApplyConfiguration(new ProjectsMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new TimeTraCkersMap());
        }

        public async Task CommitAsync()
        {
            var cetZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CreatedAt").CurrentValue = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").IsModified = false;
                    entry.Property("UpdatedAt").CurrentValue = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                }
            }
            var x = await base.SaveChangesAsync();
        }
    }
}
