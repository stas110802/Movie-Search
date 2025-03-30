using MediatR;
using MovieSearch.Domain.Dtos;

namespace MovieSearch.Application.Actors.Commands.CreateActor;

public sealed record CreateActorCommand(string Name) : IRequest<ActorReadDto>;