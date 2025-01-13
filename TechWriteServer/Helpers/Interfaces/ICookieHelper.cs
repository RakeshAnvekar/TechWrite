namespace TechWriteServer.Helpers.Interfaces;

public interface ICookieHelper
{
    #region Methods
    public Task SetCookieAsync(string cookieName, string value, int expirationMinutes = 120);

    public Task<string?> GetCookieAsync(string cookieName);

    public Task DeleteCookieAsync(string cookieName);
    #endregion
}
