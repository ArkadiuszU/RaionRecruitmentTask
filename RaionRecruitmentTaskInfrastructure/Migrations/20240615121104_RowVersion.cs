using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaionRecruitmentTaskInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RowVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Balances");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Balances",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Balances");

            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "Balances",
                type: "bigint",
                rowVersion: true,
                nullable: false,
                defaultValue: 0L);
        }
    }
}
