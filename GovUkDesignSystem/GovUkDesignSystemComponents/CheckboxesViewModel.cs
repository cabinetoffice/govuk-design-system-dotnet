namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class CheckboxesViewModel : ItemSetViewModel
    {
        public const string HIDDEN_CHECKBOX_DUMMY_VALUE = "hidden_checkbox_dummy_value";
        public override string StyleNamePrefix { get; } = "govuk-checkboxes";
        public override string ItemDesignFileName { get; } = "/GovUkDesignSystemComponents/CheckboxItem.cshtml";
    }
}
