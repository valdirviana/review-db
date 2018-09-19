using ReviewDB.Domain.Validation.MovieAgreggate;

namespace ReviewDB.Domain.Commands.MovieAgreggate
{
    public class UpdateMovieCommand : MovieCommand
    {
        public UpdateMovieCommand(string title)
        {
            Title = title;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateMovieCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}