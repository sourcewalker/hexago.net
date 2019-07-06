using AutoMapper;
using Core.Shared.Mapping;

namespace Admin.Service
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

            });
        }
    }
}