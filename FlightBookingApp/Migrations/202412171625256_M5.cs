namespace FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserBookings", "Bookingstatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserBookings", "Bookingstatus", c => c.String());
        }
    }
}
