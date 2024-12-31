using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestaoDeProfissionaisPersistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    TipoDocumentoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_TipoDocumentos_TipoDocumentoID",
                        column: x => x.TipoDocumentoID,
                        principalTable: "TipoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    EspecialidadeID = table.Column<int>(type: "INTEGER", nullable: false),
                    NumDocumento = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataUltimaAlteracao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profissionais_Especialidades_EspecialidadeID",
                        column: x => x.EspecialidadeID,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoDocumentos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "CRM" },
                    { 2, "CRN" },
                    { 3, "CREFITO" },
                    { 4, "CRO" },
                    { 5, "COREN" },
                    { 6, "CRP" },
                    { 7, "CRF" },
                    { 8, "CREF" }
                });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome", "TipoDocumentoID" },
                values: new object[,]
                {
                    { 1, "Cardiologia", 1 },
                    { 2, "Ortopedia", 1 },
                    { 3, "Pediatria", 1 },
                    { 4, "Dermatologia", 1 },
                    { 5, "Ginecologia", 1 },
                    { 6, "Neurologia", 1 },
                    { 7, "Psiquiatria", 1 },
                    { 8, "Anestesiologia", 1 },
                    { 9, "Radiologia", 1 },
                    { 10, "Endocrinologia", 1 },
                    { 11, "Nutricionista Clínico", 2 },
                    { 12, "Nutrição Esportiva", 2 },
                    { 13, "Nutrição Oncológica", 2 },
                    { 14, "Fisioterapia Ortopédica", 3 },
                    { 15, "Fisioterapia Neurológica", 3 },
                    { 16, "Fisioterapia Respiratória", 3 },
                    { 17, "Ortodontia", 4 },
                    { 18, "Implantodontia", 4 },
                    { 19, "Endodontia", 4 },
                    { 20, "Enfermagem Geral", 5 },
                    { 21, "Enfermagem Obstétrica", 5 },
                    { 22, "Psicologia Clínica", 6 },
                    { 23, "Psicologia Organizacional", 6 },
                    { 24, "Neuropsicologia", 6 },
                    { 25, "Farmácia Clínica", 7 },
                    { 26, "Farmácia Hospitalar", 7 },
                    { 27, "Análises Clínicas", 7 },
                    { 28, "Personal Trainer", 8 },
                    { 29, "Preparação Física", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_TipoDocumentoID",
                table: "Especialidades",
                column: "TipoDocumentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_EspecialidadeID",
                table: "Profissionais",
                column: "EspecialidadeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");
        }
    }
}
