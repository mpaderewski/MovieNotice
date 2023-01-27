using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieNotice.API.Migrations
{
    /// <inheritdoc />
    public partial class updateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_UserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieStatus",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FollowedMovies");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "FollowedMovies");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Movies",
                newName: "TmdbId");

            migrationBuilder.AddColumn<int>(
                name: "MovieStatus",
                table: "FollowedMovies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieStatus",
                table: "FollowedMovies");

            migrationBuilder.RenameColumn(
                name: "TmdbId",
                table: "Movies",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "MovieStatus",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Users_UserId",
                table: "Movies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
