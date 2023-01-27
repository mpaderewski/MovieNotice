using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieNotice.API.Migrations
{
    /// <inheritdoc />
    public partial class updateTablesPlssdsdsdsaddaadsdasdaad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_FollowedMovies_FollowedMoviesId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameColumn(
                name: "FollowedMoviesId",
                table: "Movie",
                newName: "MoviesListId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_FollowedMoviesId",
                table: "Movie",
                newName: "IX_Movie_MoviesListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_FollowedMovies_MoviesListId",
                table: "Movie",
                column: "MoviesListId",
                principalTable: "FollowedMovies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_FollowedMovies_MoviesListId",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameColumn(
                name: "MoviesListId",
                table: "Movies",
                newName: "FollowedMoviesId");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_MoviesListId",
                table: "Movies",
                newName: "IX_Movies_FollowedMoviesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_FollowedMovies_FollowedMoviesId",
                table: "Movies",
                column: "FollowedMoviesId",
                principalTable: "FollowedMovies",
                principalColumn: "Id");
        }
    }
}
