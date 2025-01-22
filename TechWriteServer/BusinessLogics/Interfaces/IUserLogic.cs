using TechWriteServer.Models.User;

namespace TechWriteServer.BusinessLogics.Interfaces;

public interface IUserLogic
{
    #region Methods
    public Task<User?> RegisterUserAsync(User user, CancellationToken cancellationToken);

    public Task<List<User>?> GetAllUserAsync(CancellationToken cancellationToken);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name=""></param>
    /// <returns></returns>
    public Task<User?> LoginAsync(User user, CancellationToken cancellationToken);
    /// <summary>
    /// Gets user name by user id.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests, allowing the operation to be cancelled.</param>
    /// <returns>User display name else null</returns>
    public Task<string?> GetUserNameAsync(Guid userId, CancellationToken cancellationToken);


    #endregion
}
