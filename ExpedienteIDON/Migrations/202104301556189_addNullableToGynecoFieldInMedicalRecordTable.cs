namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullableToGynecoFieldInMedicalRecordTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalRecords", "GynecoRecordId", "dbo.GynecoRecords");
            DropIndex("dbo.MedicalRecords", new[] { "GynecoRecordId" });
            AlterColumn("dbo.MedicalRecords", "GynecoRecordId", c => c.Int());
            CreateIndex("dbo.MedicalRecords", "GynecoRecordId");
            AddForeignKey("dbo.MedicalRecords", "GynecoRecordId", "dbo.GynecoRecords", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecords", "GynecoRecordId", "dbo.GynecoRecords");
            DropIndex("dbo.MedicalRecords", new[] { "GynecoRecordId" });
            AlterColumn("dbo.MedicalRecords", "GynecoRecordId", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicalRecords", "GynecoRecordId");
            AddForeignKey("dbo.MedicalRecords", "GynecoRecordId", "dbo.GynecoRecords", "Id", cascadeDelete: true);
        }
    }
}
