using System;
using System.Collections.Generic;

namespace smshosting.api.cs.client.entities
{
    public class Contact
    {
        [System.Text.Json.Serialization.JsonPropertyName("msisdn")]
        public String Msisdn { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public String Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("lastname")]
        public String Lastname { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public String Email { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("groups")]
        public List<Group> Groups { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("customFields")]
        public List<CustomField> CustomFields { get; set; }


        public Contact()
        {
        }
    }
}
