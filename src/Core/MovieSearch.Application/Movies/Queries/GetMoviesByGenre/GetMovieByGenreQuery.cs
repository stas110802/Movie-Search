using MediatR;
using MovieSearch.Domain.Dtos;

namespace MovieSearch.Application.Movies.Queries.GetMoviesByGenre;

public sealed record GetMovieByGenreQuery (string Genre) : IRequest<IEnumerable<MovieReadDto>>;