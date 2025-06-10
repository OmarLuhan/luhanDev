namespace HangFire.Notifiers.Email;

public class MailOptions
{
    public string Host { set; get; }=null!;
    public int Port { set; get; }
    public string UserName { set; get; }=null!;
    public string Password { set; get; }=null!;
};