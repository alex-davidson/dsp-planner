namespace DspPlanner.Model.Mappers;

public record struct ValidationFailure(string Message, bool IsFatal)
{
    public static ValidationFailure Error(string message) => new ValidationFailure(message, true);
    public static ValidationFailure Warning(string message) => new ValidationFailure(message, false);
}
