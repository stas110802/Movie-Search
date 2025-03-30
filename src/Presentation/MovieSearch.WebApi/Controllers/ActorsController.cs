using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieSearch.Application.Actors.Commands.CreateActor;
using MovieSearch.Application.Actors.Queries.GetAllActors;
using MovieSearch.Domain.Dtos;

namespace MovieSearch.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorController : Controller
{
    private readonly IMediator _mediator;

    public ActorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<ActorReadDto>> GetAllActors()
    {
        var actors = await _mediator.Send(new GetAllActorsQuery());

        return Ok(actors);
    }
    
    [HttpPost]
    public async Task<ActionResult<ActorReadDto>> AddNewActor(string fullName)
    {
        var actor = await _mediator.Send(new CreateActorCommand(fullName));

        return Ok(actor);
    }
}