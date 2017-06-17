using System.Web.Http;
using System.Configuration;
using System.Net;
using System.IO;

namespace kFeed.Controllers
{
    public class FetchUsersController
    {
        [HttpGet]
        public string Get()
        {
            var url = $"{ConfigurationManager.AppSettings["BaseURI"]}/api/v1/users";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("auth", ConfigurationManager.AppSettings["APIToken"]);
            request.ContentType = "application/json";

            using(var response = (HttpWebResponse)request.GetResponse())
            {
				using (StreamReader sr = new StreamReader(response.GetResponseStream()))
				{
					string values = sr.ReadToEnd();
				}
            }
            return url;
        }
    }
}
