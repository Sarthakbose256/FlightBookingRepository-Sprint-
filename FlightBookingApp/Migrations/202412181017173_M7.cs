namespace FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "BookingId", "dbo.UserBookings");
            DropIndex("dbo.Payments", new[] { "BookingId" });
            AddColumn("dbo.FlightDetails", "TicketPrice", c => c.Double(nullable: false));
            AddColumn("dbo.FlightDetails", "Discount", c => c.Double(nullable: false));
            DropColumn("dbo.FlightDetails", "PriceEconomy");
            DropColumn("dbo.FlightDetails", "PriceBusiness");
            DropColumn("dbo.FlightDetails", "PriceFirst");
            DropColumn("dbo.FlightDetails", "TotalSeats");
            DropTable("dbo.Payments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.String(nullable: false, maxLength: 5),
                        BookingId = c.String(maxLength: 5),
                        PaymentAmount = c.Double(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            AddColumn("dbo.FlightDetails", "TotalSeats", c => c.Int(nullable: false));
            AddColumn("dbo.FlightDetails", "PriceFirst", c => c.Double(nullable: false));
            AddColumn("dbo.FlightDetails", "PriceBusiness", c => c.Double(nullable: false));
            AddColumn("dbo.FlightDetails", "PriceEconomy", c => c.Double(nullable: false));
            DropColumn("dbo.FlightDetails", "Discount");
            DropColumn("dbo.FlightDetails", "TicketPrice");
            CreateIndex("dbo.Payments", "BookingId");
            AddForeignKey("dbo.Payments", "BookingId", "dbo.UserBookings", "BookingId");
        }
    }
}
