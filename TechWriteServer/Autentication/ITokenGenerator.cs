using TechWriteServer.Models.User;

namespace TechWriteServer.Autentication;

public interface ITokenGenerator
{
    /// <summary>
    /// Gets the new token for each sucessfull login.
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returns token if the user login is sucessful or null</returns>
    Task<string?> GenerateTokenAsync(User user, CancellationToken cancellationToken);
}
