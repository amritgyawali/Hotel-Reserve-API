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
                FirstName = "Hari",
                LastName = "Sharma",
                Email = "harisharma@gmail.com",
                Password = "123456789",
                CreatedOn = new DateTime(2024, 1, 1, 11, 11, 11),
                UserType = "OWNER"
            });

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 2,
                FirstName = "amrit",
                LastName = "gyawali",
                Email = "amritgyawali@gmail.com",
                Password = "223456789",
                CreatedOn = new DateTime(2024, 2, 2, 1, 1, 1),
                UserType = "USER"
            });

            modelBuilder.Entity<Hotel>().HasData(new Hotel()
            {
                Id = 1,
                Name = "Hyatt hotel",
                Description = "Beautiful Hotel",
                Visibility = true,
                UserId = 1,
                Image = File.ReadAllBytes("Images/h1.jpg"),
                ImageExtension = Path.GetExtension("Images/h1.jpg")
            });

            modelBuilder.Entity<Hotel>().HasData(new Hotel()
            {
                Id = 2,
                Name = "Annapurna Resort",
                Description = "Cold Hotel",
                Visibility = true,
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
                RoomType = "Luxury",
                RoomPrice = 2000.0f
            });

            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 2,
                HotelId = 2,
                Image = File.ReadAllBytes("Images/r2.jpg"),
                ImageExtension= Path.GetExtension("Images/r2.jpg"),
                Description = "Standard Room with City View",
                RoomType = "Standard",
                RoomPrice = 1080.0f
            });

            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                Id = 1,
                RoomId = 1,
                UserId = 1,
                BookingFrom = DateTime.Now.AddDays(1),
                BookingTo = DateTime.Now.AddDays(5),
                BookingVerification = BookingVerification.PENDING
            });

            modelBuilder.Entity<Booking>().HasData(new Booking
            {
                Id = 2,
                RoomId = 2,
                UserId = 1,
                BookingFrom = DateTime.Now.AddDays(3),
                BookingTo = DateTime.Now.AddDays(8),
                BookingVerification = BookingVerification.CONFIRMED
            });
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<BookingVerification>().HaveConversion<string>();
        }
    }
}
