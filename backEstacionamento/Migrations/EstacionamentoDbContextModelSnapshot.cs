﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Estacionamento.Migrations
{
    [DbContext(typeof(EstacionamentoDbContext))]
    partial class EstacionamentoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Property<string>("_Cpf")
                        .HasColumnType("TEXT").HasMaxLength(11);

                    b.Property<string>("_Email")
                        .HasColumnType("TEXT").HasMaxLength(35);

                    b.Property<string>("_Nome")
                        .HasColumnType("TEXT").HasMaxLength(40);

                    b.HasKey("_Cpf");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("ClienteVeiculo", b =>
                {
                    b.Property<string>("Clientes_Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cliente_Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Veiculo_Placa")
                        .HasColumnType("TEXT");

                    b.Property<string>("Veiculos_Placa")
                        .HasColumnType("TEXT");

                    b.HasKey("Clientes_Cpf");

                    b.HasIndex("Cliente_Cpf");

                    b.HasIndex("Veiculo_Placa");

                    b.ToTable("clienteVeiculo");
                });

            modelBuilder.Entity("ClienteVeiculo1", b =>
                {
                    b.Property<string>("Clientes_Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Veiculos_Placa")
                        .HasColumnType("TEXT");

                    b.HasKey("Clientes_Cpf", "Veiculos_Placa");

                    b.HasIndex("Veiculos_Placa");

                    b.ToTable("ClienteVeiculo1");
                });

            modelBuilder.Entity("Marca", b =>
                {
                    b.Property<int?>("_idMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("_nomeMarca")
                        .HasColumnType("TEXT");

                    b.Property<string>("_segmento")
                        .HasColumnType("TEXT");

                    b.HasKey("_idMarca");

                    b.ToTable("marca");
                });

            modelBuilder.Entity("Modelo", b =>
                {
                    b.Property<int?>("idModelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Marca_idMarca")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("_AnoModelo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("_TipoModelo")
                        .HasColumnType("TEXT");

                    b.Property<int?>("_idMarca")
                        .HasColumnType("INTEGER");

                    b.Property<string>("_motor")
                        .HasColumnType("TEXT");

                    b.Property<string>("_nomeModelo")
                        .HasColumnType("TEXT");

                    b.Property<int?>("_qtdPortas")
                        .HasColumnType("INTEGER");

                    b.HasKey("idModelo");

                    b.HasIndex("Marca_idMarca");

                    b.ToTable("modelo");
                });

            modelBuilder.Entity("NotaFiscal", b =>
                {
                    b.Property<string>("_NumeroNota")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cliente_Cpf")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Servico_idServico")
                        .HasColumnType("INTEGER");

                    b.Property<string>("_Cpf")
                        .HasColumnType("TEXT");

                    b.Property<double?>("_ValorDaNota")
                        .HasColumnType("REAL");

                    b.Property<int?>("_idServico")
                        .HasColumnType("INTEGER");

                    b.HasKey("_NumeroNota");

                    b.HasIndex("Cliente_Cpf");

                    b.HasIndex("Servico_idServico");

                    b.ToTable("notafiscal");
                });

            modelBuilder.Entity("Periodo", b =>
                {
                    b.Property<int?>("_idPeriodo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Veiculo_Placa")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("_HoraEntrada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("_HoraSaida")
                        .HasColumnType("TEXT");

                    b.Property<string>("_Placa")
                        .HasColumnType("TEXT");

                    b.HasKey("_idPeriodo");

                    b.HasIndex("Veiculo_Placa");

                    b.ToTable("periodo");
                });

            modelBuilder.Entity("Servico", b =>
                {
                    b.Property<int?>("_idServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NotaFiscal_NumeroNota")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Ticket_codTicket")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Veiculo_Placa")
                        .HasColumnType("TEXT");

                    b.Property<int?>("_codTicket")
                        .HasColumnType("INTEGER");

                    b.Property<string>("_tipoServico")
                        .HasColumnType("TEXT");

                    b.Property<double?>("_valorServico")
                        .HasColumnType("REAL");

                    b.HasKey("_idServico");

                    b.HasIndex("NotaFiscal_NumeroNota");

                    b.HasIndex("Ticket_codTicket");

                    b.HasIndex("Veiculo_Placa");

                    b.ToTable("servico");
                });

            modelBuilder.Entity("Ticket", b =>
                {
                    b.Property<int?>("_codTicket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Periodo_idPeriodo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Veiculo_Placa")
                        .HasColumnType("TEXT");

                    b.Property<string>("_Placa")
                        .HasColumnType("TEXT");

                    b.Property<int?>("_idPeriodo")
                        .HasColumnType("INTEGER");

                    b.HasKey("_codTicket");

                    b.HasIndex("Periodo_idPeriodo");

                    b.HasIndex("Veiculo_Placa");

                    b.ToTable("ticket");
                });

            modelBuilder.Entity("Veiculo", b =>
                {
                    b.Property<string>("_Placa")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ModeloidModelo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("_Cor")
                        .HasColumnType("TEXT");

                    b.Property<int?>("_idModelo")
                        .HasColumnType("INTEGER");

                    b.HasKey("_Placa");

                    b.HasIndex("ModeloidModelo");

                    b.ToTable("veiculo");
                });

            modelBuilder.Entity("ClienteVeiculo", b =>
                {
                    b.HasOne("Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("Cliente_Cpf");

                    b.HasOne("Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("Veiculo_Placa");

                    b.Navigation("Cliente");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("ClienteVeiculo1", b =>
                {
                    b.HasOne("Cliente", null)
                        .WithMany()
                        .HasForeignKey("Clientes_Cpf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Veiculo", null)
                        .WithMany()
                        .HasForeignKey("Veiculos_Placa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Modelo", b =>
                {
                    b.HasOne("Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("Marca_idMarca");

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("NotaFiscal", b =>
                {
                    b.HasOne("Cliente", "Cliente")
                        .WithMany("NotaFiscais")
                        .HasForeignKey("Cliente_Cpf");

                    b.HasOne("Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("Servico_idServico");

                    b.Navigation("Cliente");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Periodo", b =>
                {
                    b.HasOne("Veiculo", "Veiculo")
                        .WithMany("Periodos")
                        .HasForeignKey("Veiculo_Placa");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Servico", b =>
                {
                    b.HasOne("NotaFiscal", null)
                        .WithMany("Servicos")
                        .HasForeignKey("NotaFiscal_NumeroNota");

                    b.HasOne("Ticket", "Ticket")
                        .WithMany("Servicos")
                        .HasForeignKey("Ticket_codTicket");

                    b.HasOne("Veiculo", null)
                        .WithMany("Servicos")
                        .HasForeignKey("Veiculo_Placa");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Ticket", b =>
                {
                    b.HasOne("Periodo", "Periodo")
                        .WithMany()
                        .HasForeignKey("Periodo_idPeriodo");

                    b.HasOne("Veiculo", "Veiculo")
                        .WithMany("Tickets")
                        .HasForeignKey("Veiculo_Placa");

                    b.Navigation("Periodo");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Veiculo", b =>
                {
                    b.HasOne("Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloidModelo");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Navigation("NotaFiscais");
                });

            modelBuilder.Entity("NotaFiscal", b =>
                {
                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("Ticket", b =>
                {
                    b.Navigation("Servicos");
                });

            modelBuilder.Entity("Veiculo", b =>
                {
                    b.Navigation("Periodos");

                    b.Navigation("Servicos");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
