using Microsoft.AspNetCore.Mvc;

namespace TechWriteServer.Controllers;

public class ErrorController : Controller
{
    public IActionResult HandleError(int statusCode)
    {
        if (statusCode == 403)
        {
            return RedirectToAction("NotFoundError", "Error");
        }
        if (statusCode == 500)
        {
            return RedirectToAction("InternerServerError", "Error");
        }

        return View("Error");  // You can handle other errors here
    }
    public  IActionResult NotFoundError()
    {
        return View("NotFoundError");
    }

    private IActionResult ForbiddenError()
    {
        return View("ForbiddenError");
    }

    public IActionResult InternerServerError()
    {
        return View("InternerServerError");
    }
}
