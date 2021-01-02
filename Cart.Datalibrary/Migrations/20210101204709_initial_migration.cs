using Microsoft.EntityFrameworkCore.Migrations;

namespace Cart.Datalibrary.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECORD_STATUS_ID = table.Column<long>(nullable: false),
                    CODE = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ITEM_MASTER",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECORD_STATUS_ID = table.Column<long>(nullable: false),
                    ACCOUNT_ID = table.Column<long>(nullable: false),
                    CODE = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEM_MASTER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RECORD_STATUS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECORD_STATUS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STOCK",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RECORD_STATUS_ID = table.Column<long>(nullable: false),
                    ACCOUNT_ID = table.Column<long>(nullable: false),
                    ITEM_MASTER_ID = table.Column<long>(nullable: false),
                    QUANTITY = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "ITEM_MASTER");

            migrationBuilder.DropTable(
                name: "RECORD_STATUS");

            migrationBuilder.DropTable(
                name: "STOCK");
        }
    }
}
