using System;
namespace smshosting.api.cs.client.entities
{
    public class MailSenderCampaignStats
    {
        [System.Text.Json.Serialization.JsonPropertyName("countEmailInserted")]
        public Int64 CountEmailInserted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("countEmailStatusPending")]
        public Int64 CountEmailStatusPending { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("countEmailStatusNoSent")]
        public Int64 CountEmailStatusNoSent { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("countEmailTotSent")]
        public Int64 CountEmailTotSent { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("countEmailStatusBounced")]
        public Int64 CountEmailStatusBounced { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("countEmailOpenedUnique")]
        public Int64 CountEmailOpenedUnique { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("countEmailClickUnique")]
        public Int64 CountEmailClickUnique { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("countEmailStatusSpamReport")]
        public Int64 CountEmailStatusSpamReport { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("countEmailCauseUnsubscribed")]
        public Int64 CountEmailCauseUnsubscribed { get; set; }


        public MailSenderCampaignStats()
        {
        }
    }
}
