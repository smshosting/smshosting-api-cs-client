using System;
using System.Collections.Generic;

namespace smshosting.api.cs.client.entities
{
    public class CustomField
    {

        [System.Text.Json.Serialization.JsonPropertyName("fieldKey")]
        public String FieldKey { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fieldName")]
        public String FieldName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fieldType")]
        public String FieldType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fieldValue")]
        public String FieldValue { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fieldOptions")]
        public List<CustomFieldOption> FieldOptions { get; set; }


        public CustomField()
        {
        }
    }
}
