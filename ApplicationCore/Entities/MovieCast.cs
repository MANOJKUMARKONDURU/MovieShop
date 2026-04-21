using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class MovieCast
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int CastId { get; set; }
        public Cast Cast { get; set; }

        [Required, MaxLength(128)]
        public string Character { get; set; }
    }
}