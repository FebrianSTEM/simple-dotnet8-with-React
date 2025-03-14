using MediatR;

namespace Movies.Application.Commands.Movies.CreateMovies;

public record CreateMovieCommand(string Title, string Description, string Category) : IRequest<int>;