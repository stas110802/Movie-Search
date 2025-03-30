using AutoMapper;
using MovieSearch.Domain.Dtos;
using MovieSearch.Domain.Entities;

namespace MovieSearch.Application.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieReadDto>();
        CreateMap<MovieApiDto, MovieReadDto>();
        CreateMap<MovieReadDto, Movie>();
    }
}