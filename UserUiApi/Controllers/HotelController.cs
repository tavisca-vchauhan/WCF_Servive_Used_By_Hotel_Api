using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserUiApi.Attribute;
using UserUiApi.Models;

namespace UserUiApi.Controllers
{
    public class HotelController : Controller
    {
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                List<Hotel> hotels = new List<Hotel>();
                List<Hotel> hotelJasonData = new List<Hotel>();
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("http://localhost:61970/GetHotelDetails.svc/Hotels");
                if (response.IsSuccessStatusCode)
                {
                    hotels = await response.Content.ReadAsAsync<List<Hotel>>();
                }
                using (StreamReader r = new StreamReader("/Users/Vchauhan/source/repos/UserApi/HotelData.json"))
                {
                    string json = r.ReadToEnd();
                    hotelJasonData = JsonConvert.DeserializeObject<List<Hotel>>(json);
                }
                foreach (Hotel hotel in hotels)
                {
                    foreach (Hotel hoteldata in hotelJasonData)
                    {
                        if (hotel.hotelId != hoteldata.hotelId)
                        {
                            continue;
                        }
                        else
                        {
                            hotel.hotelId = hoteldata.hotelId;
                            hotel.HotelName = hoteldata.HotelName;
                            hotel.HotelAddress = hoteldata.HotelAddress;
                            hotel.EmailAddress = hoteldata.EmailAddress;
                            hotel.IsBooked = hoteldata.IsBooked;
                            hotel.Amenities = hoteldata.Amenities;
                        }
                    }
                }
                ViewBag.title = "Hotel Controller";
                return View(hotels);
            }
            catch (Exception e)
            {
                LogAttribute.response = "Failue";
                LogAttribute.exception = e.Message;
                throw new Exception(e.Message);
            }
        }
    }
}