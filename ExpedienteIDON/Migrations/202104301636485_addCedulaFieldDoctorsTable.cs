namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCedulaFieldDoctorsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Cedula", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Cedula");
        }
    }
}
