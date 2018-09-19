using ReviewDB.Domain.Validation.MovieAgreggate;
using System;

namespace ReviewDB.Domain.Commands.MovieAgreggate
{
    public class RemoveMovieCommand : MovieCommand
    {
        public RemoveMovieCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveMovieCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}