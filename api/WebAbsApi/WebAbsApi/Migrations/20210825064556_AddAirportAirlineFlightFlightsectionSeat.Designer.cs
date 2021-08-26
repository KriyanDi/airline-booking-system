﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAbsApi.Data;

namespace WebAbsApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210825064556_AddAirportAirlineFlightFlightsectionSeat")]
    partial class AddAirportAirlineFlightFlightsectionSeat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAbsApi.Data.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Airlines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "DELTA"
                        },
                        new
                        {
                            Id = 2,
                            Name = "SSSKY"
                        },
                        new
                        {
                            Id = 3,
                            Name = "FLYSS"
                        },
                        new
                        {
                            Id = 4,
                            Name = "ARB"
                        },
                        new
                        {
                            Id = 5,
                            Name = "WIZZ"
                        });
                });

            modelBuilder.Entity("WebAbsApi.Data.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Airports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AAY"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ABA"
                        },
                        new
                        {
                            Id = 3,
                            Name = "MAC"
                        },
                        new
                        {
                            Id = 4,
                            Name = "FSD"
                        },
                        new
                        {
                            Id = 5,
                            Name = "ZAG"
                        });
                });

            modelBuilder.Entity("WebAbsApi.Data.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirlineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirlineId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("FlightNumber")
                        .IsUnique()
                        .HasFilter("[FlightNumber] IS NOT NULL");

                    b.HasIndex("OriginId");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AirlineId = 2,
                            Date = new DateTime(2021, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 5,
                            FlightNumber = "111111111",
                            OriginId = 1
                        },
                        new
                        {
                            Id = 2,
                            AirlineId = 2,
                            Date = new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DestinationId = 1,
                            FlightNumber = "211111111",
                            OriginId = 5
                        });
                });

            modelBuilder.Entity("WebAbsApi.Data.FlightSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<string>("SeatClass")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FlightId", "SeatClass")
                        .IsUnique()
                        .HasFilter("[SeatClass] IS NOT NULL");

                    b.ToTable("FlightSections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FlightId = 1,
                            SeatClass = "FIRST"
                        },
                        new
                        {
                            Id = 2,
                            FlightId = 1,
                            SeatClass = "ECONOMY"
                        },
                        new
                        {
                            Id = 3,
                            FlightId = 2,
                            SeatClass = "BUSINESS"
                        });
                });

            modelBuilder.Entity("WebAbsApi.Data.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Column")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FlightSectionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<string>("Row")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FlightSectionId", "Row", "Column")
                        .IsUnique()
                        .HasFilter("[Row] IS NOT NULL AND [Column] IS NOT NULL");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            Id = 8226,
                            Column = "A",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "0"
                        },
                        new
                        {
                            Id = 1486,
                            Column = "B",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "0"
                        },
                        new
                        {
                            Id = 7435,
                            Column = "C",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "0"
                        },
                        new
                        {
                            Id = 9754,
                            Column = "D",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "0"
                        },
                        new
                        {
                            Id = 3520,
                            Column = "A",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "1"
                        },
                        new
                        {
                            Id = 1213,
                            Column = "B",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "1"
                        },
                        new
                        {
                            Id = 6424,
                            Column = "C",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "1"
                        },
                        new
                        {
                            Id = 6108,
                            Column = "D",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "1"
                        },
                        new
                        {
                            Id = 1458,
                            Column = "A",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "2"
                        },
                        new
                        {
                            Id = 244,
                            Column = "B",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "2"
                        },
                        new
                        {
                            Id = 2292,
                            Column = "C",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "2"
                        },
                        new
                        {
                            Id = 7536,
                            Column = "D",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "2"
                        },
                        new
                        {
                            Id = 1140,
                            Column = "A",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "3"
                        },
                        new
                        {
                            Id = 406,
                            Column = "B",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "3"
                        },
                        new
                        {
                            Id = 226,
                            Column = "C",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "3"
                        },
                        new
                        {
                            Id = 4871,
                            Column = "D",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "3"
                        },
                        new
                        {
                            Id = 1569,
                            Column = "A",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "4"
                        },
                        new
                        {
                            Id = 3786,
                            Column = "B",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "4"
                        },
                        new
                        {
                            Id = 3512,
                            Column = "C",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "4"
                        },
                        new
                        {
                            Id = 3972,
                            Column = "D",
                            FlightSectionId = 1,
                            IsBooked = false,
                            Row = "4"
                        });
                });

            modelBuilder.Entity("WebAbsApi.Data.Flight", b =>
                {
                    b.HasOne("WebAbsApi.Data.Airline", "Airline")
                        .WithMany("Flights")
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAbsApi.Data.Airport", "DestinationAirport")
                        .WithMany("DestinationToFlights")
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("WebAbsApi.Data.Airport", "OriginAirport")
                        .WithMany("OriginToFlights")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Airline");

                    b.Navigation("DestinationAirport");

                    b.Navigation("OriginAirport");
                });

            modelBuilder.Entity("WebAbsApi.Data.FlightSection", b =>
                {
                    b.HasOne("WebAbsApi.Data.Flight", "Flight")
                        .WithMany("FlightSections")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("WebAbsApi.Data.Seat", b =>
                {
                    b.HasOne("WebAbsApi.Data.FlightSection", "FlightSection")
                        .WithMany("Seats")
                        .HasForeignKey("FlightSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightSection");
                });

            modelBuilder.Entity("WebAbsApi.Data.Airline", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("WebAbsApi.Data.Airport", b =>
                {
                    b.Navigation("DestinationToFlights");

                    b.Navigation("OriginToFlights");
                });

            modelBuilder.Entity("WebAbsApi.Data.Flight", b =>
                {
                    b.Navigation("FlightSections");
                });

            modelBuilder.Entity("WebAbsApi.Data.FlightSection", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}