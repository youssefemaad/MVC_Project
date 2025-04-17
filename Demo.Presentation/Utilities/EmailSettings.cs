using System.Net;
using System.Net.Mail;

namespace Demo.Presentation.Utilities;

public class EmailSettings
{
    public static void SendEmail(Email email)
    {
        var Client = new SmtpClient("smtp.example.com", 587);
        Client.EnableSsl = true;
        Client.Credentials = new NetworkCredential("eyoussef228@gmail.com", "rabdjotergzoarzw");
        Client.Send("eyoussef228@gmail.com", email.To, email.Subject, email.Body);
    }
}
