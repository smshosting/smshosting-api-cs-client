using System;
using System.Collections.Generic;

namespace smshosting.api.cs.client.entities
{
    public class SmsSearchResult
    {
        [System.Text.Json.Serialization.JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("smsList")]
        public List<SmsInfo> SmsList { get; set; }


        public SmsSearchResult()
        {
        }
    }
}
