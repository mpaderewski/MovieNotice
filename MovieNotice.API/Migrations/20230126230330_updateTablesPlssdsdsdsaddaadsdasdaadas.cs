using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieNotice.API.Migrations
{
    /// <inheritdoc />
    public partial class updateTablesPlssdsdsdsaddaadsdasdaadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieStatus",
                table: "FollowedMovies");

            migrationBuilder.AddColumn<int>(
                name: "MovieStatus",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieStatus",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "MovieStatus",
                table: "FollowedMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
