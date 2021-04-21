using System;
using System.Collections.Generic;

namespace smshosting.api.cs.client.entities
{
    public class SmsResult
    {
        public const String SEND_SANDBOX = "SANDBOX";
        public const String SEND_STATUS_INSERTED = "INSERTED";
        public const String SEND_STATUS_NOT_INSERTED = "NOT_INSERTED";

        [System.Text.Json.Serialization.JsonPropertyName("from")]
        public String From { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("text")]
        public String Text { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("transactionId")]
        public String TransactionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("smsInserted")]
        public int SmsInserted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("smsNotInserted")]
        public int SmsNotInserted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sms")]
        public List<Sms> Sms { get; set; }


        public SmsResult()
        {
        }
    }
}
