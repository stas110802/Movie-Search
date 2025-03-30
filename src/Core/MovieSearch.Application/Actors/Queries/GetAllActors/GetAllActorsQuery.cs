using MediatR;
using MovieSearch.Domain.Dtos;

namespace MovieSearch.Application.Actors.Queries.GetAllActors;

public sealed record GetAllActorsQuery : IRequest<IEnumerable<ActorReadDto>>;
