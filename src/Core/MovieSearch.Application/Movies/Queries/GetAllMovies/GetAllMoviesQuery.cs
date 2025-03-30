using MediatR;
using MovieSearch.Domain.Dtos;

namespace MovieSearch.Application.Movies.Queries.GetAllMovies;

public sealed record GetAllMoviesQuery : IRequest<IEnumerable<MovieReadDto>>;