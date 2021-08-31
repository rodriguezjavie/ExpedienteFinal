namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeMunicipioPatientTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios");
            DropIndex("dbo.Patients", new[] { "MunicipioId" });
            DropColumn("dbo.Patients", "MunicipioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "MunicipioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "MunicipioId");
            AddForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios", "Id", cascadeDelete: true);
        }
    }
}
