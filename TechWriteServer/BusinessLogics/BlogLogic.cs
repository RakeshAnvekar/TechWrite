﻿using TechWriteServer.BusinessLogics.Interfaces;
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
    private readonly IBlogLikeRepository _blogLikeRepository;
    private readonly IUserRepository _userRepository;
    #endregion

    #region Constructors
    public BlogLogic(IBlogRepository blogRepository, IBlogCommentRepository blogCommentRepository, ITagRepository tagRepository, IBlogLikeRepository blogLikeRepository, IUserRepository userRepository)
    {
        _blogRepository = blogRepository;
        _blogCommentRepository = blogCommentRepository;
        _tagRepository = tagRepository;
        _blogLikeRepository = blogLikeRepository;
        _userRepository = userRepository;
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
                blog.BlogLikes= await _blogLikeRepository.GetAsync(blog.BlogId, cancellationToken);
                var tagData= await _tagRepository.GetAsync(blog.TagId,cancellationToken);
                blog.TagName = tagData?.TagName;
                blog.User = await _userRepository.GetAsync(blog.UserId, cancellationToken);
               
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
        var trendingblogs = new List<Blog>();
        if (allActiveBlogs != null)
        {
            foreach (var blog in allActiveBlogs)
            {
                blog.User = await _userRepository.GetAsync(blog.UserId, cancellationToken);
                trendingblogs.Add(blog);
            }
        }        
      return trendingblogs?.Where(x => x.IsTranding==true).ToList();
    }

    public async Task ApproveBlogAsync(int blogId, CancellationToken cancellationToken)
    {
      await _blogRepository.ApproveAsync(blogId, cancellationToken);
    }

    public async Task RejectBlogAsync(int blogId, string comment, CancellationToken cancellationToken)
    {
        await _blogRepository.RejectAsync(blogId, comment, cancellationToken);
    }

    public async Task<Blog?> BlogLikeAsync(int blogId, CancellationToken cancellationToken)
    {
        return await _blogRepository.BlogLikeAsync(blogId, cancellationToken);
    }

    public async Task<Blog?> BlogDisLikeAsync(int blogId, CancellationToken cancellationToken)
    {
        return await _blogRepository.BlogDisLikeAsync(blogId, cancellationToken);
    }
    #endregion


}
