namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedicinesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrescriptionId = c.Int(nullable: false),
                        Medicine = c.String(),
                        UnitOfMeasure = c.String(),
                        Dose = c.String(),
                        Frequency = c.String(),
                        Administration = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Indications = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prescriptions", t => t.PrescriptionId, cascadeDelete: true)
                .Index(t => t.PrescriptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicines", "PrescriptionId", "dbo.Prescriptions");
            DropIndex("dbo.Medicines", new[] { "PrescriptionId" });
            DropTable("dbo.Medicines");
        }
    }
}
