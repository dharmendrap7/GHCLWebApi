using System;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace GHCLDataAccessLayer
{
    public class SendMailMessage
    {
        static bool isSendEmail = true;
        static bool isSendSMS = true;

        /// <summary>
        /// To send user registraion OTP email.
        /// </summary>
        /// <param name="toMailAddress"></param>
        /// <param name="authenticationCode"></param>
        public static void SendMail(string toMailAddress, string authenticationCode)
        {
            if (isSendEmail)
            {                
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail.transportsystem.in");
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("postmaster@transportsystem.in", "robin@1177");
                SmtpServer.EnableSsl = false;

                mail.From = new MailAddress("postmaster@transportsystem.in");
                mail.To.Add(toMailAddress);
                mail.Subject = "GHCL AUTHENTICATION MAIL";
                mail.Body = "Hi , <br/><br/>Thank you for registering with GHCL, please use the authentication code:  <b>" + authenticationCode + "</b>  to complete the registration process. <br/><br/> Thanks &amp; Regards,<br/> GHCL, <br/>www.GHCL.com , <br/>info@GHCL.in ,<br/>Contact Number: 080-41623100 .";
                mail.IsBodyHtml = true;
                SmtpServer.Send(mail);
            }
            
        }

        /// <summary>
        /// To send forgot password OTP email.
        /// </summary>
        /// <param name="toMailAddress"></param>
        /// <param name="authenticationCode"></param>
        public static void SendForgotPasswordMail(string toMailAddress, string authenticationCode)
        {
            if (isSendEmail)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail.transportsystem.in");
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("postmaster@transportsystem.in", "robin@1177");
                SmtpServer.EnableSsl = false;

                mail.From = new MailAddress("postmaster@transportsystem.in");
                mail.To.Add(toMailAddress);
                mail.Subject = "GHCL FORGOT PASSWORD AUTHENTICATION MAIL";
                mail.Body = "Hi , <br/><br/>Please use the authentication code:  <b>" + authenticationCode + "</b>  to reset the password. <br/><br/> Thanks &amp; Regards,<br/> GHCL, <br/>www.GHCL.com , <br/>info@GHCL.in ,<br/>Contact Number: 080-41623100 .";
                mail.IsBodyHtml = true;
                SmtpServer.Send(mail);
            }

        }

        /// <summary>
        /// To send user registration OTP message.
        /// </summary>
        /// <param name="contactNumber"></param>
        /// <param name="authenticationCode"></param>
        public static void SendSMS(string contactNumber, string authenticationCode)
        {
            if (isSendSMS)
            {
                if (contactNumber != null && contactNumber != string.Empty)
                {
                    //Your authentication key
                    string authKey = "DjqxRBYLw1R2pKaqmj4DFwifVg";
                    //Multiple mobiles numbers separated by comma
                    string mobileNumber = contactNumber;
                    //Sender ID,While using route4 sender id should be 6 characters long.
                    string senderId = "RNSOFT";
                    //Your message to send, Add URL encoding here.
                    string message = "Thank you for registering with GHCL, please use the authentication code: " + authenticationCode + " to complete the registration process.";

                    //Prepare you post parameters
                    StringBuilder sbPostData = new StringBuilder();
                    sbPostData.AppendFormat("authkey={0}", authKey);
                    sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
                    sbPostData.AppendFormat("&message={0}", message);
                    sbPostData.AppendFormat("&sender={0}", senderId);
                    sbPostData.AppendFormat("&route={0}", "1");

                    try
                    {
                        //Call Send SMS API
                        string sendSMSUri = "http://ui.netsms.co.in/API/SendSMS.aspx?APIkey=DjqxRBYLw1R2pKaqmj4DFwifVg&SenderID=RNSOFT&SMSType=2&Mobile=" + mobileNumber + "&MsgText=" + message.ToString();
                        //Create HTTPWebrequest
                        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                        //Prepare and Add URL Encoded data
                        UTF8Encoding encoding = new UTF8Encoding();
                        byte[] data = encoding.GetBytes(sbPostData.ToString());
                        //Specify post method
                        httpWReq.Method = "POST";
                        httpWReq.ContentType = "application/x-www-form-urlencoded";
                        httpWReq.ContentLength = data.Length;
                        using (Stream stream = httpWReq.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                        //Get the response
                        HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        string responseString = reader.ReadToEnd();

                        //Close the response
                        reader.Close();
                        response.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            
        }

        /// <summary>
        /// To send forgot password OTP message.
        /// </summary>
        /// <param name="contactNumber"></param>
        /// <param name="authenticationCode"></param>
        public static void SendSMSForgotPassword(string contactNumber, string authenticationCode)
        {
            if (isSendSMS)
            {
                if (contactNumber != null && contactNumber != string.Empty)
                {
                    //Your authentication key
                    string authKey = "DjqxRBYLw1R2pKaqmj4DFwifVg";
                    //Multiple mobiles numbers separated by comma
                    string mobileNumber = contactNumber;
                    //Sender ID,While using route4 sender id should be 6 characters long.
                    string senderId = "RNSOFT";
                    //Your message to send, Add URL encoding here.
                    string message = "GHCL forgot password authentication code: " + authenticationCode + " to reset the password.";

                    //Prepare you post parameters
                    StringBuilder sbPostData = new StringBuilder();
                    sbPostData.AppendFormat("authkey={0}", authKey);
                    sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
                    sbPostData.AppendFormat("&message={0}", message);
                    sbPostData.AppendFormat("&sender={0}", senderId);
                    sbPostData.AppendFormat("&route={0}", "1");

                    try
                    {
                        //Call Send SMS API
                        string sendSMSUri = "http://ui.netsms.co.in/API/SendSMS.aspx?APIkey=DjqxRBYLw1R2pKaqmj4DFwifVg&SenderID=RNSOFT&SMSType=2&Mobile=" + mobileNumber + "&MsgText=" + message.ToString();
                        //Create HTTPWebrequest
                        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                        //Prepare and Add URL Encoded data
                        UTF8Encoding encoding = new UTF8Encoding();
                        byte[] data = encoding.GetBytes(sbPostData.ToString());
                        //Specify post method
                        httpWReq.Method = "POST";
                        httpWReq.ContentType = "application/x-www-form-urlencoded";
                        httpWReq.ContentLength = data.Length;
                        using (Stream stream = httpWReq.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                        //Get the response
                        HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        string responseString = reader.ReadToEnd();

                        //Close the response
                        reader.Close();
                        response.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }

        /// <summary>
        /// To send campus result message.
        /// Sender id: CAMPUS
        /// </summary>
        /// <param name="contactNumber"></param>
        /// <param name="candidateName"></param>
        public static void SendSMSCampusResult(string contactNumber, string candidateName)
        {
            if (isSendSMS)
            {
                if (contactNumber != null && contactNumber != string.Empty)
                {
                    //Your authentication key
                    string authKey = "DjqxRBYLw1R2pKaqmj4DFwifVg";
                    //Multiple mobiles numbers separated by comma
                    string mobileNumber = contactNumber;
                    //Sender ID,While using route4 sender id should be 6 characters long.
                    string senderId = "CAMPUS";
                    //Your message to send, Add URL encoding here.
                    string message = "GHCL's Campus Result: Hi + " + candidateName + " Congratulations!  You are selected for the next round.All the best. GHCL Campus Connect Team.";

                    //Prepare you post parameters
                    StringBuilder sbPostData = new StringBuilder();
                    sbPostData.AppendFormat("authkey={0}", authKey);
                    sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
                    sbPostData.AppendFormat("&message={0}", message);
                    sbPostData.AppendFormat("&sender={0}", senderId);
                    sbPostData.AppendFormat("&route={0}", "1");

                    try
                    {
                        //Call Send SMS API
                        string sendSMSUri = "http://ui.netsms.co.in/API/SendSMS.aspx?APIkey=DjqxRBYLw1R2pKaqmj4DFwifVg&SenderID=CAMPUS&SMSType=2&Mobile=" + mobileNumber + "&MsgText=" + message.ToString();
                        //Create HTTPWebrequest
                        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                        //Prepare and Add URL Encoded data
                        UTF8Encoding encoding = new UTF8Encoding();
                        byte[] data = encoding.GetBytes(sbPostData.ToString());
                        //Specify post method
                        httpWReq.Method = "POST";
                        httpWReq.ContentType = "application/x-www-form-urlencoded";
                        httpWReq.ContentLength = data.Length;
                        using (Stream stream = httpWReq.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                        //Get the response
                        HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        string responseString = reader.ReadToEnd();

                        //Close the response
                        reader.Close();
                        response.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }

        /// <summary>
        /// To send campus result message.
        /// Sender id: HRDEPT
        /// </summary>
        /// <param name="contactNumber"></param>
        /// <param name="candidateName"></param>
        public static void SendSMSCampusFinalSelection(string contactNumber, string candidateName)
        {
            if (isSendSMS)
            {
                if (contactNumber != null && contactNumber != string.Empty)
                {
                    //Your authentication key
                    string authKey = "DjqxRBYLw1R2pKaqmj4DFwifVg";
                    //Multiple mobiles numbers separated by comma
                    string mobileNumber = contactNumber;
                    //Sender ID,While using route4 sender id should be 6 characters long.
                    string senderId = "HRDEPT";
                    //Your message to send, Add URL encoding here.
                    string message = "GHCL's Campus Result: Hi + " + candidateName + " Congratulations!  You are selected for Placement Opportunity @ GHCL, through Campus Drive @ IEC College of Engineering and Technology,Greater Noida. Waiting for your early onboarding for the same. Nice Days ahead. Any queries, Plz contact @ 080-4162-3100 (Extn- 12).Warm Regards.HRD-GHCL.";

                    //Prepare you post parameters
                    StringBuilder sbPostData = new StringBuilder();
                    sbPostData.AppendFormat("authkey={0}", authKey);
                    sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
                    sbPostData.AppendFormat("&message={0}", message);
                    sbPostData.AppendFormat("&sender={0}", senderId);
                    sbPostData.AppendFormat("&route={0}", "1");

                    try
                    {
                        //Call Send SMS API
                        string sendSMSUri = "http://ui.netsms.co.in/API/SendSMS.aspx?APIkey=DjqxRBYLw1R2pKaqmj4DFwifVg&SenderID=HRDEPT&SMSType=2&Mobile=" + mobileNumber + "&MsgText=" + message.ToString();
                        //Create HTTPWebrequest
                        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                        //Prepare and Add URL Encoded data
                        UTF8Encoding encoding = new UTF8Encoding();
                        byte[] data = encoding.GetBytes(sbPostData.ToString());
                        //Specify post method
                        httpWReq.Method = "POST";
                        httpWReq.ContentType = "application/x-www-form-urlencoded";
                        httpWReq.ContentLength = data.Length;
                        using (Stream stream = httpWReq.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                        //Get the response
                        HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        string responseString = reader.ReadToEnd();

                        //Close the response
                        reader.Close();
                        response.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }


    }
}
