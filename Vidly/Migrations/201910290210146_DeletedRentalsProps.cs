namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedRentalsProps : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropPrimaryKey("dbo.Rentals");
            AlterColumn("dbo.Rentals", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Rentals", "Id");
            DropColumn("dbo.Rentals", "DateAdded");
            DropColumn("dbo.Rentals", "DateReturned");
            DropColumn("dbo.Rentals", "Customer_Id");
            DropColumn("dbo.Rentals", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Byte(nullable: false));
            AddColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            AddColumn("dbo.Rentals", "DateAdded", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.Rentals");
            AlterColumn("dbo.Rentals", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Rentals", "Id");
            CreateIndex("dbo.Rentals", "Movie_Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
