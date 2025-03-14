using MediatR;
using Movies.Contract.Response;

namespace Movies.Application.Queries.Movies.GetMovies;

public record GetMoviesQuery() : IRequest<GetMoviesResponse>;