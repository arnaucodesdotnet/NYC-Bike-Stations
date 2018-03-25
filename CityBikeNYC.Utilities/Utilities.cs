using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace CityBikeNYC.Utilities
{
    public class Utilities : IUtilities
    {
        public Utilities()
        {

        }

        public JToken DownloadJsonFromURL(string url)
        {
            try
            {
                using (WebClient n = new WebClient())
                {
                    string dataString = n.DownloadString(url);
                    return JToken.Parse(dataString);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
