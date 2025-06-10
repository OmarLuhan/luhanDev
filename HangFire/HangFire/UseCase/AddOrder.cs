using Hangfire;
using HangFire.Dtos;
using HangFire.Notifiers.Email;

namespace HangFire.UseCase;

public class AddOrder(ISendEmail sendEmail,ILogger<AddOrder> logger)
{
    public async Task Execute(OrderDto order)
    {
        var orderId = Guid.NewGuid().ToString();
        logger.LogInformation("Processing order number {OrderId} for customer {CustomerName}", orderId,
            order.CustomerName);
        await Task.Delay(1000);
        var email = new EmailDto
        {
            For = order.CustomerEmail,
            Subject = $"Order Confirmation - {orderId}",
            Body = $"Dear {order.CustomerName},<br/>Thank you for your order of {order.ProductName}.<br/>Your order number is {orderId}."
        };
        logger.LogInformation("Sending email with subject: {Subject}", email.Subject);
       BackgroundJob.Enqueue(()=> sendEmail.Execute(email));
    }
}