namespace FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AgentBookings", "Bookingstatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AgentBookings", "Bookingstatus", c => c.String());
        }
    }
}
