using System;
using System.Net;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//this class instantiates a connection object using the json config file
//ouput: connection object
//on obj instantiation check no config file issues

namespace UES
    {
        class DataSource
        {
            private string _uri;
            private string _userName;
            private string _password;

            public string Uri
            {
                get { return _uri; }
                set { _uri = value; }
            }

            public string UserName
            {
                get { return _userName; }
                set { _userName = value; }
            }

            public string Password
            {
                get { return _password; }
                set { _password = value; }
            }

            // Obtain URI from Config.json 
            public string GetUri()
            {
                DataSource uri = JsonConvert.DeserializeObject<DataSource>(File.ReadAllText("../../../Config.json"));
                return uri.Uri;
            }

            // Obtain UserName from Config.json
            public string GetUserName()
            {
                DataSource username = JsonConvert.DeserializeObject<DataSource>(File.ReadAllText("../../../Config.json"));
                return username.UserName;
            }

            // Obtain Password from Config.json
            public string GetPassword()
            {
                DataSource password = JsonConvert.DeserializeObject<DataSource>(File.ReadAllText("../../../Config.json"));
                return password.Password;
            }
        }
    }




