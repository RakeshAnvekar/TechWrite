using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechWriteServer.DbContext;
using TechWriteServer.Models.Blog;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.Repositories;

public class BlogRepository : IBlogRepository
{
    #region Private Properties
    private readonly TechWriteAppDbContext _techWriteAppDbContext;
    #endregion

    #region Constructors
    public BlogRepository(TechWriteAppDbContext techWriteAppDbContext)
    {
        _techWriteAppDbContext = techWriteAppDbContext;
    }   

    #endregion

    #region Public Methods
    public async Task<List<Blog>?> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _techWriteAppDbContext.Blogs
            .OrderByDescending(x => x.PublishedDate)
            .ToListAsync(cancellationToken);
    }
    public async Task<Blog?> CreateAsync(Blog blog, CancellationToken cancellationToken)
    {
        if(blog == null)  throw new ArgumentNullException(nameof(blog));

        blog.IsActive = true;
        await _techWriteAppDbContext.AddAsync(blog, cancellationToken);
        var result= await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
        if(result > 0)
        {
            return blog;
        }
        return null;
    }

    public async Task ApproveAsync(int blogId, CancellationToken cancellationToken)
    {
        if (blogId == 0) throw new InvalidOperationException(nameof(blogId));

       var blog = await _techWriteAppDbContext.Blogs.FindAsync(blogId, cancellationToken);

        if (blog!=null)
        {
            blog.IsApproved = true;
            blog.IsActive = true;
            blog.RejectComment = "";
            await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task RejectAsync(int blogId, string comment, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(comment)) throw new ArgumentNullException(nameof(comment));

        var blog= await _techWriteAppDbContext.Blogs.FindAsync(blogId, cancellationToken);

        if (blog != null) {
            blog.IsApproved= false;
            blog.IsActive = false;
            blog.RejectComment = comment;
            await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<Blog?> BlogLikeAsync(int blogId, CancellationToken cancellationToken)    {
       

       //var existingBlog=await _techWriteAppDbContext.Blogs.FindAsync(blogId,cancellationToken);
       // if (existingBlog != null) {
       //     existingBlog.BlogLikes = existingBlog.BlogLikes +1;
       //    await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);           
       // }
        return null;
    }

    public async Task<Blog?> BlogDisLikeAsync(int blogId, CancellationToken cancellationToken)
    {

        //var existingBlog = await _techWriteAppDbContext.Blogs.FindAsync(blogId, cancellationToken);
        //if (existingBlog != null)
        //{
        //    existingBlog.BlogLikes = -1;
        //    await _techWriteAppDbContext.SaveChangesAsync(cancellationToken);
        //}
        //return existingBlog;
        return null;
    }

    #endregion
}
