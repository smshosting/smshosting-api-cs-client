using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class GroupResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("group")]
        public Group Group { get; set; }

        public GroupResponse()
        {
        }
    }
}
