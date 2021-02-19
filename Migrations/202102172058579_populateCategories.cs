namespace ProjectBeheerder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        name = c.String(nullable: false),
                        MinimumAantalUren = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CategorieId = c.Byte(nullable: false),
                        DatumToegevoegd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategorieId, cascadeDelete: true)
                .Index(t => t.CategorieId);

            Sql("insert into Categories (Id,Name,MinimumAantalUren ) VALUES (1,'Front-End project' , 40)");
            Sql("insert into Categories (Id,Name,MinimumAantalUren ) VALUES (2,'Back-End project' , 32)");
            Sql("insert into Categories (Id,Name,MinimumAantalUren ) VALUES (3,'Full-End project' , 48)");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "CategorieId", "dbo.Categories");
            DropIndex("dbo.Projects", new[] { "CategorieId" });
            DropTable("dbo.Projects");
            DropTable("dbo.Categories");
        }
    }
}
