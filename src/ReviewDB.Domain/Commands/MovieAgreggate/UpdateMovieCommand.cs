using ReviewDB.Domain.Validation.MovieAgreggate;
using System;

namespace ReviewDB.Domain.Commands.MovieAgreggate
{
    public class UpdateMovieCommand : MovieCommand
    {
        public UpdateMovieCommand(Guid id, string originalTitle)
        {
            Id = id;
            OriginalTitle = originalTitle;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateMovieCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
