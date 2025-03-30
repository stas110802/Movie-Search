using AutoMapper;
using MediatR;
using MovieSearch.Domain;
using MovieSearch.Domain.Dtos;
using MovieSearch.Domain.Entities;
using MovieSearch.Domain.Repositories;

namespace MovieSearch.Application.Movies.Queries.GetMoviesByTitle;

public sealed class GetMovieByTitleQueryHandler : IRequestHandler<GetMovieByTitleQuery, IEnumerable<MovieReadDto>>
{
    private readonly IMovieRepository _repository;
    private readonly IRestMovieClient _restClient;
    private readonly IMapper _mapper;

    public GetMovieByTitleQueryHandler(IMovieRepository repository, IRestMovieClient restClient, IMapper mapper)
    {
        _repository = repository;
        _restClient = restClient;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieReadDto>> Handle(GetMovieByTitleQuery request,
        CancellationToken cancellationToken)
    {
        var title = request.Title;
        var dbSearchMovies = await _repository.GetByTitleAsync(title, 65);

        if (dbSearchMovies.Any())
        {
            var mapDbSearchMovies = _mapper.Map<IEnumerable<MovieReadDto>>(dbSearchMovies);

            return mapDbSearchMovies;
        }

        if (!request.UseHelperApi) 
            return Array.Empty<MovieReadDto>();
        
        var restSearchMovies = await _restClient.GetMoviesByNameAsync(title);
        var mapRestSearchMovies = _mapper.Map<IEnumerable<MovieReadDto>>(restSearchMovies);

        var cache = _mapper.Map<IEnumerable<Movie>>(mapRestSearchMovies);
        foreach (var movie in cache)
        {
            await _repository.AddAsync(movie);
        }

        return mapRestSearchMovies;

    }
}