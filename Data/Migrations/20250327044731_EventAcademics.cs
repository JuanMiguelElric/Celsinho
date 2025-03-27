using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sbelt.Data.Migrations
{
    public partial class EventAcademics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Criação da tabela EventAcademics com a coluna de identidade correta
            migrationBuilder.CreateTable(
                name: "EventAcademics",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Definido como coluna de identidade (não nulo e tipo inteiro)
                    Nome = table.Column<string>(maxLength: 256, nullable: false), // Nome como string
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_EventAcademics", x => x.ID);
                });

            // Criação da tabela Matricula com a coluna de identidade corrigida
            migrationBuilder.CreateTable(
                name: "Matricula", // Corrigido o nome da tabela de "Matriculas" para "Matricula"
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),  // Definido como coluna de identidade (não nulo e tipo inteiro)
                    UserId = table.Column<string>(nullable: false),  // Alterado para string para ser compatível com AspNetUsers.Id
                    EventAcademics_Id = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Matricula", x => x.ID); // Definindo a chave primária para "ID" na tabela Matricula
                    table.ForeignKey(
                        name: "Fk_Matricula_AspNetUsers",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id", // AspNetUsers.Id é string, então UserId precisa ser string também
                        onDelete: ReferentialAction.Cascade);
                });

            // Renomeando coluna de id para 'Id' corretamente
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Matricula",
                newName: "Id");

            // Adicionando a coluna 'Discriminator' para a tabela AspNetUsers
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            // Criação da tabela Certificado
            migrationBuilder.CreateTable(
                name: "Certificado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(nullable: true),
                    Conclusao = table.Column<float>(nullable: true),
                    MatriculaId = table.Column<int>(nullable: false)  // MatriculaId como chave estrangeira
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificado_Matricula_MatriculaId", // Definindo a chave estrangeira
                        column: x => x.MatriculaId,
                        principalTable: "Matricula",  // Referência à tabela 'Matricula'
                        principalColumn: "Id", // A coluna 'Id' de 'Matricula' será referenciada
                        onDelete: ReferentialAction.Cascade); // Definindo o comportamento de exclusão
                });

            // Criação dos índices para as tabelas Matricula e Certificado
            migrationBuilder.CreateIndex(
                name: "IX_Matricula_UserId",
                table: "Matricula",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_MatriculaId",
                table: "Certificado",
                column: "MatriculaId");

            // Adicionando a chave estrangeira para UserId na tabela Matricula
            migrationBuilder.AddForeignKey(
                name: "FK_Matricula_AspNetUsers_UserId",
                table: "Matricula",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Desfazendo as mudanças feitas na migração Up
            migrationBuilder.DropForeignKey(
                name: "FK_Matricula_AspNetUsers_UserId",
                table: "Matricula");

            migrationBuilder.DropTable(
                name: "Certificado");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_UserId",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Matricula");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Matricula",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "eventacademicsid",
                table: "Matricula",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
