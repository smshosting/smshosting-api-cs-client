using System;
using System.Collections.Generic;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class GroupListResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("groupList")]
        public List<Group> GroupList { get; set; }

        public GroupListResponse()
        {
        }
    }
}
