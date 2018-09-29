using ReviewDB.Domain.Validation.MovieAgreggate;
using System;

namespace ReviewDB.Domain.Commands.MovieAgreggate
{
    public class RegisterMovieCommand : MovieCommand
    {
        protected RegisterMovieCommand(Guid id,
            int tmdbId,
            string originalTitle,
            string overview,
            string imdbId,
            double popularity,
            DateTime releaseDate,
            string homepage,
            bool adult)
        {
            Id = id;
            TmdbId = tmdbId;
            OriginalTitle = originalTitle;
            Overview = overview;
            ImdbId = imdbId;
            Popularity = popularity;
            ReleaseDate = releaseDate;
            Homepage = homepage;
            Adult = adult;
        }

        public RegisterMovieCommand() { }

        public override bool IsValid()
        {
            ValidationResult = new RegisterMovieCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
