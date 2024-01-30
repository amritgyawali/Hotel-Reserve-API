using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public Context Context { get;}
        public EmailService EmailService { get; }
        public JwtService JwtService { get; }

        public ReservationController(Context context, EmailService emailService, JwtService jwtService)
        {
            Context = context;
            EmailService = emailService;
            JwtService = jwtService;
        }

        [HttpPost("Register")]
        public ActionResult Register(User user)
        {
            if(Context.Users.Any(u => u.Email.Equals(user.Email))) {
                return Ok("Same Email");
            }

            user.CreatedOn = DateTime.Now;
            
            Context.Users.Add(user);
            Context.SaveChanges();

            const string subject = "Account Created";
            var body = $"""
                   <html>
                    <body>
                        <h1>Hi, {user.FirstName} {user.LastName}</h1>

                        <h2>Your account has been created and enjoy Hotel Reservation System.</h2>
                        <h2>Thanks</h2>

                    </body>
                   </html>
                """;

            EmailService.SendEmail(user.Email, subject, body);

            return Ok("Account Registered! Please Check Your Email");
        }

        [HttpGet("Login")]
        public ActionResult Login(string email, string password, string accountType)
        {
            
            if(Context.Users.Any(u => u.Email.Equals(email) && u.Password.Equals(password) && u.UserType.Equals(accountType)))
            {
                var user = Context.Users.Single(user => user.Email.Equals(email) && user.Password.Equals(password) && user.UserType.Equals(accountType));

                return Ok(JwtService.GenerateToken(user));
            }

            return Ok("NO ACCOUNT");
        }

        [HttpGet("GetHotels")]
        public ActionResult GetHotels()
        {
            if (Context.Hotels.Any())
            {
                return Ok(Context.Hotels.ToList());
            }

            return NotFound();
        }
        

        [HttpGet("GetRooms")]
        public ActionResult GetRooms()
        {
            if (Context.Rooms.Any())
            {
               return Ok(Context.Rooms.ToList());
            }
            return NotFound();
        }

        [HttpPost("SetBookings")]
        public ActionResult SetBookings(Booking booking)
        {
            // Check for overlap
            var isOverlap = Context.Bookings.Any(b =>
                b.RoomId == booking.RoomId &&
                b.Id != booking.Id && 
                (
                    (b.BookingFrom.Year < booking.BookingTo.Year && b.BookingTo.Year > booking.BookingFrom.Year) ||
                    (b.BookingFrom.Year == booking.BookingTo.Year && b.BookingTo.Year == booking.BookingFrom.Year &&
                     b.BookingFrom.Month <= booking.BookingTo.Month && b.BookingTo.Month >= booking.BookingFrom.Month &&
                     b.BookingFrom.Day <= booking.BookingTo.Day && b.BookingTo.Day >= booking.BookingFrom.Day)
                ));

            if (isOverlap)
            {
                return Ok("Booked Not Available");
            }

            Context.Bookings.Add(booking);
            Context.SaveChanges();

            return Ok("Booking Done");
        }



        [HttpGet("GetBookings")]
        public ActionResult GetBookings()
        {
            if (Context.Bookings.Any())
            {
                return Ok(Context.Bookings.ToList());
            }
            return NotFound();
        }

        [HttpGet("GetSpecificBookings")]
        public ActionResult GetSpecificBookings(int userId) {

            var specificBookings = Context.Bookings
                .Where(booking => booking.UserId == userId)
                .ToList();

            if (specificBookings.Any())
            {
                return Ok(specificBookings);
            }

            return Ok("No Res");
        }
    }
}
