using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Commands.Movies.CreateMovies;
using Movies.Contract.Excpetions;
using Movies.Domain.Entities;
using Movies.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Commands.Movies.UpdateMovies;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Unit>
{
    private readonly MoviesDbContext _moviesDbContext;

    public UpdateMovieCommandHandler(MoviesDbContext moviesDbContext)
    {
        _moviesDbContext = moviesDbContext;

    }

    public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (movie is null) { throw new NotFoundException($"{nameof(Movie)} with {nameof(Movie.Id)}: {request.Id} was not found in database"); }

        movie.Title = request.Title;
        movie.Category = request.Category;
        movie.Description = request.Description;

        _moviesDbContext.Movies.Update(movie);
        await _moviesDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
