using Microsoft.AspNetCore.Mvc;
using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.Models.User;

namespace TechWriteServer.Controllers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserApiController : ControllerBase
{
    #region Private Properties
    private readonly IUserLogic _userLogic;
    private readonly ILogger<UserApiController> _logger;
    #endregion

    #region Constructors
    public UserApiController(IUserLogic userLogic, ILogger<UserApiController> logger)
    {
        _logger = logger;
        _userLogic = userLogic;
    }
    #endregion

    #region Methods
    [HttpPost("Register")]
    public async Task<IActionResult> Post(User user)
    {
        try
        {
            var result = await _userLogic.RegisterUserAsync(user, HttpContext.RequestAborted);
            return Ok(new { message = "User registered successfully!",result });
        }
        catch (Exception ex) {
            _logger.LogError($"Class : {nameof(UserApiController)} , Erroe while registering the user : {user} , Exception : {ex.InnerException}");
            return BadRequest();
        }
    }
    #endregion

}
