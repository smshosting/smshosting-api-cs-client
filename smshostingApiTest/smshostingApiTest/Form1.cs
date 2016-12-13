using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unirest_net.http;
using System.Web;
using Newtonsoft.Json;

namespace smshostingApiTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bGetUser_Click(object sender, EventArgs e)
        {
            HttpResponse<String> jsonResponse = Unirest.get(tbUserUrl.Text)
                .header("accept", tbUserAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .asString();
            tbUserResult.Text = format_text(jsonResponse.Body, tbUserAccept.Text);
        }

        private void bOtpSendPost_Click(object sender, EventArgs e)
        {
            String body = "";
            body = body + "&text=" + HttpUtility.UrlEncode(tbOtpSendText.Text);
            body = body + "&to=" + HttpUtility.UrlEncode(tbOtpSendTo.Text);
            body = body + "&from=" + HttpUtility.UrlEncode(tbOtpSendFrom.Text);
            body = body + "&sandbox=" + cbOtpSendSandbox.Checked;
            body = body + "&app_id=" + HttpUtility.UrlEncode(tbOtpSendAppId.Text);
            body = body + "&encoding=" + HttpUtility.UrlEncode(cbOtpSendEncoding.Text);
            body = body + "&code_len=" + HttpUtility.UrlEncode(tbOtpSendCodLen.Text);
            body = body + "&max_retry=" + HttpUtility.UrlEncode(tbOtpSendMaxRetry.Text);
            body = body + "&ttl=" + HttpUtility.UrlEncode(tbOtpSendTtl.Text);
            HttpResponse<String> jsonResponse = Unirest.post(tbOtpSendUrl.Text)
                .header("Content-Type", "application/x-www-form-urlencoded")
                .header("Accept", tbOtpSendAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .body(body)
                .asString();

            tbSendResult.Text = format_text(jsonResponse.Body, tbOtpSendAccept.Text);


        }




        private void bOtpCheckGet_Click(object sender, EventArgs e)
        {
            String queryString = "?";
            queryString = queryString + "&verify_id=" + HttpUtility.UrlEncode(tbOtpCheckVerifyId.Text);
            queryString = queryString + "&verify_code=" + HttpUtility.UrlEncode(tbOtpCheckCode.Text);
            queryString = queryString + "&ip_address=" + HttpUtility.UrlEncode(tbOtpCheckIp.Text);
            HttpResponse<String> jsonResponse = Unirest.get(tbOtpCheckUrl.Text + queryString)
                .header("accept", tbOtpCheckAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .asString();
            tbCheckResult.Text = format_text(jsonResponse.Body, tbOtpCheckAccept.Text);
        }

        private void bOtpSearchGet_Click(object sender, EventArgs e)
        {
            String queryString = "?";
            queryString = queryString + "&verify_id=" + HttpUtility.UrlEncode(tbOtpSearchVerifyId.Text);
            HttpResponse<String> jsonResponse = Unirest.get(tbOtpSearchUrl.Text + queryString)
                .header("accept", cbOtpSearchAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .asString();
            tbSearchResult.Text = format_text(jsonResponse.Body, cbOtpSearchAccept.Text);
        }

        private void bOtpCommandPost_Click(object sender, EventArgs e)
        {
            String body = "";
            body = body + "&verify_id=" + HttpUtility.UrlEncode(tbOtpCommandVerifyId.Text);
            body = body + "&command=" + HttpUtility.UrlEncode(tbOtpCommandCommand.Text);
            HttpResponse<String> jsonResponse = Unirest.post(tbOtpCommandUrl.Text)
                .header("Content-Type", "application/x-www-form-urlencoded")
                .header("Accept", tbOtpCommandAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .body(body)
                .asString();
            tbCommandResult.Text = format_text(jsonResponse.Body, tbOtpCommandAccept.Text);
        }

        private void bSmsSearchGET_Click(object sender, EventArgs e)
        {
            String queryString = "?";
            queryString = queryString + "&id=" + HttpUtility.UrlEncode(tbSmsSearchId.Text);
            queryString = queryString + "&transactionId=" + HttpUtility.UrlEncode(tbSmsSearchTransactionId.Text);
            queryString = queryString + "&msisdn=" + HttpUtility.UrlEncode(tbSmsSearchMsisdn.Text);
            queryString = queryString + "&fromDate=" + HttpUtility.UrlEncode(tbSmsSearchFromDate.Text);
            queryString = queryString + "&toDate=" + HttpUtility.UrlEncode(tbSmsSearchToDate.Text);
            queryString = queryString + "&status=" + HttpUtility.UrlEncode(tbSmsSearchStatus.Text);
            queryString = queryString + "&offset=" + HttpUtility.UrlEncode(tbSmsSearchOffset.Text);
            queryString = queryString + "&limit=" + HttpUtility.UrlEncode(tbSmsSearchLimit.Text);
            HttpResponse<String> jsonResponse = Unirest.get(tbSmsSearchUrl.Text + queryString)
                .header("accept", cbSmsSearchAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .asString();

            tbSmsSearchResult.Text = format_text(jsonResponse.Body, cbSmsSearchAccept.Text);



        }

        private void bSmsSendPost_Click_1(object sender, EventArgs e)
        {
            String body = "";
            body = body + "&from=" + HttpUtility.UrlEncode(tbSmsSendFrom.Text);
            body = body + "&to=" + HttpUtility.UrlEncode(tbSmsSendTo.Text);
            body = body + "&group=" + HttpUtility.UrlEncode(tbSmsSendGroup.Text);
            body = body + "&text=" + HttpUtility.UrlEncode(tbSmsSendText.Text);
            body = body + "&date=" + HttpUtility.UrlEncode(tbSmsSendDate.Text);
            body = body + "&transactionId=" + HttpUtility.UrlEncode(tbSmsSendTransaction.Text);
            body = body + "&sandbox=" + tbSmsSendSandbox.Checked;
            body = body + "&statusCallback=" + HttpUtility.UrlEncode(tbSmsSendCallback.Text);
            body = body + "&encoding=" + HttpUtility.UrlEncode(tbSmsSendEncoding.Text);



            HttpResponse<String> jsonResponse = Unirest.post(tbSmsSendUrl.Text)
                .header("Content-Type", "application/x-www-form-urlencoded")
                .header("Accept", tbSmsSendAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .body(body)
                .asString();
            tbSmsSendResult.Text = format_text(jsonResponse.Body, tbSmsSendAccept.Text);
        }


        private static string format_json(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        private static string format_xml(string xml)
        {

            return System.Xml.Linq.XDocument.Parse(xml).ToString();
        }


        private static string format_text(string response, string format)
        {
            string ris = "";
            try
            {
                if (format == "application/json")
                {
                    ris = format_json(response);
                }
                else if (format == "application/xml")
                {
                    ris = format_xml(response);
                }
                else
                {
                    ris = response;
                }
            }
            catch (Exception ex)
            {
                ris= response;
            }
            return ris;
        }

        private void bSmsSendbulkPost_Click(object sender, EventArgs e)
        {
            String body = "";
            body = body + "&from=" + HttpUtility.UrlEncode(tbSmsSendbulkFrom.Text);
            body = body + "&to=" + HttpUtility.UrlEncode(tbSmsSendbulkTo.Text);
            body = body + "&group=" + HttpUtility.UrlEncode(tbSmsSendbulkGroup.Text);
            body = body + "&text=" + HttpUtility.UrlEncode(tbSmsSendbulkText.Text);
            body = body + "&date=" + HttpUtility.UrlEncode(tbSmsSendbulkDate.Text);
            body = body + "&transactionId=" + HttpUtility.UrlEncode(tbSmsSendbulkTransaction.Text);
            body = body + "&sandbox=" + tbSmsSendbulkSandbox.Checked;
            body = body + "&statusCallback=" + HttpUtility.UrlEncode(tbSmsSendbulkCallback.Text);
            body = body + "&encoding=" + HttpUtility.UrlEncode(tbSmsSendbulkEncoding.Text);

            HttpResponse<String> jsonResponse = Unirest.post(tbSmsSendbulkUrl.Text)
                .header("Content-Type", "application/x-www-form-urlencoded")
                .header("Accept", tbSmsSendbulkAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .body(body)
                .asString();
            tbSmsSendbulkResult.Text = format_text(jsonResponse.Body, tbSmsSendbulkAccept.Text);
        }

        private void bSmsEstimatePost_Click(object sender, EventArgs e)
        {
            String body = "";
            body = body + "&from=" + HttpUtility.UrlEncode(tbSmsEstimateFrom.Text);
            body = body + "&to=" + HttpUtility.UrlEncode(tbSmsEstimateTo.Text);
            body = body + "&group=" + HttpUtility.UrlEncode(tbSmsEstimateGroup.Text);
            body = body + "&text=" + HttpUtility.UrlEncode(tbSmsEstimateText.Text);
            body = body + "&encoding=" + HttpUtility.UrlEncode(tbSmsEstimateEncoding.Text);

            HttpResponse<String> jsonResponse = Unirest.post(tbSmsEstimateUrl.Text)
                .header("Content-Type", "application/x-www-form-urlencoded")
                .header("Accept", tbSmsEstimateAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .body(body)
                .asString();
            tbSmsEstimateResult.Text = format_text(jsonResponse.Body, tbSmsEstimateAccept.Text);
        }

        private void bSmsCancelPost_Click(object sender, EventArgs e)
        {
            String body = "";
            body = body + "&id=" + HttpUtility.UrlEncode(tbSmsCancelId.Text);
            body = body + "&transactionId=" + HttpUtility.UrlEncode(tbSmsCancelTransaction.Text);

            HttpResponse<String> jsonResponse = Unirest.post(tbSmsCancelUrl.Text)
                .header("Content-Type", "application/x-www-form-urlencoded")
                .header("Accept", tbSmsCancelAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .body(body)
                .asString();
            tbSmsCancelResult.Text = format_text(jsonResponse.Body, tbSmsCancelAccept.Text);
        }

        private void bSmsRecvSearchGet_Click(object sender, EventArgs e)
        {
            String queryString = "?";
            queryString = queryString + "&from=" + HttpUtility.UrlEncode(tbSmsRecvSearchFrom.Text);
            queryString = queryString + "&simRefId=" + HttpUtility.UrlEncode(tbSmsRecvSearchSimRefId.Text);
            queryString = queryString + "&fromDate=" + HttpUtility.UrlEncode(tbSmsRecvSearchFromDate.Text);
            queryString = queryString + "&toDate=" + HttpUtility.UrlEncode(tbSmsRecvSearchToDate.Text);
            queryString = queryString + "&offset=" + HttpUtility.UrlEncode(tbSmsRecvSearchOffset.Text);
            queryString = queryString + "&limit=" + HttpUtility.UrlEncode(tbSmsRecvSearchLimit.Text);
            HttpResponse<String> jsonResponse = Unirest.get(tbSmsRecvSearchUrl.Text + queryString)
                .header("accept", tbSmsRecvSearchAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .asString();

            tbSmsRecvSearchResult.Text = format_text(jsonResponse.Body, tbSmsRecvSearchAccept.Text);



        }

        private void bSimListGet_Click(object sender, EventArgs e)
        {
            HttpResponse<String> jsonResponse = Unirest.get(tbSimListUrl.Text)
                .header("accept", tbSimListAccept.Text)
                .basicAuth(tbAuth_key.Text, tbAuth_secret.Text)
                .asString();

                tbSimListResult.Text = format_text(jsonResponse.Body, tbSimListAccept.Text);
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["Auth_key"] = tbAuth_key.Text;
            Properties.Settings.Default["Auth_secret"] = tbAuth_secret.Text;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                tbAuth_key.Text = Properties.Settings.Default["Auth_key"].ToString();
                tbAuth_secret.Text = Properties.Settings.Default["Auth_secret"].ToString();
            } catch (Exception exc)
            {

            }
        }
    }
}
