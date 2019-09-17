using Core.Shared.DTO;
using System.Collections.Generic;
using Web.Service.Models;

namespace Web.Service.Mapping.Helper
{
    public static class ExtractMapper
    {
        public static ExtractModel toExtractModel(this ParticipationDto participation)
            => AutoMapper.Mapper.Map<ParticipationDto, ExtractModel>(participation);

        public static IEnumerable<ExtractModel> toExtractModels(this IEnumerable<ParticipationDto> participations)
            => AutoMapper.Mapper.Map<IEnumerable<ParticipationDto>, IEnumerable<ExtractModel>>(participations);
    }
}