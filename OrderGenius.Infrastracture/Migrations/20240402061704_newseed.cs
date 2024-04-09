using Microsoft.EntityFrameworkCore.Migrations;
using OrderGenius.Core.Entities.OrderAggregate;
using OrderGenius.Core.Entities.ProductAggregate;
using OrderGenius.Infrastracture.Data;
using OrderGenius.Infrastracture.SeedData;
using System.Text.Json;

#nullable disable

namespace OrderGenius.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class newseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var codeConfigData = File.ReadAllText("../OrderGenius.Infrastracture/SeedData/Products.json");
            var codeConfig = JsonSerializer.Deserialize<List<Product>>(codeConfigData);
            foreach (var item in codeConfig)
            {

               migrationBuilder.InsertData(
               table: "Products",
               columns: new[] { "Name", "Description", "Price", "PictureUrl" },
               values: new object[] { item.Name, item.Description, item.UnitPrice, item.PictureUrl });
            }

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }

    }
}
