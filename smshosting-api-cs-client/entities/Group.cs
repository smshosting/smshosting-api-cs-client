using System;
namespace smshosting.api.cs.client.entities
{
    public class Group
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Int64 Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public String Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("contactCount")]
        public Int64 ContactCount { get; set; }


        public Group()
        {
        }
    }
}
