using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Estudos.Migrations
{
    /// <inheritdoc />
    public partial class relashionShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeId",
                table: "Medicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_MedicoId",
                table: "Pacientes",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadeId",
                table: "Medicos",
                column: "EspecialidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadeId",
                table: "Medicos",
                column: "EspecialidadeId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Medicos_MedicoId",
                table: "Pacientes",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadeId",
                table: "Medicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Medicos_MedicoId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_MedicoId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_EspecialidadeId",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "EspecialidadeId",
                table: "Medicos");
        }
    }
}
