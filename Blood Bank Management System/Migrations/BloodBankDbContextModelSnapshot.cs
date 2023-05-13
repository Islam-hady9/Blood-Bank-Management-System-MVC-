﻿// <auto-generated />
using System;
using Blood_Bank_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blood_Bank_Management_System.Migrations
{
    [DbContext(typeof(BloodBankDbContext))]
    partial class BloodBankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Blood_Bank_Management_System.Models.BloodBank", b =>
                {
                    b.Property<int>("BloodBankId")
                        .HasColumnType("int");

                    b.Property<string>("BloodBankEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("BloodBankQuantity")
                        .HasColumnType("real");

                    b.Property<int>("BloodGroup")
                        .HasColumnType("int");

                    b.Property<int>("StatusOfBlood")
                        .HasColumnType("int");

                    b.HasKey("BloodBankId");

                    b.ToTable("BloodBanks");
                });

            modelBuilder.Entity("Blood_Bank_Management_System.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeID")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("EmployeeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeAge")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePhone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("Field")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Blood_Bank_Management_System.Models.Hospital", b =>
                {
                    b.Property<int>("HospitalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospitalId"), 1L, 1);

                    b.Property<DateTime>("DateOfAcception")
                        .HasColumnType("datetime2");

                    b.Property<string>("HospitalEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceivedUnits")
                        .HasColumnType("int");

                    b.HasKey("HospitalId");

                    b.ToTable("Hospitals");
                });
#pragma warning restore 612, 618
        }
    }
}