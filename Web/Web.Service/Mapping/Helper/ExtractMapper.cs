using Core.Shared.DTO;
using System.Collections.Generic;
using Web.Service.Models;

namespace Web.Service.Mapping.Helper
{
    public static class ExtractMapper
    {
        public static ExtractModel toExtractModel(this ParticipationDto vote)
            => AutoMapper.Mapper.Map<ParticipationDto, ExtractModel>(vote);

        public static IEnumerable<ExtractModel> toExtractModels(this IEnumerable<ParticipationDto> votes)
            => AutoMapper.Mapper.Map<IEnumerable<ParticipationDto>, IEnumerable<ExtractModel>>(votes);
    }
}