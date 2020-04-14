using RestSharp;
using RestSharp.Authenticators;
using System;

namespace UES
{
    class BoomiConnection
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


        public BoomiConnection(string uri, string userName, string password)
        {
            Uri = uri;
            UserName = userName;
            Password = password;

        }

        // Returns OK 200 Success 
        // Returns Not Found 404 Fail 
        public string RetrieveCourses()
        {
            var client = new RestClient(Uri);

            // Basic Auth used 
            client.Authenticator = new HttpBasicAuthenticator(UserName, Password);

            // Pass RestRequest ("Request" and "Data Format") = Request Parameter 
            var request = new RestRequest("courses.json?TermCode=20201S", DataFormat.Json);
            var response = client.Get(request);
            Console.WriteLine(response.StatusCode);

            //Returns raw content string
            return response.Content;

        }

    }
}
