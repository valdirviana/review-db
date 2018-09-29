using ReviewDB.Domain.Core.Commands;
using System;

namespace ReviewDB.Domain.Commands.MovieAgreggate
{
    public abstract class MovieCommand : Command
    {
        public Guid? Id { get; set; }
        public int? TmdbId { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string ImdbId { get; set; }
        public double Popularity { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Homepage { get; set; }
        public bool? Adult { get; set; }
    }
}
