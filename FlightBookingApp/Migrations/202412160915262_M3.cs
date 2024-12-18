namespace FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgentBookings", "FlightDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserBookings", "FlightDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserBookings", "FlightDate");
            DropColumn("dbo.AgentBookings", "FlightDate");
        }
    }
}
