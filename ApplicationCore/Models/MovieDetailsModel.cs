using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterUrl { get; set; }
        public decimal Revenue { get; set; }

        public decimal? Rating { get; set; }

        public List<string> Genres { get; set; } = new List<string>();
        public List<(string Name, string Url)> Trailers { get; set; } = new List<(string, string)>();
        public List<(int CastId, string Name, string Character, string ProfilePath)> Casts { get; set; }
            = new List<(int, string, string, string)>();
    }
}