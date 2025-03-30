using MediatR;
using MovieSearch.Domain.Dtos;

namespace MovieSearch.Application.Movies.Queries.GetMoviesByActor;

public sealed record GetMovieByActorQuery (string ActorName) : IRequest<IEnumerable<MovieReadDto>>;