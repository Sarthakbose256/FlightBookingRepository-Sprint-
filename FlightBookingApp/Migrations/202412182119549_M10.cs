namespace FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M10 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AirportDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AirportDetails",
                c => new
                    {
                        IataCode = c.String(nullable: false, maxLength: 128),
                        AirportName = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.IataCode);
            
        }
    }
}
