namespace LuxeLooks.Domain.Models.Identity;

public class ScopeAttribute : Attribute
{
    public string Scope { get; set; }

    public ScopeAttribute(string scope)
    {
        Scope = scope;
    }
}