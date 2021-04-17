namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequieredFieldsPatientNew : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Birthday", c => c.DateTime());
            AlterColumn("dbo.Patients", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Address", c => c.String());
            AlterColumn("dbo.Patients", "Email", c => c.String());
            AlterColumn("dbo.Patients", "Phone", c => c.String());
            AlterColumn("dbo.Patients", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
