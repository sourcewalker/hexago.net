using Core.Shared.DTO;
using Core.Shared.Mapping.Helper;
using Core.DAL.EF.Repository.Base;
using Core.DAL.Interfaces;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DAL.EF.Repository.Implementations
{
    public class ParticipantRepository : RepositoryBase<Participant>, IParticipantRepository
    {
        private readonly ISiteRepository _siteRepository;
        private readonly IParticipationRepository _participationRepository;

        public ParticipantRepository(
            ISiteRepository siteRepository, 
            IParticipationRepository participationRepository)
        {
            _siteRepository = siteRepository;
            _participationRepository = participationRepository;
        }

        public IEnumerable<ParticipantDto> GetAll()
        {
            return Table?.toDtos();
        }

        public int GetCount()
        {
            return Count;
        }

        public int GetCountBySite(Guid siteId)
        {
            return Context.ParticipantsQueryable
                    .Join(Context.ParticipationsQueryable,
                          participant => participant.ParticipationId,
                          participation => participation.Id,
                          (participant, participation) => 
                            new {
                                Participant = participant,
                                Participation = participation
                            })
                    .Where(participationWithParticipant => 
                                participationWithParticipant.Participation.SiteId == siteId)
                    .Count();
        }

        public async Task<IEnumerable<ParticipantDto>> GetAllAsync()
            => await Task.Run(() => Table?.toDtos());

        public ParticipantDto GetById(Guid id)
            => Find(id)?.toDto();

        public async Task<ParticipantDto> GetByIdAsync(Guid id)
            => await Task.Run(() => Find(id)?.toDto());

        public IEnumerable<ParticipantDto> GetPaged(int pageNumber, int pageSize)
            => GetRange(pageSize * (pageNumber - 1), pageSize)?.toDtos();

        public async Task<IEnumerable<ParticipantDto>> GetPagedAsync(int pageNumber, int pageSize)
            => await Task.Run(() => GetRange(pageSize * (pageNumber - 1), pageSize)?.toDtos());

        public bool Add(ParticipantDto vote)
        {
            vote.Id = vote.Id != default ? vote.Id : Guid.NewGuid();
            vote.CreatedDate = DateTime.UtcNow;
            return Add(vote?.toEntity(), true) > 0;
        }

        public async Task<bool> AddAsync(ParticipantDto vote)
        {
            vote.Id = vote.Id != default ? vote.Id : Guid.NewGuid();
            vote.CreatedDate = DateTime.UtcNow;
            return await Task.Run(() => Add(vote?.toEntity(), true) > 0);
        }

        public bool Update(ParticipantDto vote)
        {
            var voteEntity = Find(vote.Id);
            voteEntity.EmailHash = vote.EmailHash;
            voteEntity.ConsumerId = vote.ConsumerId;
            voteEntity.ModifiedDate = DateTime.UtcNow;
            return Update(voteEntity, true) > 0;
        }

        public async Task<bool> UpdateAsync(ParticipantDto vote)
        {
            vote.ModifiedDate = DateTime.UtcNow;
            return await Task.Run(() => Update(vote?.toEntity(), true) > 0);
        }

        public bool Delete(ParticipantDto vote)
            => Delete(vote?.toEntity(), true) > 0;

        public async Task<bool> DeleteAsync(ParticipantDto vote)
            => await Task.Run(() => Delete(vote?.toEntity(), true) > 0);

        public bool Delete(Guid id)
        {
            var vote = GetById(id);
            return Delete(vote?.toEntity(), true) > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
            => await Task.Run(() =>
            {
                var vote = GetById(id);
                return Delete(vote?.toEntity(), true) > 0;
            });

        public IEnumerable<ParticipantDto> GetPagedBySite(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParticipantDto>> GetPagedBySiteAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParticipantDto> GetPagedBySite(Guid siteId, int pageNumber, int pageSize)
        {
            IQueryable<Participant> filtered = 
                Context.ParticipantsQueryable
                .Join(Context.ParticipationsQueryable,
                          participant => participant.ParticipationId,
                          participation => participation.Id,
                          (participant, participation) =>
                            new {
                                Participant = participant,
                                Participation = participation
                            })
                    .Where(participationWithParticipant =>
                                participationWithParticipant.Participation.SiteId == siteId)
                    .Select(participationWithParticipant => participationWithParticipant.Participant);
            return GetRange(filtered, pageSize * (pageNumber - 1), pageSize).toDtos();
        }

        public async Task<IEnumerable<ParticipantDto>> GetPagedBySiteAsync(Guid siteId, int pageNumber, int pageSize)
        {
            return await Task.Run(() =>
            {
                IQueryable<Participant> filtered =
                    Context.ParticipantsQueryable
                    .Join(Context.ParticipationsQueryable,
                              participant => participant.ParticipationId,
                              participation => participation.Id,
                              (participant, participation) =>
                                new {
                                    Participant = participant,
                                    Participation = participation
                                })
                        .Where(participationWithParticipant =>
                                    participationWithParticipant.Participation.SiteId == siteId)
                        .Select(participationWithParticipant => participationWithParticipant.Participant);
                return GetRange(filtered, pageSize * (pageNumber - 1), pageSize).toDtos();
            });
        }

        public IEnumerable<ParticipantDto> GetBySite(Guid siteId)
        {
            return Context.ParticipantsQueryable
                    .Join(Context.ParticipationsQueryable,
                              participant => participant.ParticipationId,
                              participation => participation.Id,
                              (participant, participation) =>
                                new {
                                    Participant = participant,
                                    Participation = participation
                                })
                        .Where(participationWithParticipant =>
                                    participationWithParticipant.Participation.SiteId == siteId)
                        .Select(participationWithParticipant => participationWithParticipant.Participant)
                        .AsEnumerable()
                        .toDtos();
        }

        public async Task<IEnumerable<ParticipantDto>> GetBySiteAsync(Guid siteId)
        {
            return await Task.Run(() =>
            {
                return Context.ParticipantsQueryable
                    .Join(Context.ParticipationsQueryable,
                              participant => participant.ParticipationId,
                              participation => participation.Id,
                              (participant, participation) =>
                                new {
                                    Participant = participant,
                                    Participation = participation
                                })
                        .Where(participationWithParticipant =>
                                    participationWithParticipant.Participation.SiteId == siteId)
                        .Select(participationWithParticipant => participationWithParticipant.Participant)
                        .AsEnumerable()
                        .toDtos();
            });
        }

        public ParticipantDto GetByEmailHash(string emailHash)
        {
            var vote = Context.ParticipantsQueryable
                            .FirstOrDefault(x => x.EmailHash == emailHash);

            return vote?.toDto();
        }

        public IEnumerable<ParticipantDto> GetBetween(DateTime start, DateTime end)
        {
            return Context.ParticipantsQueryable
                        .Where(v => start < v.CreatedDate && v.CreatedDate < end)
                        .AsEnumerable()
                        .toDtos();
        }
    }
}
