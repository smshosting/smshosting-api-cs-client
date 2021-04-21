using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class EstimateResponse : GenericResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("estimate")]
        public Estimate Estimate { get; set; }

        public EstimateResponse()
        {
        }
    }
}
