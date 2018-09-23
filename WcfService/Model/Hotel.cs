using System;

namespace WcfService.Model
{
    public class Hotel
    {
        public string EmailAddress { get; set; }
        public string HotelAddress { get; set; }
        public string HotelName { get; set; }
        public bool IsBooked { get; set; }
        public int NumberOfRoomsAvailable { get; set; }
        public long PhoneNumber { get; set; }
        public double Rating { get; set; }
        public int hotelId { get; set; }
        public string[] Amenities { get; set; }

    }
    //public DateTime CheckInDateTime { get; set; }
    //public DateTime CheckOutDateTime { get; set; }
    ////DateTime.Now.ToString("MM/dd/yyyy hh:mm tt")
}