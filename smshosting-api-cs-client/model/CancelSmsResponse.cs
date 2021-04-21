using System;
using System.Collections.Generic;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class CancelSmsResponse : GenericResponse
    {

        [System.Text.Json.Serialization.JsonPropertyName("smsList")]
        public List<SmsInfo> SmsList { get; set; }

        public CancelSmsResponse()
        {
        }
    }
}
