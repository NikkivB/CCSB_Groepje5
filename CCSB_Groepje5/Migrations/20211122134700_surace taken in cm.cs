using Microsoft.EntityFrameworkCore.Migrations;

namespace CCSB_Groepje5.Migrations
{
    public partial class suracetakenincm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SurfaceTaken",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SurfaceTaken",
                table: "Vehicles",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
