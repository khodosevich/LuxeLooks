namespace LuxeLooks.SharedLibrary.Exceptions;

public class MappingException : Exception
{
    public MappingException(string message) : base(message)
    {
    }

    public MappingException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
