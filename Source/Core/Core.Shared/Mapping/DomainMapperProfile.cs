using AutoMapper;
using Core.Shared.DTO;
using Core.Model;

namespace Core.Shared.Mapping
{
    public class DomainMapperProfile : Profile
    {
        public DomainMapperProfile()
        {
            CreateMap<Site, SiteDto>();
            CreateMap<SiteDto, Site>();

            CreateMap<Participation, ParticipationDto>();
            CreateMap<ParticipationDto, Participation>();

            CreateMap<Participant, ParticipantDto>();
            CreateMap<ParticipantDto, Participant>();

            CreateMap<FailedTransaction, FailedTransactionDto>();
            CreateMap<FailedTransactionDto, FailedTransaction>();
        }
    }
}
