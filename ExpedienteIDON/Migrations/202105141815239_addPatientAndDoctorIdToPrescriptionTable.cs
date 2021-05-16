namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPatientAndDoctorIdToPrescriptionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Prescriptions", "DoctorId");
            CreateIndex("dbo.Prescriptions", "PatientId");
            AddForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
    }
}
