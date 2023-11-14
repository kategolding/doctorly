using doctorly.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace doctorly.Data.EntityFramework.Context
{
    public class DoctorlyDbContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }

        public DoctorlyDbContext(DbContextOptions<DoctorlyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Add Default Date to Created On for all Entities
            //      Loop through all items in the context with the attribute : [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            //      And Apply .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<EventEntity>()
                            .Property(x => x.CreatedOnUtc)
                            .HasDefaultValueSql("getdate()");
        }
    }
}
