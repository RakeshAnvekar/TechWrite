using Microsoft.EntityFrameworkCore;
using TechWriteServer.DbContext;
using TechWriteServer.Models.Blog;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.Repositories;

public class BlogLikeRepository : IBlogLikeRepository
{
    #region Private Properties
    private readonly TechWriteAppDbContext _techWriteAppDbContext;
    #endregion

    #region Methods
    public BlogLikeRepository(TechWriteAppDbContext techWriteAppDbContext)
    {
        _techWriteAppDbContext = techWriteAppDbContext;
    }

    public async Task CreateAsync(int blogId, Guid userId, CancellationToken cancellationToken)
    {
        var blog = await _techWriteAppDbContext.Blogs.FindAsync(blogId, cancellationToken);
        if (blog != null)
        {
            // Check if the user has already liked the blog
            var existingLike = await _techWriteAppDbContext.BlogLikes
                .FirstOrDefaultAsync(bl => bl.UserId == userId && bl.BlogId == blogId, cancellationToken);

            if (existingLike == null)
            {
                // Add new like
                await _techWriteAppDbContext.BlogLikes.AddAsync(new BlogLike { BlogId = blogId, UserId = userId }, cancellationToken);
            }
            else
            {
                // Remove the existing like
                _techWriteAppDbContext.BlogLikes.Remove(existingLike); // Use Remove, not RemoveRange
            }

            // Only call SaveChangesAsync once after modifying the BlogLikes
            await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
        }
    }

    #endregion

    #region Constructors
    public async Task<List<BlogLike>> GetAsync(int blogId, CancellationToken cancellationToken)
    {
     return await  _techWriteAppDbContext.BlogLikes.Where(bl=>bl.BlogId == blogId).Distinct().ToListAsync(cancellationToken);       
    }
    #endregion

}
