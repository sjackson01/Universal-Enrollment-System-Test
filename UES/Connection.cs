using System.Net;
using System.IO;


namespace UES
{
    class Connection
    {

        private string _dataSource;
        public string DataSource { 
            get { return _dataSource; }
            set { _dataSource = value; }
        }

        public Connection(string dataSource)
        { 
            DataSource = dataSource;
        }

        public string GetData(string dataSource) 
        {
            WebRequest request = WebRequest.Create(dataSource);
            WebResponse response = (WebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, System.Text.Encoding.GetEncoding("utf-8"));
            string json = reader.ReadToEnd();
            reader.Close();
            return json; 
        }
        
    }
}
