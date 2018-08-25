using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App4.Models;

namespace App4.Services
{
    public class WebServices
    {
        public HttpResponse Get(string Url)
        {
            var request = WebRequest.Create(Url);
            request.ContentType = "application/json";
            request.Method = "GET";
            using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
            {
                return BuildResponse(httpResponse);
            }
        }
        public HttpResponse POST(string Url,string dataString)
        {
            /*
            try
            {
            */
                Byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);
                var request = WebRequest.Create(Url);
                request.ContentType = "application/json";
                request.Method = "POST";
                request.ContentLength = dataBytes.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(dataBytes, 0, dataBytes.Length);
                dataStream.Close();
                using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
                {
                    return BuildResponse(httpResponse);
                }
            /*
            }
            catch (WebException ex)
            {
                Android.Util.Log.Error("http error", ex.Message);
                HttpWebResponse httpResponse = false;
                return BuildResponse(httpResponse);
            }
            */
        }
        private static HttpResponse BuildResponse(HttpWebResponse httpResponse)
        {
            using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var content = reader.ReadToEnd();
                var response = new HttpResponse();
                response.Content = content;
                response.HttpStatusCode = httpResponse.StatusCode;
                return response;
            }
        }

        public async Task<HttpResponse> GetAsync(string Url)
        {
            var request = WebRequest.Create(Url);
            request.ContentType = "application/json";
            request.Method = "GET";
            using (HttpWebResponse httpResponse = await request.GetResponseAsync() as HttpWebResponse)
            {
                return BuildResponse(httpResponse);
            }
        }
    }
}