using System;
using System.Collections.Generic;

namespace smshosting.api.cs.client.entities
{
    public class User
    {
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public String Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lastname")]
        public String Lastname { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("username")]
        public String Username { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public String Email { get; set; }

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

        [System.Text.Json.Serialization.JsonPropertyName("birthdate")]
        public String Birthdate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("phone")]
        public String Phone { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("msisdn")]
        public String Msisdn { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sender")]
        public String Sender { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("taxcode")]
        public String Taxcode { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("vatnumber")]
        public String Vatnumber { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("idregistrationDate")]
        public String RegistrationDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("expirationDate")]
        public String ExpirationDate { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("credit")]
        public Double Credit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("italysms")]
        public Int64 Italysms { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("senderAlias")]
        public List<String> SenderAlias { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("accountPlan")]
        public String AccountPlan { get; set; }


        public User()
        {
        }
    }
}
