using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class SendEmailCampaignResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("emailResult")]
        public EmailResult EmailResult { get; set; }

        public SendEmailCampaignResponse()
        {
        }
    }
}
