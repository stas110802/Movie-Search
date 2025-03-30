using MediatR;
using MovieSearch.Domain.Dtos;

namespace MovieSearch.Application.Movies.Queries.GetMoviesByTitle;

public sealed record GetMovieByTitleQuery (string Title, bool UseHelperApi = true) : IRequest<IEnumerable<MovieReadDto>>;