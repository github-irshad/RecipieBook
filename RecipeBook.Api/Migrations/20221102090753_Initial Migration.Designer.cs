﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RecipeBook.Api.Data;

#nullable disable

namespace RecipeBook.Api.Migrations
{
    [DbContext(typeof(RecipieDbContext))]
    [Migration("20221102090753_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RecipieBook.Api.Models.Recipie", b =>
                {
                    b.Property<int>("RecipieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RecipieId"));

                    b.Property<string>("RecipieDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecipiePhotoName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecipieTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RecipieId");

                    b.ToTable("Recipies");
                });
#pragma warning restore 612, 618
        }
    }
}