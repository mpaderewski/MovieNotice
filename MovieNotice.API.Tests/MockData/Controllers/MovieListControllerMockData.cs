using MovieNotice.Common.ModelsDto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNotice.API.Tests.MockData.Controllers
{
    public class MovieListControllerMockData
    {
        public static MoviesListDto GetOneMoviesListDto()
        {
            return new MoviesListDto()
            {
                Id = 1,
                Movies = GetManyMovieDtoList(),
                UserId = 1,
                MovieId = 1
            };
        }

        public static List<MoviesListDto> GetManyMoviesListDto()
        {
            return new List<MoviesListDto>()
            {
                GetOneMoviesListDto(),
                GetOneMoviesListDto()
            };
        }

        public static List<MoviesListDto>? GetManyMoviesListDtoNull()
        {
            return null;
        }

        public static MoviesListDto GetMoviesListDtoEmptyList()
        {
            return new MoviesListDto();
        }

        public static MoviesListDto? GetMoviesListDtoNull()
        {
            return null;
        }

        public static List<MovieDto> GetManyMovieDtoList()
        {
            return new List<MovieDto>()
            {
                new MovieDto()
                {
                    Id = 1,
                    ImdbId = "imdbId",
                    Description = "Opis",
                    Title = "Test",
                    PosterUrl = "url.jpg",
                    ReleaseDate = DateTime.ParseExact("2011-03-21 13:26", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    BackdropPath = "backdrop.png",
                    Popularity = 1
                },
                new MovieDto()
                {
                    Id = 2,
                    ImdbId = "imdbId2",
                    Description = "Opis2",
                    Title = "Test2",
                    PosterUrl = "url.jpg2",
                    ReleaseDate = DateTime.ParseExact("2011-03-21 13:26", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    BackdropPath = "backdrop.png2",
                    Popularity = 2
                },
                new MovieDto()
                {
                    Id = 3,
                    ImdbId = "imdbI3",
                    Description = "Opi3",
                    Title = "Tes3",
                    PosterUrl = "url.jpg3",
                    ReleaseDate = DateTime.ParseExact("2011-03-21 13:26", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    BackdropPath = "backdrop.png3",
                    Popularity = 3
                }
            };
        }
    }  
}