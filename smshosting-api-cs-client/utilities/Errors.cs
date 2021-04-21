using System;
namespace smshosting.api.cs.client.utilities
{
    public class Errors
    {


        //STATUS CODE ERRORS
        public const int STATUS_CODE_BAD_REQUEST = 400;

        //ERROR MESSAGES
        public const String ERROR_MSG_SEARCH_NO_PARAMS = "NO_PARAMS";

        //login
        public const  String ERROR_MSG_AUTH_CREDENTIALS = "BAD_CREDENTIALS";

        //alias
        public const  String ERROR_MSG_ALIAS_NOT_EXISTS = "ALIAS_NOT_EXISTS";
        public const  String ERROR_MSG_ALIAS_BAD_ALIAS = "BAD_ALIAS";
        public const  String ERROR_MSG_ALIAS_BAD_BUSINESSNAME = "BAD_BUSINESSNAME";
        public const  String ERROR_MSG_ALIAS_BAD_VATNUMBER = "BAD_VATNUMBER";
        public const  String ERROR_MSG_ALIAS_BAD_ADDRESS = "BAD_ADDRESS";
        public const  String ERROR_MSG_ALIAS_BAD_CITY = "BAD_CITY";
        public const  String ERROR_MSG_ALIAS_BAD_POSTCODE = "BAD_POSTCODE";
        public const  String ERROR_MSG_ALIAS_BAD_PROVINCE = "BAD_PROVINCE";
        public const  String ERROR_MSG_ALIAS_BAD_COUNTRY = "BAD_COUNTRY";
        public const  String ERROR_MSG_ALIAS_BAD_EMAIL = "BAD_EMAIL";
        public const  String ERROR_MSG_ALIAS_BAD_PHONE = "BAD_PHONE";
        public const  String ERROR_MSG_ALIAS_BAD_TAXCODE = "BAD_TAXCODE";
        public const  String ERROR_MSG_ALIAS_BAD_PEC = "BAD_PEC";
        public const  String ERROR_MSG_ALIAS_DUPLICATE_ALIAS = "DUPLICATE_ALIAS";

        //invio
        public const  String ERROR_MSG_SEND_FROM = "BAD_FROM";
        public const  String ERROR_MSG_SEND_RECIPIENT = "NO_VALID_RECIPIENT";
        public const  String ERROR_MSG_SEND_CREDIT = "BAD_CREDIT";
        public const  String ERROR_MSG_SEND_GROUP = "BAD_GROUP";
        public const  String ERROR_MSG_SEND_TO = "BAD_TO";
        public const  String ERROR_MSG_SEND_MSISDN = "BAD_MSISDN";
        public const  String ERROR_MSG_SEND_NO_CREDIT = "NO_CREDIT";
        public const  String ERROR_MSG_SEND_NO_CREDIT_RESELLER = "SENDING_DISABLED";
        public const  String ERROR_MSG_SEND_DUPLICATE_SMS = "DUPLICATE_SMS";
        public const  String ERROR_MSG_SEND_DATE = "BAD_DATE";
        public const  String ERROR_MSG_SEND_TRANSACTIONID = "BAD_TRANSACTIONID";
        public const  String ERROR_MSG_SEND_TEXT = "BAD_TEXT";
        public const  String ERROR_MSG_SEND_FILE = "BAD_FILE";
        public const  String ERROR_MSG_SEND_FILE_EXPIRATION_DATE = "BAD_FILE_EXPIRATION_DATE";
        public const  String ERROR_MSG_SEND_TEXT_PLACEHOLDER = "BAD_TEXT_PLACEHOLDER";
        public const  String ERROR_MSG_SEND_CALLBACK = "BAD_CALLBACK";
        public const  String ERROR_MSG_SEND_ENCODING = "BAD_ENCODING";
        public const  String ERROR_MSG_SEND_QUALITY = "BAD_QUALITY";
        public const  String ERROR_MSG_SEND_SEARCH_BAD_IDS = "BAD_ID";
        public const  String ERROR_MSG_SEND_SEARCH_BAD_MSISDN = "BAD_MSISDN";
        public const  String ERROR_MSG_SEND_SEARCH_BAD_DATE = "BAD_DATE";
        public const  String ERROR_MSG_SEND_SEARCH_BAD_STATUS = "BAD_STATUS";
        public const  String ERROR_MSG_RECEIVED_BAD_RECEIVEON = "BAD_RECEIVE_ON";

        //gruppi
        public const  String ERROR_MSG_GROUP_NOT_EXISTS = "GROUP_NOT_EXISTS";
        public const  String ERROR_MSG_GROUP_NAME = "BAD_GROUP_NAME";
        public const  String ERROR_MSG_GROUP_DESCRIPTION = "BAD_GROUP_DESCRIPTION";
        public const  String ERROR_MSG_GROUP_ALREADY_EXISTS = "GROUP_ALREADY_EXISTS";

        //contatti
        public const  String ERROR_MSG_CONTACT_NOT_EXISTS = "CONTACT_NOT_EXISTS";
        public const  String ERROR_MSG_CONTACT_NAME = "BAD_CONTACT_NAME";
        public const  String ERROR_MSG_CONTACT_LASTNAME = "BAD_CONTACT_LASTNAME";
        public const  String ERROR_MSG_CONTACT_GROUP = "BAD_CONTACT_GROUP";
        public const  String ERROR_MSG_CONTACT_MSISDN = "BAD_CONTACT_MSISDN";
        public const  String ERROR_MSG_MATCH_POLICY = "BAD_MATCH_POLICY";
        public const  String ERROR_MSG_CONTACT_COUNTRY = "BAD_CONTACT_COUNTRY";
        public const  String ERROR_MSG_CONTACT_ALREADY_EXISTS = "CONTACT_ALREADY_EXISTS";
        public const  String ERROR_MSG_CONTACT_EMAIL = "BAD_CONTACT_EMAIL";
        public const  String ERROR_MSG_CONTACT_FIELD_UNIQUE_KEY = "BAD_FIELD_UNIQUE_KEY";
        public const  String ERROR_MSG_CONTACT_FIELD_VALUE = "BAD_FIELD_VALUE";

        //EMAIL
        public const  String ERROR_MSG_MS_SEND_BAD_TEMPLATEID = "BAD_TEMPLATEID";
        public const  String ERROR_MSG_MS_SEND_BAD_FROM = "BAD_FROM";
        public const  String ERROR_MSG_MS_SEND_FROM_NOT_VALIDATED = "FROM_NOT_VALIDATED";
        public const  String ERROR_MSG_MS_SEND_BAD_TO = "BAD_TO";
        public const  String ERROR_MSG_MS_SEND_BAD_TO_SIZE = "BAD_TO_SIZE";
        public const  String ERROR_MSG_MS_SEND_BAD_SUBJECT = "BAD_SUBJECT";
        public const  String ERROR_MSG_MS_SEND_BAD_GROUP = "BAD_GROUP";
        public const  String ERROR_MSG_MS_CAMPAIGN_NOT_EXISTS = "CAMPAIGN_NOT_EXISTS";
        public const  String ERROR_MSG_MS_TEMPLATE_NOT_EXISTS = "TEMPLATE_NOT_EXISTS";
        public const  String ERROR_MSG_MS_EMAIL_NOT_EXISTS = "EMAIL_NOT_EXISTS";
        public const  String ERROR_MSG_MS_SEND_BAD_CAMPAIGN_TITLE = "BAD_CAMPAIGN_TITLE";


        public Errors()
        {
        }
    }
}
