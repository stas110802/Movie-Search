using AutoMapper;
using MediatR;
using MovieSearch.Domain.Dtos;
using MovieSearch.Domain.Repositories;

namespace MovieSearch.Application.Actors.Queries.GetAllActors;

public sealed class GetAllActorsQueryHandler: IRequestHandler<GetAllActorsQuery, IEnumerable<ActorReadDto>>
{ 
    private readonly IActorRepository _repository;
    private readonly IMapper _mapper;

    public GetAllActorsQueryHandler(IActorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper; 
    }
    
    public async Task<IEnumerable<ActorReadDto>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
    {
        var allMovies = await _repository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<ActorReadDto>>(allMovies);
        
        return result;
    }
}