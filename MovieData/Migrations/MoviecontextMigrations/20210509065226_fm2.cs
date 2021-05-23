using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieData.Migrations.MoviecontextMigrations
{
    public partial class fm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieentities",
                columns: table => new
                {
                    movieid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    moviename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movieyear = table.Column<int>(type: "int", nullable: false),
                    moviecategory1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    moviecategory2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movielanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movierating = table.Column<double>(type: "float", nullable: false),
                    movielead1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movielead2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    moviedescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movieduration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    moviebudget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    videotrailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieentities", x => x.movieid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieentities");
        }
    }
}
