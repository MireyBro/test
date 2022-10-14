using Microsoft.EntityFrameworkCore.Migrations;

namespace bArt_test.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INCIDENTS",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INCIDENTS", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IncidentName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACCOUNTS_INCIDENTS_IncidentName",
                        column: x => x.IncidentName,
                        principalTable: "INCIDENTS",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONTACTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONTACTS_ACCOUNTS_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ACCOUNTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_IncidentName",
                table: "ACCOUNTS",
                column: "IncidentName");

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNTS_Name",
                table: "ACCOUNTS",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EMAIL",
                table: "CONTACTS",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONTACTS_AccountId",
                table: "CONTACTS",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENTS_Name",
                table: "INCIDENTS",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTACTS");

            migrationBuilder.DropTable(
                name: "ACCOUNTS");

            migrationBuilder.DropTable(
                name: "INCIDENTS");
        }
    }
}
