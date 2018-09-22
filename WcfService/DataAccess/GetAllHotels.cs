using Cassandra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WcfService.Model;

namespace WcfService.DataAccess
{
    public class GetAllHotels
    {
        public List<Hotel> GetAll()
        {
            try
            {
                List<Hotel> hotelList = new List<Hotel>();
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect("hotel");
                string query = "select * from hotel";
                RowSet dataReader = session.Execute(query);
                foreach (Row rowValue in dataReader)
                {
                    Hotel hotel = new Hotel();
                    hotel.hotelId= Convert.ToInt32(rowValue[0]);
                    hotel.NumberOfRoomsAvailable = Convert.ToInt32(rowValue[1]);
                    hotel.PhoneNumber = Convert.ToInt64(rowValue[2]);
                    hotel.Rating = Convert.ToDouble(rowValue[3]);
                    hotelList.Add(hotel);
                }


                //SqlConnection con = new SqlConnection();
                //con.ConnectionString = @"Data Source=TAVDESK013\SQLEXPRESS;Initial Catalog=game;User ID= sa; Password=test123!@#";
                //con.Open();
                //string query = "select * from game";
                //SqlCommand cmd = new SqlCommand(query, con);
                //SqlDataReader dataReader = cmd.ExecuteReader();
                //if (dataReader.HasRows)
                //{
                //    while (dataReader.Read())
                //    {
                //        User user = new User();
                //        user.Name = Convert.ToString(dataReader[1]);
                //        user.UserName = Convert.ToString(dataReader[2]);
                //        user.Token = Convert.ToString(dataReader[3]);
                //        userList.Add(user);
                //    }
                //}
                //con.Close();


                return hotelList;
            }
            catch (Exception e)
            {
                //LogAttribute.response = "Failue";
                //LogAttribute.exception = e.Message;
                throw new Exception(e.Message);
            }
        }
    }
}
