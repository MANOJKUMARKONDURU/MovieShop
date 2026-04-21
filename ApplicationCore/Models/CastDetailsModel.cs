using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class CastDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePath { get; set; }

        public List<(int MovieId, string Title, string Character)> Movies { get; set; }
            = new List<(int, string, string)>();
    }
}