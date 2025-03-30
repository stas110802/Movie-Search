using MediatR;
using MovieSearch.Domain.Dtos;

namespace MovieSearch.Application.Movies.Commands.AddActorToMovie;

public sealed record AddActorToMovieCommand(int MovieId, int ActorId) : IRequest<bool>;
