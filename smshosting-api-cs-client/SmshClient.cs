using System;
using System.Collections.Generic;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using smshosting.api.cs.client.entities;
using smshosting.api.cs.client.model;
using smshosting.api.cs.client.utilities;

namespace smshosting.api.cs.client
{
    /// <summary>
    /// The main <c>SmshClient</c> class.
    /// Contains all methods for performing basic smshosting functions.
    /// </summary>
    public class SmshClient
    {
        private string AuthKey { get; set; }
        private string AuthSecret { get; set; }
        private string Host { get; set; }

        public SmshClient(string auth_key, string auth_secret) : this(auth_key, auth_secret, "https://api.smshosting.it")
        {
        }

        public SmshClient(string auth_key, string auth_secret, string host)
        {
            AuthKey = auth_key;
            AuthSecret = auth_secret;
            Host = host;
        }

        ~SmshClient()  // finalizer
        {
            // cleanup statements...
        }



        /// <summary>
        /// Create and retrieve a new Alias
        /// </summary>
        /// <param name="alias">String that identify the alias. Required.</param>
        /// <param name="businessname">Required.</param>
        /// <param name="address">Required.</param>
        /// <param name="city">Required.</param>
        /// <param name="postcode">Required.</param>
        /// <param name="province">Required.</param>
        /// <param name="country">Required.</param>
        /// <param name="vatnumber">Required.</param>
        /// <param name="email">Required.</param>
        /// <param name="phone">Required.</param>
        /// <param name="taxcode">Required.</param>
        /// <param name="pec">Required.</param>
        /// <returns>
        /// AliasResponse object containing the creted alias along with status code and error messages.
        /// </returns>
        public AliasResponse createAlias(
            String alias,
               String businessname,
               String address,
               String city,
               String postcode,
               String province,
               String country,
               String vatnumber,
               String email,
               String phone,
               String taxcode,
               String pec)
        {
            try
            {

                AliasResponse aliasResponse = new AliasResponse();

                String error = ValidationUtils.validateCreateAlias(alias, businessname, address, city, postcode, province, country, vatnumber, email, phone, taxcode, pec, AuthKey, AuthSecret);
                if (error != null)
                {
                    aliasResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    aliasResponse.Message = error;
                    return aliasResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/alias");
                client.Timeout = 10000;
                var request = new RestRequest(Method.POST);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


                if (alias != null) { request.AddParameter("alias", alias); }
                if (businessname != null) { request.AddParameter("businessname", businessname); }
                if (address != null) { request.AddParameter("address", address); }
                if (city != null) { request.AddParameter("city", city); }
                if (postcode != null) { request.AddParameter("postcode", postcode); }
                if (province != null) { request.AddParameter("province", province); }
                if (country != null) { request.AddParameter("country", country); }
                if (vatnumber != null) { request.AddParameter("vatnumber", vatnumber); }
                if (email != null) { request.AddParameter("email", email); }
                if (phone != null) { request.AddParameter("phone", phone); }
                if (taxcode != null) { request.AddParameter("taxcode", taxcode); }
                if (pec != null) { request.AddParameter("pec", pec); }

                IRestResponse response = client.Execute(request);

                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                    {
                        new SmshUuidJsonConverter()
                    }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    aliasResponse.StatusCode = statusCode;
                    Alias _alias = JsonSerializer.Deserialize<Alias>(response.Content, options);
                    aliasResponse.Alias = _alias;
                }
                else
                {
                    aliasResponse = JsonSerializer.Deserialize<AliasResponse>(response.Content, options);
                }




                return aliasResponse;

            }
            catch (Exception e)
            {
                return null;
            }

        }




        /// <summary>
        /// Get a list of the current registered aliases
        /// </summary>
        /// <returns>
        /// AliasListResponse object containing the list of registered alias along with status code and, eventually error messages.
        /// </returns>
        public AliasListResponse getAlias()
        {
            try
            {
                AliasListResponse aliasListResponse = new AliasListResponse();

                String error = ValidationUtils.validateGetAlias(AuthKey, AuthSecret);
                if (error != null)
                {
                    aliasListResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    aliasListResponse.Message = error;
                    return aliasListResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/alias/list");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    aliasListResponse.StatusCode = statusCode;
                    ListAlias listAlias = JsonSerializer.Deserialize<ListAlias>(response.Content, options);
                    aliasListResponse.AliasList = listAlias;

                }
                else
                {
                    aliasListResponse = JsonSerializer.Deserialize<AliasListResponse>(response.Content, options);
                }

                return aliasListResponse;

            }
            catch (Exception e)
            {
                return null;
            }

        }




        /// <summary>
        /// Delete the specified Alias
        /// </summary>
        /// <param name="id">ID of the alias. Required.</param>
        /// <returns>
        /// GenericResponse Object containing status code and error messages.
        /// </returns>
        public GenericResponse deleteAlias(
               String id)
        {
            try
            {
                GenericResponse result = new GenericResponse();

                String error = ValidationUtils.validateDeleteAlias(id, AuthKey, AuthSecret);
                if (error != null)
                {
                    result.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    result.Message = error;
                    return result;
                }

                RestClient client = new RestClient(Host + "/rest/api/alias/" + id);
                client.Timeout = 10000;
                var request = new RestRequest(Method.DELETE);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    result.StatusCode = statusCode;

                }
                else
                {
                    result = JsonSerializer.Deserialize<GenericResponse>(response.Content, options);
                }




                return result;

            }
            catch (Exception e)
            {

                return null;
            }

        }






        /// <summary>
        /// Send an SMS.
        /// </summary>
        /// <param name="from">Sender of the SMS.</param>
        /// <param name="to">Recipient The value must be a valid phone number including the international prefix, or a comma-separated list of numbers. One between this paramter and "group" Parameter must be set.</param>
        /// <param name="group">Recipient Group ID, or comma separated list of group IDs. One between this paramter and "to" Parameter must be set.</param>
        /// <param name="text">Text of the SMS. Required.</param>
        /// <param name="sendDate">Optional date for the scheduled SMS. The format must be yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name="transactionId">Optional custom transaction-ID. Max 60 characters.</param>
        /// <param name="sandbox">Set to true to test the function without sending the SMS.</param>
        /// <param name="statusCallback">Optional URL to be notified with the SMS Delivery.</param>
        /// <param name="encoding">Encoding to be used. Possible values: 7BIT, UCS2 or AUTO.</param>
        /// <returns>
        /// SendSmsResponse object with the result of the sending.
        /// </returns>
        public SendSmsResponse sendSms(
            string from,
            string to,
            string group,
            string text,
            string sendDate,
            string transactionId,
            bool? sandbox,
            string statusCallback,
            string encoding
            )
        {
            SendSmsResponse sendSmsResponse = new SendSmsResponse();

            String error = ValidationUtils.validateSendSms(from, to, group, text, sendDate, transactionId, sandbox, statusCallback, encoding, AuthKey, AuthSecret);
            if (error != null)
            {
                sendSmsResponse.StatusCode = (Errors.STATUS_CODE_BAD_REQUEST);
                sendSmsResponse.Message = error;
                return sendSmsResponse;
            }


            RestClient client = new RestClient(Host + "/rest/api/sms/send");
            client.Timeout = 10000;
            var request = new RestRequest( Method.POST);
            client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
            
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            if (from != null) { request.AddParameter("from", from); }
            if (to != null) { request.AddParameter("to", to); }
            if (group != null) { request.AddParameter("group", group); }
            if (text != null) { request.AddParameter("text", text); }
            if (sendDate != null) { request.AddParameter("date", sendDate); }
            if (transactionId != null) { request.AddParameter("transactionId", transactionId); }
            if (sandbox != null) { request.AddParameter("sandbox", sandbox.ToString()); }
            if (statusCallback != null) { request.AddParameter("statusCallback", statusCallback); }
            if (encoding != null) { request.AddParameter("encoding", encoding); }

            IRestResponse response = client.Execute(request);

            int statusCode = (int)response.StatusCode;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
                    {
                        new SmshUuidJsonConverter()
                    }
            };

            if (statusCode >= 200 && statusCode <= 299)
            {
                sendSmsResponse.StatusCode = statusCode;
                SmsResult smsResult = JsonSerializer.Deserialize<SmsResult>(response.Content, options);
                sendSmsResponse.SmsResult = smsResult;
            }
            else
            {
                sendSmsResponse = JsonSerializer.Deserialize<SendSmsResponse>(response.Content, options);
            }

            return sendSmsResponse;

        }



        /// <summary>
        /// Async send. Use this function to send SMS to 1000 or more recipients. 
        /// </summary>
        /// <param name="from">Sender of the SMS.</param>
        /// <param name="to">Recipient The value must be a valid phone number including the international prefix, or a comma-separated list of numbers. One between this paramter and "group" Parameter must be set.</param>
        /// <param name="group">Recipient Group ID, or comma separated list of group IDs. One between this paramter and "to" Parameter must be set.</param>
        /// <param name="text">Text of the SMS. Required.</param>
        /// <param name="sendDate">Optional date for the scheduled SMS. The format must be yyyy-MM-ddTHH:mm:ssZ.</param>
        /// <param name="transactionId">Optional custom transaction-ID. Max 60 characters.</param>
        /// <param name="sandbox">Set to true to test the function without sending the SMS.</param>
        /// <param name="statusCallback">Optional URL to be notified with the SMS Delivery.</param>
        /// <param name="transactionCallback">Optional URL to be notified with the general status of the sending.</param>
        /// <param name="encoding">Encoding to be used. Possible values: 7BIT, UCS2 or AUTO.</param>
        /// <returns>
        /// SendSmsResponse object with the result of the sending.
        /// </returns>
        public SendSmsBulkResponse sendSmsBulk(
            String from,
            String to,
            String group,
            String text,
            String sendDate,
            String transactionId,
            Boolean? sandbox,
            String statusCallback,
            String transactionCallback,
            String encoding)
        {
            try
            {

                SendSmsBulkResponse sendSmsBulkResponse = new SendSmsBulkResponse();

                String error = ValidationUtils.validateSendSms(from, to, group, text, sendDate, transactionId, sandbox, statusCallback, encoding, AuthKey, AuthSecret);
                if (error != null)
                {
                    sendSmsBulkResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    sendSmsBulkResponse.Message = error;
                    return sendSmsBulkResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/sms/sendbulk");
                client.Timeout = 10000;
                var request = new RestRequest(Method.POST);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (from != null) { request.AddParameter("from", from); }
                if (to != null) { request.AddParameter("to", to); }
                if (group != null) { request.AddParameter("group", group); }
                if (text != null) { request.AddParameter("text", text); }
                if (sendDate != null) { request.AddParameter("date", sendDate); }
                if (transactionId != null) { request.AddParameter("transactionId", transactionId); }
                if (sandbox != null) { request.AddParameter("sandbox", sandbox.ToString()); }
                if (statusCallback != null) { request.AddParameter("statusCallback", statusCallback); }
                if (transactionCallback != null) { request.AddParameter("transactionCallback", transactionCallback); }
                if (encoding != null) { request.AddParameter("encoding", encoding); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    sendSmsBulkResponse.StatusCode = statusCode;

                    SmsBulkResult smsBulkResult = JsonSerializer.Deserialize<SmsBulkResult>(response.Content, options);
                    sendSmsBulkResponse.SmsBulkResult = smsBulkResult;

                }
                else
                {
                    sendSmsBulkResponse = JsonSerializer.Deserialize<SendSmsBulkResponse>(response.Content, options);
                }

                return sendSmsBulkResponse;


            }
            catch (Exception e)
            {
                return null;
            }

        }


        /// <summary>
        /// Calculate the cost of an SMS campaign 
        /// </summary>
        /// <param name="from">Sender of the SMS.</param>
        /// <param name="to">Recipient The value must be a valid phone number including the international prefix, or a comma-separated list of numbers. One between this paramter and "group" Parameter must be set.</param>
        /// <param name="group">Recipient Group ID, or comma separated list of group IDs. One between this paramter and "to" Parameter must be set.</param>
        /// <param name="text">Text of the SMS. Required.</param>
        /// <param name="encoding">Encoding to be used. Possible values: 7BIT, UCS2 or AUTO.</param>
        /// <returns>
        /// EstimateResponse object with the estimate.
        /// </returns>
        public EstimateResponse estimateSendSms(
            String from,
            String to,
            String group,
            String text,
            String encoding)
        {
            try
            {

                EstimateResponse estimateResponse = new EstimateResponse();

                String error = ValidationUtils.validateEstimateSendSms(from, to, group, text, AuthKey, AuthSecret);
                if (error != null)
                {
                    estimateResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    estimateResponse.Message = error;
                    return estimateResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/sms/estimate");
                client.Timeout = 10000;
                var request = new RestRequest(Method.POST);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (from != null) { request.AddParameter("from", from); }
                if (to != null) { request.AddParameter("to", to); }
                if (group != null) { request.AddParameter("group", group); }
                if (text != null) { request.AddParameter("text", text); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };


                if (statusCode >= 200 && statusCode <= 299)
                {
                    estimateResponse.StatusCode = statusCode;
                    Estimate estimateResult = JsonSerializer.Deserialize<Estimate>(response.Content, options);
                    estimateResponse.Estimate = estimateResult;
                }
                else
                {
                    estimateResponse = JsonSerializer.Deserialize<EstimateResponse>(response.Content, options);
                }

                return estimateResponse;

            }
            catch (Exception e)
            {
                return null;
            }

        }




        /// <summary>
        /// Cancel a pending SMS
        /// </summary>
        /// <param name="id">ID of the SMS. One value between this and "transactionId" must be set.</param>
        /// <param name="transactionId">TransactionID of the SMS. One value between this and "id" must be set.</param>
        /// <returns>
        /// CancelSmsResponse  with the result of the call.
        /// </returns>
        /// 
        public CancelSmsResponse cancelSms(
                String id,
                String transactionId)
        {
            try
            {

                CancelSmsResponse cancelSmsResponse = new CancelSmsResponse();

                String error = ValidationUtils.validateCancelSms(id, transactionId, AuthKey, AuthSecret);
                if (error != null)
                {
                    cancelSmsResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    cancelSmsResponse.Message = error;
                    return cancelSmsResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/sms/cancel");
                client.Timeout = 10000;
                var request = new RestRequest(Method.POST);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (id != null) { request.AddParameter("id", id); }
                if (transactionId != null) { request.AddParameter("transactionId", transactionId); }


                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    cancelSmsResponse.StatusCode = statusCode;
                    ListSmsInfo listSmsInfo = JsonSerializer.Deserialize<ListSmsInfo>(response.Content, options);
                    cancelSmsResponse.SmsList = listSmsInfo;
                }
                else
                {
                    cancelSmsResponse = JsonSerializer.Deserialize<CancelSmsResponse>(response.Content, options);
                }

                return cancelSmsResponse;


            }
            catch (Exception e)
            {
                return null;
            }

        }




        /// <summary>
        /// Search and get details of the SMS.
        /// One parameters between "id","transactionId","msisdn","fromDate","status" must be set
        /// </summary>
        /// <param name="id">ID or comma-separated list of IDs.</param>
        /// <param name="transactionId">TransactionID associated with the sending.</param>
        /// <param name="msisdn">Recipient of the SMS</param>
        /// <param name="fromDate">Earliest sending date of the SMS.</param>
        /// <param name="toDate">Latter sending date of the SMS.</param>
        /// <param name="status">Status of the sms.</param>
        /// <param name="offset">Limit for pagination.g</param>
        /// <param name="limit">TransactionID associated with the sending</param>
        /// <returns>
        /// SmsSearchResponse with the result of the search.
        /// </returns>
        /// 
        public SmsSearchResponse searchSms(
            String id,
            String transactionId,
            String msisdn,
            String fromDate,
            String toDate,
            String status,
            Int64? offset,
            Int64? limit)
        {
            try
            {

                SmsSearchResponse smsSearchResponse = new SmsSearchResponse();

                String error = ValidationUtils.validateSearchSms(id, transactionId, msisdn, fromDate, toDate, status, AuthKey, AuthSecret);
                if (error != null)
                {
                    smsSearchResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    smsSearchResponse.Message = error;
                    return smsSearchResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/sms/search");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (id != null) { request.AddParameter("id", id); }
                if (transactionId != null) { request.AddParameter("transactionId", transactionId); }
                if (msisdn != null) { request.AddParameter("msisdn", msisdn); }
                if (fromDate != null) { request.AddParameter("fromDate", fromDate); }
                if (toDate != null) { request.AddParameter("toDate", toDate); }
                if (status != null) { request.AddParameter("status", status); }
                if (offset != null) { request.AddParameter("offset", offset); }
                if (limit != null) { request.AddParameter("limit", limit); }


                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    smsSearchResponse.StatusCode = statusCode;
                    SmsSearchResult smsSearchResult = JsonSerializer.Deserialize<SmsSearchResult>(response.Content, options);
                    smsSearchResponse.SmsSearchResult = smsSearchResult;

                }
                else
                {
                    smsSearchResponse = JsonSerializer.Deserialize<SmsSearchResponse>(response.Content, options);
                }

                return smsSearchResponse;

            }
            catch (Exception e)
            {
                return null;
            }

        }




        /// <summary>
        /// Retrieve a list of SMS received from the selected SIM
        /// One parameter between "from","simIdRef","fromDate","toDate" must be set.
        /// </summary>
        /// <param name="from">ID or comma-separated list of IDs.</param>
        /// <param name="simIdRef">TransactionID associated with the sending.</param>
        /// <param name="fromDate">Recipient of the SMS</param>
        /// <param name="toDate">Earliest sending date of the SMS.</param>
        /// <param name="offset">Latter sending date of the SMS.</param>
        /// <param name="limit">Status of the sms.</param>
        /// <returns>
        /// SmsReceivedSearchResponse with the result of the search.
        /// </returns>
        /// 

        public SmsReceivedSearchResponse searchSmsReceived(
                String from,
                String simIdRef,
                String fromDate,
                String toDate,
                Int64? offset,
                Int64? limit)
        {
            try
            {

                SmsReceivedSearchResponse smsReceivedSearchResponse = new SmsReceivedSearchResponse();

                String error = ValidationUtils.validateSearchSmsReceived(from, simIdRef, fromDate, toDate, offset, limit, AuthKey, AuthSecret);
                if (error != null)
                {
                    smsReceivedSearchResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    smsReceivedSearchResponse.Message = error;
                    return smsReceivedSearchResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/sms/received/search");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


                if (from != null) { request.AddParameter("from", from); }
                if (simIdRef != null) { request.AddParameter("simIdRef", simIdRef); }
                if (fromDate != null) { request.AddParameter("fromDate", fromDate); }
                if (toDate != null) { request.AddParameter("toDate", toDate); }
                if (offset != null) { request.AddParameter("offset", offset); }
                if (limit != null) { request.AddParameter("limit", limit); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };


                if (statusCode >= 200 && statusCode <= 299)
                {
                    smsReceivedSearchResponse.StatusCode = statusCode;
                    SmsReceivedResult smsReceivedResult = JsonSerializer.Deserialize<SmsReceivedResult>(response.Content, options);
                    smsReceivedSearchResponse.SmsReceivedResult = smsReceivedResult;
                }
                else
                {
                    smsReceivedSearchResponse = JsonSerializer.Deserialize<SmsReceivedSearchResponse>(response.Content, options);

                }

                return smsReceivedSearchResponse;

            }
            catch (Exception e)
            {
                return null;
            }

        }




        /// <summary>
        /// Retrieve the list of active forward services.
        /// </summary>
        /// <returns>
        /// SmsReceivedSearchResponseList with the result of the search.
        /// </returns>
        /// 
        public SmsReceivedSearchResponseList getSimForReceiveSmsList()
        {
            try
            {

                SmsReceivedSearchResponseList smsReceivedSearchResponseList = new SmsReceivedSearchResponseList();

                String error = ValidationUtils.validateGetSimForReceiveSmsList(AuthKey, AuthSecret);
                if (error != null)
                {
                    smsReceivedSearchResponseList.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    smsReceivedSearchResponseList.Message = error;
                    return smsReceivedSearchResponseList;
                }
                RestClient client = new RestClient(Host + "/rest/api/sms/received/sim/list");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };


                if (statusCode >= 200 && statusCode <= 299)
                {
                    smsReceivedSearchResponseList.StatusCode = statusCode;
                    ListSmsReceivedSimResponse listSmsReceivedSimResponse = JsonSerializer.Deserialize<ListSmsReceivedSimResponse>(response.Content, options);
                    smsReceivedSearchResponseList.SmsReceivedSimResponseList = listSmsReceivedSimResponse;
                }
                else
                {
                    smsReceivedSearchResponseList = JsonSerializer.Deserialize<SmsReceivedSearchResponseList>(response.Content, options);
                }

                return smsReceivedSearchResponseList;

            }
            catch (Exception e)
            {
                return null;
            }

        }




        /// <summary>
        /// Retrieve a list of the phonebook groups.
        /// </summary>
        /// <returns>
        /// GroupListResponse with the list of groups.
        /// </returns>
        /// 
        public GroupListResponse getGroupList()
        {
            try
            {

                GroupListResponse groupListResponse = new GroupListResponse();

                String error = ValidationUtils.validateGetGroupList(AuthKey, AuthSecret);
                if (error != null)
                {
                    groupListResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    groupListResponse.Message = error;
                    return groupListResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/phonebook/group/list");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    groupListResponse.StatusCode = statusCode;
                    ListGroup listGroup = JsonSerializer.Deserialize<ListGroup>(response.Content, options);
                    groupListResponse.GroupList = listGroup;
                }
                else
                {
                    groupListResponse = JsonSerializer.Deserialize<GroupListResponse>(response.Content, options);
                }

                return groupListResponse;

            }
            catch (Exception e)
            {

                return null;
            }

        }



        /// <summary>
        /// Retrieve the group with the specified ID
        /// </summary>
        /// <param name="id">Group ID. Required.</param>
        /// <returns>
        /// GroupResponse containing the required group detail.
        /// </returns>
        /// 
        public GroupResponse getGroup(String id)
        {
            try
            {

                GroupResponse groupResponse = new GroupResponse();

                String error = ValidationUtils.validateGetGroup(id, AuthKey, AuthSecret);
                if (error != null)
                {
                    groupResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    groupResponse.Message = error;
                    return groupResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/phonebook/group/" + id);
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    groupResponse.StatusCode = statusCode;
                    Group group = JsonSerializer.Deserialize<Group>(response.Content, options);
                    groupResponse.Group = group;
                }
                else
                {
                    groupResponse = JsonSerializer.Deserialize<GroupResponse>(response.Content, options);

                }

                return groupResponse;

            }
            catch (Exception e)
            {
                return null;
            }
        }




        /// <summary>
        /// Retrieve the contacts of a specified group
        /// </summary>
        /// <param name="id">Group ID. Required.</param>
        /// <param name="offset">Offset for pagination.</param>
        /// <param name="limit">Limit for pagination.</param>
        /// <returns>
        /// ContactSearchResponse containing the list of contacts.
        /// </returns>
        public ContactSearchResponse getGroupContacts(
                String id,
                Int64? offset,
                Int64? limit)
        {
            try
            {

                ContactSearchResponse contactSearchResponse = new ContactSearchResponse();

                String error = ValidationUtils.validateGetGroup(id, AuthKey, AuthSecret);
                if (error != null)
                {
                    contactSearchResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    contactSearchResponse.Message = error;
                    return contactSearchResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/phonebook/group/" + id + "/contacts");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (offset != null) { request.AddParameter("offset", offset); }
                if (limit != null) { request.AddParameter("offset", limit); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    contactSearchResponse.StatusCode = statusCode;
                    ContactSearchResult contactSearchResult = JsonSerializer.Deserialize<ContactSearchResult>(response.Content, options);
                    contactSearchResponse.ContactSearchResult = contactSearchResult;
                }
                else
                {
                    contactSearchResponse = JsonSerializer.Deserialize<ContactSearchResponse>(response.Content, options);

                }

                return contactSearchResponse;

            }
            catch (Exception e)
            {

                return null;
            }
        }





        /// <summary>
        /// Create a new group
        /// </summary>
        /// <param name="name">Name of the new group. Required.</param>
        /// <returns>
        /// GroupResponse containing the created group.
        /// </returns>
        public GroupResponse addGroup(
                String name)
        {
            try
            {

                GroupResponse groupResponse = new GroupResponse();

                String error = ValidationUtils.validateAddGroup(name, AuthKey, AuthSecret);
                if (error != null)
                {
                    groupResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    groupResponse.Message = error;
                    return groupResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/phonebook/group");
                client.Timeout = 10000;
                var request = new RestRequest(Method.POST);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (name != null) { request.AddParameter("name", name); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };


                if (statusCode >= 200 && statusCode <= 299)
                {
                    groupResponse.StatusCode = statusCode;
                    Group group = JsonSerializer.Deserialize<Group>(response.Content, options);
                    groupResponse.Group = group;

                }
                else
                {
                    groupResponse = JsonSerializer.Deserialize<GroupResponse>(response.Content, options);
                }
                return groupResponse;

            }
            catch (Exception e)
            {
                return null;
            }

        }





        /// <summary>
        /// Update the name of the specified group.
        /// </summary>
        /// <param name="id">Group ID. Required.</param>
        /// <param name="name">New name. Required.</param>
        /// <returns>
        /// GroupResponse containing the created group.
        /// </returns>
        public GroupResponse updateGroup(
                String id,
                String name)
        {
            try
            {

                GroupResponse groupResponse = new GroupResponse();

                String error = ValidationUtils.validateUpdateGroup(id, name, AuthKey, AuthSecret);
                if (error != null)
                {
                    groupResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    groupResponse.Message = error;
                    return groupResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/phonebook/group/" + id);
                client.Timeout = 10000;
                var request = new RestRequest(Method.PUT);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (name != null) { request.AddParameter("name", name); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                groupResponse.StatusCode = statusCode;

                if (statusCode >= 200 && statusCode <= 299)
                {
                    groupResponse.StatusCode = statusCode;
                    //Group group = JsonSerializer.Deserialize<Group>(response.Content, options);
                    //groupResponse.Group = group;

                }
                else
                {
                    groupResponse = JsonSerializer.Deserialize<GroupResponse>(response.Content, options);
                }
                return groupResponse;

            }
            catch (Exception e)
            {
                return null;
            }

        }




        /// <summary>
        /// Delete the specified group.
        /// </summary>
        /// <param name="id">Group ID. Required.</param>
        /// <param name="deleteContacts">Specify if the contacts of the group must be deleted or not. Default value False.</param>
        /// <returns>
        /// GenericResponse containing the result of the call.
        /// </returns>
        public GenericResponse deleteGroup(
                String id,
                Boolean? deleteContacts)
        {
            try
            {

                GenericResponse result = new GenericResponse();

                String error = ValidationUtils.validateDeleteGroup(id, AuthKey, AuthSecret);
                if (error != null)
                {
                    result.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    result.Message = error;
                    return result;
                }

                RestClient client = new RestClient(Host + "/rest/api/phonebook/group/" + id + "?delete_contacts=" + deleteContacts);
                client.Timeout = 10000;
                var request = new RestRequest(Method.DELETE);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };


                if (statusCode >= 200 && statusCode <= 299)
                {
                    result.StatusCode = statusCode;
                    //Group group = JsonSerializer.Deserialize<Group>(response.Content, options);
                    //groupResponse.Group = group;

                }
                else
                {
                    result = JsonSerializer.Deserialize<GenericResponse>(response.Content, options);
                }

                return result;

            }
            catch (Exception e)
            {
                return null;
            }

        }



        /// <summary>
        /// Search contacts.
        /// If no search parameter is set the call will return a paginated list of all contacts.
        /// </summary>
        /// <param name="name">Name or surname of the contact.</param>
        /// <param name="msisdn">Phone number of the contact.</param>
        /// <param name="fieldKey">Custom field Key.</param>
        /// <param name="fieldValue">Custom field value.</param>
        /// <param name="email">Email of the contact.</param>
        /// <param name="offset">Offset for pagination.</param>
        /// <param name="limit">Limit for pagination.</param>
        /// <returns>
        /// GenericResponse containing the result of the call.
        /// </returns>
        public ContactSearchResponse searchContacts(
                String name,
                String msisdn,
                String fieldKey,
                String fieldValue,
                String email,
                Int64? offset,
                Int64? limit)
        {
            try
            {

                ContactSearchResponse contactSearchResponse = new ContactSearchResponse();

                String error = ValidationUtils.validateSearchContacts(msisdn, fieldKey, fieldValue, email, AuthKey, AuthSecret);
                if (error != null)
                {
                    contactSearchResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    contactSearchResponse.Message = error;
                    return contactSearchResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/phonebook/contact/search");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


                if (name != null) { request.AddParameter("name", name); }
                if (msisdn != null) { request.AddParameter("msisdn", msisdn); }
                if ((fieldKey != null) && (fieldValue != null))
                {
                    request.AddParameter("fieldKey", fieldKey);
                    request.AddParameter("fieldValue", fieldValue);
                }
                if (email != null) { request.AddParameter("email", email); }
                if (offset != null) { request.AddParameter("offset", offset); }
                if (limit != null) { request.AddParameter("limit", limit); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };


                if (statusCode >= 200 && statusCode <= 299)
                {
                    contactSearchResponse.StatusCode = statusCode;
                    ContactSearchResult contactSearchResult = JsonSerializer.Deserialize<ContactSearchResult>(response.Content, options);
                    contactSearchResponse.ContactSearchResult = contactSearchResult;

                }
                else
                {
                    contactSearchResponse = JsonSerializer.Deserialize<ContactSearchResponse>(response.Content, options);

                }

                return contactSearchResponse;

            }
            catch (Exception e)
            {

                return null;
            }

        }





        /// <summary>
        /// Retrieve the specified contact
        /// </summary>
        /// <param name="id">Contact ID. Required.</param>
        /// <returns>
        /// ContactResponse containing requested contact.
        /// </returns>
        public ContactResponse getContact(
                String id)
        {
            try
            {
                ContactResponse contactResponse = new ContactResponse();

                String error = ValidationUtils.validateGetContact(id, AuthKey, AuthSecret);
                if (error != null)
                {
                    contactResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    contactResponse.Message = error;
                    return contactResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/phonebook/contact/" + id);
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    contactResponse.StatusCode = statusCode;
                    Contact contact = JsonSerializer.Deserialize<Contact>(response.Content, options);
                    contactResponse.Contact = contact;

                }
                else
                {
                    contactResponse = JsonSerializer.Deserialize<ContactResponse>(response.Content, options);
                }

                return contactResponse;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Create a new contact
        /// </summary>
        /// <param name="msisdn">Phone number of the contact. </param>
        /// <param name="name">Name of the contact. Required.</param>
        /// <param name="lastname">Last Name of the contact.</param>
        /// <param name="email">Email of the contact.</param>
        /// <param name="groupsId">ID of groups in which the contact must be included.</param>
        /// <param name="customFields">Map of Key/Value of custom fields.</param>
        /// <param name="customFieldUniqueKey">Field to use as unique value to identify a duplicate contact. Possible values are msisdn, email, name, lastname or any of the custom fields key. Default value: msisdn.</param>
        /// <returns>
        /// ContactResponse containing the created contact.
        /// </returns>
        public ContactResponse addContact(String msisdn,
                String name,
                String lastname,
                String email,
                String groupsId,
                Dictionary<string, string> customFields,
                String customFieldUniqueKey)
        {
            try
            {

                ContactResponse contactResponse = new ContactResponse();

                String error = ValidationUtils.validateAddContact(name, groupsId, customFieldUniqueKey, AuthKey, AuthSecret);
                if (error != null)
                {
                    contactResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    contactResponse.Message = error;
                    return contactResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/phonebook/contact");
                client.Timeout = 10000;
                var request = new RestRequest(Method.POST);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");


                if (msisdn != null) { request.AddParameter("msisdn", msisdn); }
                if (name != null) { request.AddParameter("name", name); }
                if (lastname != null) { request.AddParameter("lastname", lastname); }
                if (email != null) { request.AddParameter("email", email); }
                if (groupsId != null) { request.AddParameter("groupsId", groupsId); }
                if (customFieldUniqueKey != null) { request.AddParameter("customFieldUniqueKey", customFieldUniqueKey); }
                if (customFields != null)
                {
                    foreach (var pair in customFields)
                    {
                        request.AddParameter(pair.Key, pair.Value);
                    }
                }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    contactResponse.StatusCode = statusCode;
                    Contact contact = JsonSerializer.Deserialize<Contact>(response.Content, options);
                    contactResponse.Contact = contact;

                }
                else
                {
                    contactResponse = JsonSerializer.Deserialize<ContactResponse>(response.Content, options);
                }
                return contactResponse;

            }
            catch (Exception e)
            {

                return null;
            }

        }






        /// <summary>
        /// Update the specified contact
        /// </summary>
        /// <param name="id">ID of the contact to update. Required.</param>
        /// <param name="msisdn">New phone number.  </param>
        /// <param name="name">New name.</param>
        /// <param name="lastname">New Last Name.</param>
        /// <param name="email">New email.</param>
        /// <param name="groupsId">New groups ids in which the contact must be included.</param>
        /// <param name="customFields">New CustomField.</param>
        /// <returns>
        /// ContactResponse containing the created contact.
        /// </returns>
        public ContactResponse updateContact(
                String id,
                String msisdn,
                String name,
                String lastname,
                String email,
                String groupsId,
                Dictionary<string, string> customFields)
        {
            try
            {

                ContactResponse contactResponse = new ContactResponse();

                String error = ValidationUtils.validateUpdateContact(id, AuthKey, AuthSecret);
                if (error != null)
                {
                    contactResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    contactResponse.Message = error;
                    return contactResponse;
                }


                RestClient client = new RestClient(Host + "/rest/api/phonebook/contact/" + id);
                client.Timeout = 10000;
                var request = new RestRequest(Method.PUT);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (msisdn != null) { request.AddParameter("msisdn", msisdn); }
                if (name != null) { request.AddParameter("name", name); }
                if (lastname != null) { request.AddParameter("lastname", lastname); }
                if (email != null) { request.AddParameter("email", email); }
                if (groupsId != null) { request.AddParameter("groupsId", groupsId); }

                if (customFields != null)
                {
                    foreach (var pair in customFields)
                    {
                        request.AddParameter(pair.Key, pair.Value);
                    }
                }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    contactResponse.StatusCode = statusCode;
                    //Contact contact = JsonSerializer.Deserialize<Contact>(response.Content, options);
                    //contactResponse.Contact = contact;

                }
                else
                {
                    contactResponse = JsonSerializer.Deserialize<ContactResponse>(response.Content, options);
                }
                return contactResponse;

            }
            catch (Exception e)
            {
                return null;
            }

        }





        /// <summary>
        /// Delete a contact.
        /// </summary>
        /// <param name="id">Contact ID. Required.</param>
        /// <returns>
        /// GenericResponse containing the result of the api call.
        /// </returns>
        public GenericResponse deleteContact(
                String id)
        {
            try
            {

                GenericResponse result = new GenericResponse();

                String error = ValidationUtils.validateDeleteContact(id, AuthKey, AuthSecret);
                if (error != null)
                {
                    result.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    result.Message = error;
                    return result;
                }

                RestClient client = new RestClient(Host + "/rest/api/phonebook/contact/" + id);
                client.Timeout = 10000;
                var request = new RestRequest(Method.DELETE);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };


                if (statusCode >= 200 && statusCode <= 299)
                {
                    result.StatusCode = statusCode;
                    //Contact contact = JsonSerializer.Deserialize<Contact>(response.Content, options);
                    //contactResponse.Contact = contact;

                }
                else
                {
                    result = JsonSerializer.Deserialize<GenericResponse>(response.Content, options);
                }


                return result;

            }
            catch (Exception e)
            {
                return null;
            }

        }





        /// <summary>
        /// Get enabled email senders. This is a Premium Plan feature and needs a special permission.
        /// </summary>
        /// <returns>
        /// EmailSenderResponse containing the senders list.
        /// </returns>
        public EmailSenderResponse getEmailSenderList()
        {
            try
            {

                EmailSenderResponse emailSenderResponse = new EmailSenderResponse();

                String error = ValidationUtils.validateGetEmailSenderList(AuthKey, AuthSecret);
                if (error != null)
                {
                    emailSenderResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    emailSenderResponse.Message = error;
                    return emailSenderResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/email/sender/list");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    emailSenderResponse.StatusCode = statusCode;
                    ListEmailSender listEmailSender = JsonSerializer.Deserialize<ListEmailSender>(response.Content, options);
                    emailSenderResponse.EmailSenderList = listEmailSender;

                }
                else
                {
                    emailSenderResponse = JsonSerializer.Deserialize<EmailSenderResponse>(response.Content, options);
                }

                return emailSenderResponse;

            }
            catch (Exception e)
            {

                return null;
            }
        }




        /// <summary>
        /// Get available email templates. This is a Premium Plan feature and needs a special permission.
        /// </summary>
        /// <param name="offset">Offset value for pagination. </param>
        /// <param name="limit">Limit value for pagination.</param>
        /// <returns>
        /// EmailTemplatesListResponse containing the templates list.
        /// </returns>
        public EmailTemplatesListResponse getEmailTemplatesList(
                Int64? offset,
                Int64? limit)
        {
            try
            {

                EmailTemplatesListResponse emailTemplatesResponse = new EmailTemplatesListResponse();

                String error = ValidationUtils.validateGetEmailTemplatesList(AuthKey, AuthSecret);
                if (error != null)
                {
                    emailTemplatesResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    emailTemplatesResponse.Message = error;
                    return emailTemplatesResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/email/template/list");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (offset != null) { request.AddParameter("offset", offset); }
                if (limit != null) { request.AddParameter("limit", limit); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };


                if (statusCode >= 200 && statusCode <= 299)
                {
                    emailTemplatesResponse.StatusCode = statusCode;
                    EmailTemplatesResult emailTemplatesResult = JsonSerializer.Deserialize<EmailTemplatesResult>(response.Content, options);
                    emailTemplatesResponse.EmailTemplatesResult = emailTemplatesResult;

                }
                else
                {
                    emailTemplatesResponse = JsonSerializer.Deserialize<EmailTemplatesListResponse>(response.Content, options);
                }

                return emailTemplatesResponse;

            }
            catch (Exception e)
            {
                return null;
            }
        }




        /// <summary>
        /// Get template details. This is a Premium Plan feature and needs a special permission.
        /// </summary>
        /// <param name="id">Template ID. </param>
        /// <returns>
        /// EmailTemplateResponse containing the template details.
        /// </returns>
        public EmailTemplateResponse getEmailTemplate(
                String id)
        {
            try
            {

                EmailTemplateResponse emailTemplateResponse = new EmailTemplateResponse();

                String error = ValidationUtils.validateGetEmailTemplate(id, AuthKey, AuthSecret);
                if (error != null)
                {
                    emailTemplateResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    emailTemplateResponse.Message = error;
                    return emailTemplateResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/email/template/" + id);
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    emailTemplateResponse.StatusCode = statusCode;
                    EmailTemplate emailTemplate = JsonSerializer.Deserialize<EmailTemplate>(response.Content, options);
                    emailTemplateResponse.EmailTemplate = emailTemplate;

                }
                else
                {
                    emailTemplateResponse = JsonSerializer.Deserialize<EmailTemplateResponse>(response.Content, options);
                }


                return emailTemplateResponse;

            }
            catch (Exception e)
            {
                return null;
            }
        }






        /// <summary>
        /// Get email campaigns. This is a Premium Plan feature and needs a special permission.
        /// </summary>
        /// <param name="offset">Offset value for pagination.  </param>
        /// <param name="limit">Limit value for pagination. </param>
        /// <returns>
        /// EmailCampaignsListResponse containing the campaigns list.
        /// </returns>
        public EmailCampaignsListResponse getEmailCampaignsList(
                Int64? offset,
                Int64? limit)
        {
            try
            {

                EmailCampaignsListResponse emailCampaignsListResponse = new EmailCampaignsListResponse();

                String error = ValidationUtils.validateGetEmailCampaignsList(AuthKey, AuthSecret);
                if (error != null)
                {
                    emailCampaignsListResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    emailCampaignsListResponse.Message = error;
                    return emailCampaignsListResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/email/campaign/list");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (offset != null) { request.AddParameter("offset", offset); }
                if (limit != null) { request.AddParameter("limit", limit); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    emailCampaignsListResponse.StatusCode = statusCode;
                    EmailCampaignsResult emailCampaignsResult = JsonSerializer.Deserialize<EmailCampaignsResult>(response.Content, options);
                    emailCampaignsListResponse.EmailCampaignsResult = emailCampaignsResult;

                }
                else
                {
                    emailCampaignsListResponse = JsonSerializer.Deserialize<EmailCampaignsListResponse>(response.Content, options);
                }


                return emailCampaignsListResponse;

            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// Get Campaign details. This is a Premium Plan feature and needs a special permission.
        /// </summary>
        /// <param name="id">Campaign ID. </param>
        /// <returns>
        /// EmailCampaignResponse containing the campaign details.
        /// </returns>
        public EmailCampaignResponse getEmailCampaign(
                String id)
        {
            try
            {

                EmailCampaignResponse emailCampaignResponse = new EmailCampaignResponse();

                String error = ValidationUtils.validateGetEmailCampaign(id, AuthKey, AuthSecret);
                if (error != null)
                {
                    emailCampaignResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    emailCampaignResponse.Message = error;
                    return emailCampaignResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/email/campaign/" + id);
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    emailCampaignResponse.StatusCode = statusCode;
                    EmailCampaign emailCampaign = JsonSerializer.Deserialize<EmailCampaign>(response.Content, options);
                    emailCampaignResponse.EmailCampaign = emailCampaign;

                }
                else
                {
                    emailCampaignResponse = JsonSerializer.Deserialize<EmailCampaignResponse>(response.Content, options);
                }



                return emailCampaignResponse;

            }
            catch (Exception e)
            {
                return null;
            }
        }





        /// <summary>
        /// Get email details. This is a Premium Plan feature and needs a special permission.
        /// </summary>
        /// <param name="id">Email ID </param>
        /// <returns>
        /// EmailResponse containing the email details.
        /// </returns>
        public EmailResponse getEmail(
                String id)
        {
            try
            {

                EmailResponse emailResponse = new EmailResponse();

                String error = ValidationUtils.validateGetEmail(id, AuthKey, AuthSecret);
                if (error != null)
                {
                    emailResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    emailResponse.Message = error;
                    return emailResponse;
                }


                RestClient client = new RestClient(Host + "/rest/api/email/" + id);
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    emailResponse.StatusCode = statusCode;
                    Email email = JsonSerializer.Deserialize<Email>(response.Content, options);
                    emailResponse.Email = email;

                }
                else
                {
                    emailResponse = JsonSerializer.Deserialize<EmailResponse>(response.Content, options);
                }



                return emailResponse;

            }
            catch (Exception e)
            {
                return null;
            }
        }



        /// <summary>
        /// Send an email campaign. This is a Premium Plan feature and needs a special permission.
        /// </summary>
        /// <param name="templateId">template ID. Required.</param>
        /// <param name="from">email Sender. Must be verified in the web platform. Required.</param>
        /// <param name="fromName">sender Name.</param>
        /// <param name="group">recipients group ID. Required.</param>
        /// <param name="subject">email Subject. Required.</param>
        /// <param name="subjectPreviewText">email Subject preview text.</param>
        /// <param name="campaignTitle">Campaign title. Required.</param>
        /// <param name="enableOpenTracking">enable / disable the open tracking.</param>
        /// <param name="enableLinkTracking">enable / disable the link tracking.</param>
        /// <param name="date">Optional date for the schedule sending. The date format must be yyyy-MM-dd'T'HH:mm:ssZ</param>
        /// <param name="sandbox">Optional sandbox parameter to test the function without sending the email.</param>
        /// 
        /// <returns>
        /// SendEmailCampaignResponse containing the sending result.
        /// </returns>
        public SendEmailCampaignResponse sendEmailCampaign(
                String templateId,
                String from,
                String fromName,
                String group,
                String subject,
                String subjectPreviewText,
                String campaignTitle,
                Boolean? enableOpenTracking,
                Boolean? enableLinkTracking,
                String date,
                Boolean? sandbox)
        {
            try
            {

                SendEmailCampaignResponse sendEmailCampaignResponse = new SendEmailCampaignResponse();

                String error = ValidationUtils.validateSendEmailCampaign(templateId, from, group, subject, campaignTitle, date, AuthKey, AuthSecret);
                if (error != null)
                {
                    sendEmailCampaignResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    sendEmailCampaignResponse.Message = error;
                    return sendEmailCampaignResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/email/campaign/send");
                client.Timeout = 10000;
                var request = new RestRequest(Method.POST);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (templateId != null) { request.AddParameter("templateId", templateId); }
                if (from != null) { request.AddParameter("from", from); }
                if (fromName != null) { request.AddParameter("fromName", fromName); }
                if (group != null) { request.AddParameter("group", group); }
                if (subject != null) { request.AddParameter("subject", subject); }
                if (subjectPreviewText != null) { request.AddParameter("subjectPreviewText", subjectPreviewText); }
                if (campaignTitle != null) { request.AddParameter("campaignTitle", campaignTitle); }
                if (enableOpenTracking != null) { request.AddParameter("enableOpenTracking", enableOpenTracking); }
                if (enableLinkTracking != null) { request.AddParameter("enableLinkTracking", enableLinkTracking); }
                if (date != null) { request.AddParameter("date", date); }
                if (sandbox != null) { request.AddParameter("sandbox", sandbox); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };
                Console.WriteLine("ros:" + response.Content);
                if (statusCode >= 200 && statusCode <= 299)
                {
                    sendEmailCampaignResponse.StatusCode = statusCode;
                    EmailResult emailResult = JsonSerializer.Deserialize<EmailResult>(response.Content, options);
                    sendEmailCampaignResponse.EmailResult = emailResult;

                }
                else
                {
                    sendEmailCampaignResponse = JsonSerializer.Deserialize<SendEmailCampaignResponse>(response.Content, options);
                }



                return sendEmailCampaignResponse;

            }
            catch (Exception e)
            {
                return null;
            }
        }




        /// <summary>
        /// Send a single email. This is a Premium Plan feature and needs a special permission.
        /// </summary>
        /// <param name="templateId">template ID. Required.</param>
        /// <param name="from">email Sender. Must be verified in the web platform. Required.</param>
        /// <param name="fromName">sender Name.</param>
        /// <param name="to">recipient email or json containing at most 50 emails. Json format: [{'to':'ms.green@fake.it','f_s_nome':'Ms Green'},{'to':'mr.yellow@fake.it','f_s_nome':'John Yellow'}]. Required.</param>
        /// <param name="subject">email Subject. Required.</param>
        /// <param name="subjectPreviewText">email Subject preview text.</param>
        /// <param name="enableOpenTracking">enable / disable the open tracking.</param>
        /// <param name="enableLinkTracking">enable / disable the link tracking.</param>
        /// <param name="date">Optional date for the schedule sending. The date format must be yyyy-MM-dd'T'HH:mm:ssZ</param>
        /// <param name="sandbox">Optional sandbox parameter to test the function without sending the email.</param>
        /// 
        /// <returns>
        /// SendEmailCampaignResponse containing the sending result.
        /// </returns>
        public SendEmailCampaignResponse sendSingleEmail(
                String templateId,
                String from,
                String fromName,
                String to,
                String subject,
                String subjectPreviewText,
                Boolean? enableOpenTracking,
                Boolean? enableLinkTracking,
                String date,
                Boolean? sandbox)
        {
            try
            {

                SendEmailCampaignResponse sendEmailCampaignResponse = new SendEmailCampaignResponse();

                String error = ValidationUtils.validateSendSingleEmail(templateId, from, to, subject, date, AuthKey, AuthSecret);
                if (error != null)
                {
                    sendEmailCampaignResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    sendEmailCampaignResponse.Message = error;
                    return sendEmailCampaignResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/email/send");
                client.Timeout = 10000;
                var request = new RestRequest(Method.POST);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                if (templateId != null) { request.AddParameter("templateId", templateId); }
                if (from != null) { request.AddParameter("from", from); }
                if (fromName != null) { request.AddParameter("fromName", fromName); }
                if (to != null) { request.AddParameter("to", to); }
                if (subject != null) { request.AddParameter("subject", subject); }
                if (subjectPreviewText != null) { request.AddParameter("subjectPreviewText", subjectPreviewText); }
                if (enableOpenTracking != null) { request.AddParameter("enableOpenTracking", enableOpenTracking); }
                if (enableLinkTracking != null) { request.AddParameter("enableLinkTracking", enableLinkTracking); }
                if (date != null) { request.AddParameter("date", date); }
                if (sandbox != null) { request.AddParameter("sandbox", sandbox); }

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    sendEmailCampaignResponse.StatusCode = statusCode;
                    EmailResult emailResult = JsonSerializer.Deserialize<EmailResult>(response.Content, options);
                    sendEmailCampaignResponse.EmailResult = emailResult;

                }
                else
                {
                    sendEmailCampaignResponse = JsonSerializer.Deserialize<SendEmailCampaignResponse>(response.Content, options);
                }


                return sendEmailCampaignResponse;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }



        /// <summary>
        /// Retrieve the Smshosting user informations.
        /// </summary>
        /// <returns>
        /// UserResponse containing the user details.
        /// </returns>
        public UserResponse getUser()
        {
            try
            {


                UserResponse userResponse = new UserResponse();

                String error = ValidationUtils.validateGetUser(AuthKey, AuthSecret);
                if (error != null)
                {
                    userResponse.StatusCode = Errors.STATUS_CODE_BAD_REQUEST;
                    userResponse.Message = error;
                    return userResponse;
                }

                RestClient client = new RestClient(Host + "/rest/api/user");
                client.Timeout = 10000;
                var request = new RestRequest(Method.GET);
                client.Authenticator = new HttpBasicAuthenticator(AuthKey, AuthSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                int statusCode = (int)response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                        {
                            new SmshUuidJsonConverter()
                        }
                };

                if (statusCode >= 200 && statusCode <= 299)
                {
                    userResponse.StatusCode = statusCode;
                    User user = JsonSerializer.Deserialize<User>(response.Content, options);
                    userResponse.User = user;

                }
                else
                {
                    userResponse = JsonSerializer.Deserialize<UserResponse>(response.Content, options);
                }



                return userResponse;

            }
            catch (Exception e)
            {

                return null;
            }

        }



    }
}

