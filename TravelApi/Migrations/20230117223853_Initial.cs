using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Walkability = table.Column<int>(type: "int", nullable: false),
                    PublicTransit = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Country", "Description", "Name", "PublicTransit", "Rating", "Walkability" },
                values: new object[,]
                {
                    { 1, "United States", "Modern, walkable city known for its food and beer culture", "Portland", 4, 5, 5 },
                    { 2, "United States", "Like Portland, but not as cool. Thinks it invented soccer.", "Seattle", 4, 4, 3 },
                    { 3, "Germany", "The apex of human culture", "Berlin", 5, 5, 5 },
                    { 4, "UK", "Fish n' chips, innit", "London", 3, 5, 5 },
                    { 5, "United States", "Really hot weather and hotter beaches", "Miami", 1, 3, 2 },
                    { 6, "United States", "trust me, just don't", "Cleveland", 1, 1, 1 },
                    { 7, "Japan", "Lots of people, little space", "Tokyo", 5, 4, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
