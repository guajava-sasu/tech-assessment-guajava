using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WeChooz.TechAssessment.Web.Authentication;

[Route("_api/admin/login")]
public class PerformLoginEndpoint : Ardalis.ApiEndpoints.EndpointBaseAsync.WithRequest<PerformLoginRequest>
    .WithActionResult
{
    private const string CookieScheme = "Cookies";

    [HttpPost]
    public override async Task<ActionResult> HandleAsync(PerformLoginRequest request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(request.Login))
        {
            return BadRequest("Login cannot be empty.");
        }

        if (request.Login == "formation" || request.Login == "sales")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, request.Login),
                new Claim(ClaimTypes.Name, request.Login)
            };

            var identity = new ClaimsIdentity(claims, CookieScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieScheme, principal);

            return Ok(claims.Select(c => new { type = c.Type, value = c.Value }));
        }

        return Unauthorized();
    }
}
