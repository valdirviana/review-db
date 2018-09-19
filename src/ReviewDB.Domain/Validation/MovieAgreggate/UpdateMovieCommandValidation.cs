using ReviewDB.Domain.Commands.MovieAgreggate;

namespace ReviewDB.Domain.Validation.MovieAgreggate
{
    public class UpdateMovieCommandValidation : MovieValidation<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidation()
        {
            ValidationTitle();
        }
    }
}
