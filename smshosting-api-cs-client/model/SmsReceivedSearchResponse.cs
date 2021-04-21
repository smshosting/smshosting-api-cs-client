using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class SmsReceivedSearchResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("smsReceivedResult")]
        public SmsReceivedResult SmsReceivedResult { get; set; }

        public SmsReceivedSearchResponse()
        {
        }
    }
}
