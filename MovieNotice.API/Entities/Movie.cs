using MovieNotice.Common.Enums;

namespace MovieNotice.API.Entities
{
    public class Movie
    {   public int Id { get; set; }
        public int TmdbId { get; set; }
        public string ImdbId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string BackdropPath { get; set; }
        public double? Popularity { get; set; }
        public MovieStatus MovieStatus { get; set; }
    }
}
