using FluentValidation;

namespace Movies.Application.Queries.Movies.GetMovieById;

public class GetMovieByIdQueryValidator : AbstractValidator<GetMovieByIdQuery>
{
    public GetMovieByIdQueryValidator()
    {
        RuleFor(x => x.id)
            .NotEmpty()
            .WithMessage($"{nameof(GetMovieByIdQuery.id)} cannot be empty");
    }
}
