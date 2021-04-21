using System;
namespace smshosting.api.cs.client.entities
{
    public class SmsReceivedInfo
    {
        [System.Text.Json.Serialization.JsonPropertyName("simId")]
        public Int64 SimId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("from")]
        public String From { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("text")]
        public String Text { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("receiveDate")]
        public String ReceiveDate { get; set; }


        public SmsReceivedInfo()
        {
        }
    }
}
