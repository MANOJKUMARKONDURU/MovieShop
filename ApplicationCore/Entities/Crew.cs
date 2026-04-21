using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Crew
    {
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(2084)]
        public string ProfilePath { get; set; }

        public ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();
    }
}