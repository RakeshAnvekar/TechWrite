using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.Models.Blog;
using TechWriteServer.Views.Blog;

namespace TechWriteServer.Controllers.Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class BlogApiController : ControllerBase
    {
        #region Properties
        private readonly ILogger<BlogApiController> _logger;
        private readonly IBlogLogic _blogLogic;
        #endregion

        #region Contructors
        public BlogApiController(ILogger<BlogApiController> logger, IBlogLogic blogLogic)
        {
            _blogLogic = blogLogic;
            _logger = logger;
        }
        #endregion

        #region Methods
        [Authorize(Roles = "Admin,User")]
        [HttpPost("CreateNew")]
        public async Task<IActionResult> Post([FromBody] Blog blog)
        {
            try
            {
              var result= await _blogLogic.CreateNewBlog(blog,HttpContext.RequestAborted);
                return Ok(result);

            }
            catch (Exception ex) {
                _logger.LogError($"Class:{nameof(BlogApiController)}. :: Error while creating new blog. :: Exception: {ex.InnerException}");
            return BadRequest(ex);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _blogLogic.GetAllBlogsAsync(HttpContext.RequestAborted);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Class:{nameof(BlogApiController)}. :: Error while creating new blog. :: Exception: {ex.InnerException}");
                return BadRequest(ex);
            }

        }


        [Authorize(Roles = "Admin")]
        [HttpPost("ApproveBlog/{blogId:int}")]
        public async Task<IActionResult> Post(int blogId)
        {
            try
            {
               await _blogLogic.ApproveBlogAsync(blogId,HttpContext.RequestAborted);
                return Ok(new { message = "Blog approved successfully!" });

            }
            catch (Exception ex)
            {
                _logger.LogError($"Class:{nameof(BlogApiController)}. :: Error while Approving new blog. :: Exception: {ex.InnerException}");
                return BadRequest(ex);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("RejectBlog")]
        public async Task<IActionResult> Post(RejectBlog rejectBlog)
        {
            try
            {
                await _blogLogic.RejectBlogAsync(rejectBlog.BlogId, rejectBlog.RejectComment, HttpContext.RequestAborted);
                return Ok(new { message = "Blog Rejected successfully!" }); ;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Class:{nameof(BlogApiController)}. :: Error while Rejecting new blog. :: Exception: {ex.InnerException}");
                return BadRequest(ex);
            }

        }
        [Authorize(Roles = "Admin,User")]
        [HttpPut("LikeBlog/{blogId:int}")]
        public async Task<IActionResult> LikeBlog(int blogId)
        {
            try
            {
              var result =  await _blogLogic.BlogLikeAsync(blogId, HttpContext.RequestAborted);
                return Ok(result?.BlogLikes);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Class:{nameof(BlogApiController)}. :: Error while liking the blog. :: Exception: {ex.InnerException}");
                return BadRequest(ex);
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPut("DisLikeBlog/{blogId:int}")]
        public async Task<IActionResult> DisLikeBlog(int blogId)
        {
            try
            {
                var result = await _blogLogic.BlogDisLikeAsync(blogId, HttpContext.RequestAborted);
                return Ok(result?.BlogLikes);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Class:{nameof(BlogApiController)}. :: Error while disliking the blog. :: Exception: {ex.InnerException}");
                return BadRequest(ex);
            }
        }


        #endregion
    }
}
