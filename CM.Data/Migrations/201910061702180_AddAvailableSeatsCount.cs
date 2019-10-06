namespace CM.Data.MigrationConfigurations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableSeatsCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projections", "AvailableSeatsCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projections", "AvailableSeatsCount");
        }
    }
}
