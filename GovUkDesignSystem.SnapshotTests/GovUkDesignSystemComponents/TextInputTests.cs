using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class TextInputTests : SnapshotTestBase
    {
        private TextInputViewModel DefaultTextInputViewModel()
        {
            return new TextInputViewModel
            {
                Id = "test-id",
                Name = "test-name",
                Value = "test value",
                Type = "text",
                InputMode = "test-input-mode",
                DescribedBy = "test-described-by",
                Label = new LabelViewModel { Text = "test-label" },
                Hint = new HintViewModel { Text = "test-hint" },
                ErrorMessage = new ErrorMessageViewModel { Text = "test-error" },
                FormGroup = new FormGroupViewModel { Classes = "form-group-classes" },
                Autocomplete = "test autocomplete",
                Classes = "test-css-class",
                Pattern = "test-pattern",
                Spellcheck = true,
                Attributes = new Dictionary<string, string> { { "attr-name", "attr-value" } },
                TextInputAppendix = new TextInputAppendixViewModel { Text = "text-appendix" }
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("TextInput", DefaultTextInputViewModel());
        }

        [Fact]
        public async Task Render_NoLabel()
        {
            // Arrange
            var viewModel = DefaultTextInputViewModel();
            viewModel.Label = null;

            // Act & Assert
            await VerifyPartial("TextInput", viewModel);
        }

        [Fact]
        public async Task Render_NoHint()
        {
            // Arrange
            var viewModel = DefaultTextInputViewModel();
            viewModel.Hint = null;

            // Act & Assert
            await VerifyPartial("TextInput", viewModel);
        }

        [Fact]
        public async Task Render_NoError()
        {
            // Arrange
            var viewModel = DefaultTextInputViewModel();
            viewModel.ErrorMessage = null;

            // Act & Assert
            await VerifyPartial("TextInput", viewModel);
        }

        [Fact]
        public async Task Render_NoFormGroup()
        {
            // Arrange
            var viewModel = DefaultTextInputViewModel();
            viewModel.FormGroup = null;

            // Act & Assert
            await VerifyPartial("TextInput", viewModel);
        }

        [Fact]
        public async Task Render_NoAppendix()
        {
            // Arrange
            var viewModel = DefaultTextInputViewModel();
            viewModel.TextInputAppendix = null;

            // Act & Assert
            await VerifyPartial("TextInput", viewModel);
        }

        [Fact]
        public async Task Render_NoDescribedBy()
        {
            // Arrange
            var viewModel = DefaultTextInputViewModel();
            viewModel.DescribedBy = null;
            viewModel.Hint = null;
            viewModel.ErrorMessage = null;

            // Act & Assert
            await VerifyPartial("TextInput", viewModel);
        }
    }
}
