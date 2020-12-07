using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Configurations;
using AspNetCoreDILearning.Data;
using AspNetCoreDILearning.Domain.ApprovalRules;
using AspNetCoreDILearning.Services.Implementations;
using AspNetCoreDILearning.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AspNetCoreDILearning.Utils
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //  Custom configuration serialization
            services.Configure<BaseRuleConfiguration>(configuration.GetSection(BaseRuleConfiguration.BaseRule));
            return services;
        }

        public static IServiceCollection AddDummyDataProvider(this IServiceCollection services)
        {
            services.AddScoped<DummyDataProvider>();
            return services;
        }

        public static IServiceCollection AddGuidAndIdProviders(this IServiceCollection services)
        {
            //  Register the base service used for multiple interfaces
            services.AddSingleton<GuidAndIdProvider>();

            //  Use the container to dynamically provide the already registered singleton
            services.AddSingleton<IGuidProvider>(container => container.GetRequiredService<GuidAndIdProvider>());
            services.AddSingleton<IIntIdProvider>(container => container.GetRequiredService<GuidAndIdProvider>());

            return services;
        }

        public static IServiceCollection AddApiControllers(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }

        public static IServiceCollection AddBusinessRules(this IServiceCollection services)
        {
            services.TryAddEnumerable(new []
            {
                ServiceDescriptor.Singleton<ICardApprovalRule, CreditScoreApprovalRule>(),
                ServiceDescriptor.Singleton<ICardApprovalRule, CityDwellerApprovalRule>(),
                ServiceDescriptor.Singleton<ICardApprovalRule, RecommendationApprovalRule>(),

            });

            return services;
        }
    }
}
