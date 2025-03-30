using AutoMapper;
using MediatR;
using MovieSearch.Domain.Dtos;
using MovieSearch.Domain.Entities;
using MovieSearch.Domain.Repositories;

namespace MovieSearch.Application.Actors.Commands.CreateActor;

public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, ActorReadDto>
{
    private readonly IActorRepository _repository;
    private readonly IMapper _mapper;

    public CreateActorCommandHandler(IActorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ActorReadDto> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        var actor = new Actor { Name = request.Name };
        await _repository.AddAsync(actor);

        return _mapper.Map<ActorReadDto>(actor);
    }
}