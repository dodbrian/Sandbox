using CustomAuth.Identity.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LabelsController : ControllerBase
{
    [HttpGet]
    [Policy("Label:Read")]
    public IEnumerable<string> GetAll()
    {
        var strings = new[] { "red", "blue" };

        return strings;
    }
}
