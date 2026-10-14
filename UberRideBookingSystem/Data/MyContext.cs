using Microsoft.EntityFrameworkCore;
using UberRideBookingSystem.Models;

namespace UberRideBookingSystem.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) 
        {
            
        }
        public DbSet<User> users { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Ride> rides { get; set; }
        public DbSet<Rating> ratings { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Vehicle)
                .WithOne(a => a.UserDriver)
                .HasForeignKey<Vehicle>(a => a.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(a => a.DriverRides)
                .WithOne(a => a.UserDriver)
                .HasForeignKey(a => a.DriverId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(a => a.RiderRides)
                .WithOne(a => a.UserRider)
                .HasForeignKey(a => a.ReiderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ride>()
                .HasOne(a => a.Payment)
                .WithOne(a => a.Ride)
                .HasForeignKey<Payment>(a => a.RideId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ride>()
                .HasOne(a => a.Rating)
                .WithOne(a => a.ride)
                .HasForeignKey<Rating>(a => a.RideId)
                .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
