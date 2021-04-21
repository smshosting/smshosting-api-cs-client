using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class EmailCampaignsListResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("emailCampaignsResult")]
        public  EmailCampaignsResult EmailCampaignsResult { get; set; }

        public EmailCampaignsListResponse()
        {
        }
    }
}
