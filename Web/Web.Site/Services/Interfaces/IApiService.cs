using System.Threading.Tasks;

namespace Web.Site.Services.Interfaces
{
    public interface IApiService
    {
        Task<string> GetPrivacyAsync();
    }
}