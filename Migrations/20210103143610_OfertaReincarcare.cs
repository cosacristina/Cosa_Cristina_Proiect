using Microsoft.EntityFrameworkCore.Migrations;

namespace Cosa_Cristina_Proiect.Migrations
{
    public partial class OfertaReincarcare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Reincarcare",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClient = table.Column<string>(nullable: true),
                    Oras = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NumarTelefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeOferta = table.Column<string>(nullable: true),
                    EuroCredit = table.Column<decimal>(type: "decimal(6, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OfertaReincarcare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReincarcareID = table.Column<int>(nullable: false),
                    OfertaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaReincarcare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OfertaReincarcare_Oferta_OfertaID",
                        column: x => x.OfertaID,
                        principalTable: "Oferta",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertaReincarcare_Reincarcare_ReincarcareID",
                        column: x => x.ReincarcareID,
                        principalTable: "Reincarcare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reincarcare_ClientID",
                table: "Reincarcare",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaReincarcare_OfertaID",
                table: "OfertaReincarcare",
                column: "OfertaID");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaReincarcare_ReincarcareID",
                table: "OfertaReincarcare",
                column: "ReincarcareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reincarcare_Client_ClientID",
                table: "Reincarcare",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reincarcare_Client_ClientID",
                table: "Reincarcare");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "OfertaReincarcare");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropIndex(
                name: "IX_Reincarcare_ClientID",
                table: "Reincarcare");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Reincarcare");
        }
    }
}
