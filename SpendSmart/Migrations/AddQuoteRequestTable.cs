using Microsoft.EntityFrameworkCore.Migrations;

public partial class AddQuoteRequestTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Create the QuoteRequests table with columns for user information and service details.
        migrationBuilder.CreateTable(
            name: "QuoteRequests",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                HowToKnow = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_QuoteRequests", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Drop the QuoteRequests table if the migration is rolled back.
        migrationBuilder.DropTable(
            name: "QuoteRequests");
    }
}
