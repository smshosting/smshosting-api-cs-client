using System;
namespace smshosting.api.cs.client.entities
{
    public class SmsBulkResult
    {
        [System.Text.Json.Serialization.JsonPropertyName("from")]
        public String From { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("text")]
        public String Text { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("transactionId")]
        public String TransactionId { get; set; }


        public SmsBulkResult()
        {
        }
    }
}
