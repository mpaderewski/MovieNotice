using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieNotice.API.Migrations
{
    /// <inheritdoc />
    public partial class updateTablesPlssdsdsd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoviesId",
                table: "FollowedMovies",
                newName: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "FollowedMovies",
                newName: "MoviesId");
        }
    }
}
