using System.Net;
using System.Net.Mail;
using LuxeLooks.DataManagment.Repositories;
using LuxeLooks.Domain.Entity;

namespace LuxeLooks.Service.Services;

public class NotificationService 
{
    private readonly SmtpClient _smtpClient = new("smtp.mail.ru")
    {
        Port = 465,
        Credentials = new NetworkCredential("luxelooksbestshop@mail.ru", "LuxeLooks12347"),
        EnableSsl = true
    };

    private readonly SubcribeRepository _subcribeRepository;

    public NotificationService(SubcribeRepository subcribeRepository)
    {
        _subcribeRepository = subcribeRepository;
    }

    public async Task SendNotificationsForNewProductAsync(Product newProduct)
    {
        var subscribers = await _subcribeRepository.GetAll();
        foreach (var subscriber in subscribers)
        {
            if (IsSubscribedToCategory(newProduct, subscriber.Category))
            {
                await SendNotificationAsync(newProduct, subscriber.Email);
            }
        }
    }

    private bool IsSubscribedToCategory(Product product, string category)
    {
        switch (category.ToLower())
        {
            case "mens":
                return product.IsForMen && !product.IsForKids;
            case "womens":
                return !product.IsForMen && !product.IsForKids;
            case "kids":
                return product.IsForKids;
            default:
                return false;
        }
    }

    private async Task SendNotificationAsync(Product product, string email)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress("luxelooksbestshop@mail.ru"),
            Subject = "NEW PRODUCT IN YOUR FAVORITE SHOP",
            Body = $"A new product ({product.Name}) has been added to the store.\nDescription: {product.Description}\nPrice: {product.Price:C}"
        };

        mailMessage.To.Add(email);

        await _smtpClient.SendMailAsync(mailMessage);
    }
}