namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewPrescriptionsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CratedDate = c.DateTime(nullable: false),
                        OthersId = c.Int(),
                        EvolutionNoteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvolutionNotes", t => t.EvolutionNoteId, cascadeDelete: true)
                .ForeignKey("dbo.Others", t => t.OthersId)
                .Index(t => t.OthersId)
                .Index(t => t.EvolutionNoteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "OthersId", "dbo.Others");
            DropForeignKey("dbo.Prescriptions", "EvolutionNoteId", "dbo.EvolutionNotes");
            DropIndex("dbo.Prescriptions", new[] { "EvolutionNoteId" });
            DropIndex("dbo.Prescriptions", new[] { "OthersId" });
            DropTable("dbo.Prescriptions");
        }
    }
}
