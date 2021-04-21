using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class AliasResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("alias")]
        public Alias Alias { get; set; }

        public AliasResponse()
        {
        }
    }
}
