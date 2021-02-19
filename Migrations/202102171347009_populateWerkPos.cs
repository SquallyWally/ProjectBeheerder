namespace ProjectBeheerder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateWerkPos : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Werkposities (Id,Name, Niveau) VALUES (1,'Software Engineer' , 2)");
            Sql("insert into Werkposities (Id,Name, Niveau) VALUES (2,'Security Manager' , 2)");
            Sql("insert into Werkposities (Id,Name, Niveau) VALUES (3,'Project Manager' , 5)");
            Sql("insert into Werkposities (Id,Name, Niveau) VALUES (4,'Hardware Engineer' , 1)");
            Sql("insert into Werkposities (Id,Name, Niveau) VALUES (5,'IT Consult' , 3)");
        }
        
        public override void Down()
        {
        }
    }
}
