using System;
namespace smshosting.api.cs.client.entities
{
    public class Metadata
    {
        public const Int64 DEFAULT_LIMIT = 20;

        [System.Text.Json.Serialization.JsonPropertyName("count")]
        public Int64 Count { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("offset")]
        public Int64 Offset { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public Int64 Limit { get; set; }


        public Metadata()
        {
        }
    }
}
