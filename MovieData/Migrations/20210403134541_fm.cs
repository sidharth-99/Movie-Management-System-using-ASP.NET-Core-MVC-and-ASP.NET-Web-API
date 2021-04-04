using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieData.Migrations
{
    public partial class fm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adminentites",
                columns: table => new
                {
                    adminid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adminname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adminemail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adminpassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adminsecque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adminsecans = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminentites", x => x.adminid);
                });

            migrationBuilder.CreateTable(
                name: "customerentities",
                columns: table => new
                {
                    custid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    custname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custemail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custpassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custsecque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    custsecans = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerentities", x => x.custid);
                });

            migrationBuilder.CreateTable(
                name: "movieentities",
                columns: table => new
                {
                    movieid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    moviename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movieyear = table.Column<int>(type: "int", nullable: false),
                    moviecategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movielanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movierating = table.Column<double>(type: "float", nullable: false),
                    movielead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    moviedescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    movieduration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    moviebudget = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieentities", x => x.movieid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adminentites");

            migrationBuilder.DropTable(
                name: "customerentities");

            migrationBuilder.DropTable(
                name: "movieentities");
        }
    }
}
