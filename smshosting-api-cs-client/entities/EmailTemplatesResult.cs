using System;
using System.Collections.Generic;

namespace smshosting.api.cs.client.entities
{
    public class EmailTemplatesResult
    {
        [System.Text.Json.Serialization.JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("templates")]
        public List<EmailTemplate> EmailTemplatesList { get; set; }

        public EmailTemplatesResult()
        {
        }
    }
}
