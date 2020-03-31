using System;
using System.Net;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UES
{
    class Program
    {
        static void Main(string[] args)
        {

            // JSON location 
            // Place in the xml config file 
            string apiUri = "https://jsonplaceholder.typicode.com/todos/1";

            // Send web service request
            // Original Code: HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUri);
            WebRequest request = WebRequest.Create(apiUri);

            // Get response
            // Originial Code: HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            WebResponse response = (WebResponse)request.GetResponse();

            // Create stream
            Stream responseStream = response.GetResponseStream();

            // Set up the stream reader
            // Talk to Jeff about encoding 
            StreamReader readerStream = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));

            // Transfer to a string 
            string json = readerStream.ReadToEnd();

            // Close the stream
            readerStream.Close();

            // Convert into JSON object 
            var jo = JObject.Parse(json);

            Console.WriteLine(json);

            Console.WriteLine("\n");

            Console.WriteLine("userId : " + jo["userId"]);
            Console.WriteLine("id : " + jo["id"]);
            Console.WriteLine("title : " + jo["title"]);
            Console.WriteLine("completed : " + jo["completed"]);


            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("User ID");
            dt.Columns.Add("ID");
            dt.Columns.Add("Title");
            dt.Columns.Add("Completed");

            DataRow _record = dt.NewRow();
            _record["User ID"] = jo["userId"];
            _record["ID"] = jo["id"];
            _record["Title"] = jo["title"];
            _record["Completed"] = jo["completed"];

            dt.Rows.Add(_record);

            Console.WriteLine("\n");

            foreach (DataRow row in dt.Rows)
            {
                string userID = _record["User ID"].ToString();
                Console.WriteLine(userID);
                string ID = _record["ID"].ToString();
                Console.WriteLine(ID);
                string title = _record["Title"].ToString();
                Console.WriteLine(title);
                string completed = _record["Completed"].ToString();
                Console.WriteLine(completed);

            }




        }
    }
}