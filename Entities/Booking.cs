namespace API.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public BookingVerification BookingVerification = BookingVerification.PENDING;
    }

    public enum BookingVerification
    {
        PENDING, CONFIRMED
    }
}
