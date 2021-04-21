using System;
namespace smshosting.api.cs.client.entities
{
    public class EmailCampaign
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Int64 Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("campaignTitle")]
        public String CampaignTitle { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("templateId")]
        public Int64 TemplateId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("from")]
        public String From { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("fromName")]
        public String FromName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("group")]
        public String Group { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("subject")]
        public String Subject { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("subjectPreviewText")]
        public String SubjectPreviewText { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enableOpenTracking")]
        public Boolean? EnableOpenTracking { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enableLinkTracking")]
        public Boolean? EnableLinkTracking { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deferredDate")]
        public String DeferredDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("stats")]
        public MailSenderCampaignStats Stats { get; set; }


        public EmailCampaign()
        {
        }
    }
}
