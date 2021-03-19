using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Insert2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("2a2be9c1-6545-488a-95f4-bead5de83b8f"), false, false, "Maintenance facilities" },
                    { new Guid("bb73aa08-221f-4f48-8bc7-fcadaf79eb83"), true, false, "Warehouse Door" },
                    { new Guid("a1e78914-f5ef-41c6-982a-d1bbedff8f4c"), false, true, "Corridors" },
                    { new Guid("d67a2438-3a5f-47db-a375-f60ccb766645"), false, true, "Terrace Door" },
                    { new Guid("d7b1354d-eb8e-44d6-ae3e-8fe983bd8ddd"), false, true, "Washing Area" },
                    { new Guid("c028e9df-7623-4866-8087-1ff810208e34"), false, true, "Emergency Door" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("2a2be9c1-6545-488a-95f4-bead5de83b8f"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("a1e78914-f5ef-41c6-982a-d1bbedff8f4c"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("bb73aa08-221f-4f48-8bc7-fcadaf79eb83"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("c028e9df-7623-4866-8087-1ff810208e34"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("d67a2438-3a5f-47db-a375-f60ccb766645"));

            migrationBuilder.DeleteData(
                table: "Doors",
                keyColumn: "Id",
                keyValue: new Guid("d7b1354d-eb8e-44d6-ae3e-8fe983bd8ddd"));

            migrationBuilder.InsertData(
                table: "Doors",
                columns: new[] { "Id", "IsLocked", "IsOpen", "Label" },
                values: new object[,]
                {
                    { new Guid("ea4a8758-a8c3-408d-8167-f0983ec13916"), false, false, "Maintenance facilities" },
                    { new Guid("1bf57c7c-2c56-4428-817c-68389371ae91"), true, false, "Warehouse Door" },
                    { new Guid("9ef73387-bc4f-4783-857e-fae378082161"), false, true, "Corridors" },
                    { new Guid("d0d68548-2542-4569-a23e-8b7e0bcb780c"), false, true, "Terrace Door" },
                    { new Guid("f7733007-aca8-4ad5-9fec-bd273ce284ab"), false, true, "Washing Area" },
                    { new Guid("4ac81f1c-9a70-45fb-92a2-2ffcfdd02de3"), false, true, "Emergency Door" }
                });
        }
    }
}
