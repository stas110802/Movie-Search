using AutoMapper;
using MediatR;
using MovieSearch.Application.Movies.Queries.GetMoviesByTitle;
using MovieSearch.Domain.Dtos;
using MovieSearch.Domain.Entities;
using MovieSearch.Domain.Repositories;

namespace MovieSearch.Application.Movies.Queries.GetMoviesByGenre;

public sealed class GetMovieByGenreQueryHandler : IRequestHandler<GetMovieByGenreQuery, IEnumerable<MovieReadDto>>
{
    private readonly IMovieRepository _repository;
    private readonly IMapper _mapper;

    public GetMovieByGenreQueryHandler(IMovieRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieReadDto>> Handle(GetMovieByGenreQuery request,
        CancellationToken cancellationToken)
    {
        var genre = request.Genre;
        var dbSearchMovies = await _repository.GetByGenreAsync(genre);
        var mapDbSearchMovies = _mapper.Map<IEnumerable<MovieReadDto>>(dbSearchMovies);

        return mapDbSearchMovies;
    }
}