using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Cast
    {
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(16)]
        public string Gender { get; set; }

        [MaxLength(2084)]
        public string TmdbUrl { get; set; }

        [MaxLength(2084)]
        public string ProfilePath { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();
    }
}