using System;
namespace smshosting.api.cs.client.entities
{
    public class Email
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Int64? Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("campaignId")]
        public Int64? CampaignId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("templateId")]
        public Int64? TemplateId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("to")]
        public String To { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("status")]
        public String Status { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("statusDate")]
        public String StatusDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("insertDate")]
        public String InsertDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deferredDate")]
        public String DeferredDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sentDate")]
        public String SentDate { get; set; }


        public Email()
        {
        }
    }
}
