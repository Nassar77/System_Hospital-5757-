using HospitalSystem.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HospitalSystem.DAL.DB
{
    public class AppDbContext : IdentityDbContext<Patient>
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
       {

       }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole() 
                { 
                   Id = Guid.NewGuid().ToString(),
                    Name = "Doctor",
                    NormalizedName = "doctor",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Patient",
                    NormalizedName = "patient",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }

        public DbSet<RoomAvailability> RoomAvailabilities { get; set; }


    }
    
}
