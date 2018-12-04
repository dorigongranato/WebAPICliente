using System;
using System.IO;
using System.Net;
using System.Text;

namespace WebAPI_Client.Util
{
    public class WebAPI
    {
        public static string URI = "http://localhost:5002/api/client/";
        public static string Token = "123";

        public static string RequestGET(string method, string param){

            var request = (HttpWebRequest)WebRequest.Create(URI + method + "/" + param);
            request.Headers.Add("Token", Token);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;

        }

        public static string RequestAll(string method, string jsonData, string id, EMethod action)
        {

            WebRequest request;

            if (EMethod.Delete == action)
            {
                request = (HttpWebRequest)WebRequest.Create(URI + method + "/" + id);
                request.Method = EMethod.Delete.ToString();
            }
            else if (EMethod.Post == action)
            {
                request = (HttpWebRequest)WebRequest.Create(URI + method);
                request.Method = EMethod.Post.ToString();
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(URI + method + "/" + id);
                request.Method = EMethod.Put.ToString();
            }

            var data = Encoding.ASCII.GetBytes(jsonData);
            request.Headers.Add("Token", Token);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;

        }

    }
}
