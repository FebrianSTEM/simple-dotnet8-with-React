using Movies.Contract.Errors;

namespace Movies.Contract.Excpetions;

public class CustomValidationException : Exception
{
    public List<ValidationError> ValidationErrors { get; set; }

    public CustomValidationException(List<ValidationError> validationErrors)
    {
        ValidationErrors = validationErrors;
    }

}
