﻿// <auto-generated />
using System;
using EntryControl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntryControl.Migrations
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

            modelBuilder.Entity("EntryControl.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<int>("GateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EntryControl.Models.Gate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GateId")
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Gates", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lab",
                            GateId = 1050,
                            Name = 2
                        },
                        new
                        {
                            Id = 2,
                            Description = "Warehouse",
                            GateId = 2030,
                            Name = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Office",
                            GateId = 2041,
                            Name = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Central",
                            GateId = 1045,
                            Name = 1
                        });
                });

            modelBuilder.Entity("EntryControl.Models.GateAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorizationType")
                        .HasColumnType("int");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<int>("GateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GateAccess", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorizationType = 0,
                            EventType = 0,
                            GateId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorizationType = 0,
                            EventType = 0,
                            GateId = 2
                        },
                        new
                        {
                            Id = 3,
                            AuthorizationType = 0,
                            EventType = 0,
                            GateId = 3
                        },
                        new
                        {
                            Id = 4,
                            AuthorizationType = 0,
                            EventType = 0,
                            GateId = 4
                        },
                        new
                        {
                            Id = 5,
                            AuthorizationType = 1,
                            EventType = 0,
                            GateId = 1
                        },
                        new
                        {
                            Id = 6,
                            AuthorizationType = 1,
                            EventType = 0,
                            GateId = 2
                        },
                        new
                        {
                            Id = 7,
                            AuthorizationType = 1,
                            EventType = 0,
                            GateId = 3
                        },
                        new
                        {
                            Id = 8,
                            AuthorizationType = 1,
                            EventType = 1,
                            GateId = 4
                        },
                        new
                        {
                            Id = 9,
                            AuthorizationType = 2,
                            EventType = 0,
                            GateId = 1
                        },
                        new
                        {
                            Id = 10,
                            AuthorizationType = 2,
                            EventType = 1,
                            GateId = 2
                        },
                        new
                        {
                            Id = 11,
                            AuthorizationType = 2,
                            EventType = 0,
                            GateId = 3
                        },
                        new
                        {
                            Id = 12,
                            AuthorizationType = 2,
                            EventType = 0,
                            GateId = 4
                        },
                        new
                        {
                            Id = 13,
                            AuthorizationType = 3,
                            EventType = 1,
                            GateId = 1
                        },
                        new
                        {
                            Id = 14,
                            AuthorizationType = 3,
                            EventType = 1,
                            GateId = 2
                        },
                        new
                        {
                            Id = 15,
                            AuthorizationType = 3,
                            EventType = 0,
                            GateId = 3
                        },
                        new
                        {
                            Id = 16,
                            AuthorizationType = 3,
                            EventType = 0,
                            GateId = 4
                        });
                });

            modelBuilder.Entity("EntryControl.Models.ReportEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorizationLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EvenTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReportEvents");
                });

            modelBuilder.Entity("EntryControl.Models.ReportWorkHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("WorkSeconds")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ReportWorkHours");
                });

            modelBuilder.Entity("EntryControl.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorizationLevel")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Workers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorizationLevel = 0,
                            Name = "Carson",
                            Surname = "Alexander",
                            WorkerId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorizationLevel = 2,
                            Name = "Meredith",
                            Surname = "Alonso",
                            WorkerId = 2
                        },
                        new
                        {
                            Id = 3,
                            AuthorizationLevel = 1,
                            Name = "Arturo",
                            Surname = "Anand",
                            WorkerId = 3
                        },
                        new
                        {
                            Id = 4,
                            AuthorizationLevel = 3,
                            Name = "Gytis",
                            Surname = "Barzdukas",
                            WorkerId = 4
                        },
                        new
                        {
                            Id = 5,
                            AuthorizationLevel = 2,
                            Name = "Yan",
                            Surname = "Li",
                            WorkerId = 5
                        },
                        new
                        {
                            Id = 6,
                            AuthorizationLevel = 3,
                            Name = "Peggy",
                            Surname = "Justice",
                            WorkerId = 6
                        },
                        new
                        {
                            Id = 7,
                            AuthorizationLevel = 3,
                            Name = "Laura",
                            Surname = "Norman",
                            WorkerId = 7
                        },
                        new
                        {
                            Id = 8,
                            AuthorizationLevel = 3,
                            Name = "Nino",
                            Surname = "Rustin",
                            WorkerId = 8
                        },
                        new
                        {
                            Id = 9,
                            AuthorizationLevel = 3,
                            Name = "Jonas",
                            Surname = "Petraitis",
                            WorkerId = 9
                        },
                        new
                        {
                            Id = 10,
                            AuthorizationLevel = 3,
                            Name = "Simonas",
                            Surname = "Galinis",
                            WorkerId = 10
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
