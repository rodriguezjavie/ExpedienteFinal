namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePrescriptionTable : DbMigration
    {
        public override void Up()
        {
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
            
        }
    }
}
