
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.Models.Blog;

namespace TechWriteServer.Controllers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogLikeApiController : ControllerBase
{
    #region Private Properties
    private readonly ILogger<BlogLikeApiController> _logger;
    private readonly IBlogLikeLogic _logic;
    #endregion

    #region Constructors
    public BlogLikeApiController(ILogger<BlogLikeApiController> logger, IBlogLikeLogic logic)
    {
        _logger = logger;
        _logic = logic;
    }
    #endregion


    #region Methods
    [HttpGet("TotalBlogLikes")]
    public async Task<IActionResult> Get(int blogId)
    {
        try
        {
            var result = await _logic.GetAsync(blogId, HttpContext.RequestAborted);
            return Ok(result);

        }
        catch (Exception ex)
        {
            _logger.LogError($"Class:{nameof(BlogLikeApiController)}. :: Error while getting blog likes. :: Exception: {ex.InnerException}");
            return BadRequest();
        }

      

    }
    [HttpPost("UpdateBlogLike")]
    public async Task<IActionResult> Post([FromBody]BlogLikeRequest blogLikeRequest)
    {
        try
        {
           var blogLikeCount= await _logic.AddAsync(blogLikeRequest.BlogId, blogLikeRequest.UserId, HttpContext.RequestAborted);
            return Ok(blogLikeCount);

        }
        catch (Exception ex)
        {
            _logger.LogError($"Class:{nameof(BlogLikeApiController)}. :: Error while adding/updaing blog likes. :: Exception: {ex.InnerException}");
            return BadRequest();
        }
    }
    #endregion
}

