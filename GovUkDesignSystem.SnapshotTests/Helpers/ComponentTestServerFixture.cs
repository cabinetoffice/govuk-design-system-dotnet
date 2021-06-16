using GovUkDesignSystem.GovUkDesignSystemComponents;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace GovUkDesignSystem.SnapshotTests.Helpers
{
    public class ComponentTestServerFixture : WebApplicationFactory<ComponentTestStartup>
    {
        public TService GetRequiredService<TService>()
        {
            if (Server == null)
            {
                CreateDefaultClient();
            }

            return Server.Host.Services.GetRequiredService<TService>();
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            var hostBuilder = new WebHostBuilder();
            hostBuilder.ConfigureAppConfiguration((context, b) =>
            {
                //TODO use something more general?
                context.HostingEnvironment.ApplicationName = typeof(TextInputViewModel).Assembly.GetName().Name;
            });
            return hostBuilder.UseStartup<ComponentTestStartup>();
        }
    }
}