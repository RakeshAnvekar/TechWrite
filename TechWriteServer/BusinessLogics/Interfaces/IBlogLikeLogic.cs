using TechWriteServer.Models.Blog;

namespace TechWriteServer.BusinessLogics.Interfaces;

public interface IBlogLikeLogic
{
    /// <summary>
    /// Retrieves all BlogLikes for a specific blog.
    /// </summary>
    /// <param name="blogId">The ID of the blog.</param>
    /// <param name="cancellationToken">Cancellation token for task cancellation.</param>
    /// <returns>A list of BlogLike entities.</returns>
    Task<List<BlogLike>> GetAsync(int blogId, CancellationToken cancellationToken);

    /// <summary>
    /// Insert new like.
    /// </summary>
    /// <param name="blogId">The ID of the blog.</param>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="cancellationToken">Cancellation token for task cancellation.</param>
    /// <returns></returns>
    Task<int> AddAsync(int blogId,Guid userId, CancellationToken cancellationToken);

}
