using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserUiApi.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int hotelId { get; set; }
        public bool IsBooked { get; set; }
        public double Price { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string image { get; set; }
    }
}
