namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificarDataAnnotationPaciente : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Others", "Reason", c => c.String(nullable: false));
            AlterColumn("dbo.Others", "Diagnosis", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.VitalSigns", "TABD", c => c.String(nullable: false));
            AlterColumn("dbo.VitalSigns", "TABI", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VitalSigns", "TABI", c => c.Int(nullable: false));
            AlterColumn("dbo.VitalSigns", "TABD", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "Name", c => c.String());
            AlterColumn("dbo.Others", "Diagnosis", c => c.String());
            AlterColumn("dbo.Others", "Reason", c => c.String());
        }
    }
}
