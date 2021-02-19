namespace ProjectBeheerder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameFullEndToFullstack1 : DbMigration
    {
        public override void Up()
        {
            Sql(" update dbo.Categories SET name = 'Front-End project' where Id = 1");
            Sql(" update dbo.Categories SET name = 'Full-Stack project' where Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
