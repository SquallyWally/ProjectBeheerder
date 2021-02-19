namespace ProjectBeheerder.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class populateMembers : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Werknemers (Name,WerkpositieId, GeboorteDatum) VALUES ('Milo', 1,6/3/1994)");
            Sql("insert into Werknemers (Name,WerkpositieId, GeboorteDatum) VALUES ('Isa', 2 ,16/8/1993)");
        }

        public override void Down()
        {
        }
    }
}