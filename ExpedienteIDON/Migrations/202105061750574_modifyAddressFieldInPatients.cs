namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyAddressFieldInPatients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "StreetAndNumber", c => c.String());
            AddColumn("dbo.Patients", "Suburb", c => c.String());
            AddColumn("dbo.Patients", "City", c => c.String());
            AddColumn("dbo.Patients", "MunicipioId", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "ZipCode", c => c.String());
            CreateIndex("dbo.Patients", "MunicipioId");
            AddForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios");
            DropForeignKey("dbo.Municipios", "EstadoId", "dbo.Estadoes");
            DropIndex("dbo.Municipios", new[] { "EstadoId" });
            DropIndex("dbo.Patients", new[] { "MunicipioId" });
            DropColumn("dbo.Patients", "ZipCode");
            DropColumn("dbo.Patients", "MunicipioId");
            DropColumn("dbo.Patients", "City");
            DropColumn("dbo.Patients", "Suburb");
            DropColumn("dbo.Patients", "StreetAndNumber");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Municipios");
        }
    }
}
