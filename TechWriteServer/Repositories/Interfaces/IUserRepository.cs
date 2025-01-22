using TechWriteServer.Models.User;

namespace TechWriteServer.Repositories.Interfaces;

public interface IUserRepository
{
    #region Methods
    /// <summary>
    /// Retrieves all user from the data source asynchronously.
    /// </summary>
    /// <param name="cancellationToken"> A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation, which contains a collection of <see cref="User"/>.</returns>

    public Task<List<User>?> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves user from the data source asynchronously by identification.
    /// </summary>
    /// <param name="userId">The identificaton number of User.></param>
    /// <param name="cancellationToken"> A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation, which contains single item of type <see cref="User"/></returns>
    public Task<User?> GetAsync(Guid? userId, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new user in the data source asynchronously.
    /// </summary>
    /// <param name="user">The <see cref="User"/> entity to be created.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests, allowing the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<User?> CreateAsync(User user, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a user from the data source based on the provided identifier asynchronously.
    /// </summary>
    /// <param name="userId">
    /// The unique identifier of the user type to be deleted.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests, allowing the operation to be cancelled.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// </returns>
    public Task DeleteAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing user in the data source asynchronously.
    /// </summary>
    /// <param name="user">
    /// The <see cref="User"/> entity containing the updated information.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests, allowing the operation to be cancelled.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation, containing the updated <see cref="User"/> entity if the update is successful; otherwise, <c>null</c>.
    /// </returns>
    public Task<User?> UpdateAsync(User user, CancellationToken cancellationToken);
    /// <summary>
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests, allowing the operation to be cancelled.</param>
    /// <returns></returns>
    public Task<User?> IsUserExistsAsync(User user, CancellationToken cancellationToken);
    
    #endregion
}
