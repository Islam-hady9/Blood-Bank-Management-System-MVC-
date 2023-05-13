using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blood_Bank_Management_System.Migrations
{
    public partial class BloodBankM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
<<<<<<<< HEAD:Blood Bank Management System/Migrations/20230513225049_BloodBankM.cs
                name: "BloodBanks",
                columns: table => new
                {
                    BloodBankId = table.Column<int>(type: "int", nullable: false),
                    BloodBankEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<int>(type: "int", nullable: false),
                    BloodBankQuantity = table.Column<float>(type: "real", nullable: false),
                    StatusOfBlood = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBanks", x => x.BloodBankId);
========
                name: "Donors",
                columns: table => new
                {
                    DonorID = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DonorAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorAge = table.Column<int>(type: "int", nullable: false),
                    DonorGender = table.Column<int>(type: "int", nullable: false),
                    DonorBloodType = table.Column<int>(type: "int", nullable: false),
                    LastDonationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.DonorID);
>>>>>>>> 281406d162702d2949f6cc750904d7bbfb7de730:Blood Bank Management System/Migrations/20230513101117_IntialCreate.cs
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeAge = table.Column<int>(type: "int", nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeePhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Field = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HospitalPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedUnits = table.Column<int>(type: "int", nullable: false),
                    DateOfAcception = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.HospitalId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
<<<<<<<< HEAD:Blood Bank Management System/Migrations/20230513225049_BloodBankM.cs
                name: "BloodBanks");
========
                name: "Donors");
>>>>>>>> 281406d162702d2949f6cc750904d7bbfb7de730:Blood Bank Management System/Migrations/20230513101117_IntialCreate.cs

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
