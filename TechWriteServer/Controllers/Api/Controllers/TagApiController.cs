using Microsoft.AspNetCore.Mvc;
using TechWriteServer.BusinessLogics.Interfaces;

namespace TechWriteServer.Controllers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagApiController : ControllerBase
{
    #region Private Readonly Properties

    private readonly ILogger<TagApiController> _logger;
    private readonly ITagLogic _tagLogic;

    #endregion

    #region Constructors
    public TagApiController(ILogger<TagApiController> logger, ITagLogic tagLogic)
    {
        _logger = logger;
        _tagLogic = tagLogic;
    }
    #endregion

    #region Methods

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        try
        {
            var results = await _tagLogic.GetAllTagsAsync(HttpContext.RequestAborted);
            return Ok(results);
        }
        catch (Exception ex) {
            _logger.LogError($"Clas: ${nameof(TagApiController)} ,Error while getting all tags, Exception: {ex.InnerException}");
            return BadRequest();
        }
       
    }
    #endregion
}
