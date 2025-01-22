using Microsoft.AspNetCore.Mvc;

namespace TechWriteServer.Controllers;

public class ErrorController : Controller
{
    public IActionResult HandleError(int statusCode)
    {
        ViewBag.StatusCode = statusCode;

        return View("Error"); 
    }
}

