namespace Repositories.Services.Exceptions;

public sealed class UserLoginBadRequestException : BadRequestException
{
    public UserLoginBadRequestException(string message="Email or password isn't correct!!!") : base(message)
    {
    }
}
