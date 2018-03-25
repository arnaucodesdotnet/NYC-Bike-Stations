using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBikeNYC.Data
{
    public class StationBeanQuery
    {
        public string executionTime { get; set; }
        public List<StationBean> stationBeanList { get; set; }
    }
}
