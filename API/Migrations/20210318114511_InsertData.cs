using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("7e2086e3-68d8-4451-8ca4-420f1f902d64"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("a166ac36-5a98-417e-88e8-81143227e35b"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("cd86765f-450d-4a02-941b-8155c17cf3ac"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("de3b0009-4f80-4415-89bd-b2194bb2bbc0"));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("1bf57c7c-2c56-4428-817c-68389371ae91"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("4ac81f1c-9a70-45fb-92a2-2ffcfdd02de3"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("9ef73387-bc4f-4783-857e-fae378082161"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("d0d68548-2542-4569-a23e-8b7e0bcb780c"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("ea4a8758-a8c3-408d-8167-f0983ec13916"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("f7733007-aca8-4ad5-9fec-bd273ce284ab"));

            migrationBuilder.InsertData(
                table: "Doors",
                columns: new[] { "Id", "IsLocked", "IsOpen", "Label" },
                values: new object[,]
                {
                    { new Guid("cd86765f-450d-4a02-941b-8155c17cf3ac"), false, false, "Living Room Door" },
                    { new Guid("7e2086e3-68d8-4451-8ca4-420f1f902d64"), true, false, "Kitchen Room Door" },
                    { new Guid("a166ac36-5a98-417e-88e8-81143227e35b"), false, true, "BedRoom Door" },
                    { new Guid("de3b0009-4f80-4415-89bd-b2194bb2bbc0"), false, true, "Terrace Door" }
                });
        }
    }
}
