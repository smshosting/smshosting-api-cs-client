using System;
using System.Collections.Generic;

namespace smshosting.api.cs.client.entities
{
    public class EmailResult
    {
        public const String SEND_SANDBOX = "SANDBOX";
        public const String SEND_STATUS_INSERTED = "INSERTED";
        public const String SEND_STATUS_NOT_INSERTED = "NOT_INSERTED";

        [System.Text.Json.Serialization.JsonPropertyName("campaignId")]
        public Int64? CampaignId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("emailInserted")]
        public Int64? EmailInserted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("emailNotInserted")]
        public Int64? EmailNotInserted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public List<Email> Email { get; set; }



        public EmailResult()
        {
        }
    }
}
