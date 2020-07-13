using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class TextAreaTests : SnapshotTestBase
    {
        private TextAreaViewModel DefaultTextAreaViewModel()
        {
            return new TextAreaViewModel
            {
                Id = "test-id",
                Name = "test-name",
                Rows = 3,
                Value = "test value",
                DescribedBy = "test-described-by",
                Label = new LabelViewModel { Text = "test-label" },
                Hint = new HintViewModel { Text = "test-hint" },
                ErrorMessage = new ErrorMessageViewModel { Text = "test-error" },
                FormGroup = new FormGroupViewModel { Classes = "form-group-classes" },
                Autocomplete = "test autocomplete",
                Classes = "test-css-class",
                Attributes = new Dictionary<string, string> { { "attr-name", "attr-value" } }
            };
        }

        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("TextArea", DefaultTextAreaViewModel());
        }
    }
}
