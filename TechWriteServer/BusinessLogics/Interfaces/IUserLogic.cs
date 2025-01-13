using System.Diagnostics.Contracts;
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
    #endregion
}
