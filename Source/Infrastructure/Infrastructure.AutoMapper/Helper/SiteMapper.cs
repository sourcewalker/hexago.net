using Core.Shared.DTO;
using Core.Model;
using System.Collections.Generic;
using AutoMapper;

namespace Infrastructure.Helper
{
    public static class SiteMapper
    {
        public static SiteDto toDto(this Site site)
            => Mapper.Map<Site, SiteDto>(site);

        public static Site toEntity(this SiteDto siteDto)
            => Mapper.Map<SiteDto, Site>(siteDto);

        public static IEnumerable<Site> toEntities(this IEnumerable<SiteDto> siteDtos)
            => Mapper.Map<IEnumerable<SiteDto>, IEnumerable<Site>>(siteDtos);

        public static IEnumerable<SiteDto> toDtos(this IEnumerable<Site> sites)
            => Mapper.Map<IEnumerable<Site>, IEnumerable<SiteDto>>(sites);
    }
}
