using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.Models.Blog;
using TechWriteServer.Repositories.Interfaces;
using TechWriteServer.ViewModels;

namespace TechWriteServer.BusinessLogics;

public sealed class BlogLogic : IBlogLogic
{
    #region Private Properties
    private readonly IBlogRepository _blogRepository;
    private readonly IBlogCommentRepository _blogCommentRepository;
    private readonly ITagRepository _tagRepository;
    #endregion

    #region Constructors
    public BlogLogic(IBlogRepository blogRepository, IBlogCommentRepository blogCommentRepository, ITagRepository tagRepository)
    {
        _blogRepository = blogRepository;
        _blogCommentRepository = blogCommentRepository;
        _tagRepository = tagRepository;
    }
       
    #endregion

    #region Public Methods
    public async Task<BlogViewModel?> GetAllBlogsAsync(CancellationToken cancellationToken)
    {
        var blogViewData = new BlogViewModel();
        blogViewData.Blogs = await _blogRepository.GetAllAsync(cancellationToken);

        if (blogViewData.Blogs?.Count>0)
        {
            foreach (var blog in blogViewData.Blogs)
            {
                blog.BlogComments?.AddRange(await _blogCommentRepository.GetAllAsync(blog.BlogId, cancellationToken));
                var tagData= await _tagRepository.GetAsync(blog.TagId,cancellationToken);
                blog.TagName = tagData?.TagName;
            }
        }
        blogViewData.Tags= await _tagRepository.GetAllAsync(cancellationToken);        
       
        return blogViewData;
    }
    public async Task<Blog?> CreateNewBlog(Blog blog, CancellationToken cancellationToken)
    {
        if(blog == null)  throw new ArgumentNullException(nameof(blog));

        var newBlog= await _blogRepository.CreateAsync(blog, cancellationToken);
        return newBlog;
    }

    public async Task<List<Blog>?> GetAllTrandingBlogsAsync(CancellationToken cancellationToken)
    {
      var allActiveBlogs =  await _blogRepository.GetAllAsync(cancellationToken);
      return allActiveBlogs?.Where(x => x.IsTranding==true).ToList();
    }

    public async Task ApproveBlogAsync(int blogId, CancellationToken cancellationToken)
    {
      await _blogRepository.ApproveAsync(blogId, cancellationToken);
    }

    public async Task RejectBlogAsync(int blogId, string comment, CancellationToken cancellationToken)
    {
        await _blogRepository.RejectAsync(blogId, comment, cancellationToken);
    }

    public async Task<Blog?> BlogLikeAsync(Blog blog, CancellationToken cancellationToken)
    {
        return await _blogRepository.BlogLikeAsync(blog, cancellationToken);
    }

    public async Task<Blog?> BlogDisLikeAsync(Blog blog, CancellationToken cancellationToken)
    {
        return await _blogRepository.BlogDisLikeAsync(blog, cancellationToken);
    }
    #endregion


}
