﻿// <auto-generated />
using System;
using BuildingRegistry.Projections.Extract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuildingRegistry.Projections.Extract.Migrations
{
    [DbContext(typeof(ExtractContext))]
    partial class ExtractContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Be.Vlaanderen.Basisregisters.ProjectionHandling.Runner.ProjectionStates.ProjectionStateItem", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DesiredState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DesiredStateChangedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Position")
                        .HasColumnType("bigint");

                    b.HasKey("Name")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("ProjectionStates","BuildingRegistryExtract");
                });

            modelBuilder.Entity("BuildingRegistry.Projections.Extract.BuildingExtract.BuildingExtractItem", b =>
                {
                    b.Property<Guid>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("DbaseRecord")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<double>("MaximumX")
                        .HasColumnType("float");

                    b.Property<double>("MaximumY")
                        .HasColumnType("float");

                    b.Property<double>("MinimumX")
                        .HasColumnType("float");

                    b.Property<double>("MinimumY")
                        .HasColumnType("float");

                    b.Property<int?>("PersistentLocalId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ShapeRecordContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ShapeRecordContentLength")
                        .HasColumnType("int");

                    b.HasKey("BuildingId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("PersistentLocalId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Building","BuildingRegistryExtract");
                });

            modelBuilder.Entity("BuildingRegistry.Projections.Extract.BuildingUnitExtract.BuildingUnitBuildingItem", b =>
                {
                    b.Property<Guid>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("BuildingPersistentLocalId")
                        .HasColumnType("int");

                    b.Property<int?>("BuildingRetiredStatus")
                        .HasColumnType("int");

                    b.Property<bool?>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.HasKey("BuildingId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("BuildingPersistentLocalId");

                    b.ToTable("BuildingUnit_Buildings","BuildingRegistryExtract");
                });

            modelBuilder.Entity("BuildingRegistry.Projections.Extract.BuildingUnitExtract.BuildingUnitExtractItem", b =>
                {
                    b.Property<Guid>("BuildingUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("DbaseRecord")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsBuildingComplete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<double>("MaximumX")
                        .HasColumnType("float");

                    b.Property<double>("MaximumY")
                        .HasColumnType("float");

                    b.Property<double>("MinimumX")
                        .HasColumnType("float");

                    b.Property<double>("MinimumY")
                        .HasColumnType("float");

                    b.Property<int?>("PersistentLocalId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ShapeRecordContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ShapeRecordContentLength")
                        .HasColumnType("int");

                    b.HasKey("BuildingUnitId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("BuildingId");

                    b.HasIndex("PersistentLocalId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("IsComplete", "IsBuildingComplete");

                    b.ToTable("BuildingUnit","BuildingRegistryExtract");
                });
#pragma warning restore 612, 618
        }
    }
}
