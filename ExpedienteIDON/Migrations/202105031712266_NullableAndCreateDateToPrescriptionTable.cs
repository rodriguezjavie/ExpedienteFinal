namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableAndCreateDateToPrescriptionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Prescriptions", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Prescriptions", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prescriptions", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Prescriptions", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Prescriptions", "DateCreated");
        }
    }
}
