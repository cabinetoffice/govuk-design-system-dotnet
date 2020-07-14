using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class FileUploadTests : SnapshotTestBase
    {
        private FileUploadViewModel DefaultFileUploadViewModel()
        {
            return new FileUploadViewModel
            {
                Id = "test-id",
                Name = "test-name",
                Attributes = new Dictionary<string, string> { { "attr-name", "attr-value" } },
                Classes = "cssClass",
                Value = new FormFile(new MemoryStream(new byte[0], 0, 0), 0, 0, "test formfile", "test file"),
                DescribedBy = "test-described-by",
                Label = new LabelViewModel { Text = "test-label" },
                Hint = new HintViewModel { Text = "test-hint" },
                ErrorMessage = new ErrorMessageViewModel { Text = "test-error" },
                FormGroup = new FormGroupViewModel { Classes = "form-group-classes" }
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("FileUpload", DefaultFileUploadViewModel());
        }

        [Fact]
        public async Task Render_NoLabel()
        {
            // Arrange
            var viewModel = DefaultFileUploadViewModel();
            viewModel.Label = null;

            // Act & Assert
            await VerifyPartial("FileUpload", viewModel);
        }

        [Fact]
        public async Task Render_NoHint()
        {
            // Arrange
            var viewModel = DefaultFileUploadViewModel();
            viewModel.Hint = null;

            // Act & Assert
            await VerifyPartial("FileUpload", viewModel);
        }

        [Fact]
        public async Task Render_NoError()
        {
            // Arrange
            var viewModel = DefaultFileUploadViewModel();
            viewModel.ErrorMessage = null;

            // Act & Assert
            await VerifyPartial("FileUpload", viewModel);
        }
    }
}
