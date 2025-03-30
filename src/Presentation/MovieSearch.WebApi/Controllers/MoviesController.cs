using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieSearch.Application.Movies.Commands.AddActorToMovie;
using MovieSearch.Application.Movies.Queries.GetAllMovies;
using MovieSearch.Application.Movies.Queries.GetMoviesByActor;
using MovieSearch.Application.Movies.Queries.GetMoviesByGenre;
using MovieSearch.Application.Movies.Queries.GetMoviesByTitle;
using MovieSearch.Domain.Dtos;

namespace MovieSearch.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : Controller
{
    private readonly IMediator _mediator;

    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetAllMovies()
    {
        var movies = await _mediator.Send(new GetAllMoviesQuery());

        return Ok(movies);
    }

    [HttpGet("t/{title}")]
    public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetMoviesByTitle(string title)
    {
        var movies = await _mediator.Send(new GetMovieByTitleQuery(title, false));

        return Ok(movies);
    }

    [HttpGet("g/{genre}")]
    public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetMoviesByGenre(string genre)
    {
        var movies = await _mediator.Send(new GetMovieByGenreQuery(genre));

        return Ok(movies);
    }

    [HttpGet("a/{actor}")]
    public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetMoviesByActor(string actor)
    {
        var movies = await _mediator.Send(new GetMovieByActorQuery(actor));

        return Ok(movies);
    }
    
    [HttpGet("actors/{actorId}&{movieId}")]
    public async Task<ActionResult<bool>> AddActorToMovie(int movieId, int actorId)
    {
        var isSuccessful = await _mediator.Send(new AddActorToMovieCommand(movieId, actorId));

        return Ok(isSuccessful);
    }
}