using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.Model;

namespace WcfService
{

    [ServiceContract]
    public interface IGetHotelDetails
    {
        [OperationContract]
        [WebGet(
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/Hotels")]
        List<Hotel> HotelsList();

        [OperationContract]
        [WebGet(
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/RoomsById/{id}")]
        List<Room> GetAll(string id);

        [OperationContract]
        [WebInvoke(
            Method ="PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/Booking/{id}")]
        void Update(string id);

        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/SaveBookingDetails/{id}")]
        void Post(string id);
    }
}
