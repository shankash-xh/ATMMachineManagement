using System.Net;
using System.Net.Mail;

namespace Utility.EmailSender;

public class SendEmail
{
    private static readonly string _fromEmail = "shashank.step2gen@gmail.com";
    private static readonly string _password = "yzhwjqgutybkfibn";
    public static void SendOtp(string Otp, string email)
    {
        string subject = "Opt To reset Your Pin";
        string bodyTemplate = GetEmailTemplate();
        MailMessage message = new()
        {
            From = new MailAddress(_fromEmail, "ATM"),
            Subject = string.Format(subject),
            Body = string.Format(bodyTemplate, Otp),
            IsBodyHtml = true
        };
        message.To.Add(new MailAddress(email));

        SmtpClient smtpClient = new("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(_fromEmail, _password),
            EnableSsl = true
        };

        try
        {
            smtpClient.Send(message);
            Console.WriteLine("Email Sent Succesfully !!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static string GetEmailTemplate()
    {
        return "<center><h2>Varification OTP</h2></center><br>\t\t\t\t<h4>Your Varification OTP : <strong>{0}</string></h4><br>\t\t\t\tThank You!<br>If you didn't Requested This Otp Ignor it";
    }
}
