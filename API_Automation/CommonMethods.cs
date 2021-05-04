using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Automation
{
    public class CommonMethods
    {

        public static RestClient Client;
        public static IRestRequest Request;
        public static IRestResponse Response;

        public static void SetBaseUri()
        {
            Client = new RestClient(ConfigRead("BaseURL"));
          
        }

        public static IRestResponse GetResponseOfResource(string apiResource)
        {
            Request = new RestRequest();
            Request.Resource = apiResource;
            return GetResponse();
        }

        private static IRestResponse GetResponse()
        {
            Response = Client.Execute(Request);
            return Response;
        }

        public static string ConfigRead(string key)
        {
            return Convert.ToString(ConfigurationManager.AppSettings[key]);
        }

        public static IRestResponse PostResponseOfResource(string apiResource,string filepath)
        {
            Request = new RestRequest();
           
            Request.Resource = apiResource;
            var data = File.ReadAllText(filepath);
            Request.AddParameter("application/json", ParameterType.RequestBody);
            Request.AddJsonBody(data);
            Response = Client.Execute(Request,Method.POST);
            return Response;
        }

    }
}
