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
    [HttpGet("sign-in/admin")]
    [AllowAnonymous]
    public async Task SignInAdmin()
    {
        var claimsPrincipal = new ClaimsPrincipal();
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, "admin"),
            new(
                "Policy",
                "*[Company=f7a99bb1-bb03-4228-ad4d-6bd6fe2b642a]"),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        claimsPrincipal.AddIdentity(identity);
        await HttpContext.SignInAsync(claimsPrincipal);
    }

    [HttpGet("sign-in/company-pm")]
    [AllowAnonymous]
    public async Task SignInCm()
    {
        var claimsPrincipal = new ClaimsPrincipal();
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, "company-pm"),
            new(
                "Policy",
                "Project:" +
                "*[Company=f7a99bb1-bb03-4228-ad4d-6bd6fe2b642a]"),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        claimsPrincipal.AddIdentity(identity);
        await HttpContext.SignInAsync(claimsPrincipal);
    }

    [HttpGet("sign-in/project-manager")]
    [AllowAnonymous]
    public async Task SignInPm()
    {
        var claimsPrincipal = new ClaimsPrincipal();
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, "project-manager"),
            new(
                "Policy",
                "Project:" +
                "Read[Project=9c665be9-9b7c-48b7-97e4-634953980ebf]," +
                "Update[Project=9c665be9-9b7c-48b7-97e4-634953980ebf]," +
                "Delete[Project=9c665be9-9b7c-48b7-97e4-634953980ebf]"),
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        claimsPrincipal.AddIdentity(identity);
        await HttpContext.SignInAsync(claimsPrincipal);
    }

    [HttpGet("sign-in/subcontractor")]
    [AllowAnonymous]
    public async Task SignInSubcontractor()
    {
        var claimsPrincipal = new ClaimsPrincipal();
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, "subcontractor"),
            new(
                "Policy",
                "Project:" +
                "Read[Project=9c665be9-9b7c-48b7-97e4-634953980ebf]" +
                "{WorkItem:Update[Participant=acdddcf7-5d36-4675-b197-337f2c52e579]}"),
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
