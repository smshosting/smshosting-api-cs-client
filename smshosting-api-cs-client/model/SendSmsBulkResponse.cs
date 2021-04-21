using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class SendSmsBulkResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("smsBulkResult")]
        public SmsBulkResult SmsBulkResult { get; set; }

        public SendSmsBulkResponse()
        {
        }
    }
}
