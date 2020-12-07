using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreDILearning.Configurations;
using AspNetCoreDILearning.Data;
using AspNetCoreDILearning.Domain.ApprovalRules;
using AspNetCoreDILearning.Services.Implementations;
using AspNetCoreDILearning.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AspNetCoreDILearning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.TryAddEnumerable(new []
            {
                ServiceDescriptor.Singleton<ICardApprovalRule, CreditScoreApprovalRule>(),
                ServiceDescriptor.Singleton<ICardApprovalRule, CityDwellerApprovalRule>(),
                ServiceDescriptor.Singleton<ICardApprovalRule, RecommendationApprovalRule>(),

            });

            //  Register the base service used for multiple interfaces
            services.AddSingleton<GuidAndIdProvider>();

            //  Use the container to dynamically provide the already registered singleton
            services.AddSingleton<IGuidProvider>(container => container.GetRequiredService<GuidAndIdProvider>());
            services.AddSingleton<IIntIdProvider>(container => container.GetRequiredService<GuidAndIdProvider>());

            services.AddScoped<DummyDataProvider>();

            //  Custom configuration serialization
            services.Configure<BaseRuleConfiguration>(Configuration.GetSection(BaseRuleConfiguration.BaseRule));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
