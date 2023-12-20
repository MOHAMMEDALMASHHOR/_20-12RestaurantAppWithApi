namespace Repositories.Services.Exceptions;
public abstract class BadRequestException:Exception
{
    public BadRequestException(string message):base(message)
    {
        
    }
}
