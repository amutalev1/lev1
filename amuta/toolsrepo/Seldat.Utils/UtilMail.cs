using Seldat.MDS.Connector;
using Seldat.SWTools.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Seldat.Utils
{
    public static class UtilMail
    {
        #region Send Mail - isBodyHtml = true
        public static void SendMailHtml(List<string> to,string subject, string htmlBodyFilePath, Hashtable replacements, List<string> cc , List<MailAddress> bcc , List<System.Net.Mail.Attachment> attachments )
        {
            try
            {            
                var SmtpConfig = ConfigurationManager.GetSection("SMTP") as SMTP;
                SmtpClient SmtpServer = new SmtpClient(SmtpConfig.SMTPServerName);
                SmtpServer.Port = SmtpConfig.Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(SmtpConfig.Username, SmtpConfig.Password);
                SmtpServer.EnableSsl = SmtpConfig.SSLEncripted;

                MailDefinition md = new MailDefinition();
                md.From = SmtpConfig.DefaultFromEmail;
                md.Subject = subject;
                string toRecipiants = string.Join(";", to);
                md.IsBodyHtml = true;
                string sbody = string.Empty;
              
                //get file path in project
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                string dir = Path.GetDirectoryName(path);

                StreamReader reader = new StreamReader(dir + htmlBodyFilePath);
                sbody = reader.ReadToEnd();

                MailMessage mail = md.CreateMailMessage(toRecipiants, replacements, sbody, new System.Web.UI.Control());
                if (bcc != null)
                {
                    foreach (var item in bcc)
                        mail.Bcc.Add(item.Address);
                }
               
                if (attachments != null)
                {
                    foreach (var item in attachments)
                        mail.Attachments.Add(item);
                }
                SmtpServer.Send(mail);

            }
            catch (Exception )
            {
                throw;
            }
        }
        
        public static void SendMailHtml(List<string> to, string subject, string htmlBodyFilePath, Hashtable replacements)
        {
             SendMailHtml(to, subject, htmlBodyFilePath, replacements, null, null, null);
        }

        public static void SendMailHtml(List<string> to, string subject, string htmlBodyFilePath, Hashtable replacements, List<string> cc, List<MailAddress> bcc)
        {
             SendMailHtml(to, subject, htmlBodyFilePath, replacements, cc, bcc, null);
        }

        public static void SendMailHtml(List<string> to, string subject, string htmlBodyFilePath, Hashtable replacements, List<System.Net.Mail.Attachment> attachments)
        {
             SendMailHtml(to, subject, htmlBodyFilePath, replacements, null, null, attachments);
        }

        public static string SendMailMDS(List<string> to, int templateId, List<MDS.Connector.Attachment> attachments = null, List<string> cc = null, List<string> bcc = null, Dictionary<string,object> replacments = null)
        {
        
            MessageDistributionManager.SendEmail(templateId, to , replacments);
            return "";
        }
        #endregion

        #region Send Mail - isBodyHtml = false
        public static bool SendMail( List<string> to, string subject,string body, List<string> cc , List<string> bcc , List<System.Net.Mail.Attachment> attachments)
        {
            try
            {
                var SmtpConfig = ConfigurationManager.GetSection("SMTP") as SMTP;
                SmtpClient SmtpServer = new SmtpClient(SmtpConfig.SMTPServerName);
                SmtpServer.Port = SmtpConfig.Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(SmtpConfig.Username, SmtpConfig.Password);
                SmtpServer.EnableSsl = SmtpConfig.SSLEncripted;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(SmtpConfig.DefaultFromEmail);
                msg.Subject = subject;
                //add the To recepients
                foreach (var toStr in to)
                   msg.To.Add(new MailAddress(toStr));   
                msg.Body = body;

                if (cc != null)
                {
                    foreach (var ccStr in cc)
                        msg.CC.Add(new MailAddress(ccStr));
                }
                if (bcc != null)
                {
                    foreach (var bccStr in bcc)
                        msg.Bcc.Add(new MailAddress(bccStr));
                }
                if (attachments != null)
                {
                    foreach (var item in attachments)
                        msg.Attachments.Add(item);
                }
                SmtpServer.Send(msg);
                return true;

            }
            catch (Exception ex)
            {
                //write to log the ex
                return false;
            }
        }

        public static bool SendMail(List<string> to, string subject, string body)
        {
            return SendMail(to, subject, body, null, null, null);
        }

        public static bool SendMail(List<string> to, string subject, string body, List<System.Net.Mail.Attachment> attachments)
        {
            return SendMail(to, subject, body,  null, null, attachments);
        }

        public static bool SendMail(List<string> to, string subject, string body, List<string> cc, List<string> bcc)
        {
            return SendMail(to, subject, body, cc, bcc, null);
        }


        #endregion

        /// <summary>
        /// validate email address
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        public static bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
