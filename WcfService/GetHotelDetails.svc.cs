using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfService.DataAccess;
using WcfService.Model;

namespace WcfService
{
    
    public class GetHotelDetails : IGetHotelDetails
    {
        GetAllHotels gah = new GetAllHotels();
        GetAllHotelsById gahbi = new GetAllHotelsById();
        BookRoomById brbi = new BookRoomById();
        PostBookingDetails pbd = new PostBookingDetails();
        List<Hotel> hotels = new List<Hotel>();
        List<Room> rooms = new List<Room>();
        public List<Room> GetAll(string id)
        {
            rooms = gahbi.GetAll(id).ToList();
            return rooms;
        }

        public List<Hotel>  HotelsList()
        {
            hotels = gah.GetAll().ToList();
            return hotels;
        }

        public void Post(string id)
        {
            pbd.Post(id);
        }

        public void Update(string id)
        {
            brbi.Update(id);
        }
    }
}
