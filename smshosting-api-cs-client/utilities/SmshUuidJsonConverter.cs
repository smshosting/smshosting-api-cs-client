using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace smshosting.api.cs.client.utilities
{
    public class SmshUuidJsonConverter : JsonConverter<SmshUuid>
    {
        public override SmshUuid Read(
                    ref Utf8JsonReader reader,
                    Type typeToConvert,
                    JsonSerializerOptions options)
        {
            SmshUuid ris = new SmshUuid();
            try
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    ris = SmshUuid.ParseExact(reader.GetString());
                }
                else
                {
                    ris = SmshUuid.ParseExact(reader.GetInt64().ToString());
                }
            }
            catch (Exception e)
            {

            }
            return ris;
        }


        public override void Write(
            Utf8JsonWriter writer,
            SmshUuid smshUuid,
            JsonSerializerOptions options) =>
                writer.WriteStringValue(smshUuid.UUIDstr);
    }
}
