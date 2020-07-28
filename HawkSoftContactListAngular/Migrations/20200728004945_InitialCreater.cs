using Microsoft.EntityFrameworkCore.Migrations;

namespace HawkSoftContactListAngular.Migrations
{
    public partial class InitialCreater : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersHawksoft",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersHawksoft", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ContactsHawksoft",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    UsersHawksoftUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsHawksoft", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_ContactsHawksoft_UsersHawksoft_UsersHawksoftUserId",
                        column: x => x.UsersHawksoftUserId,
                        principalTable: "UsersHawksoft",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UsersHawksoft",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "email@email.com", "User1", "LastName" });

            migrationBuilder.InsertData(
                table: "UsersHawksoft",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 2, "email@email.com", "User2", "LastName" });

            migrationBuilder.InsertData(
                table: "UsersHawksoft",
                columns: new[] { "UserId", "Email", "FirstName", "LastName" },
                values: new object[] { 3, "email@email.com", "User3", "LastName" });

            migrationBuilder.InsertData(
                table: "ContactsHawksoft",
                columns: new[] { "ContactId", "Address1", "Address2", "City", "Email", "FirstName", "LastName", "State", "UsersHawksoftUserId", "Zip" },
                values: new object[] { 1, "Address1", "Address2", "Portland", "john.dohe@hotmail.com", "John", "Dhoe", "Oregon", 1, "45678" });

            migrationBuilder.InsertData(
                table: "ContactsHawksoft",
                columns: new[] { "ContactId", "Address1", "Address2", "City", "Email", "FirstName", "LastName", "State", "UsersHawksoftUserId", "Zip" },
                values: new object[] { 2, "Address1", "Address2", "Portland", "john.dohe@hotmail.com", "Cesar", "Martinez", "Oregon", 1, "45678" });

            migrationBuilder.InsertData(
                table: "ContactsHawksoft",
                columns: new[] { "ContactId", "Address1", "Address2", "City", "Email", "FirstName", "LastName", "State", "UsersHawksoftUserId", "Zip" },
                values: new object[] { 3, "Address1", "Address2", "Portland", "john.dohe@hotmail.com", "Oscar", "De La Renta", "Oregon", 1, "45678" });

            migrationBuilder.CreateIndex(
                name: "IX_ContactsHawksoft_UsersHawksoftUserId",
                table: "ContactsHawksoft",
                column: "UsersHawksoftUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactsHawksoft");

            migrationBuilder.DropTable(
                name: "UsersHawksoft");
        }
    }
}
