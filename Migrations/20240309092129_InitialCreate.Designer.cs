﻿// <auto-generated />
using BankSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankSystem.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240309092129_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("BankSystem.Models.Account", b =>
                {
                    b.Property<string>("AccountId")
                        .HasColumnType("TEXT");

                    b.Property<float>("Balance")
                        .HasColumnType("REAL");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankSystem.Models.History", b =>
                {
                    b.Property<int>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReceivedAccountId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SentAccountId")
                        .HasColumnType("TEXT");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("HistoryId");

                    b.HasIndex("ReceivedAccountId");

                    b.HasIndex("SentAccountId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("BankSystem.Models.History", b =>
                {
                    b.HasOne("BankSystem.Models.Account", "Received")
                        .WithMany()
                        .HasForeignKey("ReceivedAccountId");

                    b.HasOne("BankSystem.Models.Account", "Sent")
                        .WithMany()
                        .HasForeignKey("SentAccountId");

                    b.Navigation("Received");

                    b.Navigation("Sent");
                });
#pragma warning restore 612, 618
        }
    }
}
