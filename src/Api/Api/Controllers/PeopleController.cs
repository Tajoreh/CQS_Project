using Application;
using Framework;
using Infrastructure.Query.Ef;
using Infrastructure.Query.Ef.Models;
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

[ApiController]
[Route("[controller]")]
public class PeopleQueryController : ControllerBase
{
    private readonly IQueryBus _queryBus;

    public PeopleQueryController(IQueryBus queryBus)
    {
        _queryBus = queryBus;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Create([FromRoute] long id)
    {
        var query = new GetPersonRequest()
        {
            Id = id
        };

        var person=await _queryBus.Execute<GetPersonRequest,Person>(query);

        return Ok(person);
    }
}