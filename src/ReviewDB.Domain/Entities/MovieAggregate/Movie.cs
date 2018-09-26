using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewDB.Domain.Entities.MovieAggregate
{
    public class Movie : BaseEntity
    {
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public string ImdbId { get; set; }
        public double Popularity { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Homepage { get; set; }
        public bool Adult { get; set; }
    }
}
