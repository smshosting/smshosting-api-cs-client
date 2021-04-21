using System;
namespace smshosting.api.cs.client.entities
{
    public class ContactSearchResult
    {
        [System.Text.Json.Serialization.JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("contacts")]
        public System.Collections.Generic.List<Contact> Contacts { get; set; }


        public ContactSearchResult()
        {
        }
    }
}
