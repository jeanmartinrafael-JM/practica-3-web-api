using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaCitasMedicasJ.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionPacienteCita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paciente",
                table: "Citas");

            migrationBuilder.AddColumn<Guid>(
                name: "Uuid",
                table: "Pacientes",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Citas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "Uuid",
                table: "Citas",
                type: "uuid",
                nullable: false,
                defaultValueSql: "gen_random_uuid()");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteId",
                table: "Citas",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Pacientes_PacienteId",
                table: "Citas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Pacientes_PacienteId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_PacienteId",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Citas");

            migrationBuilder.AddColumn<string>(
                name: "Paciente",
                table: "Citas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
