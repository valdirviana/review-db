using System;

namespace ReviewDB.Domain.Entities.MovieAggregate
{
    public class Movie : BaseEntity
    {
        public Movie(int tmdbId, string originalTitle, bool adult)
        {
            TmdbId = tmdbId;
            OriginalTitle = originalTitle;
            Adult = adult;
        }

        public int TmdbId { get; private set; }
        public string OriginalTitle { get; private set; }
        public string Overview { get; private set; }
        public string ImdbId { get; private set; }
        public double Popularity { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Homepage { get; private set; }
        public bool Adult { get; private set; }
    }
}
