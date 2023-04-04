using Microsoft.AspNetCore.Mvc;
using part2.Models;

namespace part2.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonneController : ControllerBase
{

    private readonly ILogger<PersonneController> _logger;
    private readonly IPersonneHandler _handler;

    public PersonneController(ILogger<PersonneController> logger, IPersonneHandler handler)
    {
        _logger = logger;
        _handler = handler;
    }

    [HttpPost(Name = "PostPersonne")]
    public async Task<ActionResult<Personne>> PostPersonneItem(Personne personneItem)
    {
        var result = await _handler.AddPersonne(personneItem);

        return result ? CreatedAtAction(nameof(Personne), personneItem) :
            BadRequest("Personne not valid");
    }

    [HttpPost(Name = "GetPersonnes")]
    public async Task<ActionResult<IEnumerable<GetPersonnesDto>>> GetPersonneItems()
    {
        var result = await _handler.GetPersonnes();

        return Ok(result);
    }
}
