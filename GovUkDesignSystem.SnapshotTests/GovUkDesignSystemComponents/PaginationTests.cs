using System.Collections.Generic;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests.GovUkDesignSystemComponents
{
    public class PaginationTests : SnapshotTestBase
    {
        private PaginationViewModel DefaultPaginationViewModel()
        {
            return new PaginationViewModel
            {
                Previous = new PaginationLinkViewModel
                {
                    Text = "Prev text",
                    LabelText = "Prev label text",
                    Href = "#"
                }, 
                Next = new PaginationLinkViewModel 
                { 
                    Text = "Next text",
                    LabelText = "Next label text",
                    Href = "#"
                },
                Classes = "pagination-class",
                LandmarkLabel = "landmarkLabel",
                Items = new List<PaginationItemViewModel>
                {
                    new PaginationItemViewModel
                    {
                        Number = "1",
                        VisuallyHiddenText = "1",
                        Href = "#",
                    },
                    new PaginationItemViewModel
                    {
                        Ellipsis = true
                    },
                    new PaginationItemViewModel
                    {
                        Number = "3",
                        VisuallyHiddenText = "3",
                        Href = "#",
                        Current = true
                    },
                    new PaginationItemViewModel
                    {
                        Number = "4",
                        VisuallyHiddenText = "4",
                        Href = "#"
                    }
                }
            };
        }
        
        [Fact]
        public async Task Render_AllValues()
        {
            // Act & Assert
            await VerifyPartial("Pagination", DefaultPaginationViewModel());
        }
        
        [Fact]
        public async Task Render_NoItems()
        {
            // Arrange
            var viewModel = DefaultPaginationViewModel();
            viewModel.Items = null;
            
            // Act & Assert
            await VerifyPartial("Pagination", viewModel);
        }
        
        [Fact]
        public async Task Render_LastPage()
        {
            // Arrange
            var viewModel = DefaultPaginationViewModel();
            viewModel.Items.RemoveAt(3);
            viewModel.Next = null;
            
            // Act & Assert
            await VerifyPartial("Pagination", viewModel);
        }
        
        [Fact]
        public async Task Render_FirstPage()
        {
            // Arrange
            var viewModel = DefaultPaginationViewModel();
            viewModel.Items[2].Current = false;
            viewModel.Items[0].Current = true;
            viewModel.Previous = null; 
            
            // Act & Assert
            await VerifyPartial("Pagination", viewModel);
        }
    }
}