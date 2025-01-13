using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechWriteServer.Autentication;
using TechWriteServer.BusinessLogics;
using TechWriteServer.BusinessLogics.Interfaces;
using TechWriteServer.Helpers.Interfaces;
using TechWriteServer.Models.User;

namespace TechWriteServer.Controllers;

public class UserController : Controller
{
    #region Properties
    private readonly IUserLogic _userLogic;
    private readonly ILogger<UserController> _logger;
    private readonly IValidator<User> _userValidator;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly ICookieHelper _cookieHelper;

    #endregion

    #region Constructors
    public UserController(IUserLogic userLogic, ILogger<UserController> logger, IValidator<User> userValidator, ITokenGenerator tokenGenerator, ICookieHelper cookieHelper)
    {
        _logger = logger;
        _userLogic = userLogic;
        _userValidator = userValidator;
        _tokenGenerator = tokenGenerator;
        _cookieHelper = cookieHelper;
       
    }
    #endregion

    #region Methods

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    public async Task<IActionResult> OnRegister(TechWriteServer.Models.User.User user)
    {
        try
        {
            var cancellationToken = HttpContext.RequestAborted;
            var validationResult = await _userValidator.ValidateAsync(user, cancellationToken);

            User? userResult = null;
            if (validationResult.IsValid)
            {
                userResult = await _userLogic.RegisterUserAsync(user, cancellationToken);
                TempData["SuccessMessage"] = $"Hi {userResult?.UserName}, Registration is successful.Now you can try to login.";
                return View(userResult);
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View("Register");
           
        }
        catch (Exception ex) {
            _logger.LogError($"Class:{nameof(UserController)}. :: Error while creating new blog. :: Exception: {ex.InnerException}");
            TempData["FailureMessage"] = "Registration failed, please try again after some time.";
            return View(null);
        }
       
    }

    [HttpGet]
    public async Task<IActionResult> IsEmailUnique(string emailAddress)
    {
        try
        {
            var users = await _userLogic.GetAllUserAsync(HttpContext.RequestAborted);
            if (users?.FirstOrDefault(x => x.UserEmailId == emailAddress) != null)
            {
                return Json($"The email address '{emailAddress}' is already taken.");
            }
            return Json(true);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Class:{nameof(UserController)}. :: Error while checking IsEmailUnique :: Exception: {ex.InnerException}");

            return Json(false);
        }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(User user)
    {
        try
        {
            var userExists = await _userLogic.LoginAsync(user, HttpContext.RequestAborted);
            if (userExists != null) {
              var tokenValue= await _tokenGenerator.GenerateTokenAsync(userExists, HttpContext.RequestAborted);
                if (!string.IsNullOrEmpty(tokenValue))
                {
                    TempData["userName"] = userExists?.UserName;
                    TempData["userLoggedInStatus"] = userExists?.IsUserLoggedIn;
                    await _cookieHelper.SetCookieAsync("AuthToken", tokenValue);
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    return NotFound($"Class : {nameof(UserController)} :Not able to create token for user :{user.UserEmailId}");
                }                
            }          
            return View();
        }
        catch (Exception ex) {
            _logger.LogError($"Class:{nameof(UserController)}. :: Error while user logs in :: Exception: {ex.InnerException}");
            return BadRequest();
        }
    }

    [Authorize(Roles = "User,Admin")]
    public async Task<IActionResult> Logout(User user)
    {
        await _cookieHelper.DeleteCookieAsync("AuthToken");
        TempData.Clear();
        return RedirectToAction("Login", "User");
    }
    #endregion

}
