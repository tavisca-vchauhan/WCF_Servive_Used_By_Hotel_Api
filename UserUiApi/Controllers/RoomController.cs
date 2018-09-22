using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserUiApi.Attribute;
using UserUiApi.Models;

namespace UserUiApi.Controllers
{
    public class RoomController : Controller
    {
        [Log]
        public async Task<IActionResult> GetAllRoomsById(int Book)
        {
            try
            {
                string url = "http://localhost:61970/GetHotelDetails.svc/RoomsById/" + Book;
                List<Room> rooms = new List<Room>();
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    rooms = await response.Content.ReadAsAsync<List<Room>>();
                }
                return View(rooms);
            }
            catch (Exception e)
            {
                LogAttribute.response = "Failue";
                LogAttribute.exception = e.Message;
                throw new Exception(e.Message);
            }
        }

        [Log]
        public async Task<IActionResult> UpdateBookingStatus(int Book)
        {
            try
            {
                string url = "http://localhost:61970/GetHotelDetails.svc/Booking/" + Book;
                HttpClient httpClient = new HttpClient();
                var content = new StringContent(Convert.ToString(Book));
                HttpResponseMessage response = await httpClient.PutAsync(url, content);
                url = "http://localhost:61970/GetHotelDetails.svc/SaveBookingDetails/" + Book;
                content = new StringContent(Convert.ToString(Book));
                response = await httpClient.PutAsync(url, content);
                return View();
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