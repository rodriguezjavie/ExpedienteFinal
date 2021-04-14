namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
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
                "dbo.MedicalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        FamilyRecordId = c.Int(nullable: false),
                        NonPathologicalRecordId = c.Int(nullable: false),
                        GynecoRecordId = c.Int(nullable: false),
                        PathologicRecordId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyRecords", t => t.FamilyRecordId, cascadeDelete: true)
                .ForeignKey("dbo.GynecoRecords", t => t.GynecoRecordId, cascadeDelete: true)
                .ForeignKey("dbo.NonPathologicalRecords", t => t.NonPathologicalRecordId, cascadeDelete: true)
                .ForeignKey("dbo.PathologicRecords", t => t.PathologicRecordId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.FamilyRecordId)
                .Index(t => t.NonPathologicalRecordId)
                .Index(t => t.GynecoRecordId)
                .Index(t => t.PathologicRecordId);
            
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
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(),
                        PatientGender = c.Int(nullable: false),
                        Phone = c.String(),
                        Cellphone = c.String(),
                        Email = c.String(),
                        Photo = c.String(),
                        Ocupation = c.String(),
                        PatientStudies = c.Int(nullable: false),
                        PatientCivilStatus = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OtherFamilyRecords", "FamilyRecordId", "dbo.FamilyRecords");
            DropForeignKey("dbo.MedicalRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.MedicalRecords", "PathologicRecordId", "dbo.PathologicRecords");
            DropForeignKey("dbo.OtherPathologicRecords", "PathologicRecordId", "dbo.PathologicRecords");
            DropForeignKey("dbo.MedicalRecords", "NonPathologicalRecordId", "dbo.NonPathologicalRecords");
            DropForeignKey("dbo.NonPathologicalRecords", "BloodTypeId", "dbo.BloodTypes");
            DropForeignKey("dbo.MedicalRecords", "GynecoRecordId", "dbo.GynecoRecords");
            DropForeignKey("dbo.MedicalRecords", "FamilyRecordId", "dbo.FamilyRecords");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OtherFamilyRecords", new[] { "FamilyRecordId" });
            DropIndex("dbo.OtherPathologicRecords", new[] { "PathologicRecordId" });
            DropIndex("dbo.NonPathologicalRecords", new[] { "BloodTypeId" });
            DropIndex("dbo.MedicalRecords", new[] { "PathologicRecordId" });
            DropIndex("dbo.MedicalRecords", new[] { "GynecoRecordId" });
            DropIndex("dbo.MedicalRecords", new[] { "NonPathologicalRecordId" });
            DropIndex("dbo.MedicalRecords", new[] { "FamilyRecordId" });
            DropIndex("dbo.MedicalRecords", new[] { "PatientId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OtherFamilyRecords");
            DropTable("dbo.Patients");
            DropTable("dbo.OtherPathologicRecords");
            DropTable("dbo.PathologicRecords");
            DropTable("dbo.NonPathologicalRecords");
            DropTable("dbo.MedicalRecords");
            DropTable("dbo.GynecoRecords");
            DropTable("dbo.FamilyRecords");
            DropTable("dbo.Doctors");
            DropTable("dbo.BloodTypes");
        }
    }
}
