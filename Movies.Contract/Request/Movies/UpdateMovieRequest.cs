
namespace Movies.Contract.Request.Movies;

public record UpdateMovieRequest(int Id, string Title, string Description, string Category);