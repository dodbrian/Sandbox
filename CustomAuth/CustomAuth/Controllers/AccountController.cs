using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpGet("sign-in")]
    [AllowAnonymous]
    public async Task SignIn()
    {
        var claimsPrincipal = new ClaimsPrincipal();
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, "testUser"),
            new("Policy", "Project:Read[Project=$project,Company=$company],Create{WorkItem:Read,Update[Participant=$participant]};*:*;*;Task:*;*:Delete;*[Test=123];*:*[Test=333];Template:Read{*}"),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        claimsPrincipal.AddIdentity(identity);
        await HttpContext.SignInAsync(claimsPrincipal);
    }

    [HttpGet("log-off")]
    public async Task LogOff()
    {
        await HttpContext.SignOutAsync();
    }
}
