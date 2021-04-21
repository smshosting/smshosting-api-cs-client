using System;
namespace smshosting.api.cs.client.entities
{
    public class Alias
    {
        public const String ALIAS_STATUS_VERIFIED = "VERIFIED";
        public const String ALIAS_STATUS_NOTVERIFIED = "NOTVERIFIED";

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Int64 Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("alias")]
        public String AliasName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("vatnumber")]
        public String Vatnumber { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("taxcode")]
        public String Taxcode { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("businessname")]
        public String Businessname { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("address")]
        public String Address { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("city")]
        public String City { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("postcode")]
        public String Postcode { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("province")]
        public String Province { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("country")]
        public String Country { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public String Email { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("phone")]
        public String Phone { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("status")]
        public String Status { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("pec")]
        public String Pec { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ip")]
        public String Ip { get; set; }



        public Alias()
        {
        }
    }
}
