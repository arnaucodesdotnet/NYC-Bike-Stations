using CityBikeNYC.BR;
using CityBikeNYC.Utilities;
using System.Configuration;
using Unity;
using Unity.Injection;

namespace CityBikeNYC
{
    public class ConfigureUnity
    {
        public static void Configure(IUnityContainer container)
        {
            string urlStations = ConfigurationManager.AppSettings["urlstationbeanlist"].ToString();

            container.RegisterType<IUtilities, Utilities.Utilities>();
            container.RegisterType<IAutoMapper, AutoMapper>();

            container.RegisterType<MainWindowViewModel>(
                new InjectionConstructor(
                    typeof(IStationBeanAdapter),
                    typeof(IAutoMapper)));

            container.RegisterType<IStationBeanAdapter, StationBeanAdapter>(
                new InjectionConstructor(
                    new InjectionParameter<string>(urlStations),
                    typeof(IAutoMapper),
                    typeof(IUtilities)));
        }
    }
}
