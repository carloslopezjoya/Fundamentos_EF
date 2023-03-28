using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class ColumnDescripcionCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("060146b9-dce0-4649-a194-b07b9f691815"),
                column: "FechaCreacion",
                value: new DateTime(2023, 3, 28, 16, 14, 19, 918, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("060146b9-dce0-4649-a194-b07b9f691857"),
                column: "FechaCreacion",
                value: new DateTime(2023, 3, 28, 16, 14, 19, 918, DateTimeKind.Local).AddTicks(7999));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("060146b9-dce0-4649-a194-b07b9f691815"),
                column: "FechaCreacion",
                value: new DateTime(2023, 3, 27, 17, 58, 4, 223, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("060146b9-dce0-4649-a194-b07b9f691857"),
                column: "FechaCreacion",
                value: new DateTime(2023, 3, 27, 17, 58, 4, 223, DateTimeKind.Local).AddTicks(7573));
        }
    }
}
