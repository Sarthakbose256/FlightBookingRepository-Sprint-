namespace FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FlightSchedules", "FlightDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FlightSchedules", "Duration", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FlightSchedules", "Duration", c => c.DateTime(nullable: false));
            DropColumn("dbo.FlightSchedules", "FlightDate");
        }
    }
}
