using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReviewDB.Application.ViewModel
{
    public class MovieViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public int TmdbId { get; set; }

        [Required(ErrorMessage = "The Title is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Title")]
        public string OriginalTitle { get; set; }

        public bool Adult { get; set; }

        public double Popularity { get; set; }
    }
}
