using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonServices
    {
        public static void SendEmail(string toMail, string fromMail, string displayName, string mailTitle, string mailContent)
        {
            MailMessage mail = new MailMessage();

            mail.To.Add(toMail);
            mail.From = new MailAddress(fromMail, displayName, System.Text.Encoding.GetEncoding("utf-8"));

            mail.Subject = mailTitle;
            mail.Body = mailContent;
            mail.IsBodyHtml = true;
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.qq.com");
                smtpClient.Credentials = new NetworkCredential("277602146@qq.com", "sky20100@qq");
                smtpClient.Send(mail);

            }
            catch (Exception exception)
            {

                throw (exception);
            }
        }
    }
}
