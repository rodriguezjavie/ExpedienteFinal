namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoctorAndPatientNavigationPropEnPrescription : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Prescriptions", "PatientId");
            CreateIndex("dbo.Prescriptions", "DoctorId");
            AddForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
        }
    }
}
