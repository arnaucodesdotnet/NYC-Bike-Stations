using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBikeNYC.Utilities
{
    public interface IUtilities
    {
        JToken DownloadJsonFromURL(string url);
    }
}
