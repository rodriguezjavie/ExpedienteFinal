namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewClassesToTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BiometriaHematicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Eritrocitos = c.Double(),
                        Hemoglobina = c.Double(),
                        Leucocitos = c.Double(),
                        Linfocitos = c.Double(),
                        Monocitos = c.Double(),
                        Plaquetas = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeneralOrinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Aspecto = c.String(),
                        Densidad = c.String(),
                        Ph = c.Double(),
                        Glucosa = c.Double(),
                        Proteinas = c.String(),
                        Sangre = c.String(),
                        Cetonas = c.String(),
                        Nitritos = c.String(),
                        Esterasa = c.String(),
                        Leucocitos = c.String(),
                        Bacterias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hormonas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        LH = c.Double(),
                        FSH = c.Double(),
                        Prolactina = c.Double(),
                        Progesterona = c.Double(),
                        Estrogenos = c.Double(),
                        Cortisol = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LabsTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        HemoglobinaGlucosilada = c.Double(),
                        GlucosaSerica = c.Double(),
                        GlucosaAyuno = c.Double(),
                        GlucosaCasual = c.Double(),
                        MedicalRecordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecordId, cascadeDelete: true)
                .Index(t => t.MedicalRecordId);
            
            CreateTable(
                "dbo.MedicalTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RadiographTorax = c.Boolean(nullable: false),
                        RadiographToraxDate = c.DateTime(),
                        RadiographToraxNormal = c.Boolean(nullable: false),
                        Ultrasound = c.Boolean(nullable: false),
                        UltrasoundDate = c.DateTime(),
                        UltrasoundType = c.String(),
                        Observations = c.String(),
                        Electrocardiography = c.Boolean(nullable: false),
                        ElectrocardiographyDate = c.DateTime(),
                        ElectrocardiographyNormal = c.Boolean(nullable: false),
                        ElectrocardiographyObservations = c.String(),
                        Others = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Others",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        Diagnosis = c.String(),
                        Prognosis = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OtrosLabs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        VitaminaD = c.Double(),
                        Calcio = c.Double(),
                        Fosforo = c.Double(),
                        Magnesio = c.Double(),
                        Sodio = c.Double(),
                        Potasio = c.Double(),
                        Cloro = c.Double(),
                        HemoglobinaGlugosilada = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PerfilHepaticoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        BilirrubinaTotal = c.Double(),
                        BilirrubinaDirecta = c.Double(),
                        BilirrubinaIndirecta = c.Double(),
                        FosfatasaAlcalina = c.Double(),
                        TGO = c.Double(),
                        TGP = c.Double(),
                        GGT = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PerfilTiroideos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        TSH = c.Double(),
                        T3Total = c.Double(),
                        T3Libre = c.Double(),
                        T4Total = c.Double(),
                        T4Libre = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhysicalExplorations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Habitus = c.String(),
                        Cabeza = c.String(),
                        CuelloBocio = c.Boolean(nullable: false),
                        SoploCarotideo = c.Boolean(nullable: false),
                        CuelloAcantosis = c.Boolean(nullable: false),
                        AcanosisAfectacion = c.Int(nullable: false),
                        CuelloComments = c.String(),
                        ToraxComments = c.String(),
                        AbdomenComments = c.String(),
                        ToracicosSimetricos = c.Boolean(nullable: false),
                        ToracicosSensibilidad = c.Boolean(nullable: false),
                        ToracicosFuerza = c.Boolean(nullable: false),
                        ToracicosSinovitis = c.Boolean(nullable: false),
                        ToracicosROT = c.String(),
                        ToracicosComments = c.String(),
                        PelvicoSimetrico = c.Boolean(nullable: false),
                        PelvicoFuerza = c.Boolean(nullable: false),
                        PelvicoSensibilidad = c.Boolean(nullable: false),
                        PelvicoVarices = c.Boolean(nullable: false),
                        PelvicoROTAquileo = c.Boolean(nullable: false),
                        PelvicoOnicomicosis = c.Boolean(nullable: false),
                        PelvicoPulsos = c.Boolean(nullable: false),
                        PelvicoEdema = c.Boolean(nullable: false),
                        PelvicoOtros = c.String(),
                        Genitales = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuimicaSanguineas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Glucosa = c.Double(),
                        Creatinina = c.Double(),
                        AcidoUrico = c.Double(),
                        Colesterol = c.Double(),
                        Trigliceridos = c.Double(),
                        HDL = c.Double(),
                        LDL = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VitalSigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        IMC = c.Double(nullable: false),
                        TABD = c.Int(nullable: false),
                        TABI = c.Int(nullable: false),
                        FC = c.Int(nullable: false),
                        FR = c.Int(nullable: false),
                        Waist = c.Double(nullable: false),
                        Hip = c.Double(nullable: false),
                        OxygenSaturation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Symptoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Severity = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        MedicalRecordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecordId, cascadeDelete: true)
                .Index(t => t.MedicalRecordId);
            
            AddColumn("dbo.MedicalRecords", "VitalSignsId", c => c.Int(nullable: false));
            AddColumn("dbo.MedicalRecords", "MedicalTestId", c => c.Int(nullable: false));
            AddColumn("dbo.MedicalRecords", "BiometriaHematicaId", c => c.Int());
            AddColumn("dbo.MedicalRecords", "QuimicaSanguineaId", c => c.Int());
            AddColumn("dbo.MedicalRecords", "PhysicalExplorationId", c => c.Int(nullable: false));
            AddColumn("dbo.MedicalRecords", "PerfilHepaticoId", c => c.Int());
            AddColumn("dbo.MedicalRecords", "PerfilTiroideoId", c => c.Int());
            AddColumn("dbo.MedicalRecords", "HormonasId", c => c.Int());
            AddColumn("dbo.MedicalRecords", "GeneralOrinaId", c => c.Int());
            AddColumn("dbo.MedicalRecords", "OtrosLabsId", c => c.Int());
            AddColumn("dbo.MedicalRecords", "OthersId", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicalRecords", "VitalSignsId");
            CreateIndex("dbo.MedicalRecords", "MedicalTestId");
            CreateIndex("dbo.MedicalRecords", "BiometriaHematicaId");
            CreateIndex("dbo.MedicalRecords", "QuimicaSanguineaId");
            CreateIndex("dbo.MedicalRecords", "PhysicalExplorationId");
            CreateIndex("dbo.MedicalRecords", "PerfilHepaticoId");
            CreateIndex("dbo.MedicalRecords", "PerfilTiroideoId");
            CreateIndex("dbo.MedicalRecords", "HormonasId");
            CreateIndex("dbo.MedicalRecords", "GeneralOrinaId");
            CreateIndex("dbo.MedicalRecords", "OtrosLabsId");
            CreateIndex("dbo.MedicalRecords", "OthersId");
            AddForeignKey("dbo.MedicalRecords", "BiometriaHematicaId", "dbo.BiometriaHematicas", "Id");
            AddForeignKey("dbo.MedicalRecords", "GeneralOrinaId", "dbo.GeneralOrinas", "Id");
            AddForeignKey("dbo.MedicalRecords", "HormonasId", "dbo.Hormonas", "Id");
            AddForeignKey("dbo.MedicalRecords", "MedicalTestId", "dbo.MedicalTests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicalRecords", "OthersId", "dbo.Others", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicalRecords", "OtrosLabsId", "dbo.OtrosLabs", "Id");
            AddForeignKey("dbo.MedicalRecords", "PerfilHepaticoId", "dbo.PerfilHepaticoes", "Id");
            AddForeignKey("dbo.MedicalRecords", "PerfilTiroideoId", "dbo.PerfilTiroideos", "Id");
            AddForeignKey("dbo.MedicalRecords", "PhysicalExplorationId", "dbo.PhysicalExplorations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MedicalRecords", "QuimicaSanguineaId", "dbo.QuimicaSanguineas", "Id");
            AddForeignKey("dbo.MedicalRecords", "VitalSignsId", "dbo.VitalSigns", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Symptoms", "MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.LabsTests", "MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicalRecords", "VitalSignsId", "dbo.VitalSigns");
            DropForeignKey("dbo.MedicalRecords", "QuimicaSanguineaId", "dbo.QuimicaSanguineas");
            DropForeignKey("dbo.MedicalRecords", "PhysicalExplorationId", "dbo.PhysicalExplorations");
            DropForeignKey("dbo.MedicalRecords", "PerfilTiroideoId", "dbo.PerfilTiroideos");
            DropForeignKey("dbo.MedicalRecords", "PerfilHepaticoId", "dbo.PerfilHepaticoes");
            DropForeignKey("dbo.MedicalRecords", "OtrosLabsId", "dbo.OtrosLabs");
            DropForeignKey("dbo.MedicalRecords", "OthersId", "dbo.Others");
            DropForeignKey("dbo.MedicalRecords", "MedicalTestId", "dbo.MedicalTests");
            DropForeignKey("dbo.MedicalRecords", "HormonasId", "dbo.Hormonas");
            DropForeignKey("dbo.MedicalRecords", "GeneralOrinaId", "dbo.GeneralOrinas");
            DropForeignKey("dbo.MedicalRecords", "BiometriaHematicaId", "dbo.BiometriaHematicas");
            DropIndex("dbo.Symptoms", new[] { "MedicalRecordId" });
            DropIndex("dbo.MedicalRecords", new[] { "OthersId" });
            DropIndex("dbo.MedicalRecords", new[] { "OtrosLabsId" });
            DropIndex("dbo.MedicalRecords", new[] { "GeneralOrinaId" });
            DropIndex("dbo.MedicalRecords", new[] { "HormonasId" });
            DropIndex("dbo.MedicalRecords", new[] { "PerfilTiroideoId" });
            DropIndex("dbo.MedicalRecords", new[] { "PerfilHepaticoId" });
            DropIndex("dbo.MedicalRecords", new[] { "PhysicalExplorationId" });
            DropIndex("dbo.MedicalRecords", new[] { "QuimicaSanguineaId" });
            DropIndex("dbo.MedicalRecords", new[] { "BiometriaHematicaId" });
            DropIndex("dbo.MedicalRecords", new[] { "MedicalTestId" });
            DropIndex("dbo.MedicalRecords", new[] { "VitalSignsId" });
            DropIndex("dbo.LabsTests", new[] { "MedicalRecordId" });
            DropColumn("dbo.MedicalRecords", "OthersId");
            DropColumn("dbo.MedicalRecords", "OtrosLabsId");
            DropColumn("dbo.MedicalRecords", "GeneralOrinaId");
            DropColumn("dbo.MedicalRecords", "HormonasId");
            DropColumn("dbo.MedicalRecords", "PerfilTiroideoId");
            DropColumn("dbo.MedicalRecords", "PerfilHepaticoId");
            DropColumn("dbo.MedicalRecords", "PhysicalExplorationId");
            DropColumn("dbo.MedicalRecords", "QuimicaSanguineaId");
            DropColumn("dbo.MedicalRecords", "BiometriaHematicaId");
            DropColumn("dbo.MedicalRecords", "MedicalTestId");
            DropColumn("dbo.MedicalRecords", "VitalSignsId");
            DropTable("dbo.Symptoms");
            DropTable("dbo.VitalSigns");
            DropTable("dbo.QuimicaSanguineas");
            DropTable("dbo.PhysicalExplorations");
            DropTable("dbo.PerfilTiroideos");
            DropTable("dbo.PerfilHepaticoes");
            DropTable("dbo.OtrosLabs");
            DropTable("dbo.Others");
            DropTable("dbo.MedicalTests");
            DropTable("dbo.LabsTests");
            DropTable("dbo.Hormonas");
            DropTable("dbo.GeneralOrinas");
            DropTable("dbo.BiometriaHematicas");
        }
    }
}
