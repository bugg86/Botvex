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
                name: "beatmaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<double>(type: "float", nullable: false),
                    Ar = table.Column<double>(type: "float", nullable: false),
                    Bpm = table.Column<float>(type: "real", nullable: true),
                    Convert = table.Column<int>(type: "int", nullable: false),
                    Count_circles = table.Column<int>(type: "int", nullable: false),
                    Count_sliders = table.Column<int>(type: "int", nullable: false),
                    Count_spinners = table.Column<int>(type: "int", nullable: false),
                    Cs = table.Column<double>(type: "float", nullable: false),
                    Deleted_at = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Drain = table.Column<double>(type: "float", nullable: false),
                    Hit_length = table.Column<int>(type: "int", nullable: false),
                    Is_scoreable = table.Column<int>(type: "int", nullable: false),
                    Last_updated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mode_int = table.Column<int>(type: "int", nullable: false),
                    Passcount = table.Column<int>(type: "int", nullable: false),
                    Playcount = table.Column<int>(type: "int", nullable: false),
                    Ranked = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeatmapsetExtendedId = table.Column<int>(type: "int", nullable: true),
                    Beatmapset_Id = table.Column<int>(type: "int", nullable: false),
                    Difficulty_Rating = table.Column<double>(type: "float", nullable: false),
                    Mode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Total_Length = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Max_combo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeatmapId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "beatmapsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Bpm = table.Column<float>(type: "real", nullable: false),
                    Can_be_hyped = table.Column<bool>(type: "bit", nullable: false),
                    Deleted_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discussion_enabled = table.Column<bool>(type: "bit", nullable: true),
                    Discussion_locked = table.Column<bool>(type: "bit", nullable: false),
                    Is_scoreable = table.Column<bool>(type: "bit", nullable: false),
                    Last_updated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Legacy_thread_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ranked = table.Column<int>(type: "int", nullable: false),
                    Ranked_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storyboard = table.Column<bool>(type: "bit", nullable: false),
                    Submitted_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Artist_unicode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Covers = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Favourite_count = table.Column<int>(type: "int", nullable: false),
                    Nsfw = table.Column<int>(type: "int", nullable: false),
                    Offset = table.Column<int>(type: "int", nullable: false),
                    Play_count = table.Column<int>(type: "int", nullable: false),
                    Preview_url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Spotlight = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title_unicode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Video = table.Column<int>(type: "int", nullable: false),
                    Has_favourited = table.Column<int>(type: "int", nullable: true),
                    Track_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeatmapsetId", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BeatmapsetExtendedId = table.Column<int>(type: "int", nullable: true),
                    Avatar_url = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Default_group = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Is_active = table.Column<int>(type: "int", nullable: false),
                    Is_bot = table.Column<int>(type: "int", nullable: false),
                    Is_deleted = table.Column<int>(type: "int", nullable: false),
                    Is_online = table.Column<int>(type: "int", nullable: false),
                    Is_supporter = table.Column<int>(type: "int", nullable: false),
                    Last_visit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pm_friends_only = table.Column<int>(type: "int", nullable: false),
                    Profile_colour = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_beatmapsets_BeatmapsetExtendedId",
                        column: x => x.BeatmapsetExtendedId,
                        principalTable: "beatmapsets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_beatmaps_Beatmapset_Id",
                table: "beatmaps",
                column: "Beatmapset_Id");

            migrationBuilder.CreateIndex(
                name: "IX_beatmaps_BeatmapsetExtendedId",
                table: "beatmaps",
                column: "BeatmapsetExtendedId");

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

            migrationBuilder.CreateIndex(
                name: "IX_users_BeatmapsetExtendedId",
                table: "users",
                column: "BeatmapsetExtendedId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeatmapToSet",
                table: "beatmaps",
                column: "Beatmapset_Id",
                principalTable: "beatmapsets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_beatmaps_beatmapsets_BeatmapsetExtendedId",
                table: "beatmaps",
                column: "BeatmapsetExtendedId",
                principalTable: "beatmapsets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToBeatmap",
                table: "beatmaps",
                column: "User_Id",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserToBeatmapset",
                table: "beatmapsets",
                column: "User_id",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_beatmapsets_BeatmapsetExtendedId",
                table: "users");

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
