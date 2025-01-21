using TechWriteServer.Models.Blog;

namespace TechWriteServer.Repositories.Interfaces;

public interface IBlogLikeRepository
{
    /// <summary>
    /// Retrieves all BlogLikes for a specific blog.
    /// </summary>
    /// <param name="blogId">The ID of the blog.</param>
    /// <param name="cancellationToken">Cancellation token for task cancellation.</param>
    /// <returns>A list of BlogLike entities.</returns>
    Task<List<BlogLike>> GetAsync(int blogId, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new BlogLike for a user on a specific blog.
    /// </summary>
    /// <param name="blogId">The ID of the blog.</param>
    /// <param name="userId">The ID of the user liking the blog.</param>
    /// <param name="cancellationToken">Cancellation token for task cancellation.</param>
   
    Task CreateAsync(int blogId,Guid userId, CancellationToken cancellationToken);
}
