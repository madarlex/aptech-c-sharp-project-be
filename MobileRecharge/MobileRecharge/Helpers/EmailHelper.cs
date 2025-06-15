using System.Net;
using System.Net.Mail;

namespace MobileRecharge.Helpers
{
    public class EmailHelper
    {
        public static void SendEmail(string email, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("c2003lcodedao@gmail.com");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25))
                {
                    smtp.Credentials = new NetworkCredential("c2003lcodedao@gmail.com", "codedao89");
                    //smtp.UseDefaultCredentials = true;
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
