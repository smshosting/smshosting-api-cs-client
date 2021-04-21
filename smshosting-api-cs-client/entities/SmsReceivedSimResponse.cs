using System;
namespace smshosting.api.cs.client.entities
{
    public class SmsReceivedSimResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Int64 Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sim")]
        public String Sim { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("key")]
        public String Key { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("expirationDate")]
        public String ExpirationDate { get; set; }

        public SmsReceivedSimResponse()
        {
        }
    }
}
