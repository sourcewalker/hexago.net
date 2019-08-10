using Core.Shared.DTO;
using Core.Model;
using System.Collections.Generic;

namespace Core.Shared.Mapping.Helper
{
    public static class SiteMapper
    {
        public static SiteDto toDto(this Site site)
            => AutoMapper.Mapper.Map<Site, SiteDto>(site);

        public static Site toEntity(this SiteDto siteDto)
            => AutoMapper.Mapper.Map<SiteDto, Site>(siteDto);

        public static IEnumerable<Site> toEntities(this IEnumerable<SiteDto> siteDtos)
            => AutoMapper.Mapper.Map<IEnumerable<SiteDto>, IEnumerable<Site>>(siteDtos);

        public static IEnumerable<SiteDto> toDtos(this IEnumerable<Site> sites)
            => AutoMapper.Mapper.Map<IEnumerable<Site>, IEnumerable<SiteDto>>(sites);
    }
}
