using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class initialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pendiente",
                table: "Tarea",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("060146b9-dce0-4649-a194-b07b9f691862"), null, "Actividades pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("060146b9-dce0-4649-a194-b07b9f691865"), null, "Actividades personales", 50 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "FechaCreacion", "Pendiente", "Prioridad", "Titulo" },
                values: new object[] { new Guid("060146b9-dce0-4649-a194-b07b9f691815"), new Guid("060146b9-dce0-4649-a194-b07b9f691862"), new DateTime(2023, 3, 27, 17, 58, 4, 223, DateTimeKind.Local).AddTicks(7561), null, 0, "Terminar de ver series" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "FechaCreacion", "Pendiente", "Prioridad", "Titulo" },
                values: new object[] { new Guid("060146b9-dce0-4649-a194-b07b9f691857"), new Guid("060146b9-dce0-4649-a194-b07b9f691865"), new DateTime(2023, 3, 27, 17, 58, 4, 223, DateTimeKind.Local).AddTicks(7573), null, 1, "Pago de servicios publicos" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("060146b9-dce0-4649-a194-b07b9f691815"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("060146b9-dce0-4649-a194-b07b9f691857"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("060146b9-dce0-4649-a194-b07b9f691862"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("060146b9-dce0-4649-a194-b07b9f691865"));

            migrationBuilder.AlterColumn<string>(
                name: "Pendiente",
                table: "Tarea",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "varchar",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);
        }
    }
}
