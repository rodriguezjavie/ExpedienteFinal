namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableMunicipiosAndEstadosTable : DbMigration
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
                .ForeignKey("dbo.Estados", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "MunicipioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "MunicipioId");
            AddForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios");
            DropForeignKey("dbo.Municipios", "EstadoId", "dbo.Estados");
            DropIndex("dbo.Municipios", new[] { "EstadoId" });
            DropIndex("dbo.Patients", new[] { "MunicipioId" });
            DropColumn("dbo.Patients", "MunicipioId");
            DropTable("dbo.Estados");
            DropTable("dbo.Municipios");
        }
    }
}
