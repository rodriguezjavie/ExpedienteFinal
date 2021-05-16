namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPatientAndDoctorToPrescriptionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.Prescriptions", "DoctorId", c => c.Int(nullable: false));
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
            DropColumn("dbo.Prescriptions", "DoctorId");
            DropColumn("dbo.Prescriptions", "PatientId");
        }
    }
}