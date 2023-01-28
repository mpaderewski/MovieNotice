using MovieNotice.Common.Enums;

namespace MovieNotice.API.Entities
{
    public class MovieList
    {
        public int Id { get; set; }
        public List<Movie> Movies { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
