namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersInMedicalRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalRecords", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MedicalRecords", "ApplicationUserId");
            AddForeignKey("dbo.MedicalRecords", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalRecords", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.MedicalRecords", new[] { "ApplicationUserId" });
            DropColumn("dbo.MedicalRecords", "ApplicationUserId");
        }
    }
}
