using FluentValidation;
using ReviewDB.Domain.Commands.MovieAgreggate;

namespace ReviewDB.Domain.Validation.MovieAgreggate
{
    public abstract class MovieValidation<T> : AbstractValidator<T> where T : MovieCommand
    {
        protected void ValidationTitle()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Please ensure Tittle")
                .Length(2, 200).WithMessage("The Title must have between 2 and 200 characters");
        }
    }
}
