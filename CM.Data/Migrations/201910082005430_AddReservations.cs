namespace CM.Data.MigrationConfigurations
{
    using System.Data.Entity.Migrations;

    public partial class AddReservations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    ProjectionId = c.Long(nullable: false),
                    Row = c.Short(nullable: false),
                    Column = c.Short(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projections", t => t.ProjectionId, cascadeDelete: true)
                .Index(t => t.ProjectionId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ProjectionId", "dbo.Projections");
            DropIndex("dbo.Reservations", new[] { "ProjectionId" });
            DropTable("dbo.Reservations");
        }
    }
}