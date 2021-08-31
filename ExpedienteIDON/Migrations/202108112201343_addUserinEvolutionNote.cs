namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserinEvolutionNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EvolutionNotes", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.EvolutionNotes", "ApplicationUserId");
            AddForeignKey("dbo.EvolutionNotes", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvolutionNotes", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.EvolutionNotes", new[] { "ApplicationUserId" });
            DropColumn("dbo.EvolutionNotes", "ApplicationUserId");
        }
    }
}
