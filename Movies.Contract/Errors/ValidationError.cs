namespace Movies.Contract.Errors;

public class ValidationError
{
    public string Property { get; set; }
    public string Message { get; set; }
}
