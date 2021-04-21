using System;
using System.Collections.Generic;

namespace smshosting.api.cs.client.entities
{
    public class EmailCampaignsResult
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Metadata Metadata { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("campaignList")]
        public List<EmailCampaign> EmailCampaign { get; set; }


        public EmailCampaignsResult()
        {
        }
    }
}
