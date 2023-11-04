using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class cricao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    _Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    _Nome = table.Column<string>(type: "TEXT", nullable: true),
                    _Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x._Cpf);
                });

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    _nomeMarca = table.Column<string>(type: "TEXT", nullable: false),
                    _segmento = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x._nomeMarca);
                });

            migrationBuilder.CreateTable(
                name: "modelo",
                columns: table => new
                {
                    _nomeModelo = table.Column<string>(type: "TEXT", nullable: false),
                    _motor = table.Column<string>(type: "TEXT", nullable: true),
                    _qtdPortas = table.Column<int>(type: "INTEGER", nullable: true),
                    _nomeMarca = table.Column<string>(type: "TEXT", nullable: true),
                    _TipoModelo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelo", x => x._nomeModelo);
                });

            migrationBuilder.CreateTable(
                name: "notafiscal",
                columns: table => new
                {
                    _NumeroNota = table.Column<string>(type: "TEXT", nullable: false),
                    _ValorDaNota = table.Column<double>(type: "REAL", nullable: true),
                    _Cpf = table.Column<int>(type: "INTEGER", nullable: true),
                    _OrdemServico = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notafiscal", x => x._NumeroNota);
                });

            migrationBuilder.CreateTable(
                name: "periodo",
                columns: table => new
                {
                    _Placa = table.Column<string>(type: "TEXT", nullable: false),
                    _HoraEntrada = table.Column<DateTime>(type: "TEXT", nullable: true),
                    _HoraSaida = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodo", x => x._Placa);
                });

            migrationBuilder.CreateTable(
                name: "servico",
                columns: table => new
                {
                    _OrdemServico = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _Placa = table.Column<string>(type: "TEXT", nullable: true),
                    _tipoServico = table.Column<int>(type: "INTEGER", nullable: true),
                    _valorServico = table.Column<double>(type: "REAL", nullable: true),
                    _valorPagar = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servico", x => x._OrdemServico);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    _codTicket = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _Placa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x._codTicket);
                });

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    _Placa = table.Column<string>(type: "TEXT", nullable: false),
                    _Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    _nomeModelo = table.Column<string>(type: "TEXT", nullable: true),
                    _CorExterna = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x._Placa);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "modelo");

            migrationBuilder.DropTable(
                name: "notafiscal");

            migrationBuilder.DropTable(
                name: "periodo");

            migrationBuilder.DropTable(
                name: "servico");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "veiculo");
        }
    }
}
