namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "dbo.BloodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Cellphone = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        DoctorGender = c.Int(nullable: false),
                        Cedula = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId, cascadeDelete: true)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.EvolutionNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
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
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
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
                .Index(t => t.DoctorId)
                .Index(t => t.VitalSignsId)
                .Index(t => t.BiometriaHematicaId)
                .Index(t => t.QuimicaSanguineaId)
                .Index(t => t.PerfilHepaticoId)
                .Index(t => t.PerfilTiroideoId)
                .Index(t => t.HormonasId)
                .Index(t => t.GeneralOrinaId)
                .Index(t => t.OtrosLabsId)
                .Index(t => t.OthersId);
            
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
                "dbo.Others",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(nullable: false),
                        Diagnosis = c.String(nullable: false),
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
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Birthday = c.DateTime(),
                        PatientGender = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        Cellphone = c.String(),
                        Email = c.String(nullable: false),
                        Photo = c.String(),
                        Ocupation = c.String(),
                        PatientStudies = c.Int(nullable: false),
                        PatientCivilStatus = c.Int(nullable: false),
                        StreetAndNumber = c.String(),
                        Suburb = c.String(),
                        City = c.String(),
                        MunicipioId = c.Int(nullable: false),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipios", t => t.MunicipioId, cascadeDelete: true)
                .Index(t => t.MunicipioId);
            
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
                        TABD = c.String(nullable: false),
                        TABI = c.String(nullable: false),
                        FC = c.Int(nullable: false),
                        FR = c.Int(nullable: false),
                        Waist = c.Double(nullable: false),
                        Hip = c.Double(nullable: false),
                        OxygenSaturation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FamilyRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusDiabetes = c.Int(nullable: false),
                        ParentDiabetes = c.Int(nullable: false),
                        SiblingDiabetes = c.Int(nullable: false),
                        ChildDiabetes = c.Int(nullable: false),
                        StatusHypertension = c.Int(nullable: false),
                        ParentHypertension = c.Int(nullable: false),
                        SiblingHypertension = c.Int(nullable: false),
                        ChildHypertension = c.Int(nullable: false),
                        StatusThyroid = c.Int(nullable: false),
                        ParentThyroid = c.Int(nullable: false),
                        SiblingThyroid = c.Int(nullable: false),
                        ChildThyroid = c.Int(nullable: false),
                        StatusHypertriglyceridemia = c.Int(nullable: false),
                        ParentHypertriglyceridemia = c.Int(nullable: false),
                        SiblingHypertriglyceridemia = c.Int(nullable: false),
                        ChildHypertriglyceridemia = c.Int(nullable: false),
                        StatusHypercholesterolemia = c.Int(nullable: false),
                        ParentHypercholesterolemia = c.Int(nullable: false),
                        SiblingHypercholesterolemia = c.Int(nullable: false),
                        ChildHypercholesterolemia = c.Int(nullable: false),
                        StatusCancer = c.Int(nullable: false),
                        ParentCancer = c.Int(nullable: false),
                        SiblingCancer = c.Int(nullable: false),
                        ChildCancer = c.Int(nullable: false),
                        StatusHeartAttack = c.Int(nullable: false),
                        ParentHeartAttack = c.Int(nullable: false),
                        SiblingHeartAttack = c.Int(nullable: false),
                        ChildHeartAttack = c.Int(nullable: false),
                        StatusHeartAttackTwo = c.Int(nullable: false),
                        ParentHeartAttackTwo = c.Int(nullable: false),
                        SiblingHeartAttackTwo = c.Int(nullable: false),
                        ChildHeartAttackTwo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GynecoRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Menarca = c.Int(),
                        Gesta = c.Int(),
                        Para = c.Int(),
                        Cesarea = c.Int(),
                        Aborto = c.Int(),
                        Obitos = c.Int(),
                        SexualLifeStart = c.Int(),
                        RegularMenstrualCycle = c.Boolean(nullable: false),
                        LastMenstruationDate = c.DateTime(),
                        Amenorrea = c.Boolean(nullable: false),
                        BirthControlMethod = c.Int(nullable: false),
                        PregnancyHypertension = c.Int(nullable: false),
                        PregnancyHypertensionDate = c.DateTime(),
                        PregnancyDiabetes = c.Int(nullable: false),
                        PregnancyDiabetesDate = c.DateTime(),
                        ChildrenPlus4Kg = c.Int(nullable: false),
                        ChildrenPlus4KgDate = c.DateTime(),
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
                "dbo.MedicalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        FamilyRecordId = c.Int(nullable: false),
                        NonPathologicalRecordId = c.Int(nullable: false),
                        GynecoRecordId = c.Int(),
                        PathologicRecordId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        VitalSignsId = c.Int(nullable: false),
                        MedicalTestId = c.Int(nullable: false),
                        BiometriaHematicaId = c.Int(),
                        QuimicaSanguineaId = c.Int(),
                        PhysicalExplorationId = c.Int(nullable: false),
                        PerfilHepaticoId = c.Int(),
                        PerfilTiroideoId = c.Int(),
                        HormonasId = c.Int(),
                        GeneralOrinaId = c.Int(),
                        OtrosLabsId = c.Int(),
                        OthersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BiometriaHematicas", t => t.BiometriaHematicaId)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.FamilyRecords", t => t.FamilyRecordId, cascadeDelete: true)
                .ForeignKey("dbo.GeneralOrinas", t => t.GeneralOrinaId)
                .ForeignKey("dbo.GynecoRecords", t => t.GynecoRecordId)
                .ForeignKey("dbo.Hormonas", t => t.HormonasId)
                .ForeignKey("dbo.MedicalTests", t => t.MedicalTestId, cascadeDelete: true)
                .ForeignKey("dbo.NonPathologicalRecords", t => t.NonPathologicalRecordId, cascadeDelete: true)
                .ForeignKey("dbo.Others", t => t.OthersId, cascadeDelete: true)
                .ForeignKey("dbo.OtrosLabs", t => t.OtrosLabsId)
                .ForeignKey("dbo.PathologicRecords", t => t.PathologicRecordId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.PerfilHepaticoes", t => t.PerfilHepaticoId)
                .ForeignKey("dbo.PerfilTiroideos", t => t.PerfilTiroideoId)
                .ForeignKey("dbo.PhysicalExplorations", t => t.PhysicalExplorationId, cascadeDelete: true)
                .ForeignKey("dbo.QuimicaSanguineas", t => t.QuimicaSanguineaId)
                .ForeignKey("dbo.VitalSigns", t => t.VitalSignsId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId)
                .Index(t => t.FamilyRecordId)
                .Index(t => t.NonPathologicalRecordId)
                .Index(t => t.GynecoRecordId)
                .Index(t => t.PathologicRecordId)
                .Index(t => t.VitalSignsId)
                .Index(t => t.MedicalTestId)
                .Index(t => t.BiometriaHematicaId)
                .Index(t => t.QuimicaSanguineaId)
                .Index(t => t.PhysicalExplorationId)
                .Index(t => t.PerfilHepaticoId)
                .Index(t => t.PerfilTiroideoId)
                .Index(t => t.HormonasId)
                .Index(t => t.GeneralOrinaId)
                .Index(t => t.OtrosLabsId)
                .Index(t => t.OthersId);
            
            CreateTable(
                "dbo.MedicalTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RadiographTorax = c.Boolean(nullable: false),
                        RadiographToraxDate = c.DateTime(),
                        RadiographToraxNormal = c.Boolean(nullable: false),
                        RadiographToraxObservations = c.String(),
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
                "dbo.NonPathologicalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodTypeId = c.Int(),
                        Smoking = c.Boolean(nullable: false),
                        SmokingCigars = c.Int(),
                        SmokingStarted = c.Int(),
                        ExSmoking = c.Boolean(nullable: false),
                        ExSmokingHowLong = c.Int(),
                        ExSmokingWhenStopped = c.Int(),
                        ExSmokingCigars = c.Int(),
                        Alcohol = c.Boolean(nullable: false),
                        AlcoholLiters = c.Int(),
                        DrugsType = c.Int(nullable: false),
                        DietType = c.Int(nullable: false),
                        ExerciseType = c.Int(nullable: false),
                        Hygiene = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BloodTypes", t => t.BloodTypeId)
                .Index(t => t.BloodTypeId);
            
            CreateTable(
                "dbo.PathologicRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DiabetesType1 = c.Boolean(nullable: false),
                        Diabetes1DiagnosticYear = c.Int(),
                        Diabetes1Comment = c.String(),
                        DiabetesType2 = c.Boolean(nullable: false),
                        Diabetes2DiagnosticYear = c.Int(),
                        Diabetes2Comment = c.String(),
                        Obesity = c.Boolean(nullable: false),
                        ObesityDiagnosticYear = c.Int(),
                        ObesityComment = c.String(),
                        MaxWeight = c.Int(),
                        WeightDiagnosticYear = c.Int(),
                        WeightComment = c.String(),
                        Hypertension = c.Boolean(nullable: false),
                        HypertensionDiagnosticYear = c.Int(),
                        HypertensionComment = c.String(),
                        IschemicHeartDisease = c.Boolean(nullable: false),
                        IschemicHeartDiseaseDiagnosticYear = c.Int(),
                        IschemicHeartDiseaseComment = c.String(),
                        NoIschemicHeartDisease = c.Boolean(nullable: false),
                        NoIschemicHeartDiseaseDiagnosticYear = c.Int(),
                        NoIschemicHeartDiseaseComment = c.String(),
                        CerebralDisease = c.Boolean(nullable: false),
                        CerebralDiseaseDiagnosticYear = c.Int(),
                        CerebralDiseaseComment = c.String(),
                        Epilepsy = c.Boolean(nullable: false),
                        EpilepsyDiagnosticYear = c.Int(),
                        EpilepsyComment = c.String(),
                        Thyroid = c.Boolean(nullable: false),
                        ThyroidDiagnosticYear = c.Int(),
                        ThyroidComment = c.String(),
                        LungDisease = c.Boolean(nullable: false),
                        LungDiseaseDiagnosticYear = c.Int(),
                        LungDiseaseComment = c.String(),
                        LiverDisease = c.Boolean(nullable: false),
                        LiverDiseaseDiagnosticYear = c.Int(),
                        LiverDiseaseComment = c.String(),
                        Colon = c.Boolean(nullable: false),
                        ColonDiagnosticYear = c.Int(),
                        ColonComment = c.String(),
                        Cancer = c.Boolean(nullable: false),
                        CancerDiagnosticYear = c.Int(),
                        CancerComment = c.String(),
                        Hypertriglyceridemia = c.Boolean(nullable: false),
                        HypertriglyceridemiaDiagnosticYear = c.Int(),
                        HypertriglyceridemiaComment = c.String(),
                        Hypercholesterolemia = c.Boolean(nullable: false),
                        HypercholesterolemiaDiagnosticYear = c.Int(),
                        HypercholesterolemiaComment = c.String(),
                        Necropathy = c.Boolean(nullable: false),
                        NecropathyDiagnosticYear = c.Int(),
                        NecropathyComment = c.String(),
                        Retinopathy = c.Boolean(nullable: false),
                        RetinopathyDiagnosticYear = c.Int(),
                        RetinopathyComment = c.String(),
                        Ophthalmological = c.Boolean(nullable: false),
                        OphthalmologicalDiagnosticYear = c.Int(),
                        OphthalmologicalComment = c.String(),
                        Neuropathy = c.Boolean(nullable: false),
                        NeuropathyDiagnosticYear = c.Int(),
                        NeuropathyComment = c.String(),
                        BloodTransfusion = c.Boolean(nullable: false),
                        BloodTransfusionDiagnosticYear = c.Int(),
                        BloodTransfusionComment = c.String(),
                        Allergy = c.Boolean(nullable: false),
                        AllergyDiagnosticYear = c.Int(),
                        AllergyComment = c.String(),
                        Surgery = c.Boolean(nullable: false),
                        SurgeryDiagnosticYear = c.Int(),
                        SurgeryComment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OtherPathologicRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PathologicRecordId = c.Int(nullable: false),
                        Name = c.String(),
                        DiagnosticYear = c.Int(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PathologicRecords", t => t.PathologicRecordId, cascadeDelete: true)
                .Index(t => t.PathologicRecordId);
            
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
                "dbo.MedicinesPrescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrescriptionId = c.Int(nullable: false),
                        Medicine = c.String(),
                        UnitOfMeasure = c.String(),
                        Dose = c.String(),
                        Frequency = c.String(),
                        Administration = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Indications = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Prescriptions", t => t.PrescriptionId, cascadeDelete: true)
                .Index(t => t.PrescriptionId);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CratedDate = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        EvolutionNoteId = c.Int(),
                        MedicalRecordId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.EvolutionNotes", t => t.EvolutionNoteId)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecordId)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.EvolutionNoteId)
                .Index(t => t.MedicalRecordId);
            
            CreateTable(
                "dbo.OtherFamilyRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FamilyRecordId = c.Int(nullable: false),
                        Name = c.String(),
                        Parents = c.Int(nullable: false),
                        Sibilings = c.Int(nullable: false),
                        Childs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyRecords", t => t.FamilyRecordId, cascadeDelete: true)
                .Index(t => t.FamilyRecordId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Symptoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Severity = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        MedicalRecordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedicalRecords", t => t.MedicalRecordId, cascadeDelete: true)
                .Index(t => t.MedicalRecordId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Symptoms", "MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OtherFamilyRecords", "FamilyRecordId", "dbo.FamilyRecords");
            DropForeignKey("dbo.MedicinesPrescriptions", "PrescriptionId", "dbo.Prescriptions");
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Prescriptions", "MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.Prescriptions", "EvolutionNoteId", "dbo.EvolutionNotes");
            DropForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.LabsTests", "MedicalRecordId", "dbo.MedicalRecords");
            DropForeignKey("dbo.MedicalRecords", "VitalSignsId", "dbo.VitalSigns");
            DropForeignKey("dbo.MedicalRecords", "QuimicaSanguineaId", "dbo.QuimicaSanguineas");
            DropForeignKey("dbo.MedicalRecords", "PhysicalExplorationId", "dbo.PhysicalExplorations");
            DropForeignKey("dbo.MedicalRecords", "PerfilTiroideoId", "dbo.PerfilTiroideos");
            DropForeignKey("dbo.MedicalRecords", "PerfilHepaticoId", "dbo.PerfilHepaticoes");
            DropForeignKey("dbo.MedicalRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.MedicalRecords", "PathologicRecordId", "dbo.PathologicRecords");
            DropForeignKey("dbo.OtherPathologicRecords", "PathologicRecordId", "dbo.PathologicRecords");
            DropForeignKey("dbo.MedicalRecords", "OtrosLabsId", "dbo.OtrosLabs");
            DropForeignKey("dbo.MedicalRecords", "OthersId", "dbo.Others");
            DropForeignKey("dbo.MedicalRecords", "NonPathologicalRecordId", "dbo.NonPathologicalRecords");
            DropForeignKey("dbo.NonPathologicalRecords", "BloodTypeId", "dbo.BloodTypes");
            DropForeignKey("dbo.MedicalRecords", "MedicalTestId", "dbo.MedicalTests");
            DropForeignKey("dbo.MedicalRecords", "HormonasId", "dbo.Hormonas");
            DropForeignKey("dbo.MedicalRecords", "GynecoRecordId", "dbo.GynecoRecords");
            DropForeignKey("dbo.MedicalRecords", "GeneralOrinaId", "dbo.GeneralOrinas");
            DropForeignKey("dbo.MedicalRecords", "FamilyRecordId", "dbo.FamilyRecords");
            DropForeignKey("dbo.MedicalRecords", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.MedicalRecords", "BiometriaHematicaId", "dbo.BiometriaHematicas");
            DropForeignKey("dbo.EvolutionNotes", "VitalSignsId", "dbo.VitalSigns");
            DropForeignKey("dbo.EvolutionNotes", "QuimicaSanguineaId", "dbo.QuimicaSanguineas");
            DropForeignKey("dbo.EvolutionNotes", "PerfilTiroideoId", "dbo.PerfilTiroideos");
            DropForeignKey("dbo.EvolutionNotes", "PerfilHepaticoId", "dbo.PerfilHepaticoes");
            DropForeignKey("dbo.EvolutionNotes", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "MunicipioId", "dbo.Municipios");
            DropForeignKey("dbo.EvolutionNotes", "OtrosLabsId", "dbo.OtrosLabs");
            DropForeignKey("dbo.EvolutionNotes", "OthersId", "dbo.Others");
            DropForeignKey("dbo.EvolutionNotes", "HormonasId", "dbo.Hormonas");
            DropForeignKey("dbo.EvolutionNotes", "GeneralOrinaId", "dbo.GeneralOrinas");
            DropForeignKey("dbo.EvolutionNotes", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.EvolutionNotes", "BiometriaHematicaId", "dbo.BiometriaHematicas");
            DropForeignKey("dbo.Municipios", "EstadoId", "dbo.Estadoes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Symptoms", new[] { "MedicalRecordId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OtherFamilyRecords", new[] { "FamilyRecordId" });
            DropIndex("dbo.Prescriptions", new[] { "MedicalRecordId" });
            DropIndex("dbo.Prescriptions", new[] { "EvolutionNoteId" });
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            DropIndex("dbo.MedicinesPrescriptions", new[] { "PrescriptionId" });
            DropIndex("dbo.OtherPathologicRecords", new[] { "PathologicRecordId" });
            DropIndex("dbo.NonPathologicalRecords", new[] { "BloodTypeId" });
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
            DropIndex("dbo.MedicalRecords", new[] { "PathologicRecordId" });
            DropIndex("dbo.MedicalRecords", new[] { "GynecoRecordId" });
            DropIndex("dbo.MedicalRecords", new[] { "NonPathologicalRecordId" });
            DropIndex("dbo.MedicalRecords", new[] { "FamilyRecordId" });
            DropIndex("dbo.MedicalRecords", new[] { "PatientId" });
            DropIndex("dbo.MedicalRecords", new[] { "DoctorId" });
            DropIndex("dbo.LabsTests", new[] { "MedicalRecordId" });
            DropIndex("dbo.Patients", new[] { "MunicipioId" });
            DropIndex("dbo.EvolutionNotes", new[] { "OthersId" });
            DropIndex("dbo.EvolutionNotes", new[] { "OtrosLabsId" });
            DropIndex("dbo.EvolutionNotes", new[] { "GeneralOrinaId" });
            DropIndex("dbo.EvolutionNotes", new[] { "HormonasId" });
            DropIndex("dbo.EvolutionNotes", new[] { "PerfilTiroideoId" });
            DropIndex("dbo.EvolutionNotes", new[] { "PerfilHepaticoId" });
            DropIndex("dbo.EvolutionNotes", new[] { "QuimicaSanguineaId" });
            DropIndex("dbo.EvolutionNotes", new[] { "BiometriaHematicaId" });
            DropIndex("dbo.EvolutionNotes", new[] { "VitalSignsId" });
            DropIndex("dbo.EvolutionNotes", new[] { "DoctorId" });
            DropIndex("dbo.EvolutionNotes", new[] { "PatientId" });
            DropIndex("dbo.Municipios", new[] { "EstadoId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Symptoms");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OtherFamilyRecords");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.MedicinesPrescriptions");
            DropTable("dbo.PhysicalExplorations");
            DropTable("dbo.OtherPathologicRecords");
            DropTable("dbo.PathologicRecords");
            DropTable("dbo.NonPathologicalRecords");
            DropTable("dbo.MedicalTests");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.LabsTests");
            DropTable("dbo.GynecoRecords");
            DropTable("dbo.FamilyRecords");
            DropTable("dbo.VitalSigns");
            DropTable("dbo.QuimicaSanguineas");
            DropTable("dbo.PerfilTiroideos");
            DropTable("dbo.PerfilHepaticoes");
            DropTable("dbo.Patients");
            DropTable("dbo.OtrosLabs");
            DropTable("dbo.Others");
            DropTable("dbo.Hormonas");
            DropTable("dbo.GeneralOrinas");
            DropTable("dbo.EvolutionNotes");
            DropTable("dbo.Municipios");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Doctors");
            DropTable("dbo.BloodTypes");
            DropTable("dbo.BiometriaHematicas");
        }
    }
}
