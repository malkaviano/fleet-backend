﻿// <auto-generated />
using EFRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFRepository.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200304000405_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFRepository.Entities.VehicleEntity", b =>
                {
                    b.Property<string>("Series");

                    b.Property<long>("Number");

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<byte>("Passengers");

                    b.Property<string>("Type");

                    b.HasKey("Series", "Number");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
