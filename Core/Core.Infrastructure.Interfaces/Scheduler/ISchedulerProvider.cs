using Core.Shared.Configuration;
using Core.Infrastructure.Interfaces.Crm;
using System;
using System.Threading.Tasks;

namespace Core.Infrastructure.Interfaces.Scheduler
{
    public interface ISchedulerProvider
    {
        Task RetryParticipationSyncRecurrently(
            CrmData data,
            Configuration requestWideSettings,
            CronEnum occurence,
            bool requestConsumerId = false);

        Task<object> RetryParticipationSyncImmediately(
            CrmData data,
            Configuration requestWideSettings,
            bool requestConsumerId = false);

        Task DelayedParticipationRetrySync(
            CrmData data,
            Configuration requestWideSettings,
            TimeSpan delay,
            bool requestConsumerId = false);
    }
}
