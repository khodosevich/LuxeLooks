using LuxeLooks.SharedLibrary.Exceptions;

namespace LuxeLooks.SharedLibrary.Mappers;

public class StringToGuidMapper
{
    public Guid MapTo(string id)
    {
        if (!Guid.TryParse(id,out var guidId))
        {
            throw new MappingException("Invalid id");
        }

        return guidId;
    }
}