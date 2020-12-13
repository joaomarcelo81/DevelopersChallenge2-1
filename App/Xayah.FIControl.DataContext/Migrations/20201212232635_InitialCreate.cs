using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Xayah.FIControl.DataContext.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "XayahFIControl");

            migrationBuilder.CreateTable(
                name: "BankStatement",
                schema: "XayahFIControl",
                columns: table => new
                {
                    BankStatementId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ofx = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Severity = table.Column<string>(type: "TEXT", nullable: true),
                    Dataserver = table.Column<string>(type: "TEXT", nullable: true),
                    Language = table.Column<string>(type: "TEXT", nullable: true),
                    Trnuid = table.Column<string>(type: "TEXT", nullable: true),
                    Curdef = table.Column<string>(type: "TEXT", nullable: true),
                    Bankid = table.Column<string>(type: "TEXT", nullable: true),
                    Acctid = table.Column<string>(type: "TEXT", nullable: true),
                    Accttype = table.Column<string>(type: "TEXT", nullable: true),
                    Balamt = table.Column<string>(type: "TEXT", nullable: true),
                    Dtasof = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankStatement", x => x.BankStatementId);
                });

            migrationBuilder.CreateTable(
                name: "Accountlaunche",
                schema: "XayahFIControl",
                columns: table => new
                {
                    AccountlauncheId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    Trntype = table.Column<string>(type: "TEXT", nullable: true),
                    Dtposted = table.Column<string>(type: "TEXT", nullable: true),
                    Trnamt = table.Column<string>(type: "TEXT", nullable: true),
                    Memo = table.Column<string>(type: "TEXT", nullable: true),
                    BankStatementId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accountlaunche", x => x.AccountlauncheId);
                    table.ForeignKey(
                        name: "FK_Accountlaunche_BankStatement_BankStatementId",
                        column: x => x.BankStatementId,
                        principalSchema: "XayahFIControl",
                        principalTable: "BankStatement",
                        principalColumn: "BankStatementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accountlaunche_BankStatementId",
                schema: "XayahFIControl",
                table: "Accountlaunche",
                column: "BankStatementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accountlaunche",
                schema: "XayahFIControl");

            migrationBuilder.DropTable(
                name: "BankStatement",
                schema: "XayahFIControl");
        }
    }
}
