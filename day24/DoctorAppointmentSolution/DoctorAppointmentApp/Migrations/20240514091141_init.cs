using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAppointmentApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<float>(type: "real", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "Available", "DoctorName", "Experience", "Specialization" },
                values: new object[,]
                {
                    { 101, true, "Ramu", 5.5f, "Heart" },
                    { 102, true, "Samu", 8.5f, "Skin" },
                    { 103, true, "Kamu", 2f, "Eye" },
                    { 104, true, "Tamu", 7f, "Heart" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
