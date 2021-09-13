namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCreatedinPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Created");
        }
    }
}
