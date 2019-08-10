using Core.Shared.DTO;
using Core.Model;
using System.Collections.Generic;

namespace Core.Shared.Mapping.Helper
{
    public static class ParticipationMapper
    {
        public static ParticipationDto toDto(this Participation participation)
            => AutoMapper.Mapper.Map<Participation, ParticipationDto>(participation);

        public static Participation toEntity(this ParticipationDto participationDto)
            => AutoMapper.Mapper.Map<ParticipationDto, Participation>(participationDto);

        public static IEnumerable<Participation> toEntities(this IEnumerable<ParticipationDto> participationDtos)
            => AutoMapper.Mapper.Map<IEnumerable<ParticipationDto>, IEnumerable<Participation>>(participationDtos);

        public static IEnumerable<ParticipationDto> toDtos(this IEnumerable<Participation> participations)
            => AutoMapper.Mapper.Map<IEnumerable<Participation>, IEnumerable<ParticipationDto>>(participations);
    }
}
