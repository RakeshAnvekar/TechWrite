using TechWriteServer.Models.Blog;

namespace TechWriteServer.Repositories.Interfaces;

public interface IBlogRepository
{
    /// <summary>
    /// Retrieves all Blogs from the data source asynchronously.
    /// </summary>
    /// <param name="cancellationToken"> A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation, which contains a collection of <see cref="Blog"/>.</returns>
    public Task<List<Blog>?> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Inserts new Blog to the data source asynchronously.
    /// </summary>
    /// <param name="cancellationToken"> A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns>A task representing the asynchronous operation, which contains a collection of <see cref="Blog"/>.</returns>
    public Task<Blog?> CreateAsync(Blog blog, CancellationToken cancellationToken);

    /// <summary>
    /// Approves the blog.
    /// </summary>
    /// <param name="blogId">The identification of blog</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns></returns>
    public Task ApproveAsync(int blogId, CancellationToken cancellationToken);

    /// <summary>
    /// Rejects the blog,with comment.
    /// </summary>
    /// <param name="blogId">The identification of blog</param>
    /// <param name="comment">The reject comment of the blog</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns></returns>
    public Task RejectAsync(int blogId,string comment, CancellationToken cancellationToken);
    /// <summary>
    /// Likes the blog content by incrementing likes by 1.
    /// </summary>
    /// <param name="blog">The Blog</param>
    /// <param name="cancellationToken">The CancellationToken</param>
    /// <returns>Returns Updated blog</returns>
    public Task<Blog?> BlogLikeAsync(Blog blog, CancellationToken cancellationToken);
    /// <summary>
    /// Dislikes the blog content by decrementing likes by 1.
    /// </summary>
    /// <param name="blog">The Blog</param>
    /// <param name="cancellationToken">The CancellationToken</param>
    /// <returns>Returns Updated blog</returns>
    public Task<Blog?> BlogDisLikeAsync(Blog blog, CancellationToken cancellationToken);
}
