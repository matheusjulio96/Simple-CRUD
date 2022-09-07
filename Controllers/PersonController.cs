using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simple_CRUD.Commands;
using Simple_CRUD.Infrastructure;
using Simple_CRUD.Queries;

namespace Simple_CRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IMediator mediator;

    public PersonController(ILogger<PersonController> logger, IMediator mediator)
    {
        _logger = logger;
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IEnumerable<Person>> Get([FromBody] GetPersonsRequest request)
    {
        return await mediator.Send(request);
    }

    [HttpPost("id")]
    public async Task<Person> GetByID([FromBody] GetPersonRequest request)
    {
        return await mediator.Send(request);
    }

    [HttpPost("create")]
    public async Task<CommandResponse<Person>> Create([FromBody] CreatePersonCommand request)
    {
        return await mediator.Send(request);
    }

    [HttpPost("update")]
    public async Task<CommandResponse<Person>> Update([FromBody] UpdatePersonCommand request)
    {
        return await mediator.Send(request);
    }

    [HttpPost("delete")]
    public async Task<CommandResponse<Person>> Delete([FromBody] DeletePersonCommand request)
    {
        return await mediator.Send(request);
    }
}
