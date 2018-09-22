using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserUiApi.Models
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
}
