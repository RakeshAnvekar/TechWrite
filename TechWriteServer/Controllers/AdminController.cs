using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.ViewModels;

namespace TechWriteServer.Controllers;
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    #region Private Properties
    private readonly IBlogLogic _logLogic;
    private readonly ILogger<AdminController> _logger;
    #endregion

    #region Constructors
    public AdminController(IBlogLogic logLogic, ILogger<AdminController> logger)
    {
        _logger = logger;
        _logLogic = logLogic;
    }
    #endregion

    #region Public Methods
    public async Task<IActionResult> Index()
    {
        try
        {
            var blogs =await _logLogic.GetAllBlogsAsync(HttpContext.RequestAborted);
            var adminActionViewModel = new AdminActionViewModel()
            {
                Blogs = blogs?.Blogs
            };
            return View(adminActionViewModel);
        }
        catch (Exception ex) {
            _logger.LogError($"Class : {nameof(AdminController)}, Error in Admin Controller, Exception : {ex.InnerException}");
            return BadRequest();
        }
       
    }
    #endregion
}
