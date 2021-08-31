namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatesFieldMedicinesPrescriptionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicinesPrescriptions", "TreatmentDuration", c => c.String());
            DropColumn("dbo.MedicinesPrescriptions", "StartDate");
            DropColumn("dbo.MedicinesPrescriptions", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicinesPrescriptions", "EndDate", c => c.DateTime());
            AddColumn("dbo.MedicinesPrescriptions", "StartDate", c => c.DateTime());
            DropColumn("dbo.MedicinesPrescriptions", "TreatmentDuration");
        }
    }
}
