namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvolutionNotesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EvolutionNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        VitalSignsId = c.Int(nullable: false),
                        BiometriaHematicaId = c.Int(),
                        QuimicaSanguineaId = c.Int(),
                        PerfilHepaticoId = c.Int(),
                        PerfilTiroideoId = c.Int(),
                        HormonasId = c.Int(),
                        GeneralOrinaId = c.Int(),
                        OtrosLabsId = c.Int(),
                        OthersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BiometriaHematicas", t => t.BiometriaHematicaId)
                .ForeignKey("dbo.GeneralOrinas", t => t.GeneralOrinaId)
                .ForeignKey("dbo.Hormonas", t => t.HormonasId)
                .ForeignKey("dbo.Others", t => t.OthersId, cascadeDelete: true)
                .ForeignKey("dbo.OtrosLabs", t => t.OtrosLabsId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.PerfilHepaticoes", t => t.PerfilHepaticoId)
                .ForeignKey("dbo.PerfilTiroideos", t => t.PerfilTiroideoId)
                .ForeignKey("dbo.QuimicaSanguineas", t => t.QuimicaSanguineaId)
                .ForeignKey("dbo.VitalSigns", t => t.VitalSignsId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.VitalSignsId)
                .Index(t => t.BiometriaHematicaId)
                .Index(t => t.QuimicaSanguineaId)
                .Index(t => t.PerfilHepaticoId)
                .Index(t => t.PerfilTiroideoId)
                .Index(t => t.HormonasId)
                .Index(t => t.GeneralOrinaId)
                .Index(t => t.OtrosLabsId)
                .Index(t => t.OthersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvolutionNotes", "VitalSignsId", "dbo.VitalSigns");
            DropForeignKey("dbo.EvolutionNotes", "QuimicaSanguineaId", "dbo.QuimicaSanguineas");
            DropForeignKey("dbo.EvolutionNotes", "PerfilTiroideoId", "dbo.PerfilTiroideos");
            DropForeignKey("dbo.EvolutionNotes", "PerfilHepaticoId", "dbo.PerfilHepaticoes");
            DropForeignKey("dbo.EvolutionNotes", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.EvolutionNotes", "OtrosLabsId", "dbo.OtrosLabs");
            DropForeignKey("dbo.EvolutionNotes", "OthersId", "dbo.Others");
            DropForeignKey("dbo.EvolutionNotes", "HormonasId", "dbo.Hormonas");
            DropForeignKey("dbo.EvolutionNotes", "GeneralOrinaId", "dbo.GeneralOrinas");
            DropForeignKey("dbo.EvolutionNotes", "BiometriaHematicaId", "dbo.BiometriaHematicas");
            DropIndex("dbo.EvolutionNotes", new[] { "OthersId" });
            DropIndex("dbo.EvolutionNotes", new[] { "OtrosLabsId" });
            DropIndex("dbo.EvolutionNotes", new[] { "GeneralOrinaId" });
            DropIndex("dbo.EvolutionNotes", new[] { "HormonasId" });
            DropIndex("dbo.EvolutionNotes", new[] { "PerfilTiroideoId" });
            DropIndex("dbo.EvolutionNotes", new[] { "PerfilHepaticoId" });
            DropIndex("dbo.EvolutionNotes", new[] { "QuimicaSanguineaId" });
            DropIndex("dbo.EvolutionNotes", new[] { "BiometriaHematicaId" });
            DropIndex("dbo.EvolutionNotes", new[] { "VitalSignsId" });
            DropIndex("dbo.EvolutionNotes", new[] { "PatientId" });
            DropTable("dbo.EvolutionNotes");
        }
    }
}
