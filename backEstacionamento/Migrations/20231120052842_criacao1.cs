using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estacionamento.Migrations
{
    /// <inheritdoc />
    public partial class criacao1 : Migration
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
                    _idMarca = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nomeMarca = table.Column<string>(type: "TEXT", nullable: true),
                    _segmento = table.Column<string>(type: "TEXT", nullable: true)
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
                    _AnoModelo = table.Column<int>(type: "INTEGER", nullable: true),
                    _TipoModelo = table.Column<string>(type: "TEXT", nullable: true),
                    _idMarca = table.Column<int>(type: "INTEGER", nullable: true),
                    Marca_idMarca = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelo", x => x._idModelo);
                    table.ForeignKey(
                        name: "FK_modelo_marca_Marca_idMarca",
                        column: x => x.Marca_idMarca,
                        principalTable: "marca",
                        principalColumn: "_idMarca");
                });

            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    _Placa = table.Column<string>(type: "TEXT", nullable: false),
                    _Cor = table.Column<string>(type: "TEXT", nullable: true),
                    _idModelo = table.Column<int>(type: "INTEGER", nullable: true),
                    Modelo_idModelo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x._Placa);
                    table.ForeignKey(
                        name: "FK_veiculo_modelo_Modelo_idModelo",
                        column: x => x.Modelo_idModelo,
                        principalTable: "modelo",
                        principalColumn: "_idModelo");
                });

            migrationBuilder.CreateTable(
                name: "ClienteVeiculo",
                columns: table => new
                {
                    Clientes_Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Veiculos_Placa = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteVeiculo", x => new { x.Clientes_Cpf, x.Veiculos_Placa });
                    table.ForeignKey(
                        name: "FK_ClienteVeiculo_cliente_Clientes_Cpf",
                        column: x => x.Clientes_Cpf,
                        principalTable: "cliente",
                        principalColumn: "_Cpf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteVeiculo_veiculo_Veiculos_Placa",
                        column: x => x.Veiculos_Placa,
                        principalTable: "veiculo",
                        principalColumn: "_Placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    _idTicket = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _codTicket = table.Column<string>(type: "TEXT", nullable: true),
                    _Placa = table.Column<string>(type: "TEXT", nullable: true),
                    _HoraEntrada = table.Column<string>(type: "TEXT", nullable: true),
                    _HoraSaida = table.Column<string>(type: "TEXT", nullable: true),
                    _Pagamento = table.Column<bool>(type: "INTEGER", nullable: true),
                    Veiculo_Placa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x._idTicket);
                    table.ForeignKey(
                        name: "FK_ticket_veiculo_Veiculo_Placa",
                        column: x => x.Veiculo_Placa,
                        principalTable: "veiculo",
                        principalColumn: "_Placa");
                });

            migrationBuilder.CreateTable(
                name: "notafiscal",
                columns: table => new
                {
                    _NumeroNota = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _ValorDaNota = table.Column<double>(type: "REAL", nullable: true),
                    _Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    _idServico = table.Column<int>(type: "INTEGER", nullable: true),
                    Cliente_Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    Servico_idServico = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notafiscal", x => x._NumeroNota);
                    table.ForeignKey(
                        name: "FK_notafiscal_cliente_Cliente_Cpf",
                        column: x => x.Cliente_Cpf,
                        principalTable: "cliente",
                        principalColumn: "_Cpf");
                });

            migrationBuilder.CreateTable(
                name: "servico",
                columns: table => new
                {
                    _idServico = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _codTicket = table.Column<string>(type: "TEXT", nullable: true),
                    _tipoServico = table.Column<string>(type: "TEXT", nullable: true),
                    _valorServico = table.Column<double>(type: "REAL", nullable: true),
                    _Pagamento = table.Column<bool>(type: "INTEGER", nullable: true),
                    Ticket_idTicket = table.Column<int>(type: "INTEGER", nullable: true),
                    NotaFiscal_NumeroNota = table.Column<int>(type: "INTEGER", nullable: true),
                    Veiculo_Placa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servico", x => x._idServico);
                    table.ForeignKey(
                        name: "FK_servico_notafiscal_NotaFiscal_NumeroNota",
                        column: x => x.NotaFiscal_NumeroNota,
                        principalTable: "notafiscal",
                        principalColumn: "_NumeroNota");
                    table.ForeignKey(
                        name: "FK_servico_ticket_Ticket_idTicket",
                        column: x => x.Ticket_idTicket,
                        principalTable: "ticket",
                        principalColumn: "_idTicket");
                    table.ForeignKey(
                        name: "FK_servico_veiculo_Veiculo_Placa",
                        column: x => x.Veiculo_Placa,
                        principalTable: "veiculo",
                        principalColumn: "_Placa");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteVeiculo_Veiculos_Placa",
                table: "ClienteVeiculo",
                column: "Veiculos_Placa");

            migrationBuilder.CreateIndex(
                name: "IX_modelo_Marca_idMarca",
                table: "modelo",
                column: "Marca_idMarca");

            migrationBuilder.CreateIndex(
                name: "IX_notafiscal_Cliente_Cpf",
                table: "notafiscal",
                column: "Cliente_Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_notafiscal_Servico_idServico",
                table: "notafiscal",
                column: "Servico_idServico");

            migrationBuilder.CreateIndex(
                name: "IX_servico_NotaFiscal_NumeroNota",
                table: "servico",
                column: "NotaFiscal_NumeroNota");

            migrationBuilder.CreateIndex(
                name: "IX_servico_Ticket_idTicket",
                table: "servico",
                column: "Ticket_idTicket");

            migrationBuilder.CreateIndex(
                name: "IX_servico_Veiculo_Placa",
                table: "servico",
                column: "Veiculo_Placa");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_Veiculo_Placa",
                table: "ticket",
                column: "Veiculo_Placa");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_Modelo_idModelo",
                table: "veiculo",
                column: "Modelo_idModelo");

            migrationBuilder.AddForeignKey(
                name: "FK_notafiscal_servico_Servico_idServico",
                table: "notafiscal",
                column: "Servico_idServico",
                principalTable: "servico",
                principalColumn: "_idServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notafiscal_cliente_Cliente_Cpf",
                table: "notafiscal");

            migrationBuilder.DropForeignKey(
                name: "FK_servico_veiculo_Veiculo_Placa",
                table: "servico");

            migrationBuilder.DropForeignKey(
                name: "FK_ticket_veiculo_Veiculo_Placa",
                table: "ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_notafiscal_servico_Servico_idServico",
                table: "notafiscal");

            migrationBuilder.DropTable(
                name: "ClienteVeiculo");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "veiculo");

            migrationBuilder.DropTable(
                name: "modelo");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "servico");

            migrationBuilder.DropTable(
                name: "notafiscal");

            migrationBuilder.DropTable(
                name: "ticket");
        }
    }
}
