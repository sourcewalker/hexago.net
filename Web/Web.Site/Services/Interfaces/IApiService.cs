using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Site.Services.Models;

namespace Web.Site.Services.Interfaces
{
    public interface IApiService
    {
        Task<string> GetPrivacyAsync();

        Task<DataModel> GetHomeModelAsync(string culture);
    }
}