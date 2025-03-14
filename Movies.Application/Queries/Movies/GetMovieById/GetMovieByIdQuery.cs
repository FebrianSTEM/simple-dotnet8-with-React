using MediatR;
using Movies.Contract.Response;

namespace Movies.Application.Queries.Movies.GetMovieById;

public record GetMovieByIdQuery(int id) : IRequest<GetMovieByIdResponse>;