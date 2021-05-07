namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAddressFieldInPatients : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Address", c => c.String(nullable: false));
        }
    }
}
