namespace Repositories.Services.Exceptions;
public class NotFoundException:Exception
{
    public NotFoundException(int id):base($"There is no elemant with the Id: {id}")
    {
        
    }
}