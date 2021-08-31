namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeNullableGlucoseFieldVitalSignsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VitalSigns", "Glucose", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VitalSigns", "Glucose", c => c.Int(nullable: false));
        }
    }
}
