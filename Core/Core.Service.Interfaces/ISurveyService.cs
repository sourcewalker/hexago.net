using Core.Shared.DTO;
using System;
using System.Collections.Generic;

namespace Core.Service.Interfaces
{
    public interface ISurveyService
    {
        IEnumerable<ParticipationDto> ExtractParticipation(DateTime start, DateTime end);

        int GetParticipationNumberBySite(Guid siteId);
    }
}
