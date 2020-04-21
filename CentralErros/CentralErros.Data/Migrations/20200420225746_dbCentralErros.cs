using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralErros.Data.Migrations
{
    public partial class dbCentralErros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    Nivel = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aviso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    Data = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IdTipoLog = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aviso_TipoLog_IdTipoLog",
                        column: x => x.IdTipoLog,
                        principalTable: "TipoLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAplicacao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    Data = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IdTipoLog = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => new { x.Id, x.IdAplicacao });
                    table.ForeignKey(
                        name: "FK_Log_Aplicacao_IdAplicacao",
                        column: x => x.IdAplicacao,
                        principalTable: "Aplicacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Log_TipoLog_IdTipoLog",
                        column: x => x.IdTipoLog,
                        principalTable: "TipoLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioAplicacao",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false),
                    IdAplicacao = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAplicacao", x => new { x.IdUsuario, x.IdAplicacao });
                    table.ForeignKey(
                        name: "FK_UsuarioAplicacao_Aplicacao_IdAplicacao",
                        column: x => x.IdAplicacao,
                        principalTable: "Aplicacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioAplicacao_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioAviso",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false),
                    IdAviso = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioAviso", x => new { x.IdUsuario, x.IdAviso });
                    table.ForeignKey(
                        name: "FK_UsuarioAviso_Aviso_IdAviso",
                        column: x => x.IdAviso,
                        principalTable: "Aviso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioAviso_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aviso_IdTipoLog",
                table: "Aviso",
                column: "IdTipoLog");

            migrationBuilder.CreateIndex(
                name: "IX_Log_IdAplicacao",
                table: "Log",
                column: "IdAplicacao");

            migrationBuilder.CreateIndex(
                name: "IX_Log_IdTipoLog",
                table: "Log",
                column: "IdTipoLog");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioAplicacao_IdAplicacao",
                table: "UsuarioAplicacao",
                column: "IdAplicacao");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioAviso_IdAviso",
                table: "UsuarioAviso",
                column: "IdAviso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "UsuarioAplicacao");

            migrationBuilder.DropTable(
                name: "UsuarioAviso");

            migrationBuilder.DropTable(
                name: "Aplicacao");

            migrationBuilder.DropTable(
                name: "Aviso");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoLog");
        }
    }
}
