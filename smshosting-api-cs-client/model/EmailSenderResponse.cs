using System;
using System.Collections.Generic;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class EmailSenderResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("emailSenderList")]
        public List<EmailSender> EmailSenderList { get; set; }

        public EmailSenderResponse()
        {
        }
    }
}
