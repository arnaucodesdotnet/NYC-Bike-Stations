using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBikeNYC.BR
{
    public interface IAutoMapper
    {
        T Map<T>(object source);
        T2 Map<T1, T2>(T1 source, T2 destination);
    }
}
