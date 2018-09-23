using Cassandra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using WcfService.Model;

namespace WcfService.DataAccess
{
    public class PostBookingDetails
    {

        public void Post(string id)
        {
            BookDetails bookDetails = new BookDetails();
            List<Hotel> hotelJasonData = new List<Hotel>();
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotel");
            string query = "select * from room where id= "+id;
            RowSet rowset =session.Execute(query);
            foreach(Row row in rowset)
            {
                bookDetails.roomId = Convert.ToInt32(row[0]);
                bookDetails.hotelid = Convert.ToInt32(row[1]);
                bookDetails.price = Convert.ToDouble(row[4]);
                bookDetails.roomnumber = Convert.ToInt32(row[5]);
                bookDetails.roomtype = Convert.ToString(row[6]);
            }
            using (StreamReader r = new StreamReader("/Users/Vchauhan/source/repos/UserApi/HotelData.json"))
            {
                string json = r.ReadToEnd();
                hotelJasonData = JsonConvert.DeserializeObject<List<Hotel>>(json);
            }
            foreach (Hotel hoteldata in hotelJasonData)
            {
                if(hoteldata.hotelId!=bookDetails.hotelid)
                {
                    continue;
                }
                else
                {
                    bookDetails.hotelname = hoteldata.HotelName;
                    bookDetails.hoteladdress = hoteldata.HotelAddress;
                }
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=TAVDESK013\SQLEXPRESS;Initial Catalog=hotel;User ID= sa; Password=test123!@#";
            con.Open();
            query = "INSERT INTO bookdetail(roomid,hotelid ,hotelname,hoteladdress,roomnumber, price, roomtype) VALUES (" + bookDetails.roomId + "," + bookDetails.hotelid + ",'" + bookDetails.hotelname + "','" + bookDetails.hoteladdress + "'," + bookDetails.roomnumber + "," + bookDetails.price + ",'" + bookDetails.roomtype + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
}