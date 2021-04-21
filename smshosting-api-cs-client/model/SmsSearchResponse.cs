using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class SmsSearchResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("smsSearchResult")]
        public SmsSearchResult SmsSearchResult { get; set; }


        public SmsSearchResponse()
        {
        }
    }
}
