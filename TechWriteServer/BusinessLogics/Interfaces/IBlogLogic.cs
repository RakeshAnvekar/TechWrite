using TechWriteServer.Models.Blog;
using TechWriteServer.ViewModels;

namespace TechWriteServer.BusinessLogics.Interfaces;

public interface IBlogLogic
{
    #region Public Methods
    public Task<BlogViewModel?> GetAllBlogsAsync(CancellationToken cancellationToken);
    public Task<Blog?> CreateNewBlog(Blog blog, CancellationToken cancellationToken);
    public Task<List<Blog>?> GetAllTrandingBlogsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Approves the blog
    /// </summary>
    /// <param name="blogId">The identification of blog</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns></returns>
    public Task ApproveBlogAsync(int blogId, CancellationToken cancellationToken);

    /// <summary>
    /// Rejects the blog,with comment
    /// </summary>
    /// <param name="blogId">The identification of blog</param>
    /// <param name="comment">The reject comment of the blog</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete. It allows the operation to be cancelled.</param>
    /// <returns></returns>
    public Task RejectBlogAsync(int blogId, string comment, CancellationToken cancellationToken);
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
    #endregion
}
