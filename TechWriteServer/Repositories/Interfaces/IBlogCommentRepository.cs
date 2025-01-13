using TechWriteServer.Models.Blog;

namespace TechWriteServer.Repositories.Interfaces;

public interface IBlogCommentRepository
{
    #region Public Methods

    /// <summary>
    /// Retrieves all BlogComments from the data source asynchronously by blog identification .
    /// </summary>
    /// <param name="blogId"> The identificaton number of blogId.</param>
    /// <param name="cancellationToken"> A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation, which contains a collection of <see cref="BlogComment"/>.</returns>
    public Task<List<BlogComment>?> GetAllAsync(int blogId,CancellationToken cancellationToken);

    public Task DeleteAsync(Guid commentId,CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing Blog Comment in the data source asynchronously.
    /// </summary>
    /// <param name="blogComment">
    /// The <see cref="BlogComment"/> entity containing the updated information.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests, allowing the operation to be cancelled.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation, containing the updated <see cref="BlogComment"/> entity if the update is successful; otherwise, <c>null</c>.
    /// </returns>
    public Task UpdateAsync(BlogComment blogComment, CancellationToken cancellationToken);
    #endregion
}
