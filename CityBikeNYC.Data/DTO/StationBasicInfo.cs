using System.ComponentModel.DataAnnotations;

namespace CityBikeNYC.Data
{
    public class StationBasicInfo
    {
        [Display(Order = 0, ShortName = "Id")]
        public string id { get; set; }
        [Display(Order = 1, ShortName = "Estación")]
        public string stationName { get; set; }
        [Display(Order = 2, ShortName = "Estado")]
        public string statusValue { get; set; }
        [Display(Order = 3, ShortName = "Nº bicis")]
        public string availableBikes { get; set; }
    }
}
