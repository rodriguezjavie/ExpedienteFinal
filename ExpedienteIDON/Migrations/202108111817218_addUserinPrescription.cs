namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserinPrescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prescriptions", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Prescriptions", "ApplicationUserId");
            AddForeignKey("dbo.Prescriptions", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Prescriptions", new[] { "ApplicationUserId" });
            DropColumn("dbo.Prescriptions", "ApplicationUserId");
        }
    }
}
