using ReviewDB.Domain.Commands.MovieAgreggate;

namespace ReviewDB.Domain.Validation.MovieAgreggate
{
    public class RegisterMovieCommandValidation : MovieValidation<RegisterMovieCommand>
    {
        public RegisterMovieCommandValidation()
        {
            ValidationTitle();
        }
    }
}
