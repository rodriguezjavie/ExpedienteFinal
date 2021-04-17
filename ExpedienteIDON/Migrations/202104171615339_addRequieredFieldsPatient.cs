namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequieredFieldsPatient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Birthday", c => c.DateTime());
            AlterColumn("dbo.Patients", "LastName", c => c.String());
        }
    }
}
