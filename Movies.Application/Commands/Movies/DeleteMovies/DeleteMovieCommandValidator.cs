using FluentValidation;

namespace Movies.Application.Commands.Movies.DeleteMovies;

public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(DeleteMovieCommand.Id)} cannot be empty");
    }
}