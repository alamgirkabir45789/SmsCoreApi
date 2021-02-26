using Microsoft.EntityFrameworkCore.Migrations;

namespace SmsCoreApi.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassInfoID",
                table: "PaymentTypes");

            migrationBuilder.AlterColumn<int>(
                name: "SClassID",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SClassID",
                table: "PaymentTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClassInfoID",
                table: "PaymentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
