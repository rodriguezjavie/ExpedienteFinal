namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRadiographToraxObservationFielInMedicalTestTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalTests", "RadiographToraxObservations", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicalTests", "RadiographToraxObservations");
        }
    }
}
