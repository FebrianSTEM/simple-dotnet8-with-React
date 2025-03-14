using MediatR;
using System;

namespace Movies.Application.Commands.Movies.UpdateMovies;

public record UpdateMovieCommand(int Id, string Title, string Description, string Category) : IRequest<Unit>;