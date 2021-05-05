namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoctorIdToEvolutionNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EvolutionNotes", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.EvolutionNotes", "DoctorId");
            AddForeignKey("dbo.EvolutionNotes", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvolutionNotes", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.EvolutionNotes", new[] { "DoctorId" });
            DropColumn("dbo.EvolutionNotes", "DoctorId");
        }
    }
}
