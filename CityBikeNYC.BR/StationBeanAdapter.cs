using System;
using CityBikeNYC.Data;
using CityBikeNYC.Utilities;
using Newtonsoft.Json.Linq;

namespace CityBikeNYC.BR
{
    public class StationBeanAdapter : IStationBeanAdapter
    {
        private readonly string stationBeanURL;

        private readonly IAutoMapper mapper;
        private readonly IUtilities utilities;

        public StationBeanAdapter(string stationBeanURL, IAutoMapper mapper, IUtilities utilities)
        {
            this.stationBeanURL = stationBeanURL;
            this.mapper = mapper;
            this.utilities = utilities;
        }

        public StationBeanQuery GetStationBeanList()
        {
            return GetDataFromUrl<StationBeanQuery>(stationBeanURL);
        }

        private T GetDataFromUrl<T>(string url) where T : class
        {
            T resultData = null;

            try
            {
                JToken data = utilities.DownloadJsonFromURL(url);
                JObject parsedData = JObject.Parse(data.ToString());
                resultData = mapper.Map<T>(parsedData);
            }
            catch (Exception ex)
            {
                throw;
            }

            return resultData;
        }

    }
}
