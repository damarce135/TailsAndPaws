using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP.Data.Migrations
{
    public partial class UpdateToAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendario",
                columns: table => new
                {
                    IdCalendario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Asunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaCompleto = table.Column<bool>(type: "bit", nullable: true),
                    TemaColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendario", x => x.IdCalendario);
                });

            migrationBuilder.CreateTable(
                name: "Canton",
                columns: table => new
                {
                    IdCanton = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCanton = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canton", x => x.IdCanton);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    IdDistrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDistrito = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.IdDistrito);
                });

            migrationBuilder.CreateTable(
                name: "Donante",
                columns: table => new
                {
                    IdDonante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donante", x => x.IdDonante);
                });

            migrationBuilder.CreateTable(
                name: "GrupoSanguineo",
                columns: table => new
                {
                    IdGsanguineo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGsanguineo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoSanguineo", x => x.IdGsanguineo);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    IdProvincia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProvincia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.IdProvincia);
                });

            migrationBuilder.CreateTable(
                name: "ProdCategoria",
                columns: table => new
                {
                    IdProdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCategoria", x => x.IdProdCategoria);
                    table.ForeignKey(
                        name: "FK_ProdCategoria_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdCategoria_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adoptante",
                columns: table => new
                {
                    IdAdoptante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdProvincia = table.Column<int>(type: "int", nullable: false),
                    IdCanton = table.Column<int>(type: "int", nullable: false),
                    IdDistrito = table.Column<int>(type: "int", nullable: false),
                    DetalleDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptante", x => x.IdAdoptante);
                    table.ForeignKey(
                        name: "FK_Adoptante_Canton_IdCanton",
                        column: x => x.IdCanton,
                        principalTable: "Canton",
                        principalColumn: "IdCanton",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adoptante_Distrito_IdDistrito",
                        column: x => x.IdDistrito,
                        principalTable: "Distrito",
                        principalColumn: "IdDistrito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adoptante_Provincia_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincia",
                        principalColumn: "IdProvincia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizacion",
                columns: table => new
                {
                    IdOrganizacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProvincia = table.Column<int>(type: "int", nullable: false),
                    IdCanton = table.Column<int>(type: "int", nullable: false),
                    IdDistrito = table.Column<int>(type: "int", nullable: false),
                    DetalleDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizacion", x => x.IdOrganizacion);
                    table.ForeignKey(
                        name: "FK_Organizacion_Canton_IdCanton",
                        column: x => x.IdCanton,
                        principalTable: "Canton",
                        principalColumn: "IdCanton",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizacion_Distrito_IdDistrito",
                        column: x => x.IdDistrito,
                        principalTable: "Distrito",
                        principalColumn: "IdDistrito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organizacion_Provincia_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincia",
                        principalColumn: "IdProvincia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Castrado = table.Column<bool>(type: "bit", nullable: false),
                    Edad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizacion = table.Column<int>(type: "int", nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adoptado = table.Column<bool>(type: "bit", nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.IdAnimal);
                    
                    table.ForeignKey(
                        name: "FK_Animal_Organizacion_IdOrganizacion",
                        column: x => x.IdOrganizacion,
                        principalTable: "Organizacion",
                        principalColumn: "IdOrganizacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdProveedor",
                columns: table => new
                {
                    IdProdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdOrganizacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdProveedor", x => x.IdProdProveedor);
                    table.ForeignKey(
                        name: "FK_ProdProveedor_Organizacion_IdOrganizacion",
                        column: x => x.IdOrganizacion,
                        principalTable: "Organizacion",
                        principalColumn: "IdOrganizacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdProveedor_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adopcion",
                columns: table => new
                {
                    IdAdopcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAnimal = table.Column<int>(type: "int", nullable: false),
                    IdAdoptante = table.Column<int>(type: "int", nullable: false),
                    FechaAdopcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSeguimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopcion", x => x.IdAdopcion);
                    table.ForeignKey(
                        name: "FK_Adopcion_Adoptante_IdAdoptante",
                        column: x => x.IdAdoptante,
                        principalTable: "Adoptante",
                        principalColumn: "IdAdoptante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adopcion_Animal_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "Animal",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adopcion_IdAdoptante",
                table: "Adopcion",
                column: "IdAdoptante");

            migrationBuilder.CreateIndex(
                name: "IX_Adopcion_IdAnimal",
                table: "Adopcion",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptante_IdCanton",
                table: "Adoptante",
                column: "IdCanton");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptante_IdDistrito",
                table: "Adoptante",
                column: "IdDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_Adoptante_IdProvincia",
                table: "Adoptante",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_GrupoSanguineoIdGsanguineo",
                table: "Animal",
                column: "GrupoSanguineoIdGsanguineo");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_IdOrganizacion",
                table: "Animal",
                column: "IdOrganizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Organizacion_IdCanton",
                table: "Organizacion",
                column: "IdCanton");

            migrationBuilder.CreateIndex(
                name: "IX_Organizacion_IdDistrito",
                table: "Organizacion",
                column: "IdDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_Organizacion_IdProvincia",
                table: "Organizacion",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCategoria_IdCategoria",
                table: "ProdCategoria",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ProdCategoria_IdProducto",
                table: "ProdCategoria",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProveedor_IdOrganizacion",
                table: "ProdProveedor",
                column: "IdOrganizacion");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProveedor_IdProducto",
                table: "ProdProveedor",
                column: "IdProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adopcion");

            migrationBuilder.DropTable(
                name: "Calendario");

            migrationBuilder.DropTable(
                name: "Donante");

            migrationBuilder.DropTable(
                name: "ProdCategoria");

            migrationBuilder.DropTable(
                name: "ProdProveedor");

            migrationBuilder.DropTable(
                name: "Adoptante");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "GrupoSanguineo");

            migrationBuilder.DropTable(
                name: "Organizacion");

            migrationBuilder.DropTable(
                name: "Canton");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
