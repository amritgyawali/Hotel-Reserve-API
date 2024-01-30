using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }


        public Context(DbContextOptions<Context>options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Amrit",
                LastName = "Gyawali",
                Email = "amritgyawali9@gmail.com",
                Password = "123456789",
                CreatedOn = new DateTime(2024, 1, 1, 11, 11, 11),
                UserType = "OWNER"
            });

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 2,
                FirstName = "Ar",
                LastName = "Rehman",
                Email = "arrehman@gmail.com",
                Password = "123456789",
                CreatedOn = new DateTime(2024, 2, 2, 1, 1, 1),
                UserType = "USER"
            });

            modelBuilder.Entity<Hotel>().HasData(new Hotel()
            {
                Id = 1,
                Name = "The Ritz-Carlton",
                Description = "Experience opulence and luxury at The Ritz-Carlton. Located in prime city centers and resort destinations around the world.",
                UserId = 1,
                Image = File.ReadAllBytes("Images/h1.jpg"),
                ImageExtension = Path.GetExtension("Images/h1.jpg")
            });

            modelBuilder.Entity<Hotel>().HasData(new Hotel()
            {
                Id = 2,
                Name = "Four Seasons Hotel",
                Description = "Indulge in world-class service and accommodations at Four Seasons. Unforgettable experiences await you.",
                UserId = 1,
                Image = File.ReadAllBytes("Images/h2.jpg"),
                ImageExtension = Path.GetExtension("Images/h2.jpg")
            });



            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 1,
                HotelId = 1,
                Image = File.ReadAllBytes("Images/r1.jpg"),
                ImageExtension = Path.GetExtension("Images/r1.jpg"),
                Description = "Luxury Suite with Mountain View",
                RoomType = "Luxury Suite",
                RoomPrice = 2000.0f
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 2,
                HotelId = 1,
                Image = File.ReadAllBytes("Images/r2.jpg"),
                ImageExtension = Path.GetExtension("Images/r2.jpg"),
                Description = "Deluxe Room with City Skyline",
                RoomType = "Deluxe Room",
                RoomPrice = 1500.0f
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 3,
                HotelId = 2,
                Image = File.ReadAllBytes("Images/r3.jpg"),
                ImageExtension = Path.GetExtension("Images/r3.jpg"),
                Description = "Royal Suite with Panoramic Sea Views",
                RoomType = "Royal Suite",
                RoomPrice = 2500.0f
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 4,
                HotelId = 2,
                Image = File.ReadAllBytes("Images/r4.jpg"),
                ImageExtension = Path.GetExtension("Images/r4.jpg"),
                Description = "Executive Suite with Garden View",
                RoomType = "Executive Suite",
                RoomPrice = 2200.0f
            });

            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                Id = 1,
                RoomId = 1,
                UserId = 2,
                BookingFrom = DateTime.Now.AddDays(1),
                BookingTo = DateTime.Now.AddDays(5),
                HotelId = 1,
                ExpAmt = 5500f,
            });

            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                Id = 2,
                RoomId = 2,
                UserId = 2,
                BookingFrom = DateTime.Now.AddDays(3),
                BookingTo = DateTime.Now.AddDays(8),
                HotelId = 2,
                ExpAmt = 25900f
            });
        }
    }
}
