using Cassandra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WcfService.Model;

namespace WcfService.DataAccess
{
    public class GetAllHotelsById
    {
        public List<Room> GetAll(string id)
        {
            try
            {
                List<Room> roomList = new List<Room>();
                Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
                ISession session = cluster.Connect("hotel");
                string query = "select * from room";
                RowSet dataReader = session.Execute(query);
                foreach (Row rowValue in dataReader)
                {
                    Room room = new Room();
                    int HotelId = Convert.ToInt32(rowValue[1]);
                    if(Convert.ToInt32(id)!=HotelId)
                    {
                        continue;
                    }
                    else
                    {
                        room.image= Convert.ToString(rowValue[2]);
                        room.id= Convert.ToInt32(rowValue[0]);
                        room.IsBooked = Convert.ToBoolean(rowValue[3]);
                        room.hotelid = Convert.ToInt32(rowValue[1]);
                        room.price = Convert.ToDouble(rowValue[4]);
                        room.roomnumber = Convert.ToInt32(rowValue[5]);
                        room.roomtype = Convert.ToString(rowValue[6]);
                        roomList.Add(room);
                    }
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


                return roomList;
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