using AutoMapper;
using Infrastructure.AutoMapper.Profiles;
using Web.Service.Mapping;

namespace Web.Service
{
    public class MappingConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                // Mapping on BLL
                config.AddProfile<DomainMapperProfile>();
                config.AddProfile(new DomainMapperProfile());

                // Mapping on Presentation
                config.AddProfile<ViewMapperProfile>();
                config.AddProfile(new ViewMapperProfile());

            });
        }
    }
}