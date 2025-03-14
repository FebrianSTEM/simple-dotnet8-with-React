using MediatR;
using Movies.Application.Commands.Movies.CreateMovies;
using Movies.Application.Commands.Movies.DeleteMovies;
using Movies.Application.Commands.Movies.UpdateMovies;
using Movies.Application.Queries.Movies.GetMovieById;
using Movies.Application.Queries.Movies.GetMovies;
using Movies.Contract.Request.Movies;

namespace Movies.Presentation.Modules;

public static class MovieModules
{
    public static void AddMoviesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/movies", async (IMediator mediator, CancellationToken ct) =>
        {
            var movies = await mediator.Send(new GetMoviesQuery(), ct);
            return Results.Ok(movies);
        }).WithTags("Movies");

        app.MapGet("api/movies/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var movie = await mediator.Send(new GetMovieByIdQuery(id), ct);
            return Results.Ok(movie);
        }).WithTags("Movies");

        app.MapPost("api/movies", async (IMediator mediator, CreateMovieRequest createMovieRequest, CancellationToken ct) =>
        {
            var command = new CreateMovieCommand(createMovieRequest.Title, createMovieRequest.Description, createMovieRequest.Category);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Movies");

        app.MapPut("api/movies/{id}", async (IMediator mediator, int id, UpdateMovieRequest updateMovieRequest, CancellationToken ct) =>
        {
            var command = new UpdateMovieCommand(id, updateMovieRequest.Title, updateMovieRequest.Description, updateMovieRequest.Category);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Movies");

        app.MapDelete("api/movies/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var command = new DeleteMovieCommand(id);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Movies");
    }
}
