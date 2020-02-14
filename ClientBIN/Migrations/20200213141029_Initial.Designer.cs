﻿// <auto-generated />
using ClientBIN.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClientBIN.Migrations
{
    [DbContext(typeof(MyAppContextDb))]
    [Migration("20200213141029_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClientBIN.Models.BIN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BIN_LEN")
                        .HasColumnType("int");

                    b.Property<string>("CODE_A2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CODE_A3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CODE_N3")
                        .HasColumnType("int");

                    b.Property<long>("END_BIN")
                        .HasColumnType("bigint");

                    b.Property<string>("PS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_ID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("START_BIN")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("BINs");
                });
#pragma warning restore 612, 618
        }
    }
}