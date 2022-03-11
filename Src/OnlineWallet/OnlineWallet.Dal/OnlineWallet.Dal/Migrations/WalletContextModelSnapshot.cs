﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineWallet.Dal;

namespace OnlineWallet.Dal.Migrations
{
    [DbContext(typeof(WalletContext))]
    partial class WalletContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("OnlineWallet.Dal.DbWallet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Balance")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("OnlineWallet.Dal.Entities.DbCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("OnlineWallet.Dal.Entities.DbTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("AddMoney")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sum")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("OnlineWallet.Dal.DbWallet", b =>
                {
                    b.HasOne("OnlineWallet.Dal.Entities.DbCustomer", "Customer")
                        .WithOne("Wallet")
                        .HasForeignKey("OnlineWallet.Dal.DbWallet", "CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OnlineWallet.Dal.Entities.DbTransaction", b =>
                {
                    b.HasOne("OnlineWallet.Dal.DbWallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("OnlineWallet.Dal.Entities.DbCustomer", b =>
                {
                    b.Navigation("Wallet");
                });
#pragma warning restore 612, 618
        }
    }
}
