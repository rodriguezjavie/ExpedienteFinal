namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePrescriptionsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            DropTable("dbo.Prescriptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
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
            
            CreateIndex("dbo.Prescriptions", "PatientId");
            CreateIndex("dbo.Prescriptions", "DoctorId");
            AddForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
    }
}
