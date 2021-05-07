namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableMunicipioIdAndEstadoId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios");
            DropForeignKey("dbo.Municipios", "EstadoId", "dbo.Estadoes");
            DropIndex("dbo.Patients", new[] { "MunicipioId" });
            DropIndex("dbo.Municipios", new[] { "EstadoId" });
            AlterColumn("dbo.Patients", "MunicipioId", c => c.Int());
            AlterColumn("dbo.Municipios", "EstadoId", c => c.Int());
            CreateIndex("dbo.Patients", "MunicipioId");
            CreateIndex("dbo.Municipios", "EstadoId");
            AddForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios", "Id");
            AddForeignKey("dbo.Municipios", "EstadoId", "dbo.Estadoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Municipios", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios");
            DropIndex("dbo.Municipios", new[] { "EstadoId" });
            DropIndex("dbo.Patients", new[] { "MunicipioId" });
            AlterColumn("dbo.Municipios", "EstadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "MunicipioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Municipios", "EstadoId");
            CreateIndex("dbo.Patients", "MunicipioId");
            AddForeignKey("dbo.Municipios", "EstadoId", "dbo.Estadoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios", "Id", cascadeDelete: true);
        }
    }
}
