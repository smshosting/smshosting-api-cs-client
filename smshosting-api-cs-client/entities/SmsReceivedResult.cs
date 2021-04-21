using System;
using System.Collections.Generic;

namespace smshosting.api.cs.client.entities
{
    public class SmsReceivedResult
    {

        [System.Text.Json.Serialization.JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("smsList")]
        public List<SmsReceivedInfo> SmsList { get; set; }



        public SmsReceivedResult()
        {
        }
    }
}
