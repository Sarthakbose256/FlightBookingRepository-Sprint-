namespace FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.String(nullable: false, maxLength: 5),
                        AdminName = c.String(),
                        AdminPwd = c.String(),
                        AdminEmail = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.AgentBookings",
                c => new
                    {
                        BookingId = c.String(nullable: false, maxLength: 5),
                        AgentId = c.String(maxLength: 4),
                        UserName = c.String(),
                        FlightNumber = c.String(maxLength: 10),
                        SeatNumber = c.String(),
                        TicketPrice = c.Double(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        CommissionEarned = c.Double(nullable: false),
                        Bookingstatus = c.String(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Agents", t => t.AgentId)
                .ForeignKey("dbo.FlightDetails", t => t.FlightNumber)
                .Index(t => t.AgentId)
                .Index(t => t.FlightNumber);
            
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        agentId = c.String(nullable: false, maxLength: 4),
                        password = c.String(maxLength: 10),
                        AgentName = c.String(),
                        Email = c.String(),
                        AgentPhone = c.String(maxLength: 10),
                        City = c.String(),
                        Location = c.String(),
                        CommissionRate = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.agentId);
            
            CreateTable(
                "dbo.FlightDetails",
                c => new
                    {
                        FlightNumber = c.String(nullable: false, maxLength: 10),
                        Airline = c.String(),
                        FlightType = c.String(),
                        PriceEconomy = c.Double(nullable: false),
                        PriceBusiness = c.Double(nullable: false),
                        PriceFirst = c.Double(nullable: false),
                        TotalSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightNumber);
            
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
            
            CreateTable(
                "dbo.AuthenticateAgents",
                c => new
                    {
                        ApplicantNum = c.Int(nullable: false, identity: true),
                        password = c.String(),
                        ApplicantName = c.String(),
                        ApplicantEmail = c.String(),
                        ApplicantPhone = c.String(maxLength: 10),
                        ApplicantCity = c.String(),
                        ApplicantLocation = c.String(),
                        CommissionRate = c.Double(nullable: false),
                        ApprovalStatus = c.String(),
                    })
                .PrimaryKey(t => t.ApplicantNum);
            
            CreateTable(
                "dbo.FlightSchedules",
                c => new
                    {
                        ScheduleId = c.String(nullable: false, maxLength: 5),
                        FlightNumber = c.String(maxLength: 10),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        Duration = c.DateTime(nullable: false),
                        DepartureLoc = c.String(),
                        ArrivalLocation = c.String(),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.FlightDetails", t => t.FlightNumber)
                .Index(t => t.FlightNumber);
            
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
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.UserBookings", t => t.BookingId)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.UserBookings",
                c => new
                    {
                        BookingId = c.String(nullable: false, maxLength: 5),
                        UserId = c.String(maxLength: 4),
                        FlightNumber = c.String(maxLength: 10),
                        TicketPrice = c.Double(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        SeatNumber = c.String(),
                        Bookingstatus = c.String(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.FlightDetails", t => t.FlightNumber)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.FlightNumber);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 4),
                        password = c.String(maxLength: 10),
                        UserName = c.String(),
                        Email = c.String(),
                        UserPhone = c.String(maxLength: 10),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "BookingId", "dbo.UserBookings");
            DropForeignKey("dbo.UserBookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserBookings", "FlightNumber", "dbo.FlightDetails");
            DropForeignKey("dbo.FlightSchedules", "FlightNumber", "dbo.FlightDetails");
            DropForeignKey("dbo.AgentBookings", "FlightNumber", "dbo.FlightDetails");
            DropForeignKey("dbo.AgentBookings", "AgentId", "dbo.Agents");
            DropIndex("dbo.UserBookings", new[] { "FlightNumber" });
            DropIndex("dbo.UserBookings", new[] { "UserId" });
            DropIndex("dbo.Payments", new[] { "BookingId" });
            DropIndex("dbo.FlightSchedules", new[] { "FlightNumber" });
            DropIndex("dbo.AgentBookings", new[] { "FlightNumber" });
            DropIndex("dbo.AgentBookings", new[] { "AgentId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserBookings");
            DropTable("dbo.Payments");
            DropTable("dbo.FlightSchedules");
            DropTable("dbo.AuthenticateAgents");
            DropTable("dbo.AirportDetails");
            DropTable("dbo.FlightDetails");
            DropTable("dbo.Agents");
            DropTable("dbo.AgentBookings");
            DropTable("dbo.Admins");
        }
    }
}
