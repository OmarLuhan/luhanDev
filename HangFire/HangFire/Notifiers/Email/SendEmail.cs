using MailKit.Net.Smtp;
using HangFire.Dtos;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace HangFire.Notifiers.Email;
public interface ISendEmail
{
    Task Execute(EmailDto request);
}
public class SendEmail(IOptions<MailOptions> mailOptions,ILogger<SendEmail> logger): ISendEmail
{
    private readonly MailOptions _mailOptions = mailOptions.Value;
    public async Task Execute(EmailDto request)
    {
        MimeMessage email = new();
        email.From.Add(MailboxAddress.Parse(_mailOptions.UserName));
        email.To.Add(MailboxAddress.Parse(request.For));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Html) { Text = request.Body };
        using SmtpClient smtp = new();
        await smtp.ConnectAsync(
            _mailOptions.Host,
            _mailOptions.Port,
            SecureSocketOptions.StartTls
        );
        await smtp.AuthenticateAsync(
            _mailOptions.UserName,
            _mailOptions.Password
        );
        await smtp.SendAsync(email); 
        await smtp.DisconnectAsync(true);
        logger.LogInformation("successfully sent email to {Email}", request.For);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}