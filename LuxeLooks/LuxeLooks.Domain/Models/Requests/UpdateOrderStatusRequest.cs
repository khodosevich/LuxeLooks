namespace LuxeLooks.Domain.Models.Requests;

public class UpdateOrderStatusRequest
{
    public string Id { get; set; }
    public string NewStatus { get; set; }
}