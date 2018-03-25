using AutoMapper;
using CityBikeNYC.Data;
using Newtonsoft.Json.Linq;

namespace CityBikeNYC.BR
{
    public class AutoMapper : IAutoMapper
    {
        private readonly Mapper engine;
        private readonly IRuntimeMapper mapper;

        public AutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                Configure(cfg);
            });
            engine = new Mapper(config);
            mapper = engine.DefaultContext.Mapper;
        }

        private void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<JObject, StationBeanQuery>()
                .ForMember(dest => dest.executionTime, opt => opt.MapFrom(src => src["executionTime"]))
                .ForMember(dest => dest.stationBeanList, opt => opt.MapFrom(src => src["stationBeanList"]));

            cfg.CreateMap<JObject, StationBean>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src["id"]))
                .ForMember(dest => dest.stationName, opt => opt.MapFrom(src => src["stationName"]))
                .ForMember(dest => dest.availableDocks, opt => opt.MapFrom(src => src["availableDocks"]))
                .ForMember(dest => dest.totalDocks, opt => opt.MapFrom(src => src["totalDocks"]))
                .ForMember(dest => dest.latitude, opt => opt.MapFrom(src => src["latitude"]))
                .ForMember(dest => dest.longitude, opt => opt.MapFrom(src => src["longitude"]))
                .ForMember(dest => dest.statusValue, opt => opt.MapFrom(src => src["statusValue"]))
                .ForMember(dest => dest.statusKey, opt => opt.MapFrom(src => src["statusKey"]))
                .ForMember(dest => dest.availableBikes, opt => opt.MapFrom(src => src["availableBikes"]))
                .ForMember(dest => dest.stAddress1, opt => opt.MapFrom(src => src["stAddress1"]))
                .ForMember(dest => dest.stAddress2, opt => opt.MapFrom(src => src["stAddress2"]))
                .ForMember(dest => dest.city, opt => opt.MapFrom(src => src["city"]))
                .ForMember(dest => dest.postalCode, opt => opt.MapFrom(src => src["postalCode"]))
                .ForMember(dest => dest.location, opt => opt.MapFrom(src => src["location"]))
                .ForMember(dest => dest.altitude, opt => opt.MapFrom(src => src["altitude"]))
                .ForMember(dest => dest.testStation, opt => opt.MapFrom(src => src["testStation"]))
                .ForMember(dest => dest.lastCommunicationTime, opt => opt.MapFrom(src => src["lastCommunicationTime"]))
                .ForMember(dest => dest.landMark, opt => opt.MapFrom(src => src["landMark"]));

            cfg.CreateMap<StationBasicInfo, StationBean>();

            cfg.CreateMap<StationExtendedInfo, StationBean>();
        }

        public T Map<T>(object source)
        {
            return mapper.Map<T>(source);
        }

        public T2 Map<T1, T2>(T1 source, T2 destination)
        {
            return mapper.Map(source, destination);
        }
    }
}
