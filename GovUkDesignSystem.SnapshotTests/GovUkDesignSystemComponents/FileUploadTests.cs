using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
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

        [Fact]
        public async Task Render_NoDescribedBy()
        {
            // Arrange
            var viewModel = DefaultFileUploadViewModel();
            viewModel.DescribedBy = null;
            viewModel.ErrorMessage = null;
            viewModel.Hint = null;

            // Act & Assert
            await VerifyPartial("FileUpload", viewModel);
        }
    }
}
