using System;
using System.Collections.Generic;
using System.Net;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;


namespace UES
{
    class MoodleConnection
    {
        private MySqlConnection _connect;
        private string _server;
        private string _database;
        private string _uid;
        private string _password;
        public MySqlConnection Connect
        {
            get { return _connect; }
            set { _connect = value; }
        }
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        public string Database
        {
            get { return _database; }
            set { _database = value; }
        }
        public string Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public MoodleConnection(string server, string database, string uid, string password)
        {
            Server = server;
            Database = database;
            Uid = uid;
            Password = password;

            string connectionString;
            connectionString = "SERVER=" + Server + ";" + "DATABASE=" +
            Database + ";" + "UID=" + Uid + ";" + "PASSWORD=" + Password + ";";
            Connect = new MySqlConnection(connectionString);

        }

        public bool OpenConnection()
        {
            try
            {
                Connect.Open();
                Console.WriteLine("Connection Open");
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection failed: " + e);
                return false;
            }
        }
    }
}
 
