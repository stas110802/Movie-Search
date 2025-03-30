using AutoMapper;
using MediatR;
using MovieSearch.Domain.Dtos;
using MovieSearch.Domain.Repositories;

namespace MovieSearch.Application.Movies.Queries.GetAllMovies;

public sealed class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieReadDto>>
{ 
    private readonly IMovieRepository _repository;
    private readonly IMapper _mapper;

    public GetAllMoviesQueryHandler(IMovieRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper; 
    }
    
    public async Task<IEnumerable<MovieReadDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        var allMovies = await _repository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<MovieReadDto>>(allMovies);
        
        return result;
    }
}