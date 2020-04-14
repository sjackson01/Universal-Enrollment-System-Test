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
            // Test Connection 
            // MoodleConnection db = new MoodleConnection("localhost", "Test", "root", "tiger");
            // Console.WriteLine(db.OpenConnection());

            /*
            // Obtain URI from Config.json 
            DataSource uri = JsonConvert.DeserializeObject<DataSource>(File.ReadAllText("../../../Config.json"));
            // Obtain UserName from Config.json
            DataSource username = JsonConvert.DeserializeObject<DataSource>(File.ReadAllText("../../../Config.json"));
            // Obtain Password from Config.json
            DataSource password = JsonConvert.DeserializeObject<DataSource>(File.ReadAllText("../../../Config.json"));
            */

            // Connect to data source
            BoomiConnection connection = new BoomiConnection("http://boomidev01.lsu.edu/ws/rest/srr/courselist/", "moodle@lsuuis-2RZOV4", "134d5290-ee2a-47f1-ba4b-3ca283d42cbc");

            var rawData = connection.RetrieveCourses();

            Console.WriteLine(rawData.ToString());
            /*
            var rawJason = connection.Get();

            Console.WriteLine(rawJason);
            */
            /*
            // Convert Rest Api Json 
            string json = JsonLink.Get();
            
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
           */


        }
    }
}