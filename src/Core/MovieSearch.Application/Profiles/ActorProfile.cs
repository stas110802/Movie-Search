using AutoMapper;
using MovieSearch.Domain.Dtos;
using MovieSearch.Domain.Entities;

namespace MovieSearch.Application.Profiles;

public class ActorProfile : Profile
{
    public ActorProfile()
    {
        CreateMap<Actor, ActorReadDto>();
        CreateMap<ActorReadDto, Actor>();
    }
}