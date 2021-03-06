﻿using System;
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
            MoodleConnection db = new MoodleConnection("localhost", "Test", "root", "tiger");
            Console.WriteLine(db.OpenConnection());

            // Obtain URI from Config.json 
            DataSource dataSource = JsonConvert.DeserializeObject<DataSource>(File.ReadAllText("../../../Config.json"));

            // Connect to data source
            GetData JsonLink = new GetData(dataSource.Uri);
            string json = JsonLink.Get(JsonLink.DataSource);
            
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