using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieNotice.API.Controllers;
using MovieNotice.API.Interfaces;
using MovieNotice.API.Tests.MockData.Controllers;
using System.Security.Claims;

namespace MovieNotice.API.Tests.Controllers
{
    public class MovieListControllerTests
    {
        private readonly Mock<IMovieListService> _movieListService;
        private readonly Mock<IHttpContextAccessor> _httpContextAccessor;
        private readonly MovieListController controller;
        private readonly int listId = 1;
        private readonly int userId = 1;


        private static ClaimsPrincipal user = new ClaimsPrincipal(
                        new ClaimsIdentity(
                            new Claim[] { new Claim(ClaimTypes.NameIdentifier, "1") },
                            "Basic")
                        );

        public MovieListControllerTests()
        {
            _movieListService = new Mock<IMovieListService>();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            controller = new MovieListController(_movieListService.Object, _httpContextAccessor.Object);

            _httpContextAccessor.Setup(h => h.HttpContext.User).Returns(user);

        }

        [Fact]
        public void GetList_ShouldReturn200OK()
        {          
            //Arrange
            _movieListService.Setup(_ => _.GetList(listId)).Returns(MovieListControllerMockData.GetOneMoviesListDto());

            //Act
            var result = (OkObjectResult)controller.GetList(listId);

            //Asert

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public void GetList_ShouldReturn404NotFoundForNullList()
        {
            //Arrange
            _movieListService.Setup(_ => _.GetList(listId)).Returns(MovieListControllerMockData.GetMoviesListDtoNull);

            //Act
            var result = (NotFoundResult)controller.GetList(listId);

            //Asert
            result.StatusCode.Should().Be(404);

        }

        [Fact]
        public void GetList_ShouldReturn200OKForEmptyList()
        {
            //Arrange
            _movieListService.Setup(_ => _.GetList(listId)).Returns(MovieListControllerMockData.GetMoviesListDtoEmptyList());

            //Act
            var result = (OkObjectResult)controller.GetList(listId);

            //Asert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public void GetLists_ShouldReturn200OK()
        {
            //Arrange
            _movieListService.Setup(_ => _.GetLists(userId)).Returns(MovieListControllerMockData.GetManyMoviesListDto());

            //Act
            var result = (OkObjectResult)controller.GetLists();

            //Asert

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public void GetLists_ShouldReturn204NoContentForEmptylList()
        {
            //Arrange
            _movieListService.Setup(_ => _.GetLists(userId)).Returns(MovieListControllerMockData.GetManyMoviesListDtoNull());

            //Act
            var result = (NoContentResult)controller.GetLists();

            //Asert

            result.StatusCode.Should().Be(204);
        }

    } 
}
