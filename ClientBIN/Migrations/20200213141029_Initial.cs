using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientBIN.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BINs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PS = table.Column<string>(nullable: true),
                    START_BIN = table.Column<long>(nullable: false),
                    END_BIN = table.Column<long>(nullable: false),
                    CODE_A2 = table.Column<string>(nullable: true),
                    CODE_A3 = table.Column<string>(nullable: true),
                    CODE_N3 = table.Column<int>(nullable: false),
                    BIN_LEN = table.Column<int>(nullable: false),
                    Product_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BINs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BINs");
        }
    }
}
