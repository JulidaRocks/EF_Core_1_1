using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProfilePicUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    AccountTitle = table.Column<string>(nullable: true),
                    CurrentBalance = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AccountStatus = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthID", "Name", "ProfilePicUrl" },
                values: new object[] { new Guid("24ce7f8a-cbeb-4b33-8a3d-952830b92d04"), "7d27b4ad-4405-4da1-b872-4b331e7c1589", "Raas Masood", "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountStatus", "AccountTitle", "CurrentBalance", "Email", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("37846734-172e-4149-8cec-6f43d1eb3f60"), "0001-1001", 0, "Raas Masood", 2342.3400000000001, "raasmasood@hotmail.com", "6096647000", new Guid("24ce7f8a-cbeb-4b33-8a3d-952830b92d04") });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
