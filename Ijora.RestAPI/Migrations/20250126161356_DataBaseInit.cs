using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ijora.RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    RetryCount = table.Column<short>(type: "smallint", nullable: false),
                    AccessToken = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    RefreshToken = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    AccessTokenExpieredAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    RefreshTokenExpieredAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    OTP = table.Column<string>(type: "longtext", nullable: true),
                    OTPExpieredAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UserJson = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Complexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    Address = table.Column<string>(type: "varchar(255)", nullable: false),
                    Developer = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    BuildYear = table.Column<int>(type: "int", nullable: false),
                    ConstructionStatus = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IsCompleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CompletionYear = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PublisherUserId = table.Column<long>(type: "bigint", nullable: false),
                    ImageUrls = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complexes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsAvaliable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PublisherPhoneNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ComplexId = table.Column<long>(type: "bigint", nullable: true),
                    WindowView = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    PropertyUsageType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    SquareMeters = table.Column<double>(type: "double", nullable: true),
                    Price = table.Column<double>(type: "double", nullable: true),
                    PropertyType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    TotalFloors = table.Column<int>(type: "int", nullable: true),
                    HasParking = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasBalcony = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    YearBuilt = table.Column<int>(type: "int", nullable: true),
                    HeatingType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IsFurnished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OwnershipType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Renovation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    KitchenArea = table.Column<double>(type: "double", nullable: false),
                    LivingArea = table.Column<double>(type: "double", nullable: true),
                    WallMaterial = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    IsInGatedCommunity = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasElevator = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AllowsPets = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AllowsChildren = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    ImageUrls = table.Column<string>(type: "longtext", nullable: false),
                    BathroomCount = table.Column<int>(type: "int", nullable: true),
                    CargoElevatorCount = table.Column<int>(type: "int", nullable: false),
                    CeilingHeight = table.Column<double>(type: "double", nullable: true),
                    OwnerCount = table.Column<int>(type: "int", nullable: false),
                    OwnershipYears = table.Column<int>(type: "int", nullable: false),
                    PropertyCondition = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Role = table.Column<string>(type: "varchar(59)", maxLength: 59, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    RegistrationDateTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    LastAuthDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_AccessToken_Phone_UserId",
                table: "Auth",
                columns: new[] { "AccessToken", "Phone", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Complexes_Id_Address_CreatedAt",
                table: "Complexes",
                columns: new[] { "Id", "Address", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_Id_Address",
                table: "RealEstates",
                columns: new[] { "Id", "Address" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth");

            migrationBuilder.DropTable(
                name: "Complexes");

            migrationBuilder.DropTable(
                name: "RealEstates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
