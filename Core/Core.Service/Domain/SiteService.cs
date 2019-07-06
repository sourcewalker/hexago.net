using Core.Shared.DTO;
using Core.DAL.Interfaces;
using Core.Infrastructure.Interfaces.Crm;
using Core.Infrastructure.Interfaces.Logging;
using Core.Infrastructure.Interfaces.Scheduler;
using Core.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.Service.Domain
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;
        private readonly ILoggingProvider _logger;
        private readonly ICrmConsumerProvider _crmProvider;
        private readonly ISchedulerProvider _scheduler;

        public SiteService
        (
            ISiteRepository siteRepository,
            ILoggingProvider logger,
            ICrmConsumerProvider crmProvider,
            ISchedulerProvider scheduler
        )
        {
            _siteRepository = siteRepository;
            _logger = logger;
            _crmProvider = crmProvider;
            _scheduler = scheduler;
        }

        public bool CreateSite(SiteDto site)
        {
            return _siteRepository.Add(site);
        }

        public bool DeleteSite(Guid id)
        {
            return _siteRepository.Delete(id);
        }

        public SiteDto GetSite(Guid id)
        {
            return _siteRepository.GetById(id);
        }

        public SiteDto GetSiteByCulture(string culture)
        {
            return _siteRepository.GetByCulture(culture);
        }

        public SiteDto GetSiteByDomain(string domain)
        {
            return _siteRepository.GetByDomain(domain);
        }

        public IEnumerable<SiteDto> GetSitesPaged(int pageNumber, int pageSize)
        {
            return _siteRepository.GetPaged(pageNumber, pageSize);
        }

        public bool UpdateSite(SiteDto site)
        {
            return _siteRepository.Update(site);
        }
    }
}
