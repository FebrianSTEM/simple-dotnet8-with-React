using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Contract.Excpetions;
using Movies.Contract.Response;
using Movies.Domain.Entities;
using Movies.Infrastructure;

namespace Movies.Application.Queries.Movies.GetMovieById;

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, GetMovieByIdResponse>
{
    private readonly MoviesDbContext _moviesDbContext;

    public GetMovieByIdQueryHandler(MoviesDbContext moviesDbContext)
    {
        _moviesDbContext = moviesDbContext;
    }

    public async Task<GetMovieByIdResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        Movie? movie = await _moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == request.id);

        if (movie == null) { throw new NotFoundException($"{nameof(Movie)} with {nameof(movie.Id)}: {request.id} was not found in database"); }

        return movie.Adapt<GetMovieByIdResponse>();
    }
}