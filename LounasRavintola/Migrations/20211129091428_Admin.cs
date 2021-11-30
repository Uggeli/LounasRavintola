using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LounasRavintola.Migrations
{
    public partial class Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ac4cd36-3a52-4515-a3fc-416c69f2f69b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed44711b-3948-438b-8a20-4896fcc5a496", "AQAAAAEAACcQAAAAEPJagAX1/1b+X1NNz6N+9eJVTckKXThLo40p/qUj3IkaTGCLBC8yx/89VxPoA+XByQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ac4cd36-3a52-4515-a3fc-416c69f2f69b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1cff70ba-1713-43a6-b7d9-74ebf10bc2cc", "AQAAAAEAACcQAAAAEOIfmwWoY5RML0b+qLzc494PUEr/EyXR+3N9t7WdLnlyBbCsdzSZFVT0vOrdrGaSZA==" });
        }
    }
}
