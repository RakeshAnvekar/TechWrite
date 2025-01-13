using TechWriteServer.Models.User;
using TechWriteServer.Models.Tag;

namespace TechWriteServer.Repositories.Interfaces;

public interface ITagRepository
{
    #region Methods
    /// <summary>
    /// Retrieves all Tags from the data source asynchronously.
    /// </summary>
    /// <param name="cancellationToken"> A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation, which contains a collection of <see cref="Tag"/>.</returns>
    public Task<List<Tag>?> GetAllAsync(CancellationToken cancellationToken);
    /// <summary>
    /// Retrieves Tag from the data source asynchronously by identification.
    /// </summary>
    /// <param name="tagId">The identificaton number of Tag.></param>
    /// <param name="cancellationToken"> A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation, which contains single item of type <see cref="Tag"/></returns>
    public Task<Tag?> GetAsync(int tagId, CancellationToken cancellationToken);
    /// <summary>
    /// Creates a new Tag in the data source asynchronously.
    /// </summary>
    /// <param name="tag">The <see cref="Tag"/> entity to be created.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests, allowing the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task CreateAsync(Tag tag, CancellationToken cancellationToken);
    /// <summary>
    /// Deletes a Tag from the data source based on the provided identifier asynchronously.
    /// </summary>
    /// <param name="tagId">
    /// The unique identifier of the Tag to be deleted.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests, allowing the operation to be cancelled.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// </returns>
    public Task DeleteAsync(int tagId, CancellationToken cancellationToken);
    /// <summary>
    /// Updates an existing Tag in the data source asynchronously.
    /// </summary>
    /// <param name="tag">
    /// The <see cref="Tag"/> entity containing the updated information.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests, allowing the operation to be cancelled.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation, containing the updated <see cref="User"/> entity if the update is successful; otherwise, <c>null</c>.
    /// </returns>
    public Task<Tag?> UpdateAsync(Tag tag, CancellationToken cancellationToken);
    #endregion
}
