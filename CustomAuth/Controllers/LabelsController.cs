using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LabelsController : ControllerBase
{
    [HttpGet]
    [Authorize("Label:Read")]
    public IEnumerable<string> GetAll()
    {
        var strings = new[] { "red", "blue" };

        return strings;
    }
}
