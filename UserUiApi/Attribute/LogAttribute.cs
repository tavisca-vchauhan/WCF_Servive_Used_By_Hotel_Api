using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Filters;
using Cassandra;

namespace UserUiApi.Attribute
{
    public class LogAttribute : ResultFilterAttribute, IActionFilter
    {
        public static string url = "";
        public static string request = "";
        public static string response = "";
        public static string status = "-";
        public static string exception = "-";
        private static Object _lock = typeof(LogAttribute);

        public void OnActionExecuted(ActionExecutedContext context)
        {

            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotel");
            var query = "SELECT * from log ";
            RowSet dataReader = session.Execute(query);
            int count = 0;
            foreach (Row r in dataReader)
            {
                count++;
            }
            count++;
            var ps = session.Prepare("INSERT INTO log (id,url,request, response, status, exception,time) values(?,?,?,?,?,?,toTimeStamp(toDate(now())))");
            var statement = ps.Bind(count, url, request, response, status, exception);
            session.Execute(statement);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            url = context.HttpContext.Request.Host.Value + "" + context.HttpContext.Request.Path.Value;
            request = context.ActionDescriptor.DisplayName;
            if (context.HttpContext.Response.Body.CanWrite)
            {
                response = "Success";
            }
            else
            {
                response = "Failure";
            }
            exception = "-";
        }
    }
}