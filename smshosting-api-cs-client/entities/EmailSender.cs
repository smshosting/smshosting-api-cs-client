using System;
namespace smshosting.api.cs.client.entities
{
    public class EmailSender
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public Int64 Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public String Email { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("emailName")]
        public String EmailName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("validationDate")]
        public String ValidationDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("insertDate")]
        public String InsertDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("contactCompany")]
        public String ContactCompany { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("contactAddress")]
        public String ContactAddress { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("contactCity")]
        public String ContactCity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("contactProvince")]
        public String ContactProvince { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("contactZipCode")]
        public String ContactZipCode { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("contactCountry")]
        public String ContactCountry { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("contactPhone")]
        public String ContactPhone { get; set; }



        public EmailSender()
        {
        }
    }
}
