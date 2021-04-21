using System;
using System.Collections.Generic;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class AliasListResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("aliasList")]
        public List<Alias> AliasList { get; set; }

        public AliasListResponse()
        {
        }
    }
}
