using System;
namespace smshosting.api.cs.client.entities
{
    public class EmailTemplate
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Int64 Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("title")]
        public String Title { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("editorType")]
        public String EditorType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("contentType")]
        public String ContentType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("insertDate")]
        public String InsertDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updateDate")]
        public String UpdateDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("customFieldsKey")]
        public String[] CustomFieldsKey { get; set; }



        public EmailTemplate()
        {
        }
    }
}
