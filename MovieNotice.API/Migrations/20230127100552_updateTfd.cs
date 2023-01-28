using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieNotice.API.Migrations
{
    /// <inheritdoc />
    public partial class updateTfd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MoviesList_MoviesListId",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "MoviesListId",
                table: "Movie",
                newName: "MovieListId");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_MoviesListId",
                table: "Movie",
                newName: "IX_Movie_MovieListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MoviesList_MovieListId",
                table: "Movie",
                column: "MovieListId",
                principalTable: "MoviesList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MoviesList_MovieListId",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "MovieListId",
                table: "Movie",
                newName: "MoviesListId");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_MovieListId",
                table: "Movie",
                newName: "IX_Movie_MoviesListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MoviesList_MoviesListId",
                table: "Movie",
                column: "MoviesListId",
                principalTable: "MoviesList",
                principalColumn: "Id");
        }
    }
}
