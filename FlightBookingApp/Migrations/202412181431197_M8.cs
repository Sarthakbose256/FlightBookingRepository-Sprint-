namespace FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AgentBookings", "CustomerName", c => c.String());
            AddColumn("dbo.AgentBookings", "Email", c => c.String());
            AddColumn("dbo.AgentBookings", "Mobile", c => c.String());
            DropColumn("dbo.AgentBookings", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AgentBookings", "UserName", c => c.String());
            DropColumn("dbo.AgentBookings", "Mobile");
            DropColumn("dbo.AgentBookings", "Email");
            DropColumn("dbo.AgentBookings", "CustomerName");
        }
    }
}
