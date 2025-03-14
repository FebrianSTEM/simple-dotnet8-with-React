using Mapster;
using Movies.Contract.Response;
using Movies.Domain.Entities;

namespace Movies.Application.Mappings;
public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<Movie>, GetMoviesResponse>.NewConfig()
        .Map(dest => dest.moviesDtos, src => src);

        TypeAdapterConfig<Movie?, GetMovieByIdResponse>.NewConfig()
        .Map(dest => dest.MovieDto, src => src);
    }
}