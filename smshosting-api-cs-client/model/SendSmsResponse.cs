using System;
using smshosting.api.cs.client.entities;

namespace smshosting.api.cs.client.model
{
    public class SendSmsResponse : GenericResponse
    {
        public SmsResult SmsResult { get; set; }

        public SendSmsResponse()
        {
        }
    }
}
