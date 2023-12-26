using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Botvex.DB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Avatar_url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Default_group = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Is_active = table.Column<int>(type: "int", nullable: false),
                    Is_bot = table.Column<int>(type: "int", nullable: false),
                    Is_deleted = table.Column<int>(type: "int", nullable: false),
                    Is_online = table.Column<int>(type: "int", nullable: false),
                    Is_supporter = table.Column<int>(type: "int", nullable: false),
                    Last_visit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pm_friends_only = table.Column<int>(type: "int", nullable: false),
                    Profile_colour = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "beatmapsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Artist_unicode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Favourite_count = table.Column<int>(type: "int", nullable: false),
                    Nsfw = table.Column<int>(type: "int", nullable: false),
                    Offset = table.Column<int>(type: "int", nullable: true),
                    Play_count = table.Column<int>(type: "int", nullable: true),
                    Preview_url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Spotlight = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Title_unicode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Video = table.Column<int>(type: "int", nullable: false),
                    Has_favourited = table.Column<int>(type: "int", nullable: true),
                    Track_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beatmapset_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToBeatmapset",
                        column: x => x.User_id,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "beatmaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Beatmapset_Id = table.Column<int>(type: "int", nullable: true),
                    Difficulty_Rating = table.Column<double>(type: "float", nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Total_Length = table.Column<int>(type: "int", nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Checksum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Max_combo = table.Column<int>(type: "int", nullable: true),
                    Accuracy = table.Column<double>(type: "float", nullable: true),
                    Ar = table.Column<double>(type: "float", nullable: true),
                    Bpm = table.Column<float>(type: "real", nullable: true),
                    Convert = table.Column<int>(type: "int", nullable: false),
                    Count_circles = table.Column<int>(type: "int", nullable: true),
                    Count_sliders = table.Column<int>(type: "int", nullable: true),
                    Count_spinners = table.Column<int>(type: "int", nullable: true),
                    Cs = table.Column<double>(type: "float", nullable: true),
                    Deleted_at = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Drain = table.Column<double>(type: "float", nullable: true),
                    Hit_length = table.Column<int>(type: "int", nullable: true),
                    Is_scoreable = table.Column<int>(type: "int", nullable: false),
                    Last_updated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mode_int = table.Column<int>(type: "int", nullable: true),
                    Passcount = table.Column<int>(type: "int", nullable: true),
                    Playcount = table.Column<int>(type: "int", nullable: true),
                    Ranked = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeatmapId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeatmapToSet",
                        column: x => x.Beatmapset_Id,
                        principalTable: "beatmapsets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserToBeatmap",
                        column: x => x.User_Id,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beatmapset_Id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreToSet",
                        column: x => x.Beatmapset_Id,
                        principalTable: "beatmapsets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beatmapset_Id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageToSet",
                        column: x => x.Beatmapset_Id,
                        principalTable: "beatmapsets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_beatmaps_Beatmapset_Id",
                table: "beatmaps",
                column: "Beatmapset_Id");

            migrationBuilder.CreateIndex(
                name: "IX_beatmaps_User_Id",
                table: "beatmaps",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_beatmapsets_User_id",
                table: "beatmapsets",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_genres_Beatmapset_Id",
                table: "genres",
                column: "Beatmapset_Id",
                unique: true,
                filter: "[Beatmapset_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_languages_Beatmapset_Id",
                table: "languages",
                column: "Beatmapset_Id",
                unique: true,
                filter: "[Beatmapset_Id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "beatmaps");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "beatmapsets");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
