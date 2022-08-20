using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieAppWorkShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Genre", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "ThE story Of the singking of the cruiseShip Named The Titanic", 5, "Titanic", 1997 },
                    { 2, "Italian Mafia", 9, "The GodFather", 1972 },
                    { 3, "Superhero Movie", 6, "Avengers:Endgame", 2019 },
                    { 4, "Jackie Chan action comedy", 3, "RushHour", 1998 },
                    { 5, "Movie about blue aliens", 6, "Avatar", 2009 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
