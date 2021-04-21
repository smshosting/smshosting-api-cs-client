using System;
namespace smshosting.api.cs.client.entities
{
    public class Estimate
    {
        [System.Text.Json.Serialization.JsonPropertyName("cost")]
        public Double Cost { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("userCredit")]
        public Double UserCredit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("smsCount")]
        public Int64 SmsCount { get; set; }


        public Estimate()
        {
        }
    }
}
