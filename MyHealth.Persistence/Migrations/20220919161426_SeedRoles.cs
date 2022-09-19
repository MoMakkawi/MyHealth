using Microsoft.EntityFrameworkCore.Migrations;

using MyHealth.Domain.Helpers;

#nullable disable

namespace MyHealth.Persistence.Migrations;

public partial class SeedRoles : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
            values: new object[] { Role.AdminId, Role.Admin, Role.Admin.ToUpper(), Role.AdminConcurrencyStamp });

        migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Role.DoctorId, Role.Doctor, Role.Doctor.ToUpper(), Role.DoctorConcurrencyStamp });
       
        migrationBuilder.InsertData(
           table: "AspNetRoles",
           columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
           values: new object[] { Role.PatientId , Role.Patient, Role.Patient.ToUpper(), Role.PatientConcurrencyStamp });
      
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DELETE FROM [AspNetRoles]");
    }
}
