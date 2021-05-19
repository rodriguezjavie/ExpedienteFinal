namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoctorIdToMedicalRecordsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalRecords", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicalRecords", "DoctorId");
            AddForeignKey("dbo.MedicalRecords", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecords", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.MedicalRecords", new[] { "DoctorId" });
            DropColumn("dbo.MedicalRecords", "DoctorId");
        }
    }
}
