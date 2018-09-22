using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserUiApi.Models
{
    public class BookDetails
    {
        public int hotelid { get; set; }
        public string hotelname { get; set; }
        public int roomnumber { get; set; }
        public double price { get; set; }
        public string roomtype { get; set; }
    }
}
