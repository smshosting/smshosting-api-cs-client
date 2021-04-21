using System;
namespace smshosting.api.cs.client.entities
{
    public class CustomFieldOption
    {
        [System.Text.Json.Serialization.JsonPropertyName("optionValue")]
        public Int64 OptionValue { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("optionName")]
        public String OptionName { get; set; }

        public CustomFieldOption()
        {
        }
    }
}
