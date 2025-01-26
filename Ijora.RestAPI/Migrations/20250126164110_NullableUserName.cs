using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ijora.RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class NullableUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Auth_AccessToken_Phone_UserId",
                table: "Auth");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Auth");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_Auth_AccessToken_Phone",
                table: "Auth",
                columns: new[] { "AccessToken", "Phone" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Auth_AccessToken_Phone",
                table: "Auth");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Auth",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auth_AccessToken_Phone_UserId",
                table: "Auth",
                columns: new[] { "AccessToken", "Phone", "UserId" });
        }
    }
}
