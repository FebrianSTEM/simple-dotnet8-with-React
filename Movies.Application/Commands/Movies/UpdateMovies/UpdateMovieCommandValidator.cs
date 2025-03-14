using FluentValidation;
using Movies.Application.Commands.Movies.DeleteMovies;
using Movies.Domain.Entities;

namespace Movies.Application.Commands.Movies.UpdateMovies;

public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    public UpdateMovieCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(UpdateMovieCommand.Id)} cannot be empty");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage($"{nameof(Movie.Category)} cannot be empty")
            .MaximumLength(30)
            .WithMessage($"{nameof(Movie.Category)} cannot be longer than 30 characters");

        RuleFor(x => x.Title)
           .NotEmpty()
           .WithMessage($"{nameof(Movie.Title)} cannot be empty")
           .MaximumLength(1000)
           .WithMessage($"{nameof(Movie.Title)} cannot be longer than 1000 characters");

        RuleFor(x => x.Description)
           .NotEmpty()
           .WithMessage($"{nameof(Movie.Description)} cannot be empty")
           .MaximumLength(100)
           .WithMessage($"{nameof(Movie.Description)} cannot be longer than 100 characters");
    }
}
