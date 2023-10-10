﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Estacionamento.Migrations
{
    [DbContext(typeof(EstacionamentoDbContext))]
    [Migration("20231010003350_criacaoinicial")]
    partial class criacaoinicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Carro", b =>
                {
                    b.Property<int>("_idCarro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cliente_idCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Marca_idMarca")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Modelo_idModelo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Veiculo_idVeiculo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_idCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_idMarca")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_idModelo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_idVeiculo")
                        .HasColumnType("INTEGER");

                    b.HasKey("_idCarro");

                    b.HasIndex("Cliente_idCliente");

                    b.HasIndex("Marca_idMarca");

                    b.HasIndex("Modelo_idModelo");

                    b.HasIndex("Veiculo_idVeiculo");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("Cliente", b =>
                {
                    b.Property<int?>("_idCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("_Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("_Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("_Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("_idCliente");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Marca", b =>
                {
                    b.Property<int?>("_idMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("_DescricaoMarca")
                        .HasColumnType("TEXT");

                    b.Property<string>("_Segmento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("_idMarca");

                    b.ToTable("marca");
                });

            modelBuilder.Entity("Modelo", b =>
                {
                    b.Property<int?>("_idModelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("_CorExterna")
                        .HasColumnType("INTEGER");

                    b.Property<string>("_Tamanho")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("_motor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("_nomeModelo")
                        .HasColumnType("TEXT");

                    b.Property<int>("_qtdPortas")
                        .HasColumnType("INTEGER");

                    b.HasKey("_idModelo");

                    b.ToTable("modelo");
                });

            modelBuilder.Entity("NotaFiscal", b =>
                {
                    b.Property<int>("_idNota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Cliente_idCliente")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Servico_idServico")
                        .HasColumnType("INTEGER");

                    b.Property<string>("_NumeroNota")
                        .HasColumnType("TEXT");

                    b.Property<double>("_ValorDaNota")
                        .HasColumnType("REAL");

                    b.Property<string>("_idCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("_idServico")
                        .HasColumnType("INTEGER");

                    b.HasKey("_idNota");

                    b.HasIndex("Cliente_idCliente");

                    b.HasIndex("Servico_idServico");

                    b.ToTable("notafiscal");
                });

            modelBuilder.Entity("Periodo", b =>
                {
                    b.Property<int?>("_idPeriodo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("_HoraEntrada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("_HoraSaida")
                        .HasColumnType("TEXT");

                    b.HasKey("_idPeriodo");

                    b.ToTable("periodo");
                });

            modelBuilder.Entity("Servico", b =>
                {
                    b.Property<int>("_idServico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("_descricaoServico")
                        .HasColumnType("TEXT");

                    b.Property<double>("_valorHora")
                        .HasColumnType("REAL");

                    b.Property<double?>("_valorPagar")
                        .HasColumnType("REAL");

                    b.HasKey("_idServico");

                    b.ToTable("servico");
                });

            modelBuilder.Entity("Ticket", b =>
                {
                    b.Property<int>("_idTicket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Carro_idCarro")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Periodo_idPeriodo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Servico_idServico")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_Servico")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_codTicket")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_idCarro")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_idPeriodo")
                        .HasColumnType("INTEGER");

                    b.HasKey("_idTicket");

                    b.HasIndex("Carro_idCarro");

                    b.HasIndex("Periodo_idPeriodo");

                    b.HasIndex("Servico_idServico");

                    b.ToTable("ticket");
                });

            modelBuilder.Entity("Veiculo", b =>
                {
                    b.Property<int?>("_idVeiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("_Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("_Placa")
                        .HasColumnType("TEXT");

                    b.HasKey("_idVeiculo");

                    b.ToTable("veiculo");
                });

            modelBuilder.Entity("Carro", b =>
                {
                    b.HasOne("Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("Cliente_idCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("Marca_idMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("Modelo_idModelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("Veiculo_idVeiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Marca");

                    b.Navigation("Modelo");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("NotaFiscal", b =>
                {
                    b.HasOne("Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("Cliente_idCliente");

                    b.HasOne("Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("Servico_idServico");

                    b.Navigation("Cliente");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Ticket", b =>
                {
                    b.HasOne("Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("Carro_idCarro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Periodo", "Periodo")
                        .WithMany()
                        .HasForeignKey("Periodo_idPeriodo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Servico", "Servico")
                        .WithMany()
                        .HasForeignKey("Servico_idServico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Periodo");

                    b.Navigation("Servico");
                });
#pragma warning restore 612, 618
        }
    }
}
