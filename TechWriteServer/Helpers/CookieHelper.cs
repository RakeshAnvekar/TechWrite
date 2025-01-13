using TechWriteServer.Helpers.Interfaces;

namespace TechWriteServer.Helpers;

public class CookieHelper : ICookieHelper
{
    #region Properties
    private readonly IHttpContextAccessor _contextAccessor;
    #endregion

    #region Constructors
    public CookieHelper(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;   
    }
    #endregion

    #region Methods
    public async Task DeleteCookieAsync(string cookieName)
    {
        _contextAccessor?.HttpContext?.Response.Cookies.Delete(cookieName);
        await Task.CompletedTask;
    }

    public async Task<string?> GetCookieAsync(string cookieName)
    {
        return await Task.FromResult(_contextAccessor?.HttpContext?.Request.Cookies[cookieName]);
    }

    public async Task SetCookieAsync(string cookieName, string value,int expirationMinutes = 120)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,// Prevent client-side JS from accessing the cookie
            Secure = true, // Only send cookie over HTTPS
            SameSite = SameSiteMode.Strict,// Restrict cross-site request handling
            Expires = DateTime.Now.AddMinutes(expirationMinutes)
        };
        _contextAccessor?.HttpContext?.Response.Cookies.Append(cookieName, value, cookieOptions);
       await Task.CompletedTask;
    }
    #endregion
}
