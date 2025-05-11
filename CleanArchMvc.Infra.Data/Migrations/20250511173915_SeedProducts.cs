using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    
    public partial class SeedProducts : Migration
    {
       
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Products(name,description,price,stock,image,categoryId)" 
                + "values('notebook','spiral notebook', 7.45,50, 'notebook1.jpg',1)");

            mb.Sql("insert into Products(name,description,price,stock,image,categoryId)"
                + "values('Eraser','circular eraser', 1.50,70, 'eraser1.jpg',1)");

            mb.Sql("insert into Products(name,description,price,stock,image,categoryId)"
                + "values('pen','blue pen', 2.00,10, 'pen1.jpg',1)");

            mb.Sql("insert into Products(name,description,price,stock,image,categoryId)"
                + "values('ruler','30com ruler', 3.50,45, 'ruler1.jpg',1)");
        }

        
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from products");
        }
    }
}
