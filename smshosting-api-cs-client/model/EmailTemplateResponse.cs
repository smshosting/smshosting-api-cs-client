using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class EmailTemplateResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("emailTemplate")]
        public EmailTemplate EmailTemplate { get; set; }

        public EmailTemplateResponse()
        {
        }
    }
}
