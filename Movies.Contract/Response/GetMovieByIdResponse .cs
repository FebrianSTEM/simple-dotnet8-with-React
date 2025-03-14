using Movies.Contract.Dtos;

namespace Movies.Contract.Response;

public record GetMovieByIdResponse(MovieDto MovieDto);