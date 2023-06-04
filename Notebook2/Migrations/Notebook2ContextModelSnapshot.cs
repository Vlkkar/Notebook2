﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notebook2.Data;

#nullable disable

namespace Notebook2.Migrations
{
    [DbContext(typeof(Notebook2Context))]
    partial class Notebook2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Notebook2.ViewModel.NoteBook", b =>
                {
                    b.Property<int>("idnote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idnote"), 1L, 1);

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("iduser")
                        .HasColumnType("int");

                    b.Property<string>("note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idnote");

                    b.ToTable("NoteBook");
                });
#pragma warning restore 612, 618
        }
    }
}