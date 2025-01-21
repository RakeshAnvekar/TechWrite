using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.Models.Blog;
using TechWriteServer.Repositories.Interfaces;

namespace TechWriteServer.BusinessLogics;

public class BlogLikeLogic : IBlogLikeLogic
{
    #region Private Properties
    private readonly IBlogLikeRepository _blogLikeRepository;
    #endregion

    #region Constructors
    public BlogLikeLogic(IBlogLikeRepository blogLikeRepository)
    {
        _blogLikeRepository = blogLikeRepository;
    }
   
    #endregion

    #region Methods
    public Task<List<BlogLike>> GetAsync(int blogId, CancellationToken cancellationToken)
    {
       return _blogLikeRepository.GetAsync(blogId, cancellationToken);
    }
    public async Task<int> AddAsync(int blogId, Guid userId, CancellationToken cancellationToken)
    {
        await _blogLikeRepository.CreateAsync(blogId, userId, cancellationToken);
        var blogLikes= await _blogLikeRepository.GetAsync(blogId, cancellationToken);
        return blogLikes.Count;
    }
    #endregion

}
