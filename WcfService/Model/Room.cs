using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.Model
{
    public class Room
    {
        public int id { get; set; }
        public int hotelid { get; set; }
        public double price { get; set; }
        public int roomnumber { get; set; }
        public string roomtype { get; set; }
        public bool IsBooked { get; set; }
        public string image { get; set; }
    }
}