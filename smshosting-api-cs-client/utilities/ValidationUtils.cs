using System;
using System.Collections.Generic;

namespace smshosting.api.cs.client.utilities
{
    public class ValidationUtils
    {
        public const String SDF_FORMAT = "yyyy-MM-dd'T'HH:mm:ssZ";

        public ValidationUtils()
        {
        }


        

        public static String validateCreateAlias(String alias, String businessname, String address, String city, String postcode, String province, String country, String vatnumber, String email, String phone, String taxcode, String pec, String authKey, String authSecret)
        {

            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (alias == null || alias.Length == 0 || alias.Length > 11)
            {
                errors.Add(Errors.ERROR_MSG_ALIAS_BAD_ALIAS);
            }

            if (businessname == null || businessname.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_ALIAS_BAD_BUSINESSNAME);
            }

            if (address == null || address.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_ALIAS_BAD_ADDRESS);
            }

            if (city == null || city.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_ALIAS_BAD_CITY);
            }

            if (postcode == null || postcode.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_ALIAS_BAD_POSTCODE);
            }

            if (province == null || province.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_ALIAS_BAD_PROVINCE);
            }

            if (country == null || country.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_ALIAS_BAD_COUNTRY);
            }

            if (country != null && "IT".Equals(country))
            {
                if (vatnumber == null || vatnumber.Length == 0)
                {
                    errors.Add(Errors.ERROR_MSG_ALIAS_BAD_VATNUMBER);
                }
                if (taxcode == null || taxcode.Length == 0)
                {
                    errors.Add(Errors.ERROR_MSG_ALIAS_BAD_TAXCODE);
                }
                if (pec == null || pec.Length == 0)
                {
                    errors.Add(Errors.ERROR_MSG_ALIAS_BAD_PEC);
                }
            }

            if (email == null || email.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_ALIAS_BAD_EMAIL);
            }

            if (phone == null || phone.Length == 0 || phone.Length > 25)
            {
                errors.Add(Errors.ERROR_MSG_ALIAS_BAD_PHONE);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetAlias(String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateDeleteAlias(String id, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;


            if (!checkIfValidId(id))
            {
                errors.Add(Errors.ERROR_MSG_ALIAS_BAD_ALIAS);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateSendSms(String from, String to, String group, String text, String sendDateTime, String transactionId, bool? sandbox, String statusCallback, String encoding, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (transactionId != null && transactionId.Length > 0)
            {
                if (transactionId.Trim().Length > 60)
                {
                    errors.Add(Errors.ERROR_MSG_SEND_TRANSACTIONID);
                }
            }


            if (sendDateTime != null && sendDateTime.Trim().Length > 0)
            {
                DateTime? dataInvio = checkData(sendDateTime, true);
                if (dataInvio == null)
                {
                    errors.Add(Errors.ERROR_MSG_SEND_DATE);

                }
            }

            if (text == null || text.Trim().Length < 1)
            {
                errors.Add(Errors.ERROR_MSG_SEND_TEXT);
            }


            if ((group == null || group.Length == 0) && (to == null || to.Length == 0))
            {
                return Errors.ERROR_MSG_SEND_RECIPIENT;
            }

            if (encoding != null)
            {
                if (!"AUTO".Equals(encoding, StringComparison.OrdinalIgnoreCase) && !"7BIT".Equals(encoding, StringComparison.OrdinalIgnoreCase) && !"UCS2".Equals(encoding, StringComparison.OrdinalIgnoreCase))
                {
                    return Errors.ERROR_MSG_SEND_ENCODING;
                }
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateEstimateSendSms(String from, String to, String group, String text, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (text == null || text.Trim().Length < 1)
            {
                errors.Add(Errors.ERROR_MSG_SEND_TEXT);
            }

            if ((group == null || group.Length == 0) && (to == null || to.Length == 0))
            {
                return Errors.ERROR_MSG_SEND_RECIPIENT;
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateCancelSms(String id, String transactionId, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if ((id == null || id.Length == 0) && (transactionId == null || transactionId.Length == 0))
            {
                return Errors.ERROR_MSG_SEARCH_NO_PARAMS;
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateSearchSms(String id, String transactionId, String msisdn, String fromDateTime, String toDateTime, String status, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if ((id == null || id.Length == 0) && (transactionId == null || transactionId.Length == 0) && (msisdn == null || msisdn.Length == 0)
                    && (fromDateTime == null || fromDateTime.Length == 0) && (toDateTime == null || toDateTime.Length == 0) && (status == null || status.Length == 0))
            {
                errors.Add(Errors.ERROR_MSG_SEARCH_NO_PARAMS);
            }

            if (id != null && id.Length > 0)
            {
                String[] ids = id.Split(",");
                if (ids != null)
                {
                    foreach (String idStr in ids)
                    {
                        if (!checkIfValidId(idStr))
                        {
                            errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_IDS);
                        }
                    }
                }
            }

            if (fromDateTime != null && fromDateTime.Length > 0)
            {
                if (checkData(fromDateTime) == null)
                {
                    errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_DATE);
                }
            }

            if (toDateTime != null && toDateTime.Length > 0)
            {
                if (checkData(toDateTime) == null)
                {
                    errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_DATE);
                }
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateSearchSmsReceived(String from, String simIdRef, String fromDateTime, String toDateTime, Int64? offset, Int64? limit, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if ((simIdRef == null || simIdRef.Length == 0) && (from == null || from.Length == 0) && (fromDateTime == null || fromDateTime.Length == 0)
                    && (toDateTime == null || toDateTime.Length == 0))
            {
                errors.Add(Errors.ERROR_MSG_SEARCH_NO_PARAMS);
            }

            if (fromDateTime != null && fromDateTime.Length > 0)
            {
                if (checkData(fromDateTime) == null)
                {
                    errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_DATE);
                }
            }

            if (toDateTime != null && toDateTime.Length > 0)
            {
                if (checkData(toDateTime) == null)
                {
                    errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_DATE);
                }
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetSimForReceiveSmsList(String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetGroupList(String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetGroup(String id, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (id == null || id.Length == 0 || !checkIfValidId(id))
            {
                errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_IDS);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateAddGroup(String name, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (name == null || name.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_GROUP_NAME);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateUpdateGroup(String id, String name, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (id == null || id.Length == 0 || !checkIfValidId(id))
            {
                errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_IDS);
            }

            if (name == null || name.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_GROUP_NAME);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateDeleteGroup(String id, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (id == null || id.Length == 0 || !checkIfValidId(id))
            {
                errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_IDS);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateSearchContacts(String msisdn, String fieldKey, String fieldValue, String email, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetContact(String id, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (id == null || id.Length == 0 || !checkIfValidId(id))
            {
                errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_IDS);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateAddContact(String name, String groupsId, String customFieldUniqueKey, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if ((name == null || name.Length == 0) && (customFieldUniqueKey == null || customFieldUniqueKey.Length == 0))
            {
                errors.Add(Errors.ERROR_MSG_SEARCH_NO_PARAMS);
            }

            if (groupsId != null && groupsId.Length > 0)
            {
                String[] ids = groupsId.Split(",");
                if (ids != null)
                {
                    foreach (String idStr in ids)
                    {
                        if (!checkIfValidId(idStr))
                        {
                            errors.Add(Errors.ERROR_MSG_CONTACT_GROUP);
                        }
                    }
                }
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateUpdateContact(String id, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (id == null || id.Length == 0 || !checkIfValidId(id))
            {
                errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_IDS);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateDeleteContact(String id, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (id == null || id.Length == 0 || !checkIfValidId(id))
            {
                errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_IDS);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetEmailSenderList(String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetEmailTemplatesList(String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetEmailTemplate(String id, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (id == null || id.Length == 0 || !checkIfValidId(id))
            {
                errors.Add(Errors.ERROR_MSG_MS_SEND_BAD_TEMPLATEID);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetEmailCampaignsList(String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetEmailCampaign(String id, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (id == null || id.Length == 0 || !checkIfValidId(id))
            {
                errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_IDS);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetEmail(String id, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (id == null || id.Length == 0 || !checkIfValidId(id))
            {
                errors.Add(Errors.ERROR_MSG_SEND_SEARCH_BAD_IDS);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateSendEmailCampaign(String templateId, String from, String group, String subject, String campaignTitle, String DateTime, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (templateId == null || templateId.Length == 0 || !checkIfValidId(templateId))
            {
                errors.Add(Errors.ERROR_MSG_MS_SEND_BAD_TEMPLATEID);
            }

            if (group == null || group.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_MS_SEND_BAD_GROUP);
            }

            if (from == null || from.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_MS_SEND_BAD_FROM);
            }

            if (subject == null || subject.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_MS_SEND_BAD_SUBJECT);
            }

            if (campaignTitle == null || campaignTitle.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_MS_SEND_BAD_CAMPAIGN_TITLE);
            }

            if (DateTime != null && DateTime.Length > 0 && checkData(DateTime, true) == null)
            {
                errors.Add(Errors.ERROR_MSG_SEND_DATE);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateSendSingleEmail(String templateId, String from, String to, String subject, String DateTime, String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            if (templateId == null || templateId.Length == 0 || !checkIfValidId(templateId))
            {
                errors.Add(Errors.ERROR_MSG_MS_SEND_BAD_TEMPLATEID);
            }

            if (to == null || to.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_MS_SEND_BAD_TO);
            }

            if (from == null || from.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_MS_SEND_BAD_FROM);
            }

            if (subject == null || subject.Length == 0)
            {
                errors.Add(Errors.ERROR_MSG_MS_SEND_BAD_SUBJECT);
            }

            if (DateTime != null && DateTime.Length > 0 && checkData(DateTime) == null)
            {
                errors.Add(Errors.ERROR_MSG_SEND_DATE);
            }

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateGetUser(String authKey, String authSecret)
        {
            HashSet<String> errors = new HashSet<String>();
            String result = null;

            String credentialError = validateTimeCredentials(authKey, authSecret);
            if (credentialError != null)
            {
                errors.Add(credentialError);
            }

            if (errors.Count != 0)
            {
                result = String.Join(",", errors);
            }

            return result;
        }

        public static String validateTimeCredentials(String authKey, String authSecret)
        {

            String error = null;

            if (authKey == null || authKey.Length == 0 || authSecret == null || authSecret.Length == 0)
            {
                error = Errors.ERROR_MSG_AUTH_CREDENTIALS;
            }

            return error;
        }

        public static DateTime? checkData(String DateTime)
        {
            return checkData(DateTime, false);
        }

        public static DateTime? checkData(String DateTimeTime, bool checkDifferito)
        {
            if (DateTimeTime == null)
            {
                return null;
            }
            DateTime ora = DateTime.Now;
            DateTime dataInvio;

            try
            {
                dataInvio = DateTime.Parse(DateTimeTime);
            }
            catch (Exception e)
            {
                return null;
            }

            if (checkDifferito)
            {
                if (dataInvio != null && dataInvio < ora)
                {
                    return null;
                }
            }

            return dataInvio;

        }

        public static bool checkIfValidId(String id)
        {

            if (id == null)
            {
                return false;
            }
            
            return true;

        }














    }
}
