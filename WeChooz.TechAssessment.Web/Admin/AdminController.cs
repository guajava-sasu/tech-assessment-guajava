using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace WeChooz.TechAssessment.Web.Admin;

public class AdminController : Controller
{
    [HttpGet]
    [Authorize(Policy = "FormationOrSales")]
    public ActionResult Handle()
    {
        Response.Headers[HeaderNames.CacheControl] = "no-cache, must-revalidate";
        return View();
    }

    [HttpGet("login")]
    [AllowAnonymous]
    public ActionResult Login()
    {
        return View(); 
    }

    [Authorize(Policy = "FormationOrSales")]
    
    [HttpPost("/participants")]
    public IActionResult AddParticipant()
    {
        return Ok("Participant added");
    }

    [Authorize(Policy = "FormationOnly")]
    [HttpPost("/sessions")]
    public IActionResult CreateSession()
    {
        return Ok("Session created");
    }

    [Authorize(Policy = "FormationOnly")]
    [HttpPost("/courses")]
    public IActionResult CreateCourse()
    {
        return Ok("Course created");
    }


}
