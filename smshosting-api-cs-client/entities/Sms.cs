using System;
using smshosting.api.cs.client.utilities;

namespace smshosting.api.cs.client.entities
{
    public class Sms
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public SmshUuid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("to")]
        public String To { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("status")]
        public String Status { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("statusDetail")]
        public String StatusDetail { get; set; }


        public Sms()
        {
            Id = new SmshUuid();
        }




    }
}
