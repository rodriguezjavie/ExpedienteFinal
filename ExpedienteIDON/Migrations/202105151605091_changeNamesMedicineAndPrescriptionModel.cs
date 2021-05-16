namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeNamesMedicineAndPrescriptionModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Medicines", newName: "MedicinesPrescriptions");
            DropForeignKey("dbo.Prescriptions", "EvolutionNoteId", "dbo.EvolutionNotes");
            DropForeignKey("dbo.Prescriptions", "OthersId", "dbo.Others");
            DropIndex("dbo.Prescriptions", new[] { "OthersId" });
            DropIndex("dbo.Prescriptions", new[] { "EvolutionNoteId" });
            DropColumn("dbo.Prescriptions", "OthersId");
            DropColumn("dbo.Prescriptions", "EvolutionNoteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prescriptions", "EvolutionNoteId", c => c.Int());
            AddColumn("dbo.Prescriptions", "OthersId", c => c.Int());
            CreateIndex("dbo.Prescriptions", "EvolutionNoteId");
            CreateIndex("dbo.Prescriptions", "OthersId");
            AddForeignKey("dbo.Prescriptions", "OthersId", "dbo.Others", "Id");
            AddForeignKey("dbo.Prescriptions", "EvolutionNoteId", "dbo.EvolutionNotes", "Id");
            RenameTable(name: "dbo.MedicinesPrescriptions", newName: "Medicines");
        }
    }
}
