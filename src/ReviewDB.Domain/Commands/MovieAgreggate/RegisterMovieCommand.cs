using ReviewDB.Domain.Validation.MovieAgreggate;

namespace ReviewDB.Domain.Commands.MovieAgreggate
{
    public class RegisterMovieCommand : MovieCommand
    {
        public RegisterMovieCommand(string title)
        {
            Title = title;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterMovieCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
