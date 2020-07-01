using AutoMapper;
using DBaseService.DTO;
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
                Mapper.CreateMap<ClientServiceDTO, ServiceModel>();
                Mapper.CreateMap<IList<ClientServiceDTO>, IList<ServiceModel>>();
                Mapper.CreateMap<ClientMetricDTO, MetricModel>();
                Mapper.CreateMap<List<ClientMetricDTO>, List<MetricModel>>();
                Mapper.CreateMap<ClientEndPointDTO, EndPointModel>();
                Mapper.CreateMap<IList<ClientEndPointDTO>, IList<EndPointModel>>();
            }
        }
    }
}