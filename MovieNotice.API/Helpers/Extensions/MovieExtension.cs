using MovieNotice.Common.Models;
using System.Diagnostics;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
using System.Linq;

namespace MovieNotice.API.Helpers.Extensions
{
    public static class MovieExtension
    {
        public static Movie ConvertToCommonMovie(this TMDbLib.Objects.Movies.Movie movie)
        {
            return new Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterPath,
                Description = movie.Overview,
                ImdbId = movie.ImdbId,
                ReleaseDate = movie.ReleaseDate
            };
        }

        public static Movie ConvertToCommonMovie(this TMDbLib.Objects.Search.SearchMovie movie)
        {
            return new Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterPath,
                Description = movie.Overview,
                ReleaseDate = movie.ReleaseDate
            };
        }

        public static ICollection<Movie> ConvertToCommonMovieICollection(this SearchContainer<SearchMovie> searchContainer)
        {
            return searchContainer.Results.Select(ConvertToCommonMovie).ToList();
        }
    }
}
