namespace ApplicationCore.Models
{
    public class MoviePagedResultModel
    {
        public IEnumerable<MovieCardResponseModel> Movies { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalMovies { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalMovies / PageSize);
    }
}