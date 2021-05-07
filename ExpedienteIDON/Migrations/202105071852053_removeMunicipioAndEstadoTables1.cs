namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeMunicipioAndEstadoTables1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Municipios", "EstadoId", "dbo.Estados");
            DropForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios");
            DropIndex("dbo.Patients", new[] { "MunicipioId" });
            DropIndex("dbo.Municipios", new[] { "EstadoId" });
            DropColumn("dbo.Patients", "MunicipioId");
            DropTable("dbo.Municipios");
            DropTable("dbo.Estados");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "MunicipioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Municipios", "EstadoId");
            CreateIndex("dbo.Patients", "MunicipioId");
            AddForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Municipios", "EstadoId", "dbo.Estades", "Id", cascadeDelete: true);
        }
    }
}
