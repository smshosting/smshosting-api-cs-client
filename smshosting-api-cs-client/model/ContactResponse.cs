using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class ContactResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("contact")]
        public Contact Contact { get; set; }


        public ContactResponse()
        {
        }
    }
}
