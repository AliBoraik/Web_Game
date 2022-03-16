﻿// <auto-generated />
using GameDataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameDataBase.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Game.Models.GameModels.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Ac")
                        .HasColumnType("int");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("int");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("int");

                    b.Property<string>("Damage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("int");

                    b.Property<int>("Hits")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Monsters");
                });
#pragma warning restore 612, 618
        }
    }
}
