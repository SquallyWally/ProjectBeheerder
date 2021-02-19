namespace ProjectBeheerder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateProjecten : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Projects (Name,CategorieId, DatumToegevoegd) VALUES ('Migrate Jquery naar Angular', 1, 4/4/2021)");
            Sql("insert into Projects (Name,CategorieId, DatumToegevoegd) VALUES ('Create Tool devkit', 2, 3/2/2021)");
        }
        
        public override void Down()
        {
        }
    }
}
