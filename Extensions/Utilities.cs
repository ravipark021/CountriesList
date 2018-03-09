using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CountriesList.Utils
{
    public static class Utilities
    {
        public static async Task<string> Get(string requestUrl)
        {
            //Create http Request
            HttpWebRequest httprequest = WebRequest.Create(requestUrl) as HttpWebRequest;
            //Add all headers.
            httprequest.ContentType = "";
            httprequest.Accept = "";
            httprequest.Headers[HttpRequestHeader.UserAgent] = "";

            httprequest.Method = "GET";
            //Get response
            HttpWebResponse response = await httprequest.GetResponseAsync() as HttpWebResponse;
            var encoding = ASCIIEncoding.ASCII;
            string responseText = string.Empty;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }
            return responseText;
        }
    }
}