using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class EmailCampaignResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("emailCampaign")]
        public EmailCampaign EmailCampaign { get; set; }


        public EmailCampaignResponse()
        {
        }
    }
}
