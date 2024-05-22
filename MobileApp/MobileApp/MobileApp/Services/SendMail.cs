using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MobileApp.Interfaces;
using MobileApp.Models;

namespace MobileApp.Services
{
    public class SendMail : ISendMail
    {
        public async Task SendResetCodeMethod(int resetCode, string toEmail)
        {
            try
            {
                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential
                    {
                        UserName = "andrei.mihai190401@gmail.com",
                        Password = "ceqw fhko rktr tkvu"
                    }
                };

                string body = $@"
                    <html>
                        <body>
                            <h2><b>Cod de resetare a parolei</b></h2>
                            <p>Buna ziua! Ati solicitat resetarea parolei.</p>
                            <p>Codul pentru resetare: {ResetPasswordModel.ResetCode}</p>
                             Vă dorim o zi minunata!<br>
                             Cu drag,
                            <p><b>BiometricHub Access</b></p>
                        </body>
                    </html>
                ";

                MailMessage message = new MailMessage("andrei.mihai190401@gmail.com", toEmail);
                message.Subject = "Cod pentru resetarea parolei";
                message.IsBodyHtml = true;
                message.Body = body;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.None;

                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
