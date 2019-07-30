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
using Hangfire;
using Infrastructure.Community;
using Infrastructure.Elmah;
using Infrastructure.Hangfire;
using Infrastructure.ProCampaign.Consumer;
using System.Reflection;
using Web.Configuration.Implementations;
using Web.Configuration.Interfaces;

namespace Web.Service
{
    public class InjectionConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = System.Web.Http.GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Web
            builder.RegisterType<ConfigurationProvider>()
                   .As<IConfigurationProvider>()
                   .InstancePerLifetimeScope();

            // Infrastructures
            builder.RegisterType<CommunityProvider>()
                   .As<IAccountProvider>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<ElmahProvider>()
                   .As<ILoggingProvider>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<HangfireProvider>()
                   .As<ISchedulerProvider>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<ConsumerProvider>()
                   .As<ICrmConsumerProvider>()
                   .InstancePerLifetimeScope();

            // DAL
            builder.RegisterType<FailedTransactionRepository>()
                   .As<IFailedTransactionRepository>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<SiteRepository>()
                   .As<ISiteRepository>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<ParticipationRepository>()
                   .As<IParticipationRepository>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<ParticipantRepository>()
                   .As<IParticipantRepository>()
                   .InstancePerLifetimeScope();

            // Services
            builder.RegisterType<ParticipationService>()
                   .As<IParticipationService>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<ParticipantService>()
                   .As<IParticipantService>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<FailedTransactionService>()
                   .As<IFailedTransactionService>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<SurveyService>()
                   .As<ISurveyService>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<SiteService>()
                   .As<ISiteService>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<JourneyService>()
                   .As<IJourneyService>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<ValidationService>()
                   .As<IValidationService>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<LegalService>()
                   .As<ILegalService>()
                   .InstancePerLifetimeScope();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            Hangfire.GlobalConfiguration.Configuration.UseAutofacActivator(container);
        }
    }
}