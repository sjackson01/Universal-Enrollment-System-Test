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
        public string Uri { get; set; }
        public string DAO { get; set; }

    }
}

