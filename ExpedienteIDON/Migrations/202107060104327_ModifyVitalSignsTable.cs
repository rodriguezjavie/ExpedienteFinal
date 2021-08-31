namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyVitalSignsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VitalSigns", "TASistBD", c => c.Int(nullable: false));
            AddColumn("dbo.VitalSigns", "TADiastBD", c => c.Int(nullable: false));
            AddColumn("dbo.VitalSigns", "TASistBI", c => c.Int(nullable: false));
            AddColumn("dbo.VitalSigns", "TADiastBI", c => c.Int(nullable: false));
            AlterColumn("dbo.VitalSigns", "Size", c => c.Double(nullable: false));
            DropColumn("dbo.VitalSigns", "TABD");
            DropColumn("dbo.VitalSigns", "TABI");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VitalSigns", "TABI", c => c.String(nullable: false));
            AddColumn("dbo.VitalSigns", "TABD", c => c.String(nullable: false));
            AlterColumn("dbo.VitalSigns", "Size", c => c.Int(nullable: false));
            DropColumn("dbo.VitalSigns", "TADiastBI");
            DropColumn("dbo.VitalSigns", "TASistBI");
            DropColumn("dbo.VitalSigns", "TADiastBD");
            DropColumn("dbo.VitalSigns", "TASistBD");
        }
    }
}
