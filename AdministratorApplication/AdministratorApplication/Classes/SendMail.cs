using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AdministratorApplication.Interfaces;
using System.Net.Http;

namespace AdministratorApplication.Classes
{
    public class SendMail : ISendMail
    {
        public async Task SendMailMethod(string employeeName, string toEmail)
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
                            <h2><b>Bună ziua, {employeeName}!</b></h2>
                            <p>Iti uram bun venit in compania noastra.</p>
                            <p>Dorim sa te anuntam ca ai fost inregistrat in sistem !</p>
                             Vă dorim o zi minunata!<br>
                             Cu drag,
                            <p><b>BiometricHub Access</b></p>
                        </body>
                    </html>
                ";

                MailMessage message = new MailMessage("andrei.mihai190401@gmail.com", toEmail);
                message.Subject = "Inregistrare angajat";
                message.IsBodyHtml = true;
                message.Body = body;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.None;

                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
