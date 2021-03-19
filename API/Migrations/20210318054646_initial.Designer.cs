﻿// <auto-generated />
using System;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DoorManagementDbContext))]
    [Migration("20210318054646_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Models.Door", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd86765f-450d-4a02-941b-8155c17cf3ac"),
                            IsLocked = false,
                            IsOpen = false,
                            Label = "Living Room Door"
                        },
                        new
                        {
                            Id = new Guid("7e2086e3-68d8-4451-8ca4-420f1f902d64"),
                            IsLocked = true,
                            IsOpen = false,
                            Label = "Kitchen Room Door"
                        },
                        new
                        {
                            Id = new Guid("a166ac36-5a98-417e-88e8-81143227e35b"),
                            IsLocked = false,
                            IsOpen = true,
                            Label = "BedRoom Door"
                        },
                        new
                        {
                            Id = new Guid("de3b0009-4f80-4415-89bd-b2194bb2bbc0"),
                            IsLocked = false,
                            IsOpen = true,
                            Label = "Terrace Door"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
