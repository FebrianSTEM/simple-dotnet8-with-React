using Movies.Contract.Dtos;

namespace Movies.Contract.Response;

public record GetMoviesResponse(List<MovieDto> moviesDtos);