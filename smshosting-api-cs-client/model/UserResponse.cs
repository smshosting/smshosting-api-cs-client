using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class UserResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("user")]
        public User User { get; set; }

        public UserResponse()
        {
        }
    }
}
