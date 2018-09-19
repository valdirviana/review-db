using ReviewDB.Domain.Commands.MovieAgreggate;

namespace ReviewDB.Domain.Validation.MovieAgreggate
{
    public class RemoveMovieCommandValidation : MovieValidation<RemoveMovieCommand>
    {
        public RemoveMovieCommandValidation()
        {
            ValidateId();
        }
    }
}
