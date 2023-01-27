using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieNotice.API.Migrations
{
    /// <inheritdoc />
    public partial class updateTablesPls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowedMovies_Movies_UserId",
                table: "FollowedMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowedMovies_Users_UserId",
                table: "FollowedMovies");

            migrationBuilder.DropIndex(
                name: "IX_FollowedMovies_UserId",
                table: "FollowedMovies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FollowedMovies_UserId",
                table: "FollowedMovies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedMovies_Movies_UserId",
                table: "FollowedMovies",
                column: "UserId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedMovies_Users_UserId",
                table: "FollowedMovies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
