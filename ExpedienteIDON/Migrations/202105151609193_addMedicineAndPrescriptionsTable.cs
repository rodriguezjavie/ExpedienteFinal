namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedicineAndPrescriptionsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicinesPrescriptions",
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
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CratedDate = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicinesPrescriptions", "PrescriptionId", "dbo.Prescriptions");
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            DropIndex("dbo.MedicinesPrescriptions", new[] { "PrescriptionId" });
            DropTable("dbo.Prescriptions");
            DropTable("dbo.MedicinesPrescriptions");
        }
    }
}
