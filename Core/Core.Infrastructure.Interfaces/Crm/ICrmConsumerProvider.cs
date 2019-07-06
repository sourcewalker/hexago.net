using Core.Shared.Configuration;
using System.Threading.Tasks;

namespace Core.Infrastructure.Interfaces.Crm
{
    public interface ICrmConsumerProvider
    {
        Configuration Configuration { get; set; }

        Task<CrmData> CreateParticipationAsync(
            CrmData data, 
            Configuration requestWideSettings, 
            bool requestConsumerId = false);

        Task<CrmData> ReadTextDocumentAsync();
    }
}
