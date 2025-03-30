using MediatR;
using MovieSearch.Domain.Dtos;

namespace MovieSearch.Application.Movies.Queries.GetMoviesByTitle;

public record GetMovieQuery (string Title) : IRequest<IEnumerable<MovieReadDto>>;
