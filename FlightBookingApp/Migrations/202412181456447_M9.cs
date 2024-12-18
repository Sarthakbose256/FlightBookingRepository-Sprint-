namespace FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Agents", "CommissionRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agents", "CommissionRate", c => c.Double(nullable: false));
        }
    }
}
