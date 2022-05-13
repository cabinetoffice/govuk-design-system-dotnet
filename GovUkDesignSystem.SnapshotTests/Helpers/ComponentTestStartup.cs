using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace GovUkDesignSystem.SnapshotTests.Helpers
{
    public class ComponentTestStartup : IStartup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<RazorViewEngineOptions>(o =>
            {
                o.ViewLocationFormats.Add("/GovUkDesignSystemComponents/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/GovUkDesignSystemComponents/SubComponents{0}" + RazorViewEngine.ViewExtension);
            });

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app)
        {
        }
    }
}