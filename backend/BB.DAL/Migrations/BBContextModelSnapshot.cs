﻿// <auto-generated />
using System;
using BB.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BB.DAL.Migrations
{
    [DbContext(typeof(BBContext))]
    partial class BBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BB.DAL.Entities.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CheckingBranchId")
                        .HasColumnType("int");

                    b.Property<int?>("CreditBranchId")
                        .HasColumnType("int");

                    b.Property<int?>("DepositBranchId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("Pin")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nchar(4)")
                        .IsFixedLength(true);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.HasIndex("CheckingBranchId")
                        .IsUnique();

                    b.HasIndex("CreditBranchId")
                        .IsUnique()
                        .HasFilter("[CreditBranchId] IS NOT NULL");

                    b.HasIndex("DepositBranchId")
                        .IsUnique()
                        .HasFilter("[DepositBranchId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("BB.DAL.Entities.CheckingBranch", b =>
                {
                    b.Property<int>("CheckingBranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Balance")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("CheckingBranchId");

                    b.ToTable("CheckingBranches");
                });

            modelBuilder.Entity("BB.DAL.Entities.CreditBranch", b =>
                {
                    b.Property<int>("CreditBranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Available")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal>("Balance")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal>("Debt")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<double>("Interest")
                        .HasColumnType("float");

                    b.Property<TimeSpan>("TimeOver")
                        .HasColumnType("time");

                    b.HasKey("CreditBranchId");

                    b.ToTable("CreditBranches");
                });

            modelBuilder.Entity("BB.DAL.Entities.Deposit", b =>
                {
                    b.Property<int>("DepositId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("CanBeTerminated")
                        .HasColumnType("bit");

                    b.Property<string>("CurrencyOfDeposit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("DepSum")
                        .HasColumnType("int");

                    b.Property<int>("DepositBranchId")
                        .HasColumnType("int");

                    b.Property<bool>("PaymentsToDeposit")
                        .HasColumnType("bit");

                    b.Property<double>("Percent")
                        .HasColumnType("float");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.HasKey("DepositId");

                    b.HasIndex("DepositBranchId");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("BB.DAL.Entities.DepositBranch", b =>
                {
                    b.Property<int>("DepositBranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("DepositBranchId");

                    b.ToTable("DepositBranches");
                });

            modelBuilder.Entity("BB.DAL.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BB.DAL.Entities.Card", b =>
                {
                    b.HasOne("BB.DAL.Entities.CheckingBranch", "CheckingBranch")
                        .WithOne("Card")
                        .HasForeignKey("BB.DAL.Entities.Card", "CheckingBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BB.DAL.Entities.CreditBranch", "CreditBranch")
                        .WithOne("Card")
                        .HasForeignKey("BB.DAL.Entities.Card", "CreditBranchId");

                    b.HasOne("BB.DAL.Entities.DepositBranch", "DepositBranch")
                        .WithOne("Card")
                        .HasForeignKey("BB.DAL.Entities.Card", "DepositBranchId");

                    b.HasOne("BB.DAL.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckingBranch");

                    b.Navigation("CreditBranch");

                    b.Navigation("DepositBranch");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BB.DAL.Entities.Deposit", b =>
                {
                    b.HasOne("BB.DAL.Entities.DepositBranch", "DepositBranch")
                        .WithMany("Deposits")
                        .HasForeignKey("DepositBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepositBranch");
                });

            modelBuilder.Entity("BB.DAL.Entities.CheckingBranch", b =>
                {
                    b.Navigation("Card");
                });

            modelBuilder.Entity("BB.DAL.Entities.CreditBranch", b =>
                {
                    b.Navigation("Card");
                });

            modelBuilder.Entity("BB.DAL.Entities.DepositBranch", b =>
                {
                    b.Navigation("Card");

                    b.Navigation("Deposits");
                });

            modelBuilder.Entity("BB.DAL.Entities.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
