using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class EmailResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public Email Email { get; set; }

        public EmailResponse()
        {
        }
    }
}
