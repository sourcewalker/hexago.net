using Core.Shared.DTO;
using Core.Model;
using System.Collections.Generic;
using AutoMapper;

namespace Infrastructure.Helper
{
    public static class ParticipantMapper
    {
        public static ParticipantDto toDto(this Participant participant)
            => Mapper.Map<Participant, ParticipantDto>(participant);

        public static Participant toEntity(this ParticipantDto participantDto)
            => Mapper.Map<ParticipantDto, Participant>(participantDto);

        public static IEnumerable<Participant> toEntities(this IEnumerable<ParticipantDto> participantDtos)
            => Mapper.Map<IEnumerable<ParticipantDto>, IEnumerable<Participant>>(participantDtos);

        public static IEnumerable<ParticipantDto> toDtos(this IEnumerable<Participant> participants)
            => Mapper.Map<IEnumerable<Participant>, IEnumerable<ParticipantDto>>(participants);
    }
}
