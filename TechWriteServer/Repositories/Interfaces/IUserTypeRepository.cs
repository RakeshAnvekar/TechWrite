using TechWriteServer.Models.User;

namespace TechWriteServer.Repositories.Interfaces;

public interface IUserTypeRepository
{
    #region Methods

    /// <summary>
    /// Retrieves all user types from the data source asynchronously.
    /// </summary>
    /// <param name="cancellationToken"> A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation, which contains a collection of <see cref="UserType"/>.</returns>
    public Task<IEnumerable<UserType>> GetAllAsync(CancellationToken cancellationToken);
    /// <summary>
    /// Retrieves user type from the data source asynchronously by identification.
    /// </summary>
    /// <param name="userTypeId">The identificaton number of User Type.></param>
    /// <param name="cancellationToken"> A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation, which contains single item of type <see cref="UserType"/></returns>
    public Task<UserType?> GetAsync(int userTypeId, CancellationToken cancellationToken);
    /// <summary>
    /// Creates a new user type in the data source asynchronously.
    /// </summary>
    /// <param name="userType">The <see cref="UserType"/> entity to be created.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests, allowing the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task CreateAsync(UserType userType,CancellationToken cancellationToken);
    /// <summary>
    /// Deletes a user type from the data source based on the provided identifier asynchronously.
    /// </summary>
    /// <param name="userTypeId">
    /// The unique identifier of the user type to be deleted.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests, allowing the operation to be cancelled.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// </returns>
    public Task DeleteAsync(int userTypeId, CancellationToken cancellationToken);
    /// <summary>
    /// Updates an existing user type in the data source asynchronously.
    /// </summary>
    /// <param name="userType">
    /// The <see cref="UserType"/> entity containing the updated information.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests, allowing the operation to be cancelled.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation, containing the updated <see cref="UserType"/> entity if the update is successful; otherwise, <c>null</c>.
    /// </returns>
    public Task<UserType?> UpdateAsync(UserType userType, CancellationToken cancellationToken);

    #endregion
}
