namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGlucoseFieldVitalSignsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VitalSigns", "Glucose", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VitalSigns", "Glucose");
        }
    }
}
