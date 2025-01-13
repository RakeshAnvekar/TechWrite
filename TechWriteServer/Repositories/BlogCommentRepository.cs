using Microsoft.EntityFrameworkCore;
using TechWriteServer.DbContext;
using TechWriteServer.Models.Blog;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.Repositories;

public class BlogCommentRepository : IBlogCommentRepository
{
    #region Private Readonly Properties
    private readonly TechWriteAppDbContext _techWriteAppDbContext;
    #endregion

    #region Constructors
    public BlogCommentRepository(TechWriteAppDbContext techWriteAppDbContext)
    {
        _techWriteAppDbContext = techWriteAppDbContext;
    }  
    #endregion

    #region Public Methods
    public async Task<List<BlogComment>?> GetAllAsync(int blogId, CancellationToken cancellationToken)
    {
        if(blogId<0) throw new ArgumentOutOfRangeException(nameof(blogId));

        return await  _techWriteAppDbContext.blogComments.Where(x=>x.BlogId==blogId).ToListAsync(cancellationToken);
    }
    public async Task DeleteAsync(Guid commentId, CancellationToken cancellationToken)
    {
        var existingCommentForBlog = await _techWriteAppDbContext.blogComments.FindAsync(commentId, cancellationToken);
        if (existingCommentForBlog != null)
        {
            _techWriteAppDbContext.blogComments.Remove(existingCommentForBlog);
            await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
        }
    }
    public async Task UpdateAsync(BlogComment blogComment, CancellationToken cancellationToken)
    {
        if(blogComment == null) throw new ArgumentNullException(nameof(blogComment));

        var existingBlogcomment = await _techWriteAppDbContext.blogComments.FindAsync(blogComment.BlogId,cancellationToken);
        if (existingBlogcomment != null) {
            blogComment.Comment=existingBlogcomment.Comment;
            await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
        }       
    }
    #endregion
}
