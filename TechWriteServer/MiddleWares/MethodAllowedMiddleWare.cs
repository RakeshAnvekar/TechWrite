using System.Text.Json;
using TechWriteServer.Models.Others;

namespace TechWriteServer.MiddleWares;

public class MethodAllowedMiddleWare
{
    #region Privete Properties
    private readonly RequestDelegate _next;
    private readonly string[] _httpMethodsToAlow;
    #endregion
    #region Constructor
    public MethodAllowedMiddleWare(RequestDelegate next, string[] httpMethodsToAlow)
    {
        _next = next;
        _httpMethodsToAlow = httpMethodsToAlow;
    }
    #endregion
    #region MiddleWare Method
    public async Task InvokeAsyc(HttpContext context)
    {

        if (!_httpMethodsToAlow.Contains(context.Request.Method)) {

          context.Response.StatusCode=StatusCodes.Status405MethodNotAllowed;
            var customResponse = new  CommonMiddleWare
            {
            Code = StatusCodes.Status405MethodNotAllowed,
            CustomMessge=$"Http {context.Request.Method} ststus code is not allowed."
            };
            var responseJson=JsonSerializer.Serialize(customResponse);
            await context.Response.WriteAsync(responseJson);
            return;//short circuit the pipeline to pevenet further processing        
        }
        await _next(context);
    }
    #endregion
}
