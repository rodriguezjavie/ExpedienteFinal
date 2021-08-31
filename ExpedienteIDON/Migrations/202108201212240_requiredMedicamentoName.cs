namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredMedicamentoName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedicinesPrescriptions", "Medicine", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicinesPrescriptions", "Medicine", c => c.String());
        }
    }
}
