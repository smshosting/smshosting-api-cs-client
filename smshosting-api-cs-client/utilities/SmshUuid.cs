using System;
using System.Globalization;


namespace smshosting.api.cs.client.utilities
{
    public class SmshUuid
    {
        private string _uuid;

        public SmshUuid()
        {
            _uuid = null;
        }

        public String UUIDstr
        {
            get
            {
                return _uuid;
            }
            set
            {
                _uuid = value;
            }
        }

        public Int64 UUIDlong
        {
            get
            {
                Int64 _nUuid = -1;
                try
                {
                    _nUuid = Int64.Parse(_uuid, System.Globalization.NumberStyles.Any, new CultureInfo("it-IT"));

                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to convert '{0}'.", _uuid);
                }

                return _nUuid;
            }
            set
            {
                _uuid = "" + value;
            }
        }

        internal static SmshUuid ParseExact(string v)
        {
            SmshUuid ris = new SmshUuid();
            ris.UUIDstr = v;
            return ris;
        }
    }
}
