using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Review
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        [MaxLength(4096)]
        public string ReviewText { get; set; }
    }
}