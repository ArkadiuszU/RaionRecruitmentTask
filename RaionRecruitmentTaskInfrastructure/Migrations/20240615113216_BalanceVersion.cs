using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaionRecruitmentTaskInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BalanceVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "Balances",
                type: "bigint",
                rowVersion: true,
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Balances");
        }
    }
}
