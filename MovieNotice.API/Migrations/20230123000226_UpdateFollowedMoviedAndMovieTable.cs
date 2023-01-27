using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieNotice.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFollowedMoviedAndMovieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_FollowedMovies_FollowedMoviesId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Users_UserId",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_UserId",
                table: "Movies",
                newName: "IX_Movies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_FollowedMoviesId",
                table: "Movies",
                newName: "IX_Movies_FollowedMoviesId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FollowedMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "FollowedMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_FollowedMovies_FollowedMoviesId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FollowedMovies");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "FollowedMovies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_UserId",
                table: "Movie",
                newName: "IX_Movie_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_FollowedMoviesId",
                table: "Movie",
                newName: "IX_Movie_FollowedMoviesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_FollowedMovies_FollowedMoviesId",
                table: "Movie",
                column: "FollowedMoviesId",
                principalTable: "FollowedMovies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Users_UserId",
                table: "Movie",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
