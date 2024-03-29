using CustomAuth.Identity.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CustomAuth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    // GET: api/Projects
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] { "value1", "value2" };
    }

    // GET: api/Projects/5
    [Policy("Project:Read")]
    [HttpGet("{id:guid}", Name = "Get")]
    public string Get([Condition("Project")] Guid id)
    {
        return "value";
    }

    // POST: api/Projects
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Projects/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/Projects/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
