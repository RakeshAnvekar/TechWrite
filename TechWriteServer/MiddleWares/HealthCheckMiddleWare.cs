namespace TechWriteServer.MiddleWares;

public class HealthCheckMiddleWare
{
    #region Private Properties
    private readonly RequestDelegate _next;
    #endregion
    #region Constructor
    public HealthCheckMiddleWare(RequestDelegate next)
    {
        _next = next;
    }
    #endregion
    #region MiddleWare method
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/healthcheck")
        {
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsync("TechWrite app is healthy");
            await context.Response.CompleteAsync();
        }
        else
        {
            await _next(context);
        }
    }
    #endregion
}
