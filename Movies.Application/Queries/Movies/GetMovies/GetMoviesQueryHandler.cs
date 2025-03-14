using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Contract.Response;
using Movies.Domain.Entities;
using Movies.Infrastructure;

namespace Movies.Application.Queries.Movies.GetMovies;

public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, GetMoviesResponse>
{
    private readonly MoviesDbContext _moviesDbContext;

    public GetMoviesQueryHandler(MoviesDbContext moviesDbContext)
    {
        _moviesDbContext = moviesDbContext;
    }
        
    public async Task<GetMoviesResponse> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        List<Movie> movies = await _moviesDbContext.Movies.ToListAsync(cancellationToken);

        return movies.Adapt<GetMoviesResponse>();
    }
}
