namespace nash_bike_trip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Trip_TripId = c.Int(),
                    })
                .PrimaryKey(t => t.OptionId)
                .ForeignKey("dbo.Trips", t => t.Trip_TripId)
                .Index(t => t.Trip_TripId);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        DepartureTitle = c.String(nullable: false),
                        ArrivalTitle = c.String(nullable: false),
                        TripDate = c.DateTime(nullable: false),
                        TripNotes = c.String(),
                    })
                .PrimaryKey(t => t.TripId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "Trip_TripId", "dbo.Trips");
            DropIndex("dbo.Options", new[] { "Trip_TripId" });
            DropTable("dbo.Trips");
            DropTable("dbo.Options");
        }
    }
}
