using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.Model
{
    public class BookDetails
    {
        public int roomId { get; set; }
        public int hotelid { get; set; }
        public string hotelname { get; set; }
        public string hoteladdress { get; set; }
        public int roomnumber { get; set; }
        public double price { get; set; }
        public string roomtype { get; set; }
    }
}