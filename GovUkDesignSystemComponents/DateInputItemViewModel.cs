using System.Collections.Generic;

namespace GovUkDesignSystem.GovUkDesignSystemComponents
{
    public class DateInputItemViewModel
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public string Value { get; set; }

        public string Autocomplete { get; set; }

        public string Pattern { get; set; } = "[0-9]*";

        public string Classes { get; set; }

        public Dictionary<string, string> Attributes { get; set; }

    }
}
