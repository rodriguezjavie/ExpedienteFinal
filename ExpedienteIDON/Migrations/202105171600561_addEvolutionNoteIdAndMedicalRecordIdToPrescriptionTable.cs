namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEvolutionNoteIdAndMedicalRecordIdToPrescriptionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "EvolutionNoteId", c => c.Int());
            AddColumn("dbo.Prescriptions", "MedicalRecordId", c => c.Int());
            CreateIndex("dbo.Prescriptions", "EvolutionNoteId");
            CreateIndex("dbo.Prescriptions", "MedicalRecordId");
            AddForeignKey("dbo.Prescriptions", "EvolutionNoteId", "dbo.EvolutionNotes", "Id");
            AddForeignKey("dbo.Prescriptions", "MedicalRecordId", "dbo.MedicalRecords", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.Prescriptions", "EvolutionNoteId", "dbo.EvolutionNotes");
            DropIndex("dbo.Prescriptions", new[] { "MedicalRecordId" });
            DropIndex("dbo.Prescriptions", new[] { "EvolutionNoteId" });
            DropColumn("dbo.Prescriptions", "MedicalRecordId");
            DropColumn("dbo.Prescriptions", "EvolutionNoteId");
        }
    }
}
