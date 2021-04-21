using System;
using System.Text.Json.Serialization;

namespace smshosting.api.cs.client.model
{


    public class GenericResponse
    {

        [JsonPropertyName("errorCode")]
        public Int64? StatusCode { get; set; }

        [JsonPropertyName("errorMsg")]
        public String Message { get; set; }

        public Boolean Error()
        {
            Boolean res = false;
            if (StatusCode != null)
            {
                if (StatusCode < 200 || StatusCode > 299)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
