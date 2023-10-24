using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class criacaoinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    _idCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    _Nome = table.Column<string>(type: "TEXT", nullable: true),
                    _Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x._idCliente);
                });

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    _idMarca = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _DescricaoMarca = table.Column<string>(type: "TEXT", nullable: true),
                    _Segmento = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x._idMarca);
                });

            migrationBuilder.CreateTable(
                name: "modelo",
                columns: table => new
                {
                    _idModelo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nomeModelo = table.Column<string>(type: "TEXT", nullable: true),
                    _Tamanho = table.Column<string>(type: "TEXT", nullable: false),
                    _motor = table.Column<string>(type: "TEXT", nullable: false),
                    _qtdPortas = table.Column<int>(type: "INTEGER", nullable: false),
                    _CorExterna = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelo", x => x._idModelo);
                });

            migrationBuilder.CreateTable(
                name: "periodo",
                columns: table => new
                {
                    _idPeriodo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _HoraEntrada = table.Column<DateTime>(type: "TEXT", nullable: true),
                    _HoraSaida = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodo", x => x._idPeriodo);
                });

            migrationBuilder.CreateTable(
                name: "servico",
                columns: table => new
                {
                    _idServico = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _descricaoServico = table.Column<string>(type: "TEXT", nullable: true),
                    _valorHora = table.Column<double>(type: "REAL", nullable: false),
                    _valorPagar = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servico", x => x._idServico);
                });

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    _idVeiculo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _Placa = table.Column<string>(type: "TEXT", nullable: true),
                    _Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x._idVeiculo);
                });

            migrationBuilder.CreateTable(
                name: "notafiscal",
                columns: table => new
                {
                    _idNota = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _NumeroNota = table.Column<string>(type: "TEXT", nullable: true),
                    _ValorDaNota = table.Column<double>(type: "REAL", nullable: false),
                    _idServico = table.Column<int>(type: "INTEGER", nullable: false),
                    _idCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    Servico_idServico = table.Column<int>(type: "INTEGER", nullable: true),
                    Cliente_idCliente = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notafiscal", x => x._idNota);
                    table.ForeignKey(
                        name: "FK_notafiscal_cliente_Cliente_idCliente",
                        column: x => x.Cliente_idCliente,
                        principalTable: "cliente",
                        principalColumn: "_idCliente");
                    table.ForeignKey(
                        name: "FK_notafiscal_servico_Servico_idServico",
                        column: x => x.Servico_idServico,
                        principalTable: "servico",
                        principalColumn: "_idServico");
                });

            migrationBuilder.CreateTable(
                name: "caminhonete",
                columns: table => new
                {
                    _idCarro = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _idVeiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    _idMarca = table.Column<int>(type: "INTEGER", nullable: false),
                    _idModelo = table.Column<int>(type: "INTEGER", nullable: false),
                    _idCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    Veiculo_idVeiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    Marca_idMarca = table.Column<int>(type: "INTEGER", nullable: false),
                    Modelo_idModelo = table.Column<int>(type: "INTEGER", nullable: false),
                    Cliente_idCliente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caminhonete", x => x._idCarro);
                    table.ForeignKey(
                        name: "FK_caminhonete_cliente_Cliente_idCliente",
                        column: x => x.Cliente_idCliente,
                        principalTable: "cliente",
                        principalColumn: "_idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_caminhonete_marca_Marca_idMarca",
                        column: x => x.Marca_idMarca,
                        principalTable: "marca",
                        principalColumn: "_idMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_caminhonete_modelo_Modelo_idModelo",
                        column: x => x.Modelo_idModelo,
                        principalTable: "modelo",
                        principalColumn: "_idModelo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_caminhonete_veiculo_Veiculo_idVeiculo",
                        column: x => x.Veiculo_idVeiculo,
                        principalTable: "veiculo",
                        principalColumn: "_idVeiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carro",
                columns: table => new
                {
                    _idCarro = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _idVeiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    _idMarca = table.Column<int>(type: "INTEGER", nullable: false),
                    _idModelo = table.Column<int>(type: "INTEGER", nullable: false),
                    _idCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    Veiculo_idVeiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    Marca_idMarca = table.Column<int>(type: "INTEGER", nullable: false),
                    Modelo_idModelo = table.Column<int>(type: "INTEGER", nullable: false),
                    Cliente_idCliente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carro", x => x._idCarro);
                    table.ForeignKey(
                        name: "FK_carro_cliente_Cliente_idCliente",
                        column: x => x.Cliente_idCliente,
                        principalTable: "cliente",
                        principalColumn: "_idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carro_marca_Marca_idMarca",
                        column: x => x.Marca_idMarca,
                        principalTable: "marca",
                        principalColumn: "_idMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carro_modelo_Modelo_idModelo",
                        column: x => x.Modelo_idModelo,
                        principalTable: "modelo",
                        principalColumn: "_idModelo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carro_veiculo_Veiculo_idVeiculo",
                        column: x => x.Veiculo_idVeiculo,
                        principalTable: "veiculo",
                        principalColumn: "_idVeiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moto",
                columns: table => new
                {
                    _idMoto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _idVeiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    _idMarca = table.Column<int>(type: "INTEGER", nullable: false),
                    _idModelo = table.Column<int>(type: "INTEGER", nullable: false),
                    _idCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    Veiculo_idVeiculo = table.Column<int>(type: "INTEGER", nullable: false),
                    Marca_idMarca = table.Column<int>(type: "INTEGER", nullable: false),
                    Modelo_idModelo = table.Column<int>(type: "INTEGER", nullable: false),
                    Cliente_idCliente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moto", x => x._idMoto);
                    table.ForeignKey(
                        name: "FK_moto_cliente_Cliente_idCliente",
                        column: x => x.Cliente_idCliente,
                        principalTable: "cliente",
                        principalColumn: "_idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_moto_marca_Marca_idMarca",
                        column: x => x.Marca_idMarca,
                        principalTable: "marca",
                        principalColumn: "_idMarca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_moto_modelo_Modelo_idModelo",
                        column: x => x.Modelo_idModelo,
                        principalTable: "modelo",
                        principalColumn: "_idModelo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_moto_veiculo_Veiculo_idVeiculo",
                        column: x => x.Veiculo_idVeiculo,
                        principalTable: "veiculo",
                        principalColumn: "_idVeiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    _idTicket = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _codTicket = table.Column<int>(type: "INTEGER", nullable: false),
                    _idCarro = table.Column<int>(type: "INTEGER", nullable: false),
                    _idPeriodo = table.Column<int>(type: "INTEGER", nullable: false),
                    _Servico = table.Column<int>(type: "INTEGER", nullable: false),
                    Carro_idCarro = table.Column<int>(type: "INTEGER", nullable: false),
                    Periodo_idPeriodo = table.Column<int>(type: "INTEGER", nullable: false),
                    Servico_idServico = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x._idTicket);
                    table.ForeignKey(
                        name: "FK_ticket_carro_Carro_idCarro",
                        column: x => x.Carro_idCarro,
                        principalTable: "carro",
                        principalColumn: "_idCarro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticket_periodo_Periodo_idPeriodo",
                        column: x => x.Periodo_idPeriodo,
                        principalTable: "periodo",
                        principalColumn: "_idPeriodo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticket_servico_Servico_idServico",
                        column: x => x.Servico_idServico,
                        principalTable: "servico",
                        principalColumn: "_idServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_caminhonete_Cliente_idCliente",
                table: "caminhonete",
                column: "Cliente_idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_caminhonete_Marca_idMarca",
                table: "caminhonete",
                column: "Marca_idMarca");

            migrationBuilder.CreateIndex(
                name: "IX_caminhonete_Modelo_idModelo",
                table: "caminhonete",
                column: "Modelo_idModelo");

            migrationBuilder.CreateIndex(
                name: "IX_caminhonete_Veiculo_idVeiculo",
                table: "caminhonete",
                column: "Veiculo_idVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_carro_Cliente_idCliente",
                table: "carro",
                column: "Cliente_idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_carro_Marca_idMarca",
                table: "carro",
                column: "Marca_idMarca");

            migrationBuilder.CreateIndex(
                name: "IX_carro_Modelo_idModelo",
                table: "carro",
                column: "Modelo_idModelo");

            migrationBuilder.CreateIndex(
                name: "IX_carro_Veiculo_idVeiculo",
                table: "carro",
                column: "Veiculo_idVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_moto_Cliente_idCliente",
                table: "moto",
                column: "Cliente_idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_moto_Marca_idMarca",
                table: "moto",
                column: "Marca_idMarca");

            migrationBuilder.CreateIndex(
                name: "IX_moto_Modelo_idModelo",
                table: "moto",
                column: "Modelo_idModelo");

            migrationBuilder.CreateIndex(
                name: "IX_moto_Veiculo_idVeiculo",
                table: "moto",
                column: "Veiculo_idVeiculo");

            migrationBuilder.CreateIndex(
                name: "IX_notafiscal_Cliente_idCliente",
                table: "notafiscal",
                column: "Cliente_idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_notafiscal_Servico_idServico",
                table: "notafiscal",
                column: "Servico_idServico");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_Carro_idCarro",
                table: "ticket",
                column: "Carro_idCarro");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_Periodo_idPeriodo",
                table: "ticket",
                column: "Periodo_idPeriodo");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_Servico_idServico",
                table: "ticket",
                column: "Servico_idServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "caminhonete");

            migrationBuilder.DropTable(
                name: "moto");

            migrationBuilder.DropTable(
                name: "notafiscal");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "carro");

            migrationBuilder.DropTable(
                name: "periodo");

            migrationBuilder.DropTable(
                name: "servico");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "modelo");

            migrationBuilder.DropTable(
                name: "veiculo");
        }
    }
}
