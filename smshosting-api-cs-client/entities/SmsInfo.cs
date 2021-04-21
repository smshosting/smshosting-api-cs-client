using System;
using smshosting.api.cs.client.utilities;

namespace smshosting.api.cs.client.entities
{
    public class SmsInfo
    {

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public SmshUuid Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("to")]
        public String To { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("text")]
        public String Text { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("from")]
        public String From { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("status")]
        public String Status { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("insertDate")]
        public String InsertDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sentDate")]
        public String SentDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deliveryDate")]
        public String DeliveryDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("transactionId")]
        public String TransactionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("price")]
        public Double Price { get; set; }



        public SmsInfo()
        {
        }
    }
}
