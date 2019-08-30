using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using Web.Service.Filters;

[assembly: OwinStartup(typeof(Web.Service.Startup))]

namespace Web.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfireAspNet(GetHangfireServers);
            app.UseHangfireDashboard(
                ConfigurationManager.AppSettings["Scheduler:Dashboard:Path"], 
                new DashboardOptions
                {
                    Authorization = new[] { new SchedulerAuthorizationFilter() },
                    AppPath = VirtualPathUtility.ToAbsolute("~")
                });
        }

        private IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("LocalHangfire", new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        UsePageLocksOnDequeue = true,
                        DisableGlobalLocks = true
                    });

            yield return new BackgroundJobServer();
        }
    }
}
