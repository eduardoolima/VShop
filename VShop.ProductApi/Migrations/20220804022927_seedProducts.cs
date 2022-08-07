using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    public partial class seedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId)" +
                "Values('Caderno', 7.55, 'Caderno 10 matérias', 10, 'caderno1.jpg', 1)");
            migrationBuilder.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId)" +
                "Values('Lápis', 3.45, 'Lápis Preto', 10, 'Lápis.jpg', 1)");
            migrationBuilder.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId)" +
                "Values('Luz RGB', 5.33, 'Luz RGB', 10, 'rgb1.jpg', 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Products");
        }
    }
}
