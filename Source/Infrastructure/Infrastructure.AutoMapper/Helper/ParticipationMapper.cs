using Core.Shared.DTO;
using Core.Model;
using System.Collections.Generic;
using AutoMapper;

namespace Infrastructure.Helper
{
    public static class ParticipationMapper
    {
        public static ParticipationDto toDto(this Participation participation)
            => Mapper.Map<Participation, ParticipationDto>(participation);

        public static Participation toEntity(this ParticipationDto participationDto)
            => Mapper.Map<ParticipationDto, Participation>(participationDto);

        public static IEnumerable<Participation> toEntities(this IEnumerable<ParticipationDto> participationDtos)
            => Mapper.Map<IEnumerable<ParticipationDto>, IEnumerable<Participation>>(participationDtos);

        public static IEnumerable<ParticipationDto> toDtos(this IEnumerable<Participation> participations)
            => Mapper.Map<IEnumerable<Participation>, IEnumerable<ParticipationDto>>(participations);
    }
}
