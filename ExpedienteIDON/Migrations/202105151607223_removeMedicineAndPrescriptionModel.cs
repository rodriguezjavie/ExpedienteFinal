namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeMedicineAndPrescriptionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.MedicinesPrescriptions", "PrescriptionId", "dbo.Prescriptions");
            DropIndex("dbo.MedicinesPrescriptions", new[] { "PrescriptionId" });
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
            DropTable("dbo.MedicinesPrescriptions");
            DropTable("dbo.Prescriptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CratedDate = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Prescriptions", "DoctorId");
            CreateIndex("dbo.Prescriptions", "PatientId");
            CreateIndex("dbo.MedicinesPrescriptions", "PrescriptionId");
            AddForeignKey("dbo.MedicinesPrescriptions", "PrescriptionId", "dbo.Prescriptions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
    }
}
