namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeMunicipioAndEstadoTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Municipios", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios");
            DropIndex("dbo.Patients", new[] { "MunicipioId" });
            DropIndex("dbo.Municipios", new[] { "EstadoId" });
            DropColumn("dbo.Patients", "MunicipioId");
            DropTable("dbo.Municipios");
            DropTable("dbo.Estadoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Estadoes",
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
                        EstadoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "MunicipioId", c => c.Int());
            CreateIndex("dbo.Municipios", "EstadoId");
            CreateIndex("dbo.Patients", "MunicipioId");
            AddForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios", "Id");
            AddForeignKey("dbo.Municipios", "EstadoId", "dbo.Estadoes", "Id");
        }
    }
}
