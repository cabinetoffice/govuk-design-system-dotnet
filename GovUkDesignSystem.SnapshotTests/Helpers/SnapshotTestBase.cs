using System;
using System.IO;
using System.Threading.Tasks;
using ApprovalTests;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GovUkDesignSystem.SnapshotTests.Helpers
{
    public abstract class SnapshotTestBase
    {
        static SnapshotTestBase()
        {
            // Work around what appears to be a bug in ApprovalTests. They will fail if this directory doesn't exist
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "EmptyFiles"));
        }

        private readonly ComponentTestServerFixture _server;

        internal SnapshotTestBase()
        {
            _server = new ComponentTestServerFixture();
        }

        protected async Task VerifyPartial(string viewName, object viewModel)
        {
            var serviceProvider = _server.GetRequiredService<IServiceProvider>();
            var viewEngine = _server.GetRequiredService<IRazorViewEngine>();
            var tempDataProvider = _server.GetRequiredService<ITempDataProvider>();

            var viewRenderer = new ViewRenderer(viewEngine, tempDataProvider, serviceProvider);

            var result = await viewRenderer.Render(viewName, viewModel);

            Approvals.VerifyHtml(result);
        }
    }
}
