using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class ContactSearchResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("contactSearchResult")]
        public ContactSearchResult ContactSearchResult { get; set; }

        public ContactSearchResponse()
        {
        }
    }
}
