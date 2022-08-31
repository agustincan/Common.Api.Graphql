using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Common.Api.Graphql.Migrations
{
    public partial class iniciodatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreventiveActions_Description",
                table: "PreventiveActions");

            migrationBuilder.DropIndex(
                name: "IX_CorrectiveActions_Description",
                table: "CorrectiveActions");

            migrationBuilder.InsertData(
                table: "CorrectiveActions",
                columns: new[] { "Id", "Active", "Description" },
                values: new object[,]
                {
                    { 1, true, "Reja Especial" },
                    { 2, true, "Reposición" },
                    { 3, true, "Sin faltante en la red pluvial" },
                    { 4, true, "Obra" }
                });

            migrationBuilder.InsertData(
                table: "PreventiveActions",
                columns: new[] { "Id", "Active", "Description" },
                values: new object[,]
                {
                    { 1, true, "Reporte" },
                    { 2, true, "Tapa Cemento" },
                    { 3, true, "Aviso" },
                    { 4, true, "Sin Peligro" },
                    { 5, true, "Peligroso" },
                    { 6, true, "Sin Faltante" },
                    { 7, true, "Tacos" },
                    { 8, true, "Limpieza" },
                    { 9, true, "No Existe Sumidero" },
                    { 10, true, "Reposición" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreventiveActions_Description",
                table: "PreventiveActions",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActions_Description",
                table: "CorrectiveActions",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreventiveActions_Description",
                table: "PreventiveActions");

            migrationBuilder.DropIndex(
                name: "IX_CorrectiveActions_Description",
                table: "CorrectiveActions");

            migrationBuilder.DeleteData(
                table: "CorrectiveActions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CorrectiveActions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CorrectiveActions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CorrectiveActions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PreventiveActions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PreventiveActions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PreventiveActions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PreventiveActions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PreventiveActions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PreventiveActions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PreventiveActions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PreventiveActions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PreventiveActions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PreventiveActions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.CreateIndex(
                name: "IX_PreventiveActions_Description",
                table: "PreventiveActions",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActions_Description",
                table: "CorrectiveActions",
                column: "Description");
        }
    }
}
