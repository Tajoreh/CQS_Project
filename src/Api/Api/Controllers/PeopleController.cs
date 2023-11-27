using Application;
using Framework;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private readonly ICommandBus _commandBus;
    public PeopleController(ICommandBus commandBus)
    {
        _commandBus = commandBus;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePersonRequest request)
    {
        var command = new CreatePersonCommand()
        {
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        await _commandBus.Dispatch(command);

        return Ok();
    }
}