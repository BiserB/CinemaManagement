namespace CM.Data.MigrationConfigurations
{
    using System.Data.Entity.Migrations;

    public partial class AddTickets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    ProjectionId = c.Long(nullable: false),
                    ReservationId = c.Long(),
                    Row = c.Short(nullable: false),
                    Column = c.Short(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projections", t => t.ProjectionId, cascadeDelete: true)
                .ForeignKey("dbo.Reservations", t => t.ReservationId)
                .Index(t => t.ProjectionId)
                .Index(t => t.ReservationId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.Tickets", "ProjectionId", "dbo.Projections");
            DropIndex("dbo.Tickets", new[] { "ReservationId" });
            DropIndex("dbo.Tickets", new[] { "ProjectionId" });
            DropTable("dbo.Tickets");
        }
    }
}