namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotesFieldToOthersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Others", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Others", "Notes");
        }
    }
}
