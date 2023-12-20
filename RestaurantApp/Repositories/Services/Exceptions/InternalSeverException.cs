namespace Repositories.Services.Exceptions;

public class InternalServerException:Exception{
    public InternalServerException(string message="Internal Server Error"):base(message)
    {
        
    }
}
