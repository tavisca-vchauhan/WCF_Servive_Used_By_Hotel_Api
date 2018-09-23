using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService.Model;

namespace WcfService.DataAccess
{
    public class BookRoomById
    {
        public void Update(string id)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotel");
            string query = "UPDATE room SET isbooked=true WHERE id="+id;
            session.Execute(query);
            query = "select hotelid from room where id = " + id;
            RowSet rowset = session.Execute(query);
            int hotelID=0;
            foreach (Row row in rowset)
            {
                hotelID = Convert.ToInt32(row[0].ToString());
            }
            query = "select NumberOfRoomsAvailable from hotel where id = " + hotelID;
            RowSet room = session.Execute(query);
            int NumberOfAvailableRooms=0;
            foreach (Row row in room)
            {
                NumberOfAvailableRooms = Convert.ToInt32(row[0].ToString());
            }
            NumberOfAvailableRooms--;
            query = "UPDATE hotel SET NumberOfRoomsAvailable= "+ NumberOfAvailableRooms + " WHERE id=" + hotelID;
            session.Execute(query);
        }
    }
}