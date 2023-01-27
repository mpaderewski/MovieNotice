using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieNotice.API.Migrations
{
    /// <inheritdoc />
    public partial class updateTablesPlssdsdsdsaddaadsdasdaadasasdasdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_FollowedMovies_MoviesListId",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FollowedMovies",
                table: "FollowedMovies");

            migrationBuilder.RenameTable(
                name: "FollowedMovies",
                newName: "MoviesList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesList",
                table: "MoviesList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MoviesList_MoviesListId",
                table: "Movie",
                column: "MoviesListId",
                principalTable: "MoviesList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MoviesList_MoviesListId",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesList",
                table: "MoviesList");

            migrationBuilder.RenameTable(
                name: "MoviesList",
                newName: "FollowedMovies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FollowedMovies",
                table: "FollowedMovies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_FollowedMovies_MoviesListId",
                table: "Movie",
                column: "MoviesListId",
                principalTable: "FollowedMovies",
                principalColumn: "Id");
        }
    }
}
