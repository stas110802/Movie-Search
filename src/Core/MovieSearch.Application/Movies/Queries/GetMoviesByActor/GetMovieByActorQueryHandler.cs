using AutoMapper;
using MediatR;
using MovieSearch.Domain.Dtos;
using MovieSearch.Domain.Repositories;

namespace MovieSearch.Application.Movies.Queries.GetMoviesByActor;

public sealed class GetMovieByActorQueryHandler : IRequestHandler<GetMovieByActorQuery, IEnumerable<MovieReadDto>>
{
    private readonly IMovieRepository _repository;
    private readonly IMapper _mapper;

    public GetMovieByActorQueryHandler(IMovieRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieReadDto>> Handle(GetMovieByActorQuery request,
        CancellationToken cancellationToken)
    {
        var actorName = request.ActorName;
        var dbSearchMovies = await _repository.GetByActorAsync(actorName);
        var mapDbSearchMovies = _mapper.Map<IEnumerable<MovieReadDto>>(dbSearchMovies);

        return mapDbSearchMovies;
    }
}