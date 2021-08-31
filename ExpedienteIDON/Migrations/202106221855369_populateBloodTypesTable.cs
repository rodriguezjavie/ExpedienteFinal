namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateBloodTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BloodTypes (Name) VALUES ('Lo Ignora')");
            Sql("INSERT INTO BloodTypes (Name) VALUES ('O +')");
            Sql("INSERT INTO BloodTypes (Name) VALUES ('O -')");
            Sql("INSERT INTO BloodTypes (Name) VALUES ('A +')");
            Sql("INSERT INTO BloodTypes (Name) VALUES ('A -')");
            Sql("INSERT INTO BloodTypes (Name) VALUES ('B +')");
            Sql("INSERT INTO BloodTypes (Name) VALUES ('B -')");
            Sql("INSERT INTO BloodTypes (Name) VALUES ('AB +')");
            Sql("INSERT INTO BloodTypes (Name) VALUES ('AB -')");
        }
        
        public override void Down()
        {
        }
    }
}
