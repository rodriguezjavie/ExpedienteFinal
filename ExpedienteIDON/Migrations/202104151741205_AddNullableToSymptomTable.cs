namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableToSymptomTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Symptoms", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Symptoms", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Symptoms", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Symptoms", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
