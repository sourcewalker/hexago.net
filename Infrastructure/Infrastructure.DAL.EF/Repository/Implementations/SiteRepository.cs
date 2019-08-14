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
    public class SiteRepository : RepositoryBase<Site>, ISiteRepository
    {
        public IEnumerable<SiteDto> GetAll()
            => Table?.toDtos();

        public async Task<IEnumerable<SiteDto>> GetAllAsync()
            => await Task.Run(() => Table?.toDtos());

        public SiteDto GetById(Guid id)
            => Find(id)?.toDto();

        public async Task<SiteDto> GetByIdAsync(Guid id)
            => await Task.Run(() => Find(id)?.toDto());

        public IEnumerable<SiteDto> GetPaged(int pageNumber, int pageSize)
            => GetRange(pageSize * (pageNumber - 1), pageSize)?.toDtos();

        public async Task<IEnumerable<SiteDto>> GetPagedAsync(int pageNumber, int pageSize)
            => await Task.Run(() => GetRange(pageSize * (pageNumber - 1), pageSize)?.toDtos());

        public bool Add(SiteDto site)
        {
            site.Id = site.Id != default ? site.Id : Guid.NewGuid();
            site.CreatedDate = DateTimeOffset.UtcNow;
            return Add(site?.toEntity(), true) > 0;
        }

        public async Task<bool> AddAsync(SiteDto site)
        {
            site.Id = site.Id != default ? site.Id : Guid.NewGuid();
            site.CreatedDate = DateTimeOffset.UtcNow;
            return await Task.Run(() => Add(site?.toEntity(), true) > 0);
        }

        public bool Update(SiteDto site)
        {
            site.ModifiedDate = DateTimeOffset.UtcNow;
            return Update(site?.toEntity(), true) > 0;
        }

        public async Task<bool> UpdateAsync(SiteDto site)
        {
            site.ModifiedDate = DateTimeOffset.UtcNow;
            return await Task.Run(() => Update(site?.toEntity(), true) > 0);
        }

        public bool Delete(SiteDto site)
            => Delete(site?.toEntity(), true) > 0;

        public async Task<bool> DeleteAsync(SiteDto site)
            => await Task.Run(() => Delete(site?.toEntity(), true) > 0);

        public bool Delete(Guid id)
        {
            var site = GetById(id);
            return Delete(site?.toEntity(), true) > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
            => await Task.Run(() =>
            {
                var site = GetById(id);
                return Delete(site?.toEntity(), true) > 0;
            });

        public SiteDto GetByDomain(string domain)
        {
            return Context.SitesQueryable
                            .First(x => domain.Contains(x.Domain))
                            .toDto();
        }

        public async Task<SiteDto> GetByDomainAsync(string domain)
            => await Task.Run(() =>
            {
                return Context.SitesQueryable
                        .First(x => domain.Contains(x.Domain))
                        .toDto();
            });

        public SiteDto GetByCulture(string culture)
        {
            return Context.SitesQueryable
                            .First(x => x.Culture == culture)
                            .toDto();
        }
    }
}
