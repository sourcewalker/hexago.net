using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Configuration.Interfaces;
using Web.Site.Services.Interfaces;

namespace Web.Site.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IApiService _apiService;
        private readonly IConfigurationProvider _configurationProvider;

        public HomeController(
                IConfigurationProvider configurationProvider,
                IApiService apiService
            ) : base(configurationProvider)
        {
            _apiService = apiService;
            _configurationProvider = configurationProvider;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Enumerables = await _apiService.GetHomeModelAsync(Thread.CurrentThread.CurrentCulture.Name);
            ViewBag.CaptchaSiteKey = _configurationProvider.GetSharedEnvironmentConfigByCulture("Captcha:SiteKey",
                                            Thread.CurrentThread.CurrentCulture);
            ViewBag.PrivacyNoticeUrl = string.Format(
                _configurationProvider.GetSharedConfig("Legal:PrivacyNoticeLink"),
                _configurationProvider.GetSharedEnvironmentConfigByCulture("Mldz:SiteId",
                    Thread.CurrentThread.CurrentCulture));
            return View();
        }

        public ActionResult Holding()
        {
            ViewBag.CaptchaSiteKey = _configurationProvider.GetSharedEnvironmentConfigByCulture("Captcha:SiteKey",
                                            Thread.CurrentThread.CurrentCulture);
            ViewBag.PrivacyNoticeUrl = string.Format(
                _configurationProvider.GetSharedConfig("Legal:PrivacyNoticeLink"),
                _configurationProvider.GetSharedEnvironmentConfigByCulture("Mldz:SiteId",
                    Thread.CurrentThread.CurrentCulture));
            return View();
        }
    }
}