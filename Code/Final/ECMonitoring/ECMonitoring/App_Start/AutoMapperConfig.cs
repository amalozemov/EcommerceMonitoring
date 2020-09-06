using AutoMapper;
using ECMonitoring.Models;
using System.Collections.Generic;

namespace ECMonitoring
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new UnifiedStateRegisterProfile());
            });
        }

        private class UnifiedStateRegisterProfile : Profile
        {
            protected override void Configure()
            {
                Mapper.CreateMap<Data.Service, ServiceModel>();
                Mapper.CreateMap<IList<Data.Service>, IList<ServiceModel>>();
                Mapper.CreateMap<Data.EndPoint, EndPointModel>();
                Mapper.CreateMap<IList<Data.EndPoint>, IList<EndPointModel>>();
            }
        }
    }
}