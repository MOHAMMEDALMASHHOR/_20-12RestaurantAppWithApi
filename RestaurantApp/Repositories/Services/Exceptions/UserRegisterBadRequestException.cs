namespace Repositories.Services.Exceptions;

public sealed class UserRegisterBadRequestException : BadRequestException
{
    public UserRegisterBadRequestException(string message="The email or password is not correct!!!") : base(message)
    {
    }
}