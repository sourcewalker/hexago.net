using Autofac;
using Autofac.Integration.WebApi;
using Core.DAL.EF.Repository.Implementations;
using Core.DAL.Interfaces;
using Core.Infrastructure.Interfaces.Account;
using Core.Infrastructure.Interfaces.Crm;
using Core.Infrastructure.Interfaces.Logging;
using Core.Infrastructure.Interfaces.Scheduler;
using Core.Service.Domain;
using Core.Service.Flow;
using Core.Service.Interfaces;
using Infrastructure.Community;
using Infrastructure.Elmah;
using Infrastructure.Hangfire;
using Infrastructure.ProCampaign.Consumer;
using System.Reflection;
using System.Web.Http;

namespace Admin.Service
{
    public class InjectionConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Services
            //builder.RegisterType<VotingService>()
            //       .As<IVotingService>()
            //       .InstancePerRequest();
            //builder.RegisterType<ValidationService>()
            //       .As<IValidationService>()
            //       .InstancePerRequest();
            //builder.RegisterType<SurveyService>()
            //       .As<ISurveyService>()
            //       .InstancePerRequest();
            //builder.RegisterType<SiteService>()
            //       .As<ISiteService>()
            //       .InstancePerRequest();
            //builder.RegisterType<RetailerService>()
            //       .As<IRetailerService>()
            //       .InstancePerRequest();
            //builder.RegisterType<ParticipationService>()
            //       .As<IParticipationService>()
            //       .InstancePerRequest();
            //builder.RegisterType<CountryService>()
            //       .As<ICountryService>()
            //       .InstancePerRequest();
            //builder.RegisterType<ChocolateBarService>()
            //       .As<IChocolateBarService>()
            //       .InstancePerRequest();

            // Infrastructures
            //builder.RegisterType<CommunityProvider>()
            //       .As<IAccountProvider>()
            //       .InstancePerRequest();
            //builder.RegisterType<ElmahProvider>()
            //       .As<ILoggingProvider>()
            //       .InstancePerRequest();
            //builder.RegisterType<HangfireProvider>()
            //       .As<ISchedulerProvider>()
            //       .InstancePerRequest();
            //builder.RegisterType<ConsumerProvider>()
            //       .As<ICrmConsumerProvider>()
            //       .InstancePerRequest();

            // DAL
            //builder.RegisterType<ChocolateBarRepository>()
            //       .As<IChocolateBarRepository>()
            //       .InstancePerRequest();
            //builder.RegisterType<CountryRepository>()
            //       .As<ICountryRepository>()
            //       .InstancePerRequest();
            //builder.RegisterType<FailedTransactionRepository>()
            //       .As<IFailedTransactionRepository>()
            //       .InstancePerRequest();
            //builder.RegisterType<RetailerRepository>()
            //       .As<IRetailerRepository>()
            //       .InstancePerRequest();
            //builder.RegisterType<SiteRepository>()
            //       .As<ISiteRepository>()
            //       .InstancePerRequest();
            //builder.RegisterType<VoteRepository>()
            //       .As<IVoteRepository>()
            //       .InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}