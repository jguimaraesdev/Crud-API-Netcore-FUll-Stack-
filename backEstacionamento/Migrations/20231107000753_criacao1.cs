﻿using System;
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
                    idModelo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _nomeModelo = table.Column<string>(type: "TEXT", nullable: true),
                    _motor = table.Column<string>(type: "TEXT", nullable: true),
                    _qtdPortas = table.Column<int>(type: "INTEGER", nullable: true),
                    _AnoModelo = table.Column<int>(type: "INTEGER", nullable: true),
                    _TipoModelo = table.Column<string>(type: "TEXT", nullable: true),
                    _idMarca = table.Column<int>(type: "INTEGER", nullable: true),
                    Marca_idMarca = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelo", x => x.idModelo);
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
                    ModeloidModelo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x._Placa);
                    table.ForeignKey(
                        name: "FK_veiculo_modelo_ModeloidModelo",
                        column: x => x.ModeloidModelo,
                        principalTable: "modelo",
                        principalColumn: "idModelo");
                });

            migrationBuilder.CreateTable(
                name: "clienteVeiculo",
                columns: table => new
                {
                    Clientes_Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Veiculos_Placa = table.Column<string>(type: "TEXT", nullable: true),
                    Veiculo_Placa = table.Column<string>(type: "TEXT", nullable: true),
                    Cliente_Cpf = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clienteVeiculo", x => x.Clientes_Cpf);
                    table.ForeignKey(
                        name: "FK_clienteVeiculo_cliente_Cliente_Cpf",
                        column: x => x.Cliente_Cpf,
                        principalTable: "cliente",
                        principalColumn: "_Cpf");
                    table.ForeignKey(
                        name: "FK_clienteVeiculo_veiculo_Veiculo_Placa",
                        column: x => x.Veiculo_Placa,
                        principalTable: "veiculo",
                        principalColumn: "_Placa");
                });

            migrationBuilder.CreateTable(
                name: "ClienteVeiculo1",
                columns: table => new
                {
                    Clientes_Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Veiculos_Placa = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteVeiculo1", x => new { x.Clientes_Cpf, x.Veiculos_Placa });
                    table.ForeignKey(
                        name: "FK_ClienteVeiculo1_cliente_Clientes_Cpf",
                        column: x => x.Clientes_Cpf,
                        principalTable: "cliente",
                        principalColumn: "_Cpf",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteVeiculo1_veiculo_Veiculos_Placa",
                        column: x => x.Veiculos_Placa,
                        principalTable: "veiculo",
                        principalColumn: "_Placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "periodo",
                columns: table => new
                {
                    _idPeriodo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _HoraEntrada = table.Column<DateTime>(type: "TEXT", nullable: true),
                    _HoraSaida = table.Column<DateTime>(type: "TEXT", nullable: true),
                    _Placa = table.Column<string>(type: "TEXT", nullable: true),
                    Veiculo_Placa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodo", x => x._idPeriodo);
                    table.ForeignKey(
                        name: "FK_periodo_veiculo_Veiculo_Placa",
                        column: x => x.Veiculo_Placa,
                        principalTable: "veiculo",
                        principalColumn: "_Placa");
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    _codTicket = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _Placa = table.Column<string>(type: "TEXT", nullable: true),
                    _idPeriodo = table.Column<int>(type: "INTEGER", nullable: true),
                    Veiculo_Placa = table.Column<string>(type: "TEXT", nullable: true),
                    Periodo_idPeriodo = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x._codTicket);
                    table.ForeignKey(
                        name: "FK_ticket_periodo_Periodo_idPeriodo",
                        column: x => x.Periodo_idPeriodo,
                        principalTable: "periodo",
                        principalColumn: "_idPeriodo");
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
                    _NumeroNota = table.Column<string>(type: "TEXT", nullable: false),
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
                    _codTicket = table.Column<int>(type: "INTEGER", nullable: true),
                    _tipoServico = table.Column<string>(type: "TEXT", nullable: true),
                    _valorServico = table.Column<double>(type: "REAL", nullable: true),
                    Ticket_codTicket = table.Column<int>(type: "INTEGER", nullable: true),
                    NotaFiscal_NumeroNota = table.Column<string>(type: "TEXT", nullable: true),
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
                        name: "FK_servico_ticket_Ticket_codTicket",
                        column: x => x.Ticket_codTicket,
                        principalTable: "ticket",
                        principalColumn: "_codTicket");
                    table.ForeignKey(
                        name: "FK_servico_veiculo_Veiculo_Placa",
                        column: x => x.Veiculo_Placa,
                        principalTable: "veiculo",
                        principalColumn: "_Placa");
                });

            migrationBuilder.CreateIndex(
                name: "IX_clienteVeiculo_Cliente_Cpf",
                table: "clienteVeiculo",
                column: "Cliente_Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_clienteVeiculo_Veiculo_Placa",
                table: "clienteVeiculo",
                column: "Veiculo_Placa");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteVeiculo1_Veiculos_Placa",
                table: "ClienteVeiculo1",
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
                name: "IX_periodo_Veiculo_Placa",
                table: "periodo",
                column: "Veiculo_Placa");

            migrationBuilder.CreateIndex(
                name: "IX_servico_NotaFiscal_NumeroNota",
                table: "servico",
                column: "NotaFiscal_NumeroNota");

            migrationBuilder.CreateIndex(
                name: "IX_servico_Ticket_codTicket",
                table: "servico",
                column: "Ticket_codTicket");

            migrationBuilder.CreateIndex(
                name: "IX_servico_Veiculo_Placa",
                table: "servico",
                column: "Veiculo_Placa");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_Periodo_idPeriodo",
                table: "ticket",
                column: "Periodo_idPeriodo");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_Veiculo_Placa",
                table: "ticket",
                column: "Veiculo_Placa");

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_ModeloidModelo",
                table: "veiculo",
                column: "ModeloidModelo");

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
                name: "FK_periodo_veiculo_Veiculo_Placa",
                table: "periodo");

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
                name: "clienteVeiculo");

            migrationBuilder.DropTable(
                name: "ClienteVeiculo1");

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

            migrationBuilder.DropTable(
                name: "periodo");
        }
    }
}