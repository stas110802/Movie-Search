using AutoMapper;
using MediatR;
using MovieSearch.Domain.Dtos;
using MovieSearch.Domain.Repositories;

namespace MovieSearch.Application.Movies.Commands.AddActorToMovie;

public sealed class AddActorToMovieCommandHandler : IRequestHandler<AddActorToMovieCommand, bool>
{
    private readonly IMovieRepository _repository;

    public AddActorToMovieCommandHandler(IMovieRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(AddActorToMovieCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddActorToMovieAsync(request.MovieId, request.ActorId);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return false;
        }
    }
}