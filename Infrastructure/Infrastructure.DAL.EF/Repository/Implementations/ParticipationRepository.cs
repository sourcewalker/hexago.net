using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Shared.DTO;
using Core.Shared.Mapping.Helper;
using Core.Model;
using Infrastructure.DAL.EF.Repository.Base;
using Core.Infrastructure.Interfaces.DAL;

namespace Infrastructure.DAL.EF.Repository.Implementations
{
    public class ParticipationRepository : RepositoryBase<Participation>, IParticipationRepository
    {
        private readonly IParticipantRepository _participantRepository;

        public ParticipationRepository(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public IEnumerable<ParticipationDto> GetAll()
        {
            return Table?.toDtos();
        }

        public int GetCount()
        {
            return Count;
        }

        public int GetCountBySite(Guid siteId)
        {
            return Context.ParticipationsQueryable
                    .Where(v => v.SiteId == siteId)
                    .Count();
        }

        public async Task<IEnumerable<ParticipationDto>> GetAllAsync()
            => await Task.Run(() => Table?.toDtos());

        public ParticipationDto GetById(Guid id)
            => Find(id)?.toDto();

        public async Task<ParticipationDto> GetByIdAsync(Guid id)
            => await Task.Run(() => Find(id)?.toDto());

        public IEnumerable<ParticipationDto> GetPaged(int pageNumber, int pageSize)
            => GetRange(pageSize * (pageNumber - 1), pageSize)?.toDtos();

        public async Task<IEnumerable<ParticipationDto>> GetPagedAsync(int pageNumber, int pageSize)
            => await Task.Run(() => GetRange(pageSize * (pageNumber - 1), pageSize)?.toDtos());

        public bool Add(ParticipationDto participation)
        {
            participation.Id = participation.Id != default ? participation.Id : Guid.NewGuid();
            participation.CreatedDate = DateTime.UtcNow;
            return Add(participation?.toEntity(), true) > 0;
        }

        public async Task<bool> AddAsync(ParticipationDto participation)
        {
            participation.Id = participation.Id != default ? participation.Id : Guid.NewGuid();
            participation.CreatedDate = DateTime.UtcNow;
            return await Task.Run(() => Add(participation?.toEntity(), true) > 0);
        }

        public bool Update(ParticipationDto participation)
        {
            var participationEntity = Find(participation.Id);
            participationEntity.Status = participation.Status;
            participationEntity.ApiStatus = participation.ApiStatus;
            participationEntity.ApiMessage = participation.ApiMessage;
            participationEntity.ModifiedDate = DateTime.UtcNow;
            return Update(participationEntity, true) > 0;
        }

        public async Task<bool> UpdateAsync(ParticipationDto participation)
        {
            participation.ModifiedDate = DateTime.UtcNow;
            return await Task.Run(() => Update(participation?.toEntity(), true) > 0);
        }

        public bool Delete(ParticipationDto participation)
            => Delete(participation?.toEntity(), true) > 0;

        public async Task<bool> DeleteAsync(ParticipationDto participation)
            => await Task.Run(() => Delete(participation?.toEntity(), true) > 0);

        public bool Delete(Guid id)
        {
            var participation = GetById(id);
            return Delete(participation?.toEntity(), true) > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
            => await Task.Run(() =>
            {
                var participation = GetById(id);
                return Delete(participation?.toEntity(), true) > 0;
            });

        public IEnumerable<ParticipationDto> GetPagedBySite(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParticipationDto>> GetPagedBySiteAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParticipationDto> GetPagedBySite(Guid siteId, int pageNumber, int pageSize)
        {
            IQueryable<Participation> filtered = Context.ParticipationsQueryable.Where(x => x.SiteId == siteId);
            return GetRange(filtered, pageSize * (pageNumber - 1), pageSize).toDtos();
        }

        public async Task<IEnumerable<ParticipationDto>> GetPagedBySiteAsync(Guid siteId, int pageNumber, int pageSize)
        {
            return await Task.Run((Func<IEnumerable<ParticipationDto>>)(() =>
            {
                IQueryable<Participation> filtered = Context.ParticipationsQueryable.Where(x => x.SiteId == siteId);
                return ParticipationMapper.toDtos(GetRange((IQueryable<Participation>)filtered, 
                    (int)(pageSize * (pageNumber - 1)), (int)pageSize));
            }));
        }

        public IEnumerable<ParticipationDto> GetBySite(Guid siteId)
        {
            return Context.ParticipationsQueryable
                            .Where(x => x.SiteId == siteId)
                            .AsEnumerable<Participation>()
                            .toDtos();
        }

        public async Task<IEnumerable<ParticipationDto>> GetBySiteAsync(Guid siteId)
        {
            return await Task.Run((Func<IEnumerable<ParticipationDto>>)(() =>
            {
                return ParticipationMapper.toDtos(Context.ParticipationsQueryable
                            .Where((System.Linq.Expressions.Expression<Func<Participation, bool>>)(x => (bool)(x.SiteId == siteId)))
                            .AsEnumerable()
);
            }));
        }

        public ParticipationDto GetByEmailHash(string emailHash)
        {
            var participant = _participantRepository.GetByEmailHash(emailHash);
            var participation = Context.ParticipationsQueryable
                            .FirstOrDefault(x => x.Id == participant.ParticipationId);

            return participation?.toDto();
        }

        public IEnumerable<ParticipationDto> GetBetween(DateTime start, DateTime end)
        {
            return Context.ParticipationsQueryable
                        .Where(v => start < v.CreatedDate && v.CreatedDate < end)
                        .AsEnumerable()
                        .toDtos();
        }
    }
}
