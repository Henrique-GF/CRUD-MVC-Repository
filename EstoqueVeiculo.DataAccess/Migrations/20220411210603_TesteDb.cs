using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueVeiculo.DataAccess.Migrations
{
    public partial class TesteDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Versao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false),
                    AnoModelo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipoVeiculo",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Carro" });

            migrationBuilder.InsertData(
                table: "TipoVeiculo",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Moto" });

            migrationBuilder.InsertData(
                table: "TipoVeiculo",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Caminhão" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoVeiculo");

            migrationBuilder.DropTable(
                name: "Veiculo");
        }
    }
}
