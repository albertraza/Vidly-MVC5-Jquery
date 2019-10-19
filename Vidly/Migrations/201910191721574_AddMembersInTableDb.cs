namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembersInTableDb : DbMigration
    {
        public override void Up()
        {
            Sql("insert into GenreTypes (Name) values ('Comedy')");
            Sql("insert into GenreTypes (Name) values ('Action')");
            Sql("insert into GenreTypes (Name) values ('Romance')");
            Sql("insert into GenreTypes (Name) values ('Family')");
        }
        
        public override void Down()
        {
        }
    }
}
