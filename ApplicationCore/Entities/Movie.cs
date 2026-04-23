using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, MaxLength(256)]
        public string Title { get; set; }

        [MaxLength(4096)]
        public string Overview { get; set; }

        [MaxLength(2084)]
        public string Tagline { get; set; }

        [MaxLength(2084)]
        public string PosterUrl { get; set; }

        [MaxLength(2084)]
        public string BackdropUrl { get; set; }

        [MaxLength(2084)]
        public string ImdbUrl { get; set; }

        [MaxLength(2084)]
        public string TmdbUrl { get; set; }

        [MaxLength(64)]
        public string OriginalLanguage { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Budget { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Revenue { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? RunTime { get; set; }
        
        public decimal? Rating { get; set; }

        // Navigation Properties
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<Trailer> Trailers { get; set; } = new List<Trailer>();
        public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
        public ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();
    }
}