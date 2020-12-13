﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Xayah.FIControl.DataContext;

namespace Xayah.FIControl.DataContext.Migrations
{
    [DbContext(typeof(XayahFIControlDataContext))]
    partial class XayahFIControlDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("XayahFIControl")
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Xayah.FIControl.Domain.Enitties.Accountlaunche", b =>
                {
                    b.Property<Guid>("AccountlauncheId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("BankStatementId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dtposted")
                        .HasColumnType("TEXT");

                    b.Property<string>("Memo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Trnamt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Trntype")
                        .HasColumnType("TEXT");

                    b.HasKey("AccountlauncheId");

                    b.HasIndex("BankStatementId");

                    b.ToTable("Accountlaunche");
                });

            modelBuilder.Entity("Xayah.FIControl.Domain.Enitties.BankStatement", b =>
                {
                    b.Property<Guid>("BankStatementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Acctid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Accttype")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Balamt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bankid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Curdef")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dataserver")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dtasof")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ofx")
                        .HasColumnType("TEXT");

                    b.Property<string>("Severity")
                        .HasColumnType("TEXT");

                    b.Property<string>("Trnuid")
                        .HasColumnType("TEXT");

                    b.HasKey("BankStatementId");

                    b.ToTable("BankStatement");
                });

            modelBuilder.Entity("Xayah.FIControl.Domain.Enitties.Accountlaunche", b =>
                {
                    b.HasOne("Xayah.FIControl.Domain.Enitties.BankStatement", null)
                        .WithMany("Accountlaunches")
                        .HasForeignKey("BankStatementId");
                });

            modelBuilder.Entity("Xayah.FIControl.Domain.Enitties.BankStatement", b =>
                {
                    b.Navigation("Accountlaunches");
                });
#pragma warning restore 612, 618
        }
    }
}