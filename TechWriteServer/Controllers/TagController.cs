using Microsoft.AspNetCore.Mvc;
using TechWriteServer.BusinessLogics.Interfaces;

namespace TechWriteServer.Controllers;

public class TagController : Controller
{
    #region Private Properties
    private readonly ILogger<TagController> _logger;
    private readonly ITagLogic _tagLogic;
    #endregion

    #region Constructors
    public TagController(ILogger<TagController> logger, ITagLogic tagLogic)
    {
        _logger = logger; 
        _tagLogic = tagLogic;
    }
    #endregion

    #region View Methods
    public async Task<IActionResult> Index()
    {
        try
        {
            var result = await _tagLogic.GetAllTagsAsync(HttpContext.RequestAborted);
            return View(result);
        }
        catch (Exception ex) {
            _logger.LogError($"Clas: ${nameof(TagController)} ,Error while getting all tags, Exception: {ex.InnerException}");
            return BadRequest();
        }
    }

    #endregion

}
