using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TunaPiano.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    Album = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SongsGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SongId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongsGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongsGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongsGenres_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Age", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, 32, "Alice Suki Waterhouse is an English singer-songwriter, actress and model. The indie pop artist released her debut studio album I Can't Let Go and debut extended play Milk Teeth in 2022.", "Suki Waterhouse" },
                    { 2, 26, "Kayleigh Rose Amstutz, known professionally as Chappell Roan, is an American singer and songwriter. Working with collaborator Dan Nigro, the majority of her music is inspired by 1980s synth-pop and early 2000s pop hits.", "Chappell Roan" },
                    { 3, 29, "Ashley Nicolette Frangipane, known professionally as Halsey, is an American singer, songwriter, and actress.", "Halsey" },
                    { 4, 18, "Cage the Elephant is an American rock band from Bowling Green, Kentucky, that formed in mid-2006. Since their formation, the band has gained a massive following in the US as well as the UK and Canada for their sound and their high-energy live performances.", "Cage the Elephant" },
                    { 5, 14, "How old are Glass Animals?\r\nGlass Animals - Wikipedia\r\nGlass Animals are an English indie rock band formed in Oxford in 2010. The band's line-up consists of Dave Bayley (vocals, guitar, keyboards, drums, songwriting), Drew MacFarlane (guitar, keyboards, backing vocals), Edmund Irwin-Singer (bass, keyboards, backing vocals), and Joe Seaward (drums).", "Glass Animals" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 100, "Rock" },
                    { 101, "Indie Pop" },
                    { 102, "Alternative/Indie" },
                    { 103, "Pop" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "ArtistId", "GenreId", "Length", "Title" },
                values: new object[,]
                {
                    { 200, "The Rise and Fall of a Midwest Princess", 2, null, 192, "Red Wine Supernova" },
                    { 201, "The Rise and Fall of a Midwest Princess", 2, null, 183, "Super Graphic Ultra Modern Girl" },
                    { 202, "Badlands", 3, null, 214, "Control" },
                    { 203, "hopeless fountain kingdom", 3, null, 181, "Bad At Love" },
                    { 204, "I Can't Let Go", 1, null, 193, "Moves" },
                    { 205, "Blackout Drunk", 1, null, 162, "My Fun" },
                    { 206, "I Love You So F***ing Much", 5, null, 224, "whatthehellishappening?" },
                    { 207, "Dreamland", 5, null, 238, "Heat Waves" },
                    { 208, "Melophobia", 4, null, 208, "Cigarette Daydreams" },
                    { 209, "Tell Me I'm Pretty", 4, null, 224, "Sweetie Little Jean" },
                    { 210, "Cage the Elephant", 4, null, 175, "Ain't No Rest for the Wicked" }
                });

            migrationBuilder.InsertData(
                table: "SongsGenres",
                columns: new[] { "Id", "GenreId", "SongId" },
                values: new object[,]
                {
                    { 301, 103, 200 },
                    { 302, 103, 201 },
                    { 303, 103, 202 },
                    { 304, 101, 203 },
                    { 305, 102, 204 },
                    { 306, 102, 205 },
                    { 307, 102, 206 },
                    { 308, 102, 207 },
                    { 309, 102, 208 },
                    { 310, 102, 209 },
                    { 311, 100, 210 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SongsGenres_GenreId",
                table: "SongsGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SongsGenres_SongId",
                table: "SongsGenres",
                column: "SongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongsGenres");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
