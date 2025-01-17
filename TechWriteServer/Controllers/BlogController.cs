using Microsoft.AspNetCore.Mvc;
using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.ViewModels;
namespace TechWriteServer.Controllers;

public class BlogController : Controller
{
    #region Private Properties
    private readonly IBlogLogic _blogLogic;
    private readonly ILogger<BlogController> _logger;
    #endregion

    #region Constructors
    public BlogController(IBlogLogic blogLogic, ILogger<BlogController> logger)
    {
        _blogLogic = blogLogic;
        _logger = logger;
    }
    #endregion

    #region View Methods

    public async Task<IActionResult> Index()
    {
        try
        {
            if (TempData["userLoggedInStatus"] != null)
            {
                var userLoggedInStatus = TempData["userLoggedInStatus"] as bool?;
                if (userLoggedInStatus.HasValue)
                {
                    ViewBag.UserLoggedInStatus = userLoggedInStatus.Value;
                }                
            }
            var loginUserName = TempData["userName"] as string;
            if (TempData?["userId"]!=null)
            {
                Guid loginUserId = (Guid)TempData?["userId"];
                ViewBag.LoginUserId = loginUserId;
            }           

            ViewBag.LoginUserName = loginUserName; // Store the message in ViewBag           
            var items = await _blogLogic.GetAllBlogsAsync(HttpContext.RequestAborted);
            return View(items);
        }
        catch (Exception ex) {
            _logger.LogError($"Class: {nameof(BlogController)} :: Eroor found while getting all blogs :: Exception: {ex.InnerException}");
            return BadRequest();
        }
    }
    [HttpGet("TrandingBlogs")]
    public async Task<IActionResult> TrandingBlogs()
    {
        try
        {
            var items = await _blogLogic.GetAllTrandingBlogsAsync(HttpContext.RequestAborted);
            return View(items);
            
        }
        catch (Exception ex)
        {
            _logger.LogError($"Class: {nameof(BlogController)} :: Eroor found while getting tranding blogs :: Exception: {ex.InnerException}");
            return BadRequest();
        }
    }

    #endregion
}
