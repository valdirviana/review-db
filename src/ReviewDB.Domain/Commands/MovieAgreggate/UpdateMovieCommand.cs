using ReviewDB.Domain.Validation.MovieAgreggate;
using System;

namespace ReviewDB.Domain.Commands.MovieAgreggate
{
    public class UpdateMovieCommand : MovieCommand
    {
        public UpdateMovieCommand(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateMovieCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}