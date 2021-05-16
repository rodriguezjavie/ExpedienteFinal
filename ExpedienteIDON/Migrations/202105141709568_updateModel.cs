namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescriptions", "EvolutionNoteId", "dbo.EvolutionNotes");
            DropIndex("dbo.Prescriptions", new[] { "EvolutionNoteId" });
            AlterColumn("dbo.Prescriptions", "EvolutionNoteId", c => c.Int());
            CreateIndex("dbo.Prescriptions", "EvolutionNoteId");
            AddForeignKey("dbo.Prescriptions", "EvolutionNoteId", "dbo.EvolutionNotes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "EvolutionNoteId", "dbo.EvolutionNotes");
            DropIndex("dbo.Prescriptions", new[] { "EvolutionNoteId" });
            AlterColumn("dbo.Prescriptions", "EvolutionNoteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Prescriptions", "EvolutionNoteId");
            AddForeignKey("dbo.Prescriptions", "EvolutionNoteId", "dbo.EvolutionNotes", "Id", cascadeDelete: true);
        }
    }
}
