﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPG.Data;

#nullable disable

namespace RPG.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RPG.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("MaxHP")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Defense = 10,
                            Dexterity = 10,
                            HP = 100,
                            Intelligence = 10,
                            MaxHP = 100,
                            Name = "FirstTestPlayer",
                            Strength = 10
                        },
                        new
                        {
                            Id = 2,
                            Defense = 10,
                            Dexterity = 10,
                            HP = 100,
                            Intelligence = 10,
                            MaxHP = 100,
                            Name = "SecondTestPlayer",
                            Strength = 10
                        },
                        new
                        {
                            Id = 3,
                            Defense = 10,
                            Dexterity = 10,
                            HP = 100,
                            Intelligence = 10,
                            MaxHP = 100,
                            Name = "ThirdTestPlayer",
                            Strength = 10
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
