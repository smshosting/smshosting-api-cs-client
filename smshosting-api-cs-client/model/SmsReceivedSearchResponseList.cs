using System;
using System.Collections.Generic;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class SmsReceivedSearchResponseList : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("smsReceivedSimResponseList")]
        public List<SmsReceivedSimResponse> SmsReceivedSimResponseList { get; set; }

        public SmsReceivedSearchResponseList()
        {
        }
    }
}
