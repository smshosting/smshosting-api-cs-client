using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class EmailTemplatesListResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("emailTemplatesResult")]
        public EmailTemplatesResult EmailTemplatesResult { get; set; }

        public EmailTemplatesListResponse()
        {
        }
    }
}
