using System.ComponentModel.DataAnnotations;

namespace LuxeLooks.Domain.Models;

public class SubscribeRequest
{
    [EmailAddress]
    public string Email { get; set; }
    public string Category { get; set; }
}