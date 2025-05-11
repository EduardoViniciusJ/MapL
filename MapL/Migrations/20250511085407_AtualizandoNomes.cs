using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapL.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoNomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comos");

            migrationBuilder.DropTable(
                name: "Oques");

            migrationBuilder.DropTable(
                name: "Porques");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto");

            migrationBuilder.RenameTable(
                name: "Projeto",
                newName: "Projetos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Conhecimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conceito = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fato = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Procedimento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conhecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conhecimentos_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estrategias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estrategias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estrategias_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motivacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motivacoes_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conhecimentos_ProjetoId",
                table: "Conhecimentos",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estrategias_ProjetoId",
                table: "Estrategias",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Motivacoes_ProjetoId",
                table: "Motivacoes",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conhecimentos");

            migrationBuilder.DropTable(
                name: "Estrategias");

            migrationBuilder.DropTable(
                name: "Motivacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos");

            migrationBuilder.RenameTable(
                name: "Projetos",
                newName: "Projeto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projeto",
                table: "Projeto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Comos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comos_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    Conceito = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fato = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Procedimento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oques_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Porques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porques_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comos_ProjetoId",
                table: "Comos",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Oques_ProjetoId",
                table: "Oques",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Porques_ProjetoId",
                table: "Porques",
                column: "ProjetoId");
        }
    }
}
